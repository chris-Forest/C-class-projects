//Submission Code : 1201_2300_A10
//chris forest

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chris_ica10
{
    public static class MyLib
    {
        /// <summary>
        /// class method to shuffle a list of points
        /// </summary>
        /// <param name="listOfPoints"></param>
        /// <returns></returns>
        public static List<Point> Shuffle(this List<Point>listOfPoints)
        {
            List<Point> listShuffled = new List<Point>(listOfPoints);
            Random rng = new Random();

            int numbs = listShuffled.Count;

            for (int i = 0; i < numbs-1; i++)
            {
                int rand = i + rng.Next(numbs - i);
                Point tempPoint = listShuffled[rand];
                listShuffled[rand] = listShuffled[i];
                listShuffled[i] = tempPoint;
            }
            return listShuffled;
        }
    }
}
