using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PriceAlertLibrary.DatabaseHelper;
using PriceAlertLibrary.DatabaseHelper.Models;

namespace WebApp.Pages.BitcoinPrices
{
    public class EditModel : PageModel
    {
        private readonly PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext _context;

        public EditModel(PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext context)
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

            var bitcoinprice =  await _context.BitcoinPrices.FirstOrDefaultAsync(m => m.Date == id);
            if (bitcoinprice == null)
            {
                return NotFound();
            }
            BitcoinPrice = bitcoinprice;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BitcoinPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BitcoinPriceExists(BitcoinPrice.Date))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BitcoinPriceExists(DateTime id)
        {
            return _context.BitcoinPrices.Any(e => e.Date == id);
        }
    }
}
