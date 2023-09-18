using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Nest;
using ProjectStomatology.Models;
using ProjectStomatology.Services;
using System.Diagnostics;

namespace ProjectStomatology.Controllers
{
    public class HomeController : Controller
    {
        private readonly StomatologyContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly ISearchClient searchClient;
        public HomeController(StomatologyContext context, IMemoryCache memoryCache, ISearchClient searchClient)
        {
            _context = context;
            _memoryCache = memoryCache;
            this.searchClient = searchClient;
        }
        public IActionResult Search()
        {
            var model = new SearchResultsModel();

            // Вручную добавляем результаты
            model.Results = new List<Order>
             {
                 new Order { CustomerFullName = "John Doe", OrderDate = DateTime.Now, TotalPrice = 99.99M },
                 new Order { CustomerFullName = "Jane Doe", OrderDate = DateTime.Now, TotalPrice = 79.99M }
             };

            return View(model);
        }
        //[Authorize]
        [HttpPost]
        public IActionResult Search(string searchText)
        {
            var response = searchClient.SearchOrder(searchText);
            var model = new SearchResultsModel { Results = response.Documents.ToList() };

        


           return View(model);


        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Patients()
        {

            var patients = _context.Rclients.ToList();



            return PartialView("Patients", patients);
        }




        public IActionResult Privacy()
        {

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}