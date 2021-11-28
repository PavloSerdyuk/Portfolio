using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;

namespace Portfolio.Data.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedUsers(builder.Entity<User>());
        }

        public static void SeedUsers(EntityTypeBuilder<User> builder) =>
            builder.HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Petro",
                    LastName = "Poroshenko",
                    Username = "Getman",
                    Password = "admin",
                    Role = "Admin"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Roman",
                    LastName = "Alberda",
                    Password = "user",
                    Username = "user",
                    Role = "User"
                });

        
    }
}
