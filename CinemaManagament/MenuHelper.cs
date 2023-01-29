using CinemaManagament.Servise;
using System;


namespace CinemaManagament
{
    public class menuHelper
    {
        public  void ShowEditOptions(CinemaManagamentServise cinemaManagamentServise)
        {
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("1. Hall");
            Console.WriteLine("2. Movie");
            Console.WriteLine("3. Snack");

            var editUserInput = Console.ReadLine();

            switch (editUserInput)
            {
                case "1":
                    Console.WriteLine("Hall");
                    break;
                case "2":
                    ShowMovieEditOptions(cinemaManagamentServise);
                    break;
                case "3":
                    Console.WriteLine("Snack");
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        public void ShowMovieEditOptions(CinemaManagamentServise cinemaManagamentServise)
        {
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Create");
            Console.WriteLine("Delete");
            Console.WriteLine("Edit price");

            var editMovieUserInput = Console.ReadLine().Trim();

            switch (editMovieUserInput)
            {
                case "1":
                    cinemaManagamentServise.CreateMovie();
                    
                    break;
                case "2":
                    Console.WriteLine("Delete movie");
                    break;

                case "3":
                    Console.WriteLine("Change price for movie");
                    break;

            }

        }
    }
}
