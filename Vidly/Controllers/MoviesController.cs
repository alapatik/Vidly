using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

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
    }
}