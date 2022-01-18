//Submission Code : 1201_2300_A09
//Chris Forest
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace chris_ica9
{
    class sheeple
    {
        private static Random _rdm = new Random();
        public const int MIN = 2;
        public const int MAX = 8;
        public int TotalItems { get; private set; }
        public int currentItems { get; private set; }
        public Color sheepColor { get; private set; }

        //manual bool, ends proccess if no items are left in queue
        public bool done
        {
            get { return currentItems==0; }
        }

        /// <summary>
        /// track and decrement number of items left in queue
        /// </summary>
        public void process()
        {
            currentItems--;
        }

        /// <summary>
        /// default ctor 
        /// generate random number of items to be queued between min and max
        /// set current total to set random total
        /// and generate a random color for each item
        /// </summary>
        public sheeple()
        {
            TotalItems = _rdm.Next(MIN, MAX+1);//inclusive?
            currentItems = TotalItems;
            sheepColor = RandColor.GetColor();
        }

        /// <summary>
        /// show items in queue in cdrawer
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="xStart"></param>
        /// <param name="yStart"></param>
        /// <param name="scale"></param>
        public void ShowSheeple(CDrawer canvas, int xStart, int yStart, int scale)
        {
            canvas.AddRectangle(xStart * scale, yStart * scale, scale * currentItems, scale, sheepColor);

            //But only show the current item count if it is first in line
            if (xStart == 0)
            {
                canvas.AddText(currentItems.ToString(), 12, xStart * scale, yStart * scale, scale * currentItems, scale, Color.Black);
            }
        }
    }
}
