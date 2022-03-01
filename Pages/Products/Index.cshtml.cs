#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AndyHahnCodingExercise.Models;

namespace AndyHahnCodingExercise.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly AndyHahnCodingExercise.Models.CoreDbContext _context;

        public IndexModel(AndyHahnCodingExercise.Models.CoreDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category).ToListAsync();
        }
    }
}
