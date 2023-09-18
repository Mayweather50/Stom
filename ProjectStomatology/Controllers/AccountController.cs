using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;
using ProjectStomatology.Models;

namespace ProjectStomatology.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        StomatologyContext db;

        public AccountController(IWebHostEnvironment webHostEnvironment, StomatologyContext db)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult File(IFormFile MyUploader)
        {


            if (MyUploader != null)
            {
                try
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(MyUploader.FileName);
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Files");
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        MyUploader.CopyTo(fileStream);
                    }
                 
                    return new ObjectResult(new { status = "success" });
                }
                catch (Exception)
                {
                    return new ObjectResult(new { status = "fail" });
                }
            }
            return new ObjectResult(new { status = "fail" });
        }
    }
}
