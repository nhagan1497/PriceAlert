﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext _context;

        public DeleteModel(PriceAlertLibrary.DatabaseHelper.PriceAlertDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitcoinpricealert = await _context.BitcoinPriceAlerts.FindAsync(id);
            if (bitcoinpricealert != null)
            {
                BitcoinPriceAlert = bitcoinpricealert;
                _context.BitcoinPriceAlerts.Remove(BitcoinPriceAlert);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
