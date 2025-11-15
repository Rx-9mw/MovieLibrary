using System.Collections.Generic;
using System.Linq;

namespace AplikacjaMVC.Models
{
    public static class MovieRepository
    {
        private static List<Movie> movies = new List<Movie>()
        {
            new Movie { Id = 1, Title = "The Fellowship of the Ring", Year = 2001, Genre = "Fantasy" },
            new Movie { Id = 2, Title = "The Two Towers", Year = 2002, Genre = "Fantasy" },
            new Movie { Id = 3, Title = "The Return of the King", Year = 2003, Genre = "Fantasy" },
            new Movie { Id = 4, Title = "Weapons", Year = 2025, Genre = "Horror" },
            new Movie { Id = 5, Title = "The Lighthouse", Year = 2019, Genre = "Horror" },
            new Movie { Id = 6, Title = "Get Out", Year = 2017, Genre = "Horror" },
            new Movie { Id = 7, Title = "Into the Spider-Verse", Year = 2018, Genre = "Animation" },
            new Movie { Id = 8, Title = "Green Book", Year = 2018, Genre = "Drama" }
        };

        public static List<Movie> GetAll()
        {
            return movies;
        }

        public static Movie? GetById(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);
        }

        public static void Add(Movie movie)
        {
            int maxId = movies.Count == 0 ? 0 : movies.Max(m => m.Id);
            movie.Id = maxId + 1;
            movies.Add(movie);
        }

        public static void Update(Movie updatedMovie)
        {
            var existing = movies.FirstOrDefault(m => m.Id == updatedMovie.Id);
            if (existing != null){
                existing.Title = updatedMovie.Title;
                existing.Year = updatedMovie.Year;
                existing.Genre = updatedMovie.Genre;
            }
        }

        public static void Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null){
                movies.Remove(movie);
            }
        }
    }
}
