using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PriceAlertLibrary.DatabaseHelper;
using PriceAlertLibrary.DatabaseHelper.Models;

namespace WebApp.Pages.BitcoinPrices
{
    public class DetailsModel : PageModel
    {
        private readonly PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext _context;

        public DetailsModel(PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext context)
        {
            _context = context;
        }

        public BitcoinPrice BitcoinPrice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitcoinprice = await _context.BitcoinPrices.FirstOrDefaultAsync(m => m.Date == id);
            if (bitcoinprice == null)
            {
                return NotFound();
            }
            else
            {
                BitcoinPrice = bitcoinprice;
            }
            return Page();
        }
    }
}
