

using System;

namespace CinemaManagament.Servise
{
    public class CinemaManagamentServise

    {
        public void CreateMovie()
        {
            Console.WriteLine("Please enter movie title");
            var userInputMovieTitle = Console.ReadLine();
            Console.WriteLine("Please enter duration");
            var userInputMovieDuration = Console.ReadLine();
            Console.WriteLine("Please enter movie genre");
            var userInputMovieGenre = Console.ReadLine();
        }
  
    }
}

