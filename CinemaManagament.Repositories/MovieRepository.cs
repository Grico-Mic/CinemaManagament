using CinemaManagamentAppication.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaManagament.Repositories
{
    public class MovieRepository
    {
        public MovieRepository()
        {
            _movies = new List<Movie>();
        }
        private List<Movie> _movies { get; set; }

        public void Create(Movie movie)
        {
            movie.Id = GenerateMovieId();
            _movies.Add(movie);
        }

        public void Delete(Movie movie)
        {
            _movies.Remove(movie);
        }

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetById(int id)
        {
            return _movies.FirstOrDefault(x => x.Id == id);
        }

        private int GenerateMovieId()
        {

            {
                var newId = 0;

                if (_movies.Count > 0)
                {
                    newId = _movies.Max(x => x.Id);

                }
                return newId + 1;
            }
        }
    }
}
