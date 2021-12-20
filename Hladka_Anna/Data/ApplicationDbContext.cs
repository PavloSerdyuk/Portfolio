using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AnnaHladkaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnaHladkaPortfolio.Data
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
	{
		public DbSet<Message> Messages { get; set; }
		public DbSet<Chat> Chats { get; set; }

		public ApplicationDbContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Message>().HasKey(l => l.Id);
			modelBuilder.Entity<Message>().Property(l => l.Text).HasMaxLength(2048).IsRequired();
			modelBuilder.Entity<Message>().HasOne(l => l.Chat).WithMany(l => l.Messages).HasForeignKey(l => l.ChatId);
			modelBuilder.Entity<Message>().ToTable("Messages");


			modelBuilder.Entity<Chat>().HasKey(l => l.Id);
			modelBuilder.Entity<Chat>().Property(l => l.From).HasMaxLength(200).IsRequired();
			modelBuilder.Entity<Chat>().Property(l => l.To).HasMaxLength(200).IsRequired();
			modelBuilder.Entity<Chat>().ToTable("Chats");
		}
	}
}
