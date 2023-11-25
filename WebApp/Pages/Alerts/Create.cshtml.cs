using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Alerts
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Data.PriceAlertContext _context;

        public CreateModel(WebApp.Data.PriceAlertContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BitcoinPriceAlert BitcoinPriceAlert { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BitcoinPriceAlerts.Add(BitcoinPriceAlert);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
