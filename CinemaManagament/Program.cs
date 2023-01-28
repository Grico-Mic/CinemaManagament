﻿using System;

namespace CinemaManagament
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("   Welcome to our cinema");
            Console.WriteLine("-----------------------------");

            string shouldContinue = "";
            do
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
                        ShowEditOptions();
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
                Console.WriteLine("Do you want to continue?Enter no for exit" );
                shouldContinue = Console.ReadLine().Trim().ToLower();
            } while (shouldContinue != "no");
            
        }

        private static void ShowEditOptions()
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
                    ShowMovieEditOptions();
                    break;
                case "3":
                    Console.WriteLine("Snack");
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        private static void ShowMovieEditOptions()
        {
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Create");
            Console.WriteLine("Delete");
            Console.WriteLine("Edit price");

            var editMovieUserInput = Console.ReadLine().Trim();

            switch (editMovieUserInput)
            {
                case "1" :
                    Console.WriteLine("Create movie");
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
