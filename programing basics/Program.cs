//***********************************************************************************************
// Chris Forest assginment 6
//***********************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string password;          // password string varaible   
            string runAgain;          // varaible for running program again   
            int upper = 0;            // checks for upper case letters    
            int lower = 0;            // checks for lower case letters  
            int symbol = 0;           // checks for symbols
            int space = 0;            // checks for spaces in the password
            int digit = 0;            // checks for numbers in password
            bool badPassword = false; // will check if all password conditions are met
            do
            {
            
                    // user input for password
                    Console.Write("Enter your password: ");
                    password = Console.ReadLine();

                    // checks if password is too small and will loop until it meets or is bigger then ideal length
                    while (password.Length < 8)
                    {
                        Console.WriteLine("password is too small");
                        Console.Write("Enter your password: ");
                        password = Console.ReadLine();
                    }

                    // checks for various things in user inputed password
                    foreach (char chLetter in password)
                    {
                    // will check for upper case letters in password
                        if (char.IsUpper(chLetter))
                        {
                        Console.WriteLine($"count: {upper}");
                           upper++;
                        }
                        // will check for lower case letters in password
                        if (char.IsLower(chLetter))
                            lower++;

                        //will check for symbols in password
                        if (char.IsSymbol(chLetter)|| (char.IsPunctuation(chLetter)))
                            symbol++;

                        // will check for any spaces in password
                        if (char.IsWhiteSpace(chLetter))
                            space++;

                        // will check for numbers in password
                        if (char.IsNumber(chLetter))
                        {
                            if (digit == 0)
                            {
                                digit++;
                            }
                        }
                        // needed for certian Punctuation thought to be symbols
                        
                    }

                //error message if there are no upper case letters in the password
                if (upper <= 0)
                {
                    Console.WriteLine("\nThere are no upper case letters please add an upper case letter(s)");
                    badPassword = true;
                }
                // error message if there are no lower case letters in the password
                if (lower <= 0)
                {
                    Console.WriteLine("\nThere are no lower case letters please add lower case letters");
                    badPassword = true;
                }
                // error message if not enough symbols are in the password
                if (symbol <= 0)
                {
                    Console.WriteLine("\nThere are no symbols please add a symbol(s)");
                    badPassword = true;
                }
                // error message if there are spaces in the password
                if (space > 0)
                {
                    Console.WriteLine("\nPlease do not use spaces");
                    badPassword = true;
                }
                // error message if not enough number are in the password
                if (digit < 1)
                {
                    Console.WriteLine("\nthere are two or more of the same numbers, please change one or more numbers \nor there is one or less numbers in the password, please add one or more numbers.");
                    badPassword = true;
                }
                    // if all password conditions are met accepeted message will display
                    if (!badPassword)
                        Console.WriteLine("\nyou have made an acceptable password");

                // prompt to ask user to rum program again
                Console.WriteLine("\nRun program again? (y/n): ");
                runAgain = Console.ReadLine();
            
            } while (runAgain=="y"||(runAgain=="Y"));
            // asks user if they want to run the program again ... exists if not
               
            
            
        }
    }
}
