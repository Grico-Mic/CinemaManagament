﻿

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
            _productRepository = new ProductRepository();
        }

        private MovieRepository _movieRepository { get; set; }

        private ProductRepository _productRepository { get; set; }


        public void CreateMovie()
        {


            Console.WriteLine("Please enter movie title");
            var userInputMovieTitle = StringValidator.CheeckNullOrEmpty(Console.ReadLine());

            //if (string.IsNullOrEmpty(userInputMovieTitle.Trim()))
            //{
            //    throw new CinemaManagamentExceptions("Invalid movie title");
            //}

            Console.WriteLine("Please enter duration");
            var userInputMovieDuration = StringValidator.ValidatePositiveInteger(Console.ReadLine());

            Console.WriteLine("Please enter movie genre:");
            var values = Enum.GetValues(typeof(GenreEnum));

            foreach (var value in values)
            {
                var testValue = (int)value;
                Console.WriteLine($"Please enter {(int)value} for {value}");
            }
            var userInputMovieGenre = StringValidator.ValidatePositiveInteger(Console.ReadLine());
            
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
            var newPrice = StringValidator.ValidatePositiveDecimal(Console.ReadLine());
            movieToEdit.Price = newPrice;

             
        }

        private Movie SelectMovie()

        {
            
            Console.WriteLine("Please choose the movie:");

            var movies = _movieRepository.GetAll();
            movies.ForEach(x => Console.WriteLine($"{x.Id} - {x.Title}.Ganre:{x.Genre}.Current price is {x.Price}"));
            var movieId = StringValidator.ValidatePositiveInteger(Console.ReadLine());
            var rezult = _movieRepository.GetById(movieId);
            if (rezult == null)
            {
                throw new CinemaManagamentExceptions($"Movie with {movieId} does not exist");
            }

            return rezult;
        }
        public void CreateProduct()
        {
            Console.WriteLine("Please enter the product name");
            var userInputProductName = StringValidator.CheeckNullOrEmpty(Console.ReadLine());

            Console.WriteLine("Please enter the price");
            var userInputProductPrice = StringValidator.ValidatePositiveDecimal(Console.ReadLine());

            Console.WriteLine("Please enter the qantity");
            var userInputProductQantuty = StringValidator.ValidatePositiveInteger(Console.ReadLine());

            var dbProduct =_productRepository.GetByName(userInputProductName);
            if (dbProduct != null)
            {
                throw new CinemaManagamentExceptions($"The product with name {userInputProductName} is alredy exist.");
            }

            var product = new Product();
            product.Name = userInputProductName;
            product.Price = userInputProductPrice;
            product.Quantity = userInputProductQantuty;

            _productRepository.CreateProduct(product);

        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }



        private static void ValidateGenreEnum(int userInputMovieGenre)
        {
            if (!Enum.IsDefined(typeof(GenreEnum), userInputMovieGenre))
            {
                throw new CinemaManagamentExceptions("Invalid Input");
            }
        }
    }
 }


