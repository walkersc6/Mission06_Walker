using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission6.Models;
using SQLitePCL;
using static System.Net.Mime.MediaTypeNames;

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
        public IActionResult AddCollection() 
        {
            //store all categories so we can access them in the view
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddCollection(Movie response) 
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Index");
        }


        public IActionResult ListMovies()
        {
            //store all the movies in database in a list
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //creating a new instance of the movie to save all of the movie's info
            Movie movieToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            //stores all categories
            ViewBag.Categories = _context.Categories
                 .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddCollection", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("ListMovies");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            //save all the soon-to-be-deleted movie's info in variable
            var movieToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("ListMovies");
        }
    }
}
