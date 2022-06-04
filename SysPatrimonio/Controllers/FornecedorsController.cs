using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysPatrimonio.Models;

namespace SysPatrimonio.Controllers
{
    public class FornecedorsController : Controller
    {
        private readonly Context _context;

        public FornecedorsController(Context context)
        {
            _context = context;
        }

        // GET: Fornecedors
        public async Task<IActionResult> Index()
        {
              return _context.DbFornecedor != null ? 
                          View(await _context.DbFornecedor.ToListAsync()) :
                          Problem("Entity set 'Context.DbFornecedor'  is null.");
        }

        // GET: Fornecedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DbFornecedor == null)
            {
                return NotFound();
            }

            var dbFornecedor = await _context.DbFornecedor
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbFornecedor == null)
            {
                return NotFound();
            }

            return View(dbFornecedor);
        }

        // GET: Fornecedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomefornecedor,endereco,fone")] DbFornecedor dbFornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbFornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbFornecedor);
        }

        // GET: Fornecedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DbFornecedor == null)
            {
                return NotFound();
            }

            var dbFornecedor = await _context.DbFornecedor.FindAsync(id);
            if (dbFornecedor == null)
            {
                return NotFound();
            }
            return View(dbFornecedor);
        }

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomefornecedor,endereco,fone")] DbFornecedor dbFornecedor)
        {
            if (id != dbFornecedor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbFornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbFornecedorExists(dbFornecedor.id))
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
            return View(dbFornecedor);
        }

        // GET: Fornecedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DbFornecedor == null)
            {
                return NotFound();
            }

            var dbFornecedor = await _context.DbFornecedor
                .FirstOrDefaultAsync(m => m.id == id);
            if (dbFornecedor == null)
            {
                return NotFound();
            }

            return View(dbFornecedor);
        }

        // POST: Fornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DbFornecedor == null)
            {
                return Problem("Entity set 'Context.DbFornecedor'  is null.");
            }
            var dbFornecedor = await _context.DbFornecedor.FindAsync(id);
            if (dbFornecedor != null)
            {
                _context.DbFornecedor.Remove(dbFornecedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbFornecedorExists(int id)
        {
          return (_context.DbFornecedor?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
