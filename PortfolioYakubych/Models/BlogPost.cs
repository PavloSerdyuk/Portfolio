using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Models
{
	public class BlogPost
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public ApplicationUser Author { get; set; }
		public ICollection<Comment> Comments { get; set; }
	}
}
