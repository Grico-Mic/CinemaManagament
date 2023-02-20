

namespace CinemaManagamentAppication.Models
{
    public class Movie : BaseEntity
    {
       
        public string Title { get; set; }
        public int Duration { get; set; }
        public GenreEnum Genre { get; set; }
        public decimal Price { get; set; }
    }
}
