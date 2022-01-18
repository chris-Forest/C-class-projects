//inheritance
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

namespace chris_ica13
{

    /// <summary>
    /// derived my random class from base Random
    /// </summary>
    class myRandom : Random
    {
        public int maxSize;

        public myRandom(int max) : base(max)
        {
            maxSize = max;
        }

        /// <summary>
        /// returns a rect and has CDrawer arg
        /// sets up rectangles to be drwan at random points
        /// </summary>
        /// <param name="drawer"></param>
        /// <returns></returns>
        public Rectangle NextDrawerRect(CDrawer drawer)
        {
            //If the CDrawer is not valid, throw an ArgumentException
            if (drawer == null)
                throw new ArgumentException("drawer noit valid");
             
            //if the Maximum size exceeds the CDrawer bounds use cdrawer coundaries
            if (maxSize < 10)
                maxSize = 10;
            if (maxSize > drawer.ScaledHeight)
                maxSize = drawer.ScaledHeight;
            if (maxSize > drawer.ScaledWidth)
                maxSize = drawer.ScaledWidth;

            //rect sized between 10 and the Maximum size( new member field ) of the CDrawer and with[X, Y] coordinates 
            //rect randomized somewhere so the Rectangle is always fully visible  
            Size size = new Size(Next(10,maxSize),Next(10,maxSize));
            Point point = new Point();
            point.Y = Next(drawer.ScaledHeight - size.Height);
            point.X = Next(drawer.ScaledWidth - size.Width);

            //create a new Rectangle object                       
            Rectangle rect = new Rectangle(point,size);
            return rect;
        }
    }

    /// <summary>
    /// derived cdrawer class inherited from base cdrawer
    /// that will add 100 rectamngles at rondom point within window size
    /// </summary>
    class myDrawer : CDrawer
    {
        myRandom random = null;
        public myDrawer(int width= 800,int height= 400) : base(width, height)
        {
            //initialize your derived Random class to 1/5 of the current scaled width
            random = new myRandom(ScaledWidth / 5);
            
            BBColour = Color.White;
            //Utilizing your derived Random class, create 100 Rectangles
            for (int i = 0; i < 100; i++)
            {
                AddRectangle(random.NextDrawerRect(this), RandColor.GetKnownColor());
            }
        }
    }

    /// <summary>
    /// this class will place an empty cdrawer at specfic point in relation to the form window
    /// </summary>
    class placement : CDrawer
    {
        //enum for each specfic position being made and used
        public enum EPosition { eRight, eBelow, eBelowRight, eNone };        

        /// <summary>
        /// set a cdrawer window with made enum and where the set form app postion is
        /// </summary>
        /// <param name="position"></param>
        /// <param name="form"></param>
        void SetPosition(EPosition position,Form form)
        {
            Point local = form.Location;//pos of form

            switch (position)
            {
                case EPosition.eRight:
                    local.X += form.Width;
                    break;
                case EPosition.eBelow:
                    local.Y += form.Height;
                    break;
                case EPosition.eBelowRight:
                    local.X += form.Width;
                    local.Y += form.Height;
                    break;
                //this is would be the default postion (is same as right of from app postion)
                case EPosition.eNone:
                    local.X += form.Width;
                    break;
                default:
                    break;
            }
            Position = local;
        }

        /// <summary>
        /// alternate method of set position method that uses a cdrawer instead of form app
        /// </summary>
        /// <param name="position"></param>
        /// <param name="drawer"></param>
        void SetPosition(EPosition position,CDrawer drawer)
        {
            Point local = drawer.Position;//pos of form

            switch (position)
            {
                case EPosition.eRight:
                    local.X += drawer.ScaledWidth;
                    break;
                case EPosition.eBelow:
                    local.Y += drawer.ScaledHeight;
                    break;
                case EPosition.eBelowRight:
                    local.X += drawer.ScaledWidth;
                    local.Y += drawer.ScaledHeight;
                    break;
                case EPosition.eNone:
                    local.X += drawer.ScaledWidth;
                    break;
                default:
                    break;
            }
            Position = local;
        }

        /// <summary>
        /// ctor that sets up gdi window placment based on enum postion 
        /// with defaults set
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="form"></param>
        /// <param name="position"></param>
        public placement(int height=600, int width=300, Form form=null, EPosition position= EPosition.eNone) : base(width,height,false)
        {
            BBColour = Color.Wheat;
            Render();
            if (form is null)
                return;
            SetPosition(position, form);
            form.Activate();
        }
    }

    /// <summary>
    /// class derived from placment class to make a gdi window but wiht a picture background
    /// </summary>
    class myPic : placement
    {
        //loaded picture to be used as background image
        static Bitmap p = Properties.Resources.home;

       /// <summary>
       /// ctor to get the form we are using and get a picture height and width
       /// </summary>
       /// <param name="form"></param>
       public myPic(Form form=null) : base(p.Height, p.Width,form)
       {
            Color color;
            int greyScale;

            // loops to analize picture bits to display it as a background
            for (int y = 0; y < p.Height; y++)
            {
                for (int x = 0; x < p.Width; x++)
                {
                    //take pictures current color and apply a grey scale to it
                    //re-apply grey scale to picture and display it
                    color = p.GetPixel(x, y);
                    greyScale = (int)((color.R * 0.3) + (color.G * 0.59) + (color.B * 0.11));
                    color = Color.FromArgb(color.A, greyScale, greyScale, greyScale);
                    SetBBPixel(x, y, color);
                    Render();
                }
            }
       }
    }
}
