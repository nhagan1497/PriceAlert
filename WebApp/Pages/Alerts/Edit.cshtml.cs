using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Alerts
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Data.PriceAlertContext _context;

        public EditModel(WebApp.Data.PriceAlertContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BitcoinPriceAlert BitcoinPriceAlert { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitcoinpricealert =  await _context.BitcoinPriceAlerts.FirstOrDefaultAsync(m => m.Id == id);
            if (bitcoinpricealert == null)
            {
                return NotFound();
            }
            BitcoinPriceAlert = bitcoinpricealert;
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

            _context.Attach(BitcoinPriceAlert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BitcoinPriceAlertExists(BitcoinPriceAlert.Id))
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

        private bool BitcoinPriceAlertExists(int id)
        {
            return _context.BitcoinPriceAlerts.Any(e => e.Id == id);
        }
    }
}
