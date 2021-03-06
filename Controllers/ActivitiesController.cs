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
using System.Text.Json;

namespace WebApplication1.Controllers
{
    //[Authorize]
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private NewActivityModel newActivityModel = new NewActivityModel();

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivitiesModel.ToListAsync());
        }
       
        // GET: Activities/NewActivity
        public IActionResult NewActivity()
        {           
            newActivityModel.Client = _context.clientModels.Where(c => c.IsActive == true).ToList();            
            return View(newActivityModel);
        }

        // GET: Activities/GetClientTask
        [HttpGet]
        public string GetClientTask(int id)
        {
            var task = _context.taskListModels.Where(t => t.IsActive == true && t.ClientId == id).ToList();

            return  JsonSerializer.Serialize(task);
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitiesModel = await _context.ActivitiesModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activitiesModel == null)
            {
                return NotFound();
            }

            return View(activitiesModel);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdService,IdOperator,StartTime,EndTIme,Comment,Time,IsActive,IsShadowing,IsExtraTime")] ActivitiesModel activitiesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activitiesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activitiesModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewActivity([Bind("Id,IdService,IdOperator,StartTime,EndTIme,Comment,Time,IsActive,IsShadowing,IsExtraTime")] ActivitiesModel activitiesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activitiesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activitiesModel);
        }
        [HttpPost]
        public async Task<bool> TesteDePost([Bind("Id,IdService,IdOperator,StartTime,EndTIme,Comment,Time,IsActive,IsShadowing,IsExtraTime")] ActivitiesModel data)            
        {           

            if (ModelState.IsValid)
            {
                _context.Add(data);
                var num =  await _context.SaveChangesAsync();
                Console.WriteLine("ok");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Console.WriteLine(errors);
            }
                     
            return true;
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitiesModel = await _context.ActivitiesModel.FindAsync(id);
            if (activitiesModel == null)
            {
                return NotFound();
            }
            return View(activitiesModel);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdService,IdOperator,StartTime,EndTIme,Comment,Time,IsActive,IsShadowing,IsExtraTime")] ActivitiesModel activitiesModel)
        {
            if (id != activitiesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activitiesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivitiesModelExists(activitiesModel.Id))
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
            return View(activitiesModel);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitiesModel = await _context.ActivitiesModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activitiesModel == null)
            {
                return NotFound();
            }

            return View(activitiesModel);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activitiesModel = await _context.ActivitiesModel.FindAsync(id);
            _context.ActivitiesModel.Remove(activitiesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivitiesModelExists(int id)
        {
            return _context.ActivitiesModel.Any(e => e.Id == id);
        }
    }
}
