using CinemaManagamentAppication.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaManagament.Repositories
{
    public class MovieRepository
    {
        public MovieRepository()
        {
            Movies = new List<Movie>();
        }
        private List<Movie> Movies { get; set; }

        public void Create(Movie movie)
        {
            Movies.Add(movie);
        }

        public void Delete(Movie movie)
        {
            Movies.Remove(movie);
        }

        public List<Movie> GetAll()
        {
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

    }
}
