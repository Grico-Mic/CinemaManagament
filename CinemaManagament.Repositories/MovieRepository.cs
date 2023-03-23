using CinemaManagamentAppication.Models;


namespace CinemaManagament.Repositories
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository() : base("Movie.txt")
        {
            
        }
    }
}
