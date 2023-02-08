

using CinemaManagament.Common.Exceptions;
using CinemaManagament.Common.Validators;
using CinemaManagament.Repositories;
using CinemaManagamentAppication.Models;
using System;


namespace CinemaManagament.Servise
{
    public class CinemaManagamentServise

    {
        public CinemaManagamentServise()
        {
            _movieRepository = new MovieRepository();
        }

        private MovieRepository _movieRepository { get; set; }
        public void CreateMovie()
        {


            Console.WriteLine("Please enter movie title");
            var userInputMovieTitle = StringValidator.CheeckNullOrEmpty(Console.ReadLine());

            //if (string.IsNullOrEmpty(userInputMovieTitle.Trim()))
            //{
            //    throw new CinemaManagamentExceptions("Invalid movie title");
            //}

            Console.WriteLine("Please enter duration");
            var userInputMovieDuration = StringValidator.ValidatePositive(Console.ReadLine());

            Console.WriteLine("Please enter movie genre:");
            var values = Enum.GetValues(typeof(GenreEnum));

            foreach (var value in values)
            {
                var testValue = (int)value;
                Console.WriteLine($"Please enter {testValue} for {value}");
            }
            var userInputMovieGenre = StringValidator.ValidatePositive(Console.ReadLine());

            ValidateGenreEnum(userInputMovieGenre);

            Console.WriteLine("Please enter price");
            var userInputMoviePrice = StringValidator.ValidatePositiveDecimal(Console.ReadLine());

            var movie = new Movie();

            movie.Title = userInputMovieTitle;
            movie.Duration = userInputMovieDuration;
            movie.Genre = (GenreEnum)userInputMovieGenre;
            movie.Price = userInputMoviePrice;

            _movieRepository.Create(movie);


        }

       
        public void DeleteMovie()
        {
            //Console.WriteLine("Please choose the movie to delete");
            //Movies.ForEach(x => Console.WriteLine($"{x.Id} - {x.Title}"));
            //var userDeleteMovieInputId = int.Parse(Console.ReadLine());
            //var movieToDelete = Movies.FirstOrDefault(x => x.Id == userDeleteMovieInputId);

            var movieToDelete = SelectMovie();
            _movieRepository.Delete(movieToDelete);


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

            var movies = _movieRepository.GetAll();
            movies.ForEach(x => Console.WriteLine($"{x.Id} - {x.Title}.Current price is {x.Price}"));
            var movieId = int.Parse(Console.ReadLine());
            var rezult = _movieRepository.GetById(movieId);

            return rezult;
        }

        private static void ValidateGenreEnum(int userInputMovieGenre)
        {
            if (Enum.IsDefined(typeof(GenreEnum), userInputMovieGenre))
            {
                throw new CinemaManagamentExceptions("Invalid Input");
            }
        }
    }
 }


