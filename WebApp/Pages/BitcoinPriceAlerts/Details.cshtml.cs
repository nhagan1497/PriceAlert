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
    public class DetailsModel : PageModel
    {
        private readonly PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext _context;

        public DetailsModel(PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext context)
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
