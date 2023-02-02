

using CinemaManagament.Repositories;
using CinemaManagamentAppication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaManagament.Servise
{
    public class CinemaManagamentServise

    {
        public CinemaManagamentServise()
        {
            MovieRepository = new MovieRepository();
        }

        private MovieRepository MovieRepository { get; set; }
        public void CreateMovie()
        {
            Console.WriteLine("Please enter movie title"); 
            var userInputMovieTitle = Console.ReadLine();

            Console.WriteLine("Please enter duration");
            var userInputMovieDuration = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter movie genre:");
            var values = Enum.GetValues(typeof(GenreEnum));

            foreach (var value in values)
            {
                var testValue = (int)value;
                Console.WriteLine($"Please enter {testValue} for {value}");
            }
            var userInputMovieGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter price");
            var userInputMoviePrice = decimal.Parse(Console.ReadLine()) ;

            var movie = new Movie();
            movie.Id = GenerateMovieId();
            movie.Title = userInputMovieTitle;
            movie.Duration = userInputMovieDuration;
            movie.Genre = (GenreEnum)userInputMovieGenre;
            movie.Price = userInputMoviePrice;

            MovieRepository.Create(movie);
        }
        public void DeleteMovie()
        {
            //Console.WriteLine("Please choose the movie to delete");
            //Movies.ForEach(x => Console.WriteLine($"{x.Id} - {x.Title}"));
            //var userDeleteMovieInputId = int.Parse(Console.ReadLine());
            //var movieToDelete = Movies.FirstOrDefault(x => x.Id == userDeleteMovieInputId);

            var movieToDelete = SelectMovie();
            MovieRepository.Delete(movieToDelete);


        }
        public void EditMoviePrice()
        {
            var movieToEdit = SelectMovie();
            Console.WriteLine("Please enter new price");
            var newPrice = decimal.Parse(Console.ReadLine());
            movieToEdit.Price = newPrice;


        }

        private Movie SelectMovie()

        {
            
            Console.WriteLine("Please choose the movie:");

            var movies = MovieRepository.GetAll();
            movies.ForEach(x => Console.WriteLine($"{x.Id} - {x.Title}.Current price is {x.Price}"));
            var movieId = int.Parse(Console.ReadLine());
            var rezult = MovieRepository.GetById(movieId);

            return rezult;
        }

        
        }

    }
}

