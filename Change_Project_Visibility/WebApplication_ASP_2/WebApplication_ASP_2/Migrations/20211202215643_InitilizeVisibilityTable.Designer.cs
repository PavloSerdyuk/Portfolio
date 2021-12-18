﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication_ASP_2.Models;

namespace WebApplication_ASP_2.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20211202215643_InitilizeVisibilityTable")]
    partial class InitilizeVisibilityTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication_ASP_2.Models.Project", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<string>("name");

                    b.Property<int>("price");

                    b.Property<string>("repository");

                    b.Property<int>("user_id");

                    b.Property<int>("visibility_id");

                    b.HasKey("id");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("WebApplication_ASP_2.Models.Visibility", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("visibility");
                });
#pragma warning restore 612, 618
        }
    }
}