﻿

using CinemaManagamentAppication.Models;
using System;
using System.Collections.Generic;

namespace CinemaManagament.Servise
{
    public class CinemaManagamentServise

    {
        public CinemaManagamentServise()
        {
            Movies = new List<Movie>();
        }

        public List<Movie> Movies { get; set; }
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
            movie.Title = userInputMovieTitle;
            movie.Duration = userInputMovieDuration;
            movie.Genre = (GenreEnum)userInputMovieGenre;
            movie.Price = userInputMoviePrice;

            Movies.Add(movie);
        }
  
    }
}

