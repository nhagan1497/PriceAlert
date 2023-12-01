using Microsoft.AspNetCore.Identity.UI.Services;
using PriceAlertLibrary.DataAnalyzer;
using PriceAlertLibrary.DatabaseHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IDatabaseHelper db = new PriceAlertDbContext();
IEmailer emailer = new Emailer();

builder.Services.AddSingleton(new DataAnalyzer(emailer, db));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
