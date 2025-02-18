using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6.Models;
using SQLitePCL;

namespace mission6.Controllers
{
    
    public class HomeController : Controller
    {
        private MovieCollectionContext _context;
        public HomeController(MovieCollectionContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }
        
       public IActionResult GettoKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCollection() //retrieve Add Collection view
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCollection(Movie response) //update database with form response
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Index");
        }

        public IActionResult ListMovies()
        {
            var movie = _context.Movies
                .OrderBy(x => x.MovieId)
                .ToList();
            return View();
        }
    }
}
