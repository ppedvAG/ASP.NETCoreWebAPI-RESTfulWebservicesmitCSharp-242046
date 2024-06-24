using BusinessLogic.Contracts;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MovieService : IMovieService
    {
        private readonly IList<Movie> _movieList =
        [
            new Movie()
            {
                Id = 6548,
                Title = "Coda",
                Description = "Film über talentierten Musikerin",
                Price = 19.99m,
                Genre = MovieType.Drama
            },
            new Movie()
            {
                Id = 6789,
                Title = "Kind Richard",
                Description = "Film über Serena und Venus Williams",
                Price = 19.99m,
                Genre = MovieType.Docu
            },
        ];

        public IList<Movie> GetMovies()
        {
            return _movieList;
        }

        public Movie GetMovie(int id)
        {
            return _movieList.FirstOrDefault(x => x.Id == id);
        }

        public void AddMovie(Movie movie)
        {
            _movieList.Add(movie);
        }
        public void DeleteMovie(int id)
        {
            _movieList.Remove(GetMovie(id));
        }
        public void UpdateMove(Movie movie)
        {
            Movie orginal = _movieList.First(e => e.Id == movie.Id);
            orginal = movie;
        }

    }
}
