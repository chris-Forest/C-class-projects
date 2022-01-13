//**********************************************************************
// Chris Forest Assignment 2
//**********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmet_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double n12Pack = 12.34;         // price for a 12 pack              
            double n6Pack = 7.89;           // Price for a 6 pack       
            double nSingles = 2.34;         // Price of 1 can            
            int    cans = 21;               // number of cans to buy
            double tCost;                   // total cost for cnas to buy   
            string nameDrink = "HotStuff";  // name varaible

            // will display my title
            Console.SetCursorPosition((Console.WindowWidth - "Chris Forest Assignment 02".Length) / 2, 0);
            Console.WriteLine("Chris Forest Assignment 02\n");

            // will display the name of drink
            Console.Write("Enter the name of the energy drink: ");         
            Console.WriteLine(nameDrink);

            // will dasplay price for a 12 pack
            Console.Write("Enter the cost of a dozen of HotStuff: ");
            Console.WriteLine(n12Pack);

            // will dispaly price for a 6 pack
            Console.Write("Enter the Cost of a six pack of HotStuff: ");
            Console.WriteLine(n6Pack);

            // will display price of how many single cans to buy
            Console.Write("Enter the cost of a single can of HotStuff: ");
            Console.WriteLine(nSingles);

            // will display number of cans to buy
            Console.Write("Enter the number of HotStuff cans to purchase: ");
            Console.WriteLine(cans);
            Console.WriteLine();

            // the dashed seperator
            Console.WriteLine("----------------------------------------------------------------\n");

            //n12Pack = cans / 12;
            //cans = cans % 12;
            //n12Pack = n12Pack * 12.34;

            // will display how many 12 pack(s) to buy with price in a dollar value
            Console.Write("Dozens to purchase: 1 @ ");
            Console.Write("{0:C}", n12Pack);
            Console.Write(" = ");
            Console.WriteLine("{0:C}", n12Pack);

            //n6Pack = cans / 6;
            //cans = cans % 6;
            //n6Pack = n6Pack * 7.89;

            //will display how many 6 pack(s) to buy with price in a dollar value
            Console.Write("Six packs to purchase: 1 @ ");
            Console.Write("{0:C}", n6Pack);
            Console.Write(" = ");
            Console.WriteLine("{0:C}", n6Pack);

            //nSingles = cans / 1;
            //cans = cans % 1;
            //nSingles = nSingles * 2.34;

            //will display how many single cans to buy with price in a dollar value
            Console.Write("Dozens to purchase: 3 @ ");
            Console.Write("{0:C}", 2.34);
            Console.Write(" = ");
            Console.WriteLine("{0:C}",nSingles*3);
            Console.WriteLine();
            
            // will calculate the total cost
            tCost = n12Pack + n6Pack + (nSingles*3);

            // will dispay total cost in a doller value
            Console.Write("Total cost: ");
            Console.Write("{0:C}", tCost);
            Console.WriteLine();
            Console.WriteLine();

            // propmt to press any key to exit
            Console.Write("Press any to exit: ");
            Console.ReadKey();
        }
    }
}
