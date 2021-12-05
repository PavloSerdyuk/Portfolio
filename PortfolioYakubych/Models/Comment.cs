using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Models
{
	public class Comment
	{
		public Guid Id { get; set; }
		[Required]
		[MaxLength(250)]
		public string Text { get; set; }
		
		public ApplicationUser Author { get; set; }

	}
}
