using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IrisFlowerWeb.Models;

namespace IrisFlowerWeb.Pages.IrisFlowers
{
    public class DeleteModel : PageModel
    {
        private readonly IrisFlowerContext _context;

        public DeleteModel(IrisFlowerContext context)
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

            var irisflower = await _context.IrisFlower.FirstOrDefaultAsync(m => m.Id == id);

            if (irisflower == null)
            {
                return NotFound();
            }
            else 
            {
                IrisFlower = irisflower;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.IrisFlower == null)
            {
                return NotFound();
            }
            var irisflower = await _context.IrisFlower.FindAsync(id);

            if (irisflower != null)
            {
                IrisFlower = irisflower;
                _context.IrisFlower.Remove(IrisFlower);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
