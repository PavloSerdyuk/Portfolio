using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data.EntityConfigurations
{
    public class RepresentationConfiguration : IEntityTypeConfiguration<Representation>
    {
        public void Configure(EntityTypeBuilder<Representation> builder)
        {
            builder.ToTable("Representation");
            builder.HasKey(representation => representation.Id);

            builder.HasOne(representation => representation.Speaker)
                .WithMany(user => user.CreatedRepresentations)
                .HasForeignKey(representation => representation.SpeakerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(journey => journey.Subscribers)
                .WithMany(user => user.AssignedRepresentations)
                .UsingEntity<UserRepresentation>(
                    juBuilder => juBuilder.HasOne(ju => ju.User!)
                        .WithMany(u => u.UserRepresentations)
                        .HasForeignKey(ju => ju.UserId),
                    juBuilder => juBuilder.HasOne(ju => ju.Representation!)
                        .WithMany(j => j.UserRepresentations)
                        .HasForeignKey(ju => ju.RepresentationId),
                    juBuilder =>
                    {
                        juBuilder.ToTable("UserRepresentation");
                        juBuilder.HasKey(ju => new { ju.RepresentationId, ju.UserId });
                    });

            builder.Property(representation => representation.Description).IsRequired();
            builder.Property(representation => representation.EndTime).IsRequired();
            builder.Property(representation => representation.StartTime).IsRequired();
        }
    }
}
