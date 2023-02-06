using CinemaManagament.Servise;
using System;
using System.IO;

namespace CinemaManagament
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("   Welcome to our cinema");
            Console.WriteLine("-----------------------------");


            var cinemaManagamentServise = new CinemaManagamentServise();
            string shouldContinue = "";
            do
            {
                try
                {
                    Console.WriteLine("Please choose one of the following options");
                    Console.WriteLine("1. Buy ticket");
                    Console.WriteLine("2. Edit");
                    Console.WriteLine("3. Display next playing movie");
                    Console.WriteLine("4. Overview");

                    var userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("Please choose one of the following options");
                            break;
                        case "2":
                            ShowEditOptions(cinemaManagamentServise);
                            break;
                        case "3":
                            Console.WriteLine("Please choose one of the following options");
                            break;
                        case "4":
                            Console.WriteLine("Please choose one of the following options");
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText("Log.txt",$"{DateTime.Now}. {ex.Message} {ex.StackTrace}");
                    Console.WriteLine($"Date of error:{DateTime.Now}.An Error has ocuped.Please try again later.");
                }
                
                Console.WriteLine("Do you want to continue?Enter no for exit");
                shouldContinue = Console.ReadLine().Trim().ToLower();
            } while (shouldContinue != "no");
        }
        private static void ShowEditOptions(CinemaManagamentServise cinemaManagementService)
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
                    ShowMovieEditOptions(cinemaManagementService);
                    break;
                case "3":
                    Console.WriteLine("Snacks");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        private static void ShowMovieEditOptions(CinemaManagamentServise cinemaManagementService)
        {
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Delete");
            Console.WriteLine("3. Edit price");

            var editMovieUserInput = Console.ReadLine().Trim();

            switch (editMovieUserInput)
            {
                case "1":
                    cinemaManagementService.CreateMovie();
                    break;
                case "2":
                    cinemaManagementService.DeleteMovie();
                    break;
                case "3":
                    cinemaManagementService.EditMoviePrice();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
