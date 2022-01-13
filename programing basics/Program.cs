//*********************************************************************************
// Chris Forest assignment 3
//*********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double rad;              // radius varible for user input
            string areaVolume;       // string for area or volume user input
            double ans;              // will display answer when needed  

            // sets my title
            Console.WriteLine("\t\t\tChris Forest assignment 3\n");

            // user propmt to enter a radius
            Console.Write("Enter the radius of a circle or sphere: ");
            double.TryParse(Console.ReadLine(), out rad);

            // my if stsament for if radius is a negative number
            if(rad<=0)
            {
                Console.WriteLine("\nyou have entered an invalid radius value. the program will exit.");
            }

            
            // user prompt to eneter area or volume
            Console.Write("Please enter desired calculation ('area' or 'volume'): ");
            areaVolume = Console.ReadLine();
            areaVolume = areaVolume.ToLower();
           
            // if statment for string name is entered right or wrong
            if (areaVolume == "area")
            {
                //math for arae of a circle
                ans = Math.PI * Math.Pow(rad, 2);
                Console.Write("\nThe area of a circle with a {0} radius of {1:F1} cm is square cm.",rad, ans);
            }
            else if (areaVolume=="volume")
            {
                //math for volume of a sphere
                ans = (4.00 / 3.00) * Math.PI * Math.Pow(rad, 3);
                Console.Write("\nThe volume of a sphere with a {0} radius of {1:F1} cm is square cm.", rad, ans);
            }
            else
            {
                // ststment if wrong string name is entered
                Console.Write("\ninvalid string program will exit");
            }
            

            //exit propmpt
            Console.WriteLine("\n\nPress any key to exit:");
            Console.ReadKey();
        }
    }
}
