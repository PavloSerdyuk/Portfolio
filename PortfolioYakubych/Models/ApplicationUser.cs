using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ICollection<BlogPost> BlogPosts { get; set; }
		public ICollection<Comment> Comments { get; set; }
	}
}
