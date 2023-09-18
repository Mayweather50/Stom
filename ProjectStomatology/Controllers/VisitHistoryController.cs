using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using ProjectStomatology.Models;
using ProjectStomatology.Repository.InterfaceRepository;

namespace ProjectStomatology.Controllers
{
    public class VisitHistoryController : Controller
    {
        StomatologyContext db;
        IVisitHistory<VisitHistory> repository;
        public VisitHistoryController(StomatologyContext context, IVisitHistory<VisitHistory> history)
        {
            db = context;
            repository = history;
        }
        public IActionResult Index()
        {
            var result = repository.GetAll();
            return View(result);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            repository.Edit(id);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                VisitHistory history = await db.VisitHistories.FirstOrDefaultAsync(p => p.Id == id);
                if (history != null)
                {
                    db.VisitHistories.Remove(history);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VisitHistory history)
        {
            repository.Create(history);

            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = repository.Edit(id);
            return View(edit);
            //try
            //{
            //    if (id != null)
            //    {
            //        Rclient rclient = await db.Rclients.FirstOrDefaultAsync(x => x.Id == id);
            //        return View(rclient);
            //    }
            //}
            //catch (Exception ex) { throw new Exception(ex.Message); }
            //return null;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VisitHistory history)
        {
            db.VisitHistories.Update(history);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //     repository.Details(id);
        //    return RedirectToAction("Details");




        //}

        [HttpGet]
        public VisitHistory Details(int id)
        {
            try
            {
                if (id != null)
                {
                    VisitHistory history = db.VisitHistories.FirstOrDefault(x => x.Id == id);
                    return history;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}
