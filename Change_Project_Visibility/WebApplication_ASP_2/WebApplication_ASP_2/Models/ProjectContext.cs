using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_2.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=projects_platform");
        }

        public DbSet<Project> projects { get; set; }
        public DbSet<Visibility> visibility { get; set; }
        public DbSet<IdentityUser> users { get; set; }
        public DbSet<IdentityUserClaim<string>> userClaims { get; set; }
    }
}
