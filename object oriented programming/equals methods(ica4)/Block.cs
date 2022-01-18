//Submission Code : 1201_2300_A04
// Chris Forest

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Diagnostics.Trace;
using GDIDrawer;

namespace chris_ica04
{
    class Block
    {
        private static CDrawer drawer;
        private static Random _rdm = new Random();
        private static int _size;//member(field)
        public int size { set { _size = Math.Abs(value); } }//property
        private Color _Color;
        private Rectangle rectangle;

        /// <summary>
        /// load drawings in gdi window
        /// </summary>
        public static bool Loading
        {
            set
            {
                if (value)
                    drawer.Clear();
                else
                    drawer.Render();
            }
        }

        //static ctor
        static Block()
        {
            drawer = new CDrawer(_rdm.Next(500, 901), _rdm.Next(300,701), false);
        }

        //instance ctor
        public Block(int blockSize)
        {
            _Color = RandColor.GetColor();
            size = blockSize;
            rectangle.X = _rdm.Next(0, drawer.ScaledWidth - _size);//no overlap??
            rectangle.Y = _rdm.Next(0, drawer.ScaledHeight - _size);
            rectangle.Width = _size;
            rectangle.Height = _size;
        }

        /// <summary>
        /// draw the rectangle
        /// </summary>
        public void AddBlock()
        {
            drawer.AddRectangle(rectangle, _Color);
        }

        /// <summary>
        /// prevent blocks form overlapping
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null|| !(obj is Block arg)) return false; // null ? return false

            if (!rectangle.IsEmpty && !arg.rectangle.IsEmpty && rectangle.IntersectsWith(arg.rectangle))
                return true;
            else
                return false;             
        }

        /// <summary>
        /// not used, just so program is happy
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 1;
        }        
    }
}
