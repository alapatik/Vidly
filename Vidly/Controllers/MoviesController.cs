using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext context;
        public MoviesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = context.MovieDbSet.Include(m => m.Genre);
            return View(movies);
        }
        public ActionResult MovieById(int id)
        {
            var movie = context.MovieDbSet.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            return View(movie);
        }
        public ActionResult New()
        {
            var movieFormViewModel = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = context.Genres.ToList()
            };
            return View("MovieForm", movieFormViewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = context.MovieDbSet.FirstOrDefault(m => m.Id == id);
            var movieFormViewModel = new MovieFormViewModel
            {
                Genres = context.Genres.ToList(),
                Movie = movie
            };
            return View("MovieForm", movieFormViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieFormViewModel movieVM)
        {
            if (movieVM.Movie.Id == 0)
            {
                context.MovieDbSet.Add(movieVM.Movie);
            }
            else
            {
                var movie = context.MovieDbSet.FirstOrDefault(m => m.Id == movieVM.Movie.Id);
                movie.Name = movieVM.Movie.Name;
                movie.GenreId = movieVM.Movie.GenreId;
                movie.NumberInStock = movieVM.Movie.NumberInStock;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}