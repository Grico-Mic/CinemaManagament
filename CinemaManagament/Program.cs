using System;

namespace CinemaManagament
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("   Welcome to our cinema");
            Console.WriteLine("-----------------------------");

            var menuHelper = new menuHelper();
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
                        menuHelper.ShowEditOptions();
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
    }
}
