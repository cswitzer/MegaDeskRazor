using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDesk.Data;
using MegaDesk.Models;
using System.Diagnostics;

namespace MegaDesk.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        public CreateModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Desk Desk { get; set; }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public IActionResult OnGet()
        {
            ViewData["DeliveryTypeId"] = new SelectList(_context.Set<DeliveryType>(), "DeliveryTypeId", "DeliveryName");
            ViewData["DesktopMaterialId"] = new SelectList(_context.Set<DesktopMaterial>(), "DesktopMaterialId", "DesktopMaterialName");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // TODO: delete quote price = 0 later and call GetQuotePrice instead
            DeskQuote.QuotePrice = 0;
            DeskQuote.QuoteDate = DateTime.Now;

            if (!ModelState.IsValid || _context.DeskQuote == null || DeskQuote == null)
            {
                Debug.WriteLine(DeskQuote.DeliveryType);
                // Debug.WriteLine(DeskQuote.Desk.DesktopMaterial); Desk not set to instance of an object
                return Page();
            }

          _context.DeskQuote.Add(DeskQuote);
          await _context.SaveChangesAsync();

          return RedirectToPage("./Index");
        }
    }
}
