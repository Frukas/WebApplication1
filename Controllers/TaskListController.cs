#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //[Authorize]
    public class TaskListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskList
        public async Task<IActionResult> Index()
        {
            return View(await _context.taskListModels.ToListAsync());
        }

        // GET: TaskList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListModel = await _context.taskListModels
                .FirstOrDefaultAsync(m => m.IdService == id);
            if (taskListModel == null)
            {
                return NotFound();
            }

            return View(taskListModel);
        }

        // GET: TaskList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdService,ClientId,GroupId,Description,IsActive")] TaskListModel taskListModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskListModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskListModel);
        }

        // GET: TaskList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListModel = await _context.taskListModels.FindAsync(id);
            if (taskListModel == null)
            {
                return NotFound();
            }
            return View(taskListModel);
        }

        // POST: TaskList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdService,ClientId,GroupId,Description,IsActive")] TaskListModel taskListModel)
        {
            if (id != taskListModel.IdService)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskListModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskListModelExists(taskListModel.IdService))
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
            return View(taskListModel);
        }

        // GET: TaskList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListModel = await _context.taskListModels
                .FirstOrDefaultAsync(m => m.IdService == id);
            if (taskListModel == null)
            {
                return NotFound();
            }

            return View(taskListModel);
        }

        // POST: TaskList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskListModel = await _context.taskListModels.FindAsync(id);
            _context.taskListModels.Remove(taskListModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskListModelExists(int id)
        {
            return _context.taskListModels.Any(e => e.IdService == id);
        }
    }
}
