using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PriceAlertLibrary.DatabaseHelper;
using PriceAlertLibrary.DatabaseHelper.Models;

namespace WebApp.Pages.BitcoinPriceAlerts
{
    public class IndexModel : PageModel
    {
        private readonly PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext _context;

        public IndexModel(PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext context)
        {
            _context = context;
        }

        public IList<BitcoinPriceAlert> BitcoinPriceAlert { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BitcoinPriceAlert = await _context.BitcoinPriceAlerts.ToListAsync();
        }
    }
}
