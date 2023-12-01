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
    public class DeleteModel : PageModel
    {
        private readonly PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext _context;

        public DeleteModel(PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitcoinprice = await _context.BitcoinPrices.FindAsync(id);
            if (bitcoinprice != null)
            {
                BitcoinPrice = bitcoinprice;
                _context.BitcoinPrices.Remove(BitcoinPrice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
