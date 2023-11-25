using Npgsql;

namespace DatabaseHelper
{
    public class PostgresHelper : IDatabaseHelper
    {
        // localhost 5432
        private string ConnectionString { get; set; }
        public PostgresHelper() 
        {
            ConnectionString = "Host=localhost:5432;Username=price;Password=price;Database=PriceAlert";
        }

        public void AddPrice(DateTime date, decimal price)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                using (NpgsqlCommand insertCommand = new NpgsqlCommand("INSERT INTO bitcoin_prices (date, price) VALUES (@value1, @value2)", connection))
                {
                    insertCommand.Parameters.AddWithValue("@value1", date);
                    insertCommand.Parameters.AddWithValue("@value2", price);

                    insertCommand.ExecuteNonQuery();
                }
            }
        }

        public decimal GetPrice(DateTime date)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(
                    "SELECT price FROM bitcoin_prices WHERE date <= @targetDate ORDER BY date DESC LIMIT 1", connection))
                {
                    command.Parameters.AddWithValue("@targetDate", date);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            return reader.GetDecimal(0);
                        }
                    }
                }
            }

            // Return a default value or throw an exception if no result is found
            return -1.0m; // You may adjust the default value as needed
        }

        public List<(string, decimal, decimal)> GetEmailAlerts(decimal currentPrice)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                List<(string, decimal, decimal)> alerts = new();
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(
                    "SELECT email, high_price, low_price FROM bitcoin_price_alerts WHERE @current_price < low_price OR @current_price > high_price", connection))
                {
                    command.Parameters.AddWithValue("@current_price", currentPrice);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Read data from the reader
                            string email = reader.GetString(0);
                            decimal highPrice = reader.GetDecimal(1);
                            decimal lowPrice = reader.GetDecimal(2);

                            // Add the data to the list
                            alerts.Add((email, highPrice, lowPrice));

                            //Console.WriteLine($"Email: {email}, High Price: {highPrice}, Low Price: {lowPrice}");
                        }
                    }
                }

                return alerts;

            }
        }

        public void UpdateAlert(string email, decimal oldHighPrice, decimal newHighPrice, decimal newLowPrice)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                // Your SQL command
                string sql = "UPDATE bitcoin_price_alerts SET high_price = @newHighPrice, low_price = @newLowPrice WHERE email = @email AND high_price = @oldHighPrice";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    // Parameters
                    command.Parameters.AddWithValue("@newHighPrice", newHighPrice);
                    command.Parameters.AddWithValue("@newLowPrice", newLowPrice);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@oldHighPrice", oldHighPrice);

                    // Execute the UPDATE query
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
