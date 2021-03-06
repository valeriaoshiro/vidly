﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;
using System.Data.Entity;


namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		//Get /api/movies
		[Authorize(Roles = RoleName.CanManageMovie)]
		public IHttpActionResult GetMovies()
		{
			return Ok(_context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>));
		}

		//Get /api/movies/1
		public IHttpActionResult GetMovies(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return NotFound();

			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		//POST /api/movies
		[HttpPost]
		[Authorize(Roles = RoleName.CanManageMovie)]
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);
			_context.Movies.Add(movie);
			_context.SaveChanges();

			movieDto.Id = movie.Id;

			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
		}

		//PUT /api/movies/1
		[HttpPut]
		[Authorize(Roles = RoleName.CanManageMovie)]
		public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			Mapper.Map(movieDto, movieInDb);

			_context.SaveChanges();

			return Ok();
		}

		//DELETE /api/movies/1
		[HttpDelete]
		[Authorize(Roles = RoleName.CanManageMovie)]
		public IHttpActionResult DeleteMovie(int id)
		{
			var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Movies.Remove(movieInDb);
			_context.SaveChanges();

			return Ok();
		}
	}
}
