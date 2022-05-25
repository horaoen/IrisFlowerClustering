using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IrisFlowerWeb.Models;

namespace IrisFlowerWeb.Pages.IrisFlowers
{
    public class EditModel : PageModel
    {
        private readonly IrisFlowerContext _context;

        public EditModel(IrisFlowerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IrisFlower IrisFlower { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.IrisFlower == null)
            {
                return NotFound();
            }

            var irisflower =  await _context.IrisFlower.FirstOrDefaultAsync(m => m.Id == id);
            if (irisflower == null)
            {
                return NotFound();
            }
            IrisFlower = irisflower;
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

            _context.Attach(IrisFlower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IrisFlowerExists(IrisFlower.Id))
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

        private bool IrisFlowerExists(int id)
        {
          return (_context.IrisFlower?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
