using CinemaManagamentAppication.Models;


namespace CinemaManagament.Repositories
{
    public class HallRepository : BaseRepository<Hall>
    {
        public HallRepository() :base("Hall.txt")
        {

        }
    }
}
