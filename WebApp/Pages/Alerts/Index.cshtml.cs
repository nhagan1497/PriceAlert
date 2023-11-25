using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Alerts
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.PriceAlertContext _context;

        public IndexModel(WebApp.Data.PriceAlertContext context)
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
