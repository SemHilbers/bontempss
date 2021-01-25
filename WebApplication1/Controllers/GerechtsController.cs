using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GerechtsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GerechtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gerechts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Gerechten.Include(g => g.Soort);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Gerechts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerecht = await _context.Gerechten
                .Include(g => g.Soort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerecht == null)
            {
                return NotFound();
            }

            return View(gerecht);
        }

        // GET: Gerechts/Create
        public IActionResult Create()
        {
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoorten, "Id", "Soort");
            return View();
        }

        // POST: Gerechts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GerechtSoortId,Naam")] Gerecht gerecht)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerecht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoorten, "Id", "Soort", gerecht.GerechtSoortId);
            return View(gerecht);
        }

        // GET: Gerechts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerecht = await _context.Gerechten.FindAsync(id);
            if (gerecht == null)
            {
                return NotFound();
            }
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoorten, "Id", "Soort", gerecht.GerechtSoortId);
            return View(gerecht);
        }

        // POST: Gerechts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GerechtSoortId,Naam")] Gerecht gerecht)
        {
            if (id != gerecht.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerecht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerechtExists(gerecht.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GerechtSoortId"] = new SelectList(_context.GerechtSoorten, "Id", "Soort", gerecht.GerechtSoortId);
            return View(gerecht);
        }

        // GET: Gerechts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerecht = await _context.Gerechten
                .Include(g => g.Soort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerecht == null)
            {
                return NotFound();
            }

            return View(gerecht);
        }

        // POST: Gerechts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerecht = await _context.Gerechten.FindAsync(id);
            _context.Gerechten.Remove(gerecht);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerechtExists(int id)
        {
            return _context.Gerechten.Any(e => e.Id == id);
        }

        // De rest van ingredienten toevoegen GET: gerechten/ingredients

        public async Task<IActionResult>AddIngredient(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerecht = await _context.Gerechten.FindAsync(id);
            if (gerecht == null)
            {
                return NotFound();
            }

            var gerechtIngredient = new GerechtIngredient { GerechtId = gerecht.Id, IngredientId = 0 };
            ViewData["IngredientId"] = new SelectList(_context.Ingredienten, "Id", "DataTextField", gerechtIngredient.IngredientId);

            return View(gerechtIngredient);

        }
        // De post methode
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIngredient(GerechtIngredient gerechtIngredient)
        {
            if (ModelState.IsValid)
            {
                var existingGerechtIngredient =
                    await _context.GerechtIngredienten.FindAsync(
                        gerechtIngredient.GerechtId,
                    gerechtIngredient.IngredientId);

                if (existingGerechtIngredient != null)
                {
                    existingGerechtIngredient.Aantal += gerechtIngredient.Aantal;
                    _context.Update(existingGerechtIngredient);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Add(gerechtIngredient);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Edit), new { id = gerechtIngredient.GerechtId });
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredienten, "Id", "DataTextField", gerechtIngredient.IngredientId);

            return View(gerechtIngredient);
        }
    }
}
