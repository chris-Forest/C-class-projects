//Submission Code : 1201_2300_A07
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

namespace Chris_ica7
{
    class Bar : IComparable
    {
        public static CDrawer drawer { get; private set; }
        public static int Height { get; private set; }
        private static Random _rdm = new Random(1);
        public int width { get; private set; }
        public bool Highlight { get; set; }
        private Color _Color;

        static Bar()
        {
            Height = 20;
            drawer = new CDrawer();
            drawer.BBColour = Color.White;
            drawer.ContinuousUpdate = false;
        }

        public Bar()
        {
            // rdm widths 10-190 in increments of 10
            width = _rdm.Next(1, 20) * 10;
            Highlight = false;
            _Color = Color.FromArgb(_rdm.Next(3, 8) * 32 - 1, _rdm.Next(3, 8) * 32, _rdm.Next(3, 8) * 32);
        }

        //return the width and color if they are the same for both Bars
        public override bool Equals(object obj)
        {
            if (!(obj is Bar arg))
                return false;
            return (width == arg.width && _Color == arg._Color);
        }

        public override int GetHashCode()
        {
            return 1;
        }

        /// <summary>
        /// display the rectangles 
        /// and differentiate weither ine is highlighted or not
        /// </summary>
        /// <param name="pointer"></param>
        public void ShowBar(Point pointer)
        {
            if (Highlight == true)
                drawer.AddRectangle(pointer.X,pointer.Y, width, Height, _Color, 2, Color.Yellow);
            else
                drawer.AddRectangle(pointer.X, pointer.Y, width, Height, _Color, 1, Color.Black);
        }

        /// <summary>
        /// compare by bar colors
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (!(obj is Bar arg))
                throw new ArgumentException("Bar : IComparable color");
            return _Color.ToArgb().CompareTo(arg._Color.ToArgb());
        }

        /// <summary>
        /// compare by bar width
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CompareWidth(Bar a,Bar b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null )
                return -1;
            else if ( b is null)
                return 1;
            return a.width.CompareTo(b.width);
        }

        /// <summary>
        /// compare by bar color
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CompareWidthClr(Bar a, Bar b)
        {
            if (a is null && b is null)
                return 0;
            else if (a is null)
                return -1;
            else if (b is null)
                return 1;

            //if width are the same, sort by color
            if (a.width == b.width)
                return a._Color.ToArgb().CompareTo(b._Color.ToArgb());
            //sort by width
            else
                return a.width.CompareTo(b.width);
        }

        // method to remove bars over a set brightness
        public static bool Bright(Bar bars)
        {
            return bars._Color.GetBrightness() > .6;
        }
    }
}
