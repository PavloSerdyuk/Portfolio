using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioYakubych.Data;
using PortfolioYakubych.DTOS;
using PortfolioYakubych.Models;
using PortfolioYakubych.Services;
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
		public BlogPostService Service { get; }

		public BlogPostsController(BlogPostService service)
		{
			Service = service;
		}

		[HttpGet]
		[Route("all")]
		public async Task<IActionResult> All()
		{
			return Ok(await Service.GetBlogPosts());
		}
		
		[HttpGet]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await Service.GetBlogPost(id));
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Create(BlogPostCreateDTO blogPost)
		{
			return Ok(await Service.CreateBlogPost(blogPost));
		}

		[Authorize]
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			if (!(await Service.DeleteBlogPost(id))) return NotFound();
			return Ok();
		}
		

		
		[Authorize]
		[HttpPut]
		public async Task<IActionResult> Update(int id, BlogPostCreateDTO blogPost)
		{
			return Ok(await Service.UpdateBlogPost(id, blogPost));
		}
	}
}
