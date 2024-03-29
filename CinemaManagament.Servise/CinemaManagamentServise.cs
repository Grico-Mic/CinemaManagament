﻿

using CinemaManagament.Common.Exceptions;
using CinemaManagament.Common.Validators;
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
            _movieRepository = new MovieRepository();
            _productRepository = new ProductRepository();
            _hallRepository = new HallRepository();
            _receiptRepository = new ReceiptRepository();
        }

        private MovieRepository _movieRepository { get; set; }

        private ProductRepository _productRepository { get; set; }

        private HallRepository _hallRepository { get; set; }

        private ReceiptRepository _receiptRepository { get; set; }





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
            _movieRepository.SaveChanges();


        }
        public void DeleteMovie()
        {
            //Console.WriteLine("Please choose the movie to delete");
            //Movies.ForEach(x => Console.WriteLine($"{x.Id} - {x.Title}"));
            //var userDeleteMovieInputId = int.Parse(Console.ReadLine());
            //var movieToDelete = Movies.FirstOrDefault(x => x.Id == userDeleteMovieInputId);

            var movieToDelete = SelectMovie();
            _movieRepository.Delete(movieToDelete);
            _movieRepository.SaveChanges();

        }
        public void EditMoviePrice()
        {
            var movieToEdit = SelectMovie();
            Console.WriteLine("Please enter new price");
            var newPrice = Console.ReadLine().ValidatePositiveDecimal();
            movieToEdit.Price = newPrice;
            _movieRepository.SaveChanges();


        }
       
        public void CreateProduct()
        {
            Console.WriteLine("Please enter the product name");
            var userInputProductName = Console.ReadLine().CheeckNullOrEmpty();

            Console.WriteLine("Please enter the price");
            var userInputProductPrice = Console.ReadLine().ValidatePositiveDecimal();

            Console.WriteLine("Please enter the qantity");
            var userInputProductQantuty = Console.ReadLine().ValidatePositiveInteger();

            var dbProduct =_productRepository.GetByFirstOrDefault((x) => x.Name == userInputProductName);
            if (dbProduct != null)
            {
                throw new CinemaManagamentExceptions($"The product with name {userInputProductName} is alredy exist.");
            }

            var product = new Product();
            product.Name = userInputProductName;
            product.Price = userInputProductPrice;
            product.Quantity = userInputProductQantuty;

            _productRepository.Create(product);
            _productRepository.SaveChanges();

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
            _productRepository.SaveChanges();
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
            _hallRepository.SaveChanges();
        }
        public void DeleteHall()
        {
            var hallToDelete = SelectHall();
            _hallRepository.Delete(hallToDelete);
            _hallRepository.SaveChanges();
        }
        public void ChangeShowingMovie()
        {
            var showHall = SelectHall();
            var showMovie = SelectMovie();

            showHall.MovieId = showMovie.Id;
            _hallRepository.SaveChanges();

        }
        public void ChangeNumberOfSeads()
        {
            var showHall = SelectHall();
            Console.WriteLine($"Number of current seads {showHall.NumberOfSeads}");

            Console.WriteLine("Please enter a new number of seads?");
            var userInputChangeNumberofSeads =Console.ReadLine().ValidatePositiveInteger();

            showHall.NumberOfSeads = userInputChangeNumberofSeads;
            _hallRepository.SaveChanges();




        }
       
        public void BuyTicket()
        {
            
            var showHall = SelectHall();
            
            Console.WriteLine($"Please enter how many ticket want?There are {showHall.NumberOfSeads} left.");
            var userInputSeatsWant = Console.ReadLine().ValidatePositiveInteger();

            if (userInputSeatsWant > showHall.NumberOfSeads)
            {
                throw new CinemaManagamentExceptions("We are sorry, there are not so many free seats");
            }
            showHall.NumberOfSeads -= userInputSeatsWant;

            var chooseProductstoBuy = ChooseProductsToBuy();

            Console.WriteLine("Please enter your name");
            var customerName = Console.ReadLine().CheeckNullOrEmpty();

            var movie = _movieRepository.GetById(showHall.MovieId);

            var receipt = new Receipt();
            receipt.CustomerName = customerName;
            receipt.HallName = showHall.Name;
            receipt.TicketQuantity = userInputSeatsWant;
            receipt.Products = chooseProductstoBuy;
            receipt.PricePerTicket = movie.Price;
            receipt.MovieTitle = movie.Title;

            _receiptRepository.Create(receipt);
            _receiptRepository.SaveChanges();
            _hallRepository.SaveChanges();
            _productRepository.SaveChanges();

            PrintReceipt(receipt);
        }

        private void PrintReceipt(Receipt receipt)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"     Thanks {receipt.CustomerName} for choose our cinema.");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Hall:{receipt.HallName}");
            Console.WriteLine($"Movie:{receipt.MovieTitle}");
            var totalTicketPrice = receipt.PricePerTicket * receipt.TicketQuantity;
            Console.WriteLine($"Ticket price:{ receipt.PricePerTicket} x { receipt.TicketQuantity} = {totalTicketPrice}");

            foreach (var product in receipt.Products)
            {
                Console.WriteLine($"Product name:{product.Name}.Quantity:{product.Quantity}.Price{product.Price}.");
            }

            var totalProductsPrice = receipt.Products.Sum(x => x.Price * x.Quantity);
            Console.WriteLine($"Total products price is:{totalProductsPrice}");

            Console.WriteLine($"Total price:{totalTicketPrice + totalProductsPrice}");
            Console.WriteLine($"Date:{receipt.DateCreated}");
        }
        private List<Product> ChooseProductsToBuy()
        { 
            var choosenProducts = new List<Product>();

            Console.WriteLine("Do you want to buy some product?Enter y for Yes");
            var sholudBuyProduct = Console.ReadLine();

            while (sholudBuyProduct.ToLower() == "y")
            {
                var productToBuy = new Product();

                var choosenProduct = SelectProduct();

                productToBuy.Id = choosenProduct.Id;
                productToBuy.Name = choosenProduct.Name;
                productToBuy.Price = choosenProduct.Price;

                Console.WriteLine("How much do you want?");
                var quantity = Console.ReadLine().ValidatePositiveInteger();
                if (quantity > choosenProduct.Quantity)
                {
                    Console.WriteLine("Not enough in stock");
                }
                else
                {
                    choosenProduct.Quantity -= quantity;
                    productToBuy.Quantity = quantity;
                }

                choosenProducts.Add(productToBuy);

                Console.WriteLine("Would you like another product?Enter n for NO");
                var userInputProductWant = Console.ReadLine();

                if (userInputProductWant.ToLower() == "n")
                {

                    sholudBuyProduct = "n";
                }
            }
            return choosenProducts;
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
            var movies = _movieRepository.GetAll();
            halls.ForEach(x => Console.WriteLine($"Id:{x.Id}. Name:{x.Name}.Movie title:{movies.FirstOrDefault(y => y.Id == x.MovieId).Title}"));

            var hallId = Console.ReadLine().ValidatePositiveInteger();
            var rezult = _hallRepository.GetById(hallId);
            if (rezult == null)
            {
                throw new CinemaManagamentExceptions($"Hall with {hallId} does not exist");
            }

            return rezult;
        }

        private Product SelectProduct()

        {
            
            var products = _productRepository.GetAll();

            products.ForEach(x => Console.WriteLine($"Id:{x.Id}.Name:{x.Name}.Price:{x.Price}"));

            var userInputChooseProductsId = Console.ReadLine().ValidatePositiveInteger();
            var userInputChoosenProduct = products.FirstOrDefault(x => x.Id == userInputChooseProductsId);

            if (userInputChoosenProduct == null)
            {
                throw new CinemaManagamentExceptions("Invalid input");
            }
            return userInputChoosenProduct;
        }

     }

 }
       



 


