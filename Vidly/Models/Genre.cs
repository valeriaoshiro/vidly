﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Genre
	{
		public byte Id { get; set; }
		public string GenreType { get; set; }
	}
}