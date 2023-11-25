using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class BitcoinPrice
{
    public DateTime Date { get; set; }

    public decimal? Price { get; set; }
}
