using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.DAL.Entities;

namespace Training.DAL
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions options)
              : base(options) { }

        public DbSet<TrainingSession> Trainings { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Subscribtion> Subscribtions { get; set; }
        public DbSet<Profile> Profiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().ToTable("Profiles");
            modelBuilder.Entity<Profile>()
                 .HasIndex(i => i.ProfileId)
                 .IsUnique();
            modelBuilder.Entity<Trainer>().ToTable("Trainers");
            modelBuilder.Entity<Trainer>()
                .HasIndex(i => i.TrainerId)
                .IsUnique();
            modelBuilder.Entity<Subscribtion>().ToTable("Subscribtions");
            modelBuilder.Entity<Subscribtion>()
                 .HasIndex(i => i.SubscribtionId)
                 .IsUnique();

            modelBuilder.Entity<TrainingSession>().ToTable("Trainings");
            modelBuilder.Entity<TrainingSession>()
                .HasIndex(i => i.TrainingId)
                .IsUnique();
            modelBuilder.Entity<TrainingSession>()
                .HasOne(t => t.Profile)
                .WithMany(profile => profile.Trainings)
                .HasForeignKey(training => training.ProfileId);

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.Subscribtion)
                .WithMany(sub => sub.Profiles)
                .HasForeignKey(p => p.SubscribtionId);
        }
    }
}
