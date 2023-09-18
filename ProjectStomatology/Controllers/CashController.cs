using Microsoft.AspNetCore.Mvc;

namespace ProjectStomatology.Controllers
{
    public class CashController : Controller
    {
        public IActionResult Index()
        {
            return PartialView("Index");
        }
    }
}
