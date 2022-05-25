using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IrisFlowerWeb.Models;

namespace IrisFlowerWeb.Pages.IrisFlowers
{
    public class CreateModel : PageModel
    {
        private readonly IrisFlowerContext _context;

        public CreateModel(IrisFlowerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public IrisFlower IrisFlower { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.IrisFlower == null || IrisFlower == null)
            {
                return Page();
            }

            _context.IrisFlower.Add(IrisFlower);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}