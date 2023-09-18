using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectStomatology.Models;
using ProjectStomatology.Repository.InterfaceRepository;

namespace ProjectStomatology.Controllers
{
    public class JdiseaseHistoryController : Controller
    {
        StomatologyContext db;
        JdiseaseHistory<JdiseaseHistory> repository;
        public JdiseaseHistoryController(StomatologyContext context, JdiseaseHistory<JdiseaseHistory> disease)
        {
            db = context;
            repository = disease;
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
                JdiseaseHistory jdisease = await db.JdiseaseHistories.FirstOrDefaultAsync(p => p.Id == id);
                if (jdisease != null)
                {
                    db.JdiseaseHistories.Remove(jdisease);
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
        public IActionResult Create(JdiseaseHistory jdisease)
        {
            repository.Create(jdisease);
          
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = repository.Edit(id);
            try
            {
                if (id != null)
                {
                    JdiseaseHistory history =  db.JdiseaseHistories.FirstOrDefault(x => x.Id == id);
                    return View(history);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JdiseaseHistory jdisease)
        {
            db.JdiseaseHistories.Update(jdisease);
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
        public JdiseaseHistory Details(int id)
        {
            try
            {
                if (id != null)
                {
                    JdiseaseHistory jdisease = db.JdiseaseHistories.FirstOrDefault(x => x.Id == id);
                    return jdisease;
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
