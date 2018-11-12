using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
			var movies = new Movie() { Name = "Shrek!" };
            return View(movies);
        }

		public ActionResult Index()
		{
			var movies = GetMovies();
			return View(movies);
		}

		private IEnumerable<Movie> GetMovies()
		{
			var movie1 = new Movie() { Id = 1, Name = "White Chicks" };
			var movie2 = new Movie() { Id = 2, Name = "Incredibles" };
			var movies = new List<Movie>();
			movies.Add(movie1);
			movies.Add(movie2);
			return movies;
		}
    }
}