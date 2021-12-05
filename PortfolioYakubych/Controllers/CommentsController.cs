using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioYakubych.DTOS;
using PortfolioYakubych.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		public BlogPostService Service { get; }

		public CommentsController(BlogPostService service)
		{
			Service = service;
		}

		[HttpGet]
		[Route("all")]
		public async Task<IActionResult> All(int postId)
		{
			return Ok(await Service.GetComments(postId));
		}

		[HttpGet]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await Service.GetComment(id));
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Create(int postId, CommentCreateDTO comment)
		{
			return Ok(await Service.CreateComment(postId, comment));
		}

		[Authorize]
		[HttpDelete]
		public async Task<IActionResult> Delete(int commentId)
		{
			if (!(await Service.DeleteComment(commentId))) return NotFound();
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
