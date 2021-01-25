using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Components
{
    public class GerechtIngredientenViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public GerechtIngredientenViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var ingredienten = await _context.GerechtIngredienten
                .Include(gi => gi.Ingredient)
                .Where(gi => gi.GerechtId == id)
                .ToListAsync();

            return View(ingredienten);
        }
    }
}
