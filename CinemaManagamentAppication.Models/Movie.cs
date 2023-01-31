

namespace CinemaManagamentAppication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public GenreEnum Genre { get; set; }
        public decimal Price { get; set; }
    }
}
