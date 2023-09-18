using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectStomatology.Models;
using ProjectStomatology.Repository.InterfaceRepository;
//using ProjectStomatology.Services;

namespace ProjectStomatology.Controllers
{
    public class RclientController : Controller
    {
        StomatologyContext db;
        IRclient<Rclient> repository;
        public RclientController(StomatologyContext context, IRclient<Rclient> rclient)
        {
            db = context;
            repository = rclient;
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
            //var delete=repository.Delete(id);
            //return View(delete);


            if (id != null)
            {
                Rclient rclient = await db.Rclients.FirstOrDefaultAsync(p => p.Id == id);
                if (rclient != null)
                    return View(rclient);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Rclient rclient = await db.Rclients.FirstOrDefaultAsync(p => p.Id == id);
                if (rclient != null)
                {
                    db.Rclients.Remove(rclient);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
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
        public IActionResult Create(Rclient rclient)
        {
            repository.Create(rclient);
            db.Rclients.Add(rclient);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var edit = repository.Edit(id);
        
            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Rclient rclient)
        {
            db.Rclients.Update(rclient);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }



        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    repository.Details(id);
        //    return RedirectToAction("Details");




        //}

        [HttpGet]
        public Rclient Details(int id)
        {
            try
            {
                if (id != null)
                {
                    Rclient rclientclient = db.Rclients.FirstOrDefault(x => x.Id == id);
                    return rclientclient;
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
