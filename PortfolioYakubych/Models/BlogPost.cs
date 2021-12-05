﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Models
{
	public class BlogPost
	{
		public Guid Id { get; set; }
		[Required]
		[MaxLength(120)]
		public string Title { get; set; }
		[Required]
		[MaxLength(2048)]
		public string Text { get; set; }
		public ApplicationUser Author { get; set; }
		public ICollection<Comment> Comments { get; set; }
	}
}
