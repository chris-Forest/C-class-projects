//*******************************************************
// Chris Forest assignment 5
//*******************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;


namespace assignment_5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const int WIDTH = 300;  // constant for width
            const int HIGHT = 300;  // constant fo height
            int diameter;           // diameter variable
            int x = 0;                // x value
            int y = 0;                // y value

            // will display my title 
            Console.WriteLine("\t\tChris Forest Assignment 5");

            // sets my GDIDrawer window size
            CDrawer draw = new CDrawer(WIDTH, HIGHT);

            // user input for daimeter
            Console.Write("\nEnter a diameter: ");

            // if input is invalid error will display
            if (int.TryParse(Console.ReadLine(), out diameter))
            {
                //parameters for diameter; statment to force diameter input to min or max
                diameter = (diameter < 10) ? 10 : diameter;
                diameter = (diameter > 100) ? 100 : diameter;

                // statment for user input
                Console.Write("\nEnter a  for x: ");
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    // parameters for x to stay in GDI draw window
                    x = (x < diameter) ? diameter / 2 : x;
                    x = (x > WIDTH - diameter / 2) ? WIDTH - diameter / 2 : x;

                    // statment if y input is invalid
                    Console.Write("\nEnter a for y: ");
                    int.TryParse(Console.ReadLine(), out y);

                    // parameters for y to stay in GDI draw window
                    y = (y < diameter) ? diameter / 2 : y;
                    y = (y > HIGHT - diameter / 2) ? HIGHT - diameter / 2 : y;
                }
                else
                {
                    // statment where if x and y are input are not valid 
                    Console.WriteLine("entry is not a valid intiger");
                }
                // will draw a cicrle in window
                draw.AddCenteredEllipse(x, y, diameter, diameter, Color.Red);

            }
            else
            {
                // if input is invalid error will display
                Console.WriteLine("entry is not a valid intiger");
            }
            Console.WriteLine("\npress any key to exit.");
            Console.ReadKey();
        }
    }
}