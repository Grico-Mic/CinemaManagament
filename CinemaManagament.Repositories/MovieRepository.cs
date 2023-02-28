using CinemaManagamentAppication.Models;
using System.Collections.Generic;

namespace CinemaManagament.Repositories
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository()
        {
            
            Data = new List<Movie>() 
            {
                new Movie(){Id = 1,Title = "Shawshank Redemption",Duration = 140,Genre = GenreEnum.Drama,Price = 1000},
                new Movie(){Id = 2,Title = "Wind River",Duration = 120,Genre = GenreEnum.Action,Price = 800},
                new Movie(){Id = 3,Title = "The boy who harnessed the wind",Duration = 120,Genre = GenreEnum.Drama,Price = 600}
             };
        }
    }
}
