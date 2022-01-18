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

namespace Chris_Drawer
{
    public class myRandom : Random
    {
        public int maxSize;
        public myRandom(int max) : base(max)
        {
            maxSize = max;
        }

        public Rectangle NextDrawerRect(CDrawer drawer) //returns a rect and has CDrawer arg
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
            Size size = new Size(Next(10, maxSize), Next(10, maxSize));
            Point point = new Point();
            point.Y = Next(drawer.ScaledHeight - size.Height);
            point.X = Next(drawer.ScaledWidth - size.Width);

            //create a new Rectangle object                       
            Rectangle rect = new Rectangle(point, size);
            return rect;
        }
    }

    public class myDrawer : CDrawer
    {
        myRandom random = null;
        List<Rectangle> rect = new List<Rectangle>();// collection for rectangles? 

        public myDrawer(int width = 600, int height = 300) : base(width, height)
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
            Render();//needed?
        }

        new public void Render()
        {
            AddText($"{ScaledWidth}x{ScaledHeight}: {GetType().Name}", 15, 1, 5, 300, 50, Color.Red);
            base.Render();
        }

        new public void Clear()
        {
            base.Clear();
            //iterate through your Rectangle collection adding the rectangles
            //this
            foreach (Rectangle item in rect)
            {
                //Color.Transparent;                
                AddRectangle(item, Color.Transparent, 2, Color.Blue);
            }
        }
    }

    #region
    public class placement : CDrawer
    {
        public enum EPosition { eRight, eBelow, eBelowRight, eNone };

        public void SetPosition(EPosition position, Form form)
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
                case EPosition.eNone:
                    break;
                default:
                    break;
            }
            Position = local;
        }

        void SetPosition(EPosition position, CDrawer drawer)//ing or add to fork later
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
                    break;
                default:
                    break;
            }
            Position = local;
        }

        public placement(int height = 600, int width = 300, Form form = null, EPosition position = placement.EPosition.eNone) : base(width, height, false)
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

    public class myPic : placement
    {
        //for ica14
        public myPic(Image image = null, Form form = null) : base(image.Height, image.Width, form)
        {
            Bitmap p = new Bitmap(image);
            Color color;
            int greyScale;
            for (int y = 0; y < p.Height; y++)
            {
                for (int x = 0; x < p.Width; x++)
                {
                    color = p.GetPixel(x, y);
                    greyScale = (int)((color.R * 0.3) + (color.G * 0.59) + (color.B * 0.11));
                    color = Color.FromArgb(color.A, greyScale, greyScale, greyScale);
                    SetBBPixel(x, y, color);

                }
            }
            Render();
        }

        new public void Render()
        {
            AddText($"{ScaledWidth}x{ScaledHeight}: {GetType().Name}", 15, 1, 5, 300, 50, Color.Red);
            base.Render();
        }
    }
}
