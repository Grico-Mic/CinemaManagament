using CinemaManagament.Repositories.Common;
using CinemaManagamentAppication.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaManagament.Repositories
{
    public class MovieRepository
    {
        public MovieRepository()
        {
            
            _movies = new List<Movie>() 
            {
                new Movie(){Id = 1,Title = "Shawshank Redemption",Duration = 140,Genre = GenreEnum.Drama,Price = 1000},
                new Movie(){Id = 2,Title = "Wind River",Duration = 120,Genre = GenreEnum.Action,Price = 800},
                new Movie(){Id = 3,Title = "The boy who harnessed the wind",Duration = 120,Genre = GenreEnum.Drama,Price = 600}
             };
        }
        private List<Movie> _movies { get; set; }

        public void Create(Movie movie)
        {
            movie.Id = IdGenerator.GenerateId<Movie>(_movies);
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

       
    }
}
