using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment__4_redo
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;    // varaible for user input      
            int rdmNum;       //varaibel for random number

            // Title
            Console.WriteLine("\t\t\tChris Forest Assignment 4");

            //  line stating your choices
            Console.WriteLine("\nPlease select your play from the following choices...\n\n Paper\n Rock\n Scissors\n");

            // user prompt for  choice selection
            Console.Write("Your selection: ");
            choice = Console.ReadLine();
            choice = choice.ToLower();

            // switch statment if wrong string was entered
            switch (choice)
            {
                case "paper":
                    break;
                case "rock":
                    break;
                case "scissors":
                    break;

                default:
                    Console.WriteLine("\nIvalid string, enter a correct string");
                    Console.Write("Your selection: \n");
                    choice = Console.ReadLine();
                    choice = choice.ToLower();
                    break;
            }

            // my random number generator
            Random randm = new Random();
            rdmNum = randm.Next(1, 4);

            switch (rdmNum)
            {
                // if scissors is picked by computer, assigned to 1
                case 1:
                    //
                    switch (choice)
                    {
                        case "paper":
                            Console.WriteLine("\ncomputer played scissors and you played paper.");
                            Console.WriteLine("\nScissors cuts paper, you lose");
                            break;
                        case "rock":
                            Console.WriteLine("\ncomputer played scissors and you played rock.");
                            Console.WriteLine("\nrock breaks scissors, you win!");
                            break;
                        case "scissors":
                            Console.WriteLine("\ncomputer played scissors and you played scissors.");
                            Console.WriteLine("\nscissors can not cut scissors, it is a tie.");
                            break;
                    }
                    break;

                // if paper is picked by computer, assigned to 2
                case 2:
                    //
                    switch (choice)
                    {
                        case "paper":
                            Console.WriteLine("\ncomputer played paper and you played paper.");
                            Console.WriteLine("\npaper and paper does nothing, it is a tie.");
                            break;
                        case "rock":
                            Console.WriteLine("\ncomputer played paper and you played rock.");
                            Console.WriteLine("\npaper covers rock, you lose.");
                            break;
                        case "scissors":
                            Console.WriteLine("\ncomputer played paper and you played scissors.");
                            Console.WriteLine("\nScissors cuts paper, you win!");
                            break;
                    }
                    break;

                //if rock is picked by computer, assigned to 3
                case 3:
                    //
                    switch (choice)
                    {
                        case "paper":
                            Console.WriteLine("\ncomputer played rock and you played paper.");
                            Console.WriteLine("paper covers rock, you win!");
                            break;
                        case "rock":
                            Console.WriteLine("\ncomputer played rock and you played rock.");
                            Console.WriteLine("rock and rock smash into each other and do nothing, it is a tie.");
                            break;
                        case "scissors":
                            Console.WriteLine("\ncomputer played rock and you played scissors.");
                            Console.WriteLine("\nrock break your scissors, you lose.");
                            break;
                    }
                    break;

            }
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
