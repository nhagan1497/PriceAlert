using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class BitcoinPriceAlert
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public decimal HighPrice { get; set; }

    public decimal LowPrice { get; set; }
}
