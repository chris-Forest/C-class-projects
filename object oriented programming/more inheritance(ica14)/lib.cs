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
        List<Rectangle> rect = new List<Rectangle>();// collection for rectangles? 

        public myDrawer(int width= 600,int height= 300) : base(width, height)
        {
            //initialize your derived Random class to 1/5 of the current scaled width
            random = new myRandom(ScaledWidth / 5);
            BBColour = Color.White;

            //populateing rect list collection
            for (int i = 0; i < 100; i++)
            {
                rect.Add(random.NextDrawerRect(this));
            }
            Clear();
            Render();
        }

        /// <summary>
        /// manual render method that invokes the base render from cdrawer 
        /// adds text to show what type of window it is
        /// </summary>
        new public void Render()
        {
            AddText($"{ScaledWidth}x{ScaledHeight}: {GetType().Name}", 15, 1, 5, 300, 50, Color.Red);
            base.Render();
        }

        /// <summary>
        /// manual clear method that invokes the base clear from cdrawer 
        /// adds rectangles from collection after a clear of gdi window
        /// </summary>
        new public void Clear()
        {
            base.Clear();
            //iterate through your Rectangle collection adding the rectangles
            foreach (Rectangle item in rect)
            {              
                AddRectangle(item, Color.Transparent, 2, Color.Blue);
            }
        }
    }

    #region
    /// <summary>
    /// this class will place an empty cdrawer at specfic point in relation to the form window
    /// </summary>
    class placement : CDrawer
    {
        public enum EPosition { eRight, eBelow, eBelowRight, eNone };

        /// <summary>
        /// set a cdrawer window with made enum and where the set form app postion is
        /// </summary>
        /// <param name="position"></param>
        /// <param name="form"></param>
        public void SetPosition(EPosition position,Form form)
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
        void SetPosition(EPosition position,CDrawer drawer)//ing or add to fork later
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
        public placement(int height=600, int width=300, Form form=null, EPosition position=placement.EPosition.eNone) : base(width,height,false)
        {
            //stuff here
            BBColour = Color.Wheat;
            Render();
            if (form is null)
                return;
            SetPosition(position, form);
            form.Activate();
        }
    }
    #endregion

    /// <summary>
    /// class derived from placment class to make a gdi window but with a picture background
    /// </summary>
    class myPic : placement
    {
        /// <summary>
        /// ctor to get the form we are using and get a picture height and width
        /// </summary>
        /// <param name="form"></param>
        public myPic(Image image=null, Form form = null) :base(image.Height,image.Width,form)
        {
            //take a picture to be used as background image
            Bitmap p = new Bitmap(image);
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
                }
            }
            Render();
        }

        /// <summary>
        /// manual render method that invokes the base render
        /// adds text to show what type of window it is
        /// </summary>
        new public void Render()
        {
            AddText($"{ScaledWidth}x{ScaledHeight}: {GetType().Name}", 15, 1, 5, 300, 50, Color.Red);
            base.Render();
        }
    }
}
