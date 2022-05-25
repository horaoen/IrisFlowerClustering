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
    public class IndexModel : PageModel
    {
        private readonly IrisFlowerContext _context;

        public IndexModel(IrisFlowerContext context)
        {
            _context = context;
        }

        public IList<IrisFlower> IrisFlower { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.IrisFlower != null)
            {
                IrisFlower = await _context.IrisFlower.ToListAsync();
            }
        }
    }
}
