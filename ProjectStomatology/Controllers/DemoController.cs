using Microsoft.AspNetCore.Mvc;

namespace ProjectStomatology.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
