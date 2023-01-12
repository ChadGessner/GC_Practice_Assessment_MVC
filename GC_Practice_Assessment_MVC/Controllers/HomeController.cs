using GC_Practice_Assessment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GC_Practice_Assessment_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<PersonVM> _people;
        public HomeController(ILogger<HomeController> logger)
        {
            _people = new List<PersonVM>()
            {

                new PersonVM()
                {
                    Id= 1,
                    UserName = "Chad",
                    Age= 39,
                    CanDrive= true,
                    CanDrink= true,
                },
                new PersonVM()
                {
                    Id= 2,
                    UserName="Clackie",
                    Age= 14,
                    CanDrink= false,
                    CanDrive=false
                    
                },
                new PersonVM()
                {
                    Id= 3,
                    Age= 33,
                    UserName="Guy",
                    CanDrive= true,
                    CanDrink=true
                    
                }
            
            
            };
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<PersonVM> persons = _people.ToList();
            return View(persons);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GetAge()
        {
            
            PersonVM model = new() 
            { 
                Id= _people[_people.Count - 1].Id + 1,
                UserName = "",
            };
            
            return View(model);
        }
        [HttpPost]
        public IActionResult GetAge(PersonVM person)
        {
            person.CanDrink = person.Age >= 21;
            person.CanDrive = person.Age >= 16;
            _people.Add(person);
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}