using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioYakubych.Data;
using PortfolioYakubych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogPostsController : ControllerBase
	{
		public ApplicationDbContext Context { get; }

		public BlogPostsController(ApplicationDbContext context)
		{
			Context = context;
		}

		/*[HttpGet]
		public async Task<IActionResult> GetAllBlogPosts()
		{
			return Ok(await Context.BlogPosts.ToListAsync());
		}
		*/
		[HttpGet]
		public async Task<IActionResult> Get(Guid id)
		{
			return Ok(await Context.BlogPosts.FirstOrDefaultAsync(l => l.Id == id));
		}

		[HttpPost]
		public async Task<IActionResult> Create(BlogPost blogPost)
		{
			await Context.BlogPosts.AddAsync(blogPost);
			await Context.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id)
		{
			var blogPost = await Context.BlogPosts.FirstOrDefaultAsync(l => l.Id == id);
			if (blogPost == null) return NotFound();
			Context.BlogPosts.Remove(blogPost);
			await Context.SaveChangesAsync();
			return Ok();
		}


		[HttpPut]
		public async Task<IActionResult> Update(Guid id, BlogPost blogPost)
		{
			/*var blogPost = await Context.BlogPosts.FirstOrDefaultAsync(l => l.Id == id);
			if (blogPost == null) return NotFound();
			Context.BlogPosts.Remove(blogPost);
			await Context.SaveChangesAsync();*/
			return Ok();
		}
	}
}
