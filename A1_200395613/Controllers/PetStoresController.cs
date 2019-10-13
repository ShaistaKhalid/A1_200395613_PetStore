using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using A1_200395613.Data;
using A1_200395613.Models;

namespace A1_200395613.Controllers
{
    public class PetStoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetStoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PetStores
        public async Task<IActionResult> Index()
        {
            return View(await _context.PetStore.ToListAsync());
        }

        // GET: PetStores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petStore = await _context.PetStore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petStore == null)
            {
                return NotFound();
            }

            return View(petStore);
        }

        // GET: PetStores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Name,Description,Nutritional_Information,Weight,Type_of_animal_food_is_for,Animal,AName,ADescription")] PetStore petStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petStore);
        }

        // GET: PetStores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petStore = await _context.PetStore.FindAsync(id);
            if (petStore == null)
            {
                return NotFound();
            }
            return View(petStore);
        }

        // POST: PetStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Name,Description,Nutritional_Information,Weight,Type_of_animal_food_is_for,Animal,AName,ADescription")] PetStore petStore)
        {
            if (id != petStore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetStoreExists(petStore.Id))
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
            return View(petStore);
        }

        // GET: PetStores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petStore = await _context.PetStore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petStore == null)
            {
                return NotFound();
            }

            return View(petStore);
        }

        // POST: PetStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petStore = await _context.PetStore.FindAsync(id);
            _context.PetStore.Remove(petStore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetStoreExists(int id)
        {
            return _context.PetStore.Any(e => e.Id == id);
        }
    }
}
