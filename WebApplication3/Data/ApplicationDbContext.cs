using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication3.Models.Movie> Repertuar { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
         modelBuilder.Entity<UserRating>().ToTable("UserRatings");

            base.OnModelCreating(modelBuilder);
        }


    }
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, MovieService movieService)
        {
            // Pobierz wszystkie filmy z MovieService
            var moviesFromService = movieService.GetAllMovies();

            // Pobierz wszystkie istniejące filmy z bazy danych
            var moviesInDb = context.Movies.ToList();

            // Usuwanie filmów, które już nie istnieją w MovieService
            var moviesToRemove = moviesInDb
                .Where(dbMovie => !moviesFromService.Any(serviceMovie => serviceMovie.Title == dbMovie.Title))
                .ToList();

            if (moviesToRemove.Any())
            {
                Console.WriteLine("Usuwanie filmów z bazy danych:");
                foreach (var movie in moviesToRemove)
                {
                    Console.WriteLine($"- {movie.Title}");
                }

                context.Movies.RemoveRange(moviesToRemove);
            }

            // Dodawanie nowych filmów z MovieService do bazy danych
            foreach (var movie in moviesFromService)
            {
                var existingMovie = moviesInDb.FirstOrDefault(m => m.Title == movie.Title);

                if (existingMovie == null)
                {
                    // Jeśli film nie istnieje w bazie danych, dodaj go
                    context.Movies.Add(movie);
                    Console.WriteLine($"Dodano film: {movie.Title}");
                }
                else
                {
                    // Jeśli film istnieje, zaktualizuj jego dane
                    existingMovie.ImageUrl = movie.ImageUrl;
                    existingMovie.Description = movie.Description;
                    Console.WriteLine($"Zaktualizowano film: {movie.Title}");
                }
            }

            // Zapisz zmiany w bazie danych
            context.SaveChanges();
        }
    }

}

