using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesLab2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MoviesDbContext(serviceProvider.GetRequiredService<DbContextOptions<MoviesDbContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Id = 1,
                        Title = "Die hard",
                        Description = "Description",
                        Gender = Gender.Action,
                        Duration = 60,
                        YearOfRelease = "1989",
                        Director = "Steven Spielber",
                        DateAdded = DateTime.Parse("1989-2-12 12:22"),
                        Rating = 7,
                        Watched = true
                    },

                    new Movie
                    {
                        Id = 2,
                        Title = "Avatar",
                        Description = "Fiction",
                        Gender = Gender.Action,
                        Duration = 120,
                        YearOfRelease = "2009",
                        Director = "James Cameron",
                        DateAdded = DateTime.Parse("2010-5-01 15:05"),                        
                        Rating = 8,
                        Watched = true
                    },

                    new Movie
                    {
                        Id = 3,
                        Title = "Poltergeist",
                        Description = "Good",
                        Gender = Gender.Horror,
                        Duration = 180,
                        YearOfRelease = "2001",
                        Director = "Unknown",
                        DateAdded = DateTime.Parse("2001-6-21 22:00"),
                        Rating = 6,
                        Watched = false
                    },

                    new Movie
                    {
                        Id = 4,
                        Title = "Old school",
                        Description = "Nice",
                        Gender = Gender.Comedy,
                        Duration = 130,
                        YearOfRelease = "2003",
                        Director = "Someone",
                        DateAdded = DateTime.Parse("2003-1-01 10:01"),
                        Rating = 7,
                        Watched = true
                    },

                    new Movie
                    {
                        Id = 5,
                        Title = "Joker",
                        Description = "Very good",
                        Gender = Gender.Action,
                        Duration = 125,
                        YearOfRelease = "2019",
                        Director = "Todd Phillips",
                        DateAdded = DateTime.Parse("2019-6-10 14:30"),
                        Rating = 8,
                        Watched = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
