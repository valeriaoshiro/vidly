using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult Index()
		{
			if(User.IsInRole("CanManageMovie"))
				return View("List");

			return View("ReadOnlyList");
		}

		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
			return View(movie);
		}

		// GET: Movies/Random
		public ActionResult Random()
		{
			var movies = new Movie() { Name = "Shrek!" };
			return View(movies);
		}

		// GET: Movies/New
		[Authorize(Roles = RoleName.CanManageMovie)]
		public ActionResult New()
		{
			var genres = _context.Genres.ToList();
			var viewModel = new MovieFormViewModel
			{
				Genres = genres,
				Movie = new Movie()
			};
			return View("MovieForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.CanManageMovie)]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel
				{
					Movie = movie,
					Genres = _context.Genres.ToList()
				};
				return View("MovieForm", viewModel);
			}
			if (movie.Id == 0)
				_context.Movies.Add(movie);
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
				movieInDb.Name = movie.Name;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Movies");
		}

		[Authorize(Roles = RoleName.CanManageMovie)]
		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
			if (movie == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel
			{
				Movie = movie,
				Genres = _context.Genres.ToList()
			};
			return View("MovieForm", viewModel);
		}
	}
}