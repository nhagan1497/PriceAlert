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
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Data.PriceAlertContext _context;

        public DetailsModel(WebApp.Data.PriceAlertContext context)
        {
            _context = context;
        }

        public BitcoinPriceAlert BitcoinPriceAlert { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitcoinpricealert = await _context.BitcoinPriceAlerts.FirstOrDefaultAsync(m => m.Id == id);
            if (bitcoinpricealert == null)
            {
                return NotFound();
            }
            else
            {
                BitcoinPriceAlert = bitcoinpricealert;
            }
            return Page();
        }
    }
}
