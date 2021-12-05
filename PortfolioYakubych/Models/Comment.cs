﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Text { get; set; }
		
		public int BlogPostId { get; set; }
		public BlogPost BlogPost { get; set; }
		public ApplicationUser Author { get; set; }

	}
}
