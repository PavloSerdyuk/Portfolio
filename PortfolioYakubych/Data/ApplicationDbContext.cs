using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PortfolioYakubych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioYakubych.Data
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
	{
		public DbSet<BlogPost> BlogPosts { get; set; }
		public DbSet<Comment> Comments { get; set; }

		public ApplicationDbContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<BlogPost>().HasKey(l => l.Id);
			modelBuilder.Entity<BlogPost>().Property(l => l.Title).HasMaxLength(120).IsRequired();
			modelBuilder.Entity<BlogPost>().Property(l => l.Text).HasMaxLength(2048).IsRequired();
			modelBuilder.Entity<BlogPost>().HasMany(l => l.Comments).WithOne(l => l.BlogPost).HasForeignKey(l => l.BlogPostId);
			modelBuilder.Entity<BlogPost>().HasOne(l => l.Author).WithMany(l => l.BlogPosts);
			modelBuilder.Entity<BlogPost>().ToTable("BlogPosts");


			modelBuilder.Entity<Comment>().HasKey(l => l.Id);
			modelBuilder.Entity<Comment>().Property(l => l.Text).HasMaxLength(200).IsRequired();
			modelBuilder.Entity<Comment>().HasOne(l => l.Author).WithMany(l => l.Comments);
			modelBuilder.Entity<Comment>().ToTable("Comments");
		}
	}
}
