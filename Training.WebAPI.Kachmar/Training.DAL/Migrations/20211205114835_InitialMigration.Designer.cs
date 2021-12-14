﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Training.DAL;

namespace Training.DAL.Migrations
{
    [DbContext(typeof(TrainingContext))]
    [Migration("20211205114835_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Training.DAL.Entities.Profile", b =>
                {
                    b.Property<long>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<long>("SubscribtionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ProfileId");

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.HasIndex("SubscribtionId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Training.DAL.Entities.Subscribtion", b =>
                {
                    b.Property<long>("SubscribtionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("SubscribtionCost")
                        .HasColumnType("int");

                    b.Property<string>("SubscribtionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("WeekWorkoutHours")
                        .HasColumnType("int");

                    b.HasKey("SubscribtionId");

                    b.HasIndex("SubscribtionId")
                        .IsUnique();

                    b.ToTable("Subscribtions");
                });

            modelBuilder.Entity("Training.DAL.Entities.Trainer", b =>
                {
                    b.Property<long>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("TrainerId");

                    b.HasIndex("TrainerId")
                        .IsUnique();

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("Training.DAL.Entities.TrainingSession", b =>
                {
                    b.Property<long>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ProfileId")
                        .HasColumnType("bigint");

                    b.Property<string>("TrainerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TrainingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("TrainingId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("TrainingId")
                        .IsUnique();

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Training.DAL.Entities.Profile", b =>
                {
                    b.HasOne("Training.DAL.Entities.Subscribtion", "Subscribtion")
                        .WithMany("Profiles")
                        .HasForeignKey("SubscribtionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscribtion");
                });

            modelBuilder.Entity("Training.DAL.Entities.TrainingSession", b =>
                {
                    b.HasOne("Training.DAL.Entities.Profile", "Profile")
                        .WithMany("Trainings")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Training.DAL.Entities.Profile", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("Training.DAL.Entities.Subscribtion", b =>
                {
                    b.Navigation("Profiles");
                });
#pragma warning restore 612, 618
        }
    }
}
