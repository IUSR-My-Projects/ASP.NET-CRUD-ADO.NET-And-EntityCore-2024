using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuhmadOmarHajHamdo.Context;
using MuhmadOmarHajHamdo.Entities;

namespace MuhmadOmarHajHamdo.Controllers
{
    public class SalaryController : Controller
    {
        private readonly MyDbContext _context;

        public SalaryController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Salary
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.salaries.Include(s => s.User);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Salary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.salaries
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // GET: Salary/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.employees, "Id", "Id");
            return View();
        }

        // POST: Salary/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mount,Month,Year,UserId")] salary salary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_context.employees, "Id", "Id", salary.UserId);
            return View(salary);
        }

        // GET: Salary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.salaries.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }

            ViewData["UserId"] = new SelectList(_context.employees, "Id", "Id", salary.UserId);
            return View(salary);
        }

        // POST: Salary/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mount,Month,Year,UserId")] salary salary)
        {
            if (id != salary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!salaryExists(salary.Id))
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

            ViewData["UserId"] = new SelectList(_context.employees, "Id", "Id", salary.UserId);
            return View(salary);
        }

        // GET: Salary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await _context.salaries
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // POST: Salary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salary = await _context.salaries.FindAsync(id);
            if (salary != null)
            {
                _context.salaries.Remove(salary);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool salaryExists(int id)
        {
            return _context.salaries.Any(e => e.Id == id);
        }
    }
}