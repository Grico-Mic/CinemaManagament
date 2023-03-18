

using CinemaManagament.Common.Exceptions;
using CinemaManagament.Common.Validators;
using CinemaManagament.Repositories;
using CinemaManagamentAppication.Models;
using System;
using System.Linq;

namespace CinemaManagament.Servise
{
    public class CinemaManagamentServise

    {
        public CinemaManagamentServise()
        {
            _movieRepository = new MovieRepository();
            _productRepository = new ProductRepository();
            _hallRepository = new HallRepository();
        }

        private MovieRepository _movieRepository { get; set; }

        private ProductRepository _productRepository { get; set; }

        private HallRepository _hallRepository { get; set; }





        public void CreateMovie()
        {


            Console.WriteLine("Please enter movie title");
            var userInputMovieTitle = Console.ReadLine().CheeckNullOrEmpty();

            //if (string.IsNullOrEmpty(userInputMovieTitle.Trim()))
            //{
            //    throw new CinemaManagamentExceptions("Invalid movie title");
            //}

            Console.WriteLine("Please enter duration");
            var userInputMovieDuration = Console.ReadLine().ValidatePositiveInteger();

            Console.WriteLine("Please enter movie genre:");
            var values = Enum.GetValues(typeof(GenreEnum));

            foreach (var value in values)
            {
                var testValue = (int)value;
                Console.WriteLine($"Please enter {(int)value} for {value}");
            }
            var userInputMovieGenre = Console.ReadLine().ValidatePositiveInteger();
            
            ValidateGenreEnum(userInputMovieGenre);

            Console.WriteLine("Please enter price");
            var userInputMoviePrice = Console.ReadLine().ValidatePositiveDecimal();

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
            var newPrice = Console.ReadLine().ValidatePositiveDecimal();
            movieToEdit.Price = newPrice;

             
        }
       
        public void CreateProduct()
        {
            Console.WriteLine("Please enter the product name");
            var userInputProductName = Console.ReadLine().CheeckNullOrEmpty();

            Console.WriteLine("Please enter the price");
            var userInputProductPrice = Console.ReadLine().ValidatePositiveDecimal();

            Console.WriteLine("Please enter the qantity");
            var userInputProductQantuty = Console.ReadLine().ValidatePositiveInteger();

            var dbProduct =_productRepository.GetByName(userInputProductName);
            if (dbProduct != null)
            {
                throw new CinemaManagamentExceptions($"The product with name {userInputProductName} is alredy exist.");
            }

            var product = new Product();
            product.Name = userInputProductName;
            product.Price = userInputProductPrice;
            product.Quantity = userInputProductQantuty;

            _productRepository.Create(product);

        }
        public void RemoveFromStock()
        {
            Console.WriteLine("Please enter a number to choose product for edit.");
           var dbProducts = _productRepository.GetAll();

            dbProducts.ForEach(x => x.Print());
            var userInput = Console.ReadLine().ValidatePositiveInteger();
           
            var choosenProduct = dbProducts.FirstOrDefault(x => x.Id == userInput);
            if (choosenProduct == null)
            {
                throw new CinemaManagamentExceptions($"The product with {userInput} does not exist.");
            }

            Console.WriteLine($"Enter qantity to remove.Actual qantity is {choosenProduct.Quantity}.");
            
            
            var userInputQantituRemove = Console.ReadLine().ValidatePositiveInteger();

            if (userInputQantituRemove >= choosenProduct.Quantity)
            {
                Console.WriteLine("You remove whole stock from this product.Would you like to delete from DB?.");
                Console.WriteLine("Enter y for yes.");
                var sholudRemoveProduct = Console.ReadLine();
                if (sholudRemoveProduct.ToLower() == "y")
                {
                    _productRepository.Delete(choosenProduct);
                }
                else
                {
                choosenProduct.Quantity = 0;
                }

            }
            else
            {
                choosenProduct.Quantity -= userInputQantituRemove;
            }
               
         }


        public void CreateHall()
        {
            var hall1 = new Hall();
            Console.WriteLine(  "Please enter name hall");
            var userInputHallName = Console.ReadLine().CheeckNullOrEmpty();

            Console.WriteLine("Please enter a number of seads");
            var userInputNubmerOfSeads = Console.ReadLine().ValidatePositiveInteger();

            Console.WriteLine("Please enter a movie to play");

            var selectedMovieForHall = SelectMovie();



            hall1.Name = userInputHallName;
            hall1.NumberOfSeads = userInputNubmerOfSeads;
            hall1.MovieId = selectedMovieForHall.Id;

            _hallRepository.Create(hall1);
        }
        public void DeleteHall()
        {
            var hallToDelete = SelectHall();
            _hallRepository.Delete(hallToDelete);
        }
        public void ChangeShowingMovie()
        {
            var showHall = SelectHall();
            var showMovie = SelectMovie();

            showHall.MovieId = showMovie.Id;

        }
        public void ChangeNumberOfSeads()
        {
            var showHall = SelectHall();
            Console.WriteLine($"Number of current seads {showHall.NumberOfSeads}");

            Console.WriteLine("Please enter a new number of seads?");
            var userInputChangeNumberofSeads =Console.ReadLine().ValidatePositiveInteger();

            showHall.NumberOfSeads = userInputChangeNumberofSeads;




        }
       
        public void BuyTicket()
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
        private Movie SelectMovie()

        {
            
            Console.WriteLine("Please choose the movie:");

            var movies = _movieRepository.GetAll();
            movies.ForEach(x => Console.WriteLine($"{x.Id} - {x.Title}.Ganre:{x.Genre}.Current price is {x.Price}"));
            var movieId = Console.ReadLine().ValidatePositiveInteger();
            var rezult = _movieRepository.GetById(movieId);
            if (rezult == null)
            {
                throw new CinemaManagamentExceptions($"Movie with {movieId} does not exist");
            }

            return rezult;
        }

        private Hall SelectHall()
        {
            Console.WriteLine("Please choose the hall:");

            var halls = _hallRepository.GetAll();
            halls.ForEach(x => Console.WriteLine($"Id:{x.Id}. Name:{x.Name}."));

            var hallId = Console.ReadLine().ValidatePositiveInteger();
            var rezult = _hallRepository.GetById(hallId);
            if (rezult == null)
            {
                throw new CinemaManagamentExceptions($"Movie with {hallId} does not exist");
            }

            return rezult;
        }

     }

 }
       



 


