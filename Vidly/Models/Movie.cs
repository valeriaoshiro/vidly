﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Movie
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		
		public Genre Genre { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public byte GenreId { get; set; }

		[Required]
		[Display(Name="Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[Required]
		public DateTime DateAdded { get; set; }

		[Required]
		[Range(1, 20)]
		[Display(Name="Number in Stock")]
		public int? NumberInStock { get; set; }

		public byte NumberAvailable { get; set; }
	}
}