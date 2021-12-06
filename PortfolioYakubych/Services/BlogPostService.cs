using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortfolioYakubych.Data;
using PortfolioYakubych.DTOS;
using PortfolioYakubych.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Services
{
	public class BlogPostService
	{
		public ApplicationDbContext Context { get; }
		public IHttpContextAccessor HttpContextAccessor { get; }
		public UserManager<ApplicationUser> UserManager { get; }
		public IMapper Mapper { get; }

		public BlogPostService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper)
		{
			Context = context;
			HttpContextAccessor = httpContextAccessor;
			UserManager = userManager;
			Mapper = mapper;
		}

		public async Task<ICollection<Comment>> GetComments(int postId)
		{
			return await Context.Comments.Where(l => l.BlogPostId == postId).ToListAsync();
		}

		public async Task<Comment> GetComment(int id)
		{
			return await Context.Comments.FirstOrDefaultAsync(l => l.Id == id);
		}

		private async Task<ApplicationUser> GetUser()
		=> await UserManager.FindByIdAsync(
			HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => 
			string.Equals(c.Type, JwtRegisteredClaimNames.Sub, StringComparison.InvariantCultureIgnoreCase))?.Value);

		public async Task<Comment> CreateComment(int postId, CommentCreateDTO comment)
		{
			var comm = Mapper.Map<Comment>(comment);
			comm.Author = await GetUser();
			comm.BlogPostId = postId;
			var result = await Context.Comments.AddAsync(comm);
			await Context.SaveChangesAsync();
			await result.ReloadAsync();
			return result.Entity;
		}

		public async Task<bool> DeleteComment(int commendId)
		{
			var comm = await Context.Comments.FirstOrDefaultAsync(l => l.Id == commendId);
			if (comm == null) return false;
			Context.Comments.Remove(comm);
			await Context.SaveChangesAsync();
			return true;
		}

		public async Task<BlogPost> CreateBlogPost(BlogPostCreateDTO blogPost)
		{
			var post = Mapper.Map<BlogPost>(blogPost);
			post.Author = await GetUser();
			var result = await Context.BlogPosts.AddAsync(post);
			await Context.SaveChangesAsync();
			await result.ReloadAsync();
			return result.Entity;
		}

		public async Task<BlogPost> UpdateBlogPost(int id, BlogPostCreateDTO blogPost)
		{
			var post = Mapper.Map<BlogPost>(blogPost);
			post.Id = id;
			var result = Context.BlogPosts.Update(post);
			await Context.SaveChangesAsync();
			await result.ReloadAsync();
			return result.Entity;
		}

		public async Task<ICollection<BlogPost>> GetBlogPosts()
		{
			return await Context.BlogPosts.ToListAsync();
		}
		public async Task<BlogPost> GetBlogPost(int id)
		{
			return await Context.BlogPosts.FirstOrDefaultAsync(l => l.Id == id);
		}

		public async Task<bool> DeleteBlogPost(int id)
		{
			var blogPost = await Context.BlogPosts.FirstOrDefaultAsync(l => l.Id == id);
			if (blogPost == null) return false;
			Context.BlogPosts.Remove(blogPost);
			await Context.SaveChangesAsync();
			return true;
		}

	}
}
