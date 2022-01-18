//Submission Code : 1201_2300_A15
//chris forest

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
using Chris_Drawer;

namespace chris_ica15
{
    /// <summary>
    /// 
    /// </summary>
    class Block
    {
        protected RectangleF localSize;
        protected static Random _rdm = new Random();
        public bool outside { get; private set; }

        /// <summary>
        /// set local varaible rectF to pointF 
        /// </summary>
        /// <param name="pointF"></param>
        public Block(PointF pointF)
        {
            this.localSize.X = pointF.X;
            this.localSize.Y = pointF.Y;
        }

        /// <summary>
        /// override equals method to check of block will intersect with each other
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Block arg)) return false;
            //if obj is me rt flalse
            //if (ReferenceEquals(this.localSize.Width, arg.localSize.Width)) return false; or below
            if (ReferenceEquals(this, arg)) return false;
            return localSize.IntersectsWith(arg.localSize);
        }

        /// <summary>
        /// just for a happy program
        /// is here because we are using override equals
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 1;
        }

        /// <summary>
        /// returns nothing
        /// derived classes will do all the work and will require the List<> of Block argument.
        /// </summary>
        /// <param name="blocks"></param>
        public virtual void Move(List<Block> blocks){}

        /// <summary>
        /// display blocks on certian key stroke
        /// set boundaris for gdi window
        /// </summary>
        /// <param name="drawer"></param>
        public virtual void ShowBlock(CDrawer drawer)
        {            
            // Create a Size structure.
            SizeF inflateSize = new SizeF(3, 3);

            //Use one of the RectangleF helper methods to determine if the block center point has exceeded the CDrawer boundaries
            //make rect obj based on cdrwar dimensions//thecn check if out
            //btm of gdi
            if (localSize.IntersectsWith(new RectangleF(0,drawer.ScaledHeight+(localSize.Height/2),drawer.ScaledWidth,10)))
            {
                outside = true;
                return;
            }
            //left border
            if (localSize.IntersectsWith(new RectangleF(0 - (localSize.Width / 2) - 10, 0, 10, drawer.ScaledHeight)))
            {
                outside = true;
                return;
            }
            //right border
            if (localSize.IntersectsWith(new RectangleF(drawer.ScaledWidth + (localSize.Width / 2), 0, 10, drawer.ScaledHeight)))
            {
                outside = true;
                return;
            }
            else
            {
                //draw black rect(copy)
                //then draw real rect on top of it
                RectangleF temp = localSize;
                temp.Inflate(inflateSize);
                drawer.AddRectangle((int)temp.X, (int)temp.Y, (int)temp.Width, (int)temp.Height, Color.Black);//background square                
            } 
        }
    }

    /// <summary>
    /// get the blocks too fall from top of gdi window
    /// </summary>
    class FallingBlock:Block
    {
        const float VEL = 6;

        /// <summary>
        /// set a ctor woth PointF memeber for starting points for blocks
        /// </summary>
        /// <param name="pointF"></param>
        public FallingBlock(PointF pointF):base(pointF)
        {
            localSize.Width = 50;
            localSize.Height = 50;            
        }

        /// <summary>
        /// overide method for colision checking
        /// If Outside, do nothing, otherwise, check for collisions with other Blocks
        /// If no collisions are evident, drop yourself by your velocity
        /// </summary>
        /// <param name="blocks"></param>
        public override void Move(List<Block> blocks)
        {           
            // if hitting border do nothing and keep program running
            if (outside) { return; }

            //otherwise check for collisions with other blocks
            else
            {
                //check for collisiosns with other blocks
                if (blocks.Contains(this))
                    return;
                //add movment to block(s)
                localSize.Y += VEL;
            }
        }

        /// <summary>
        /// overide to add the square then show rectangle
        /// invoke the base method, then add our rectangle in white.
        /// </summary>
        /// <param name="drawer"></param>
        public override void ShowBlock(CDrawer drawer)
        {
            //invoke base method and add rect in white
            base.ShowBlock(drawer);
            drawer.AddRectangle((int)localSize.X, (int)localSize.Y, (int)localSize.Width, (int)localSize.Height, Color.White);
        }
    }

    /// <summary>
    /// claas for a swaying block
    /// derived from base block class
    /// </summary>
    class drunkBlocK :Block
    {
        const float drkVEL = 3;
        private float drift = 0;

        /// <summary>
        /// ctor to set block size
        /// </summary>
        /// <param name="pointF"></param>
        public drunkBlocK(PointF pointF):base(pointF)
        {
            localSize.Width = 30;
            localSize.Height = 60;
        }

        /// <summary>
        /// Invoke the base Move(), and reduce your member Alpha value by your velocity value
        /// While the block may stop moving, the color will continue to fade away.
        /// </summary>
        /// <param name="blocks"></param>
        public override void Move(List<Block> blocks)
        {
            // if hitting border do nothing and keep program running
            if (outside) { return; }

            //otherwise check for collisions with other blocks
            else
            {
                //collision check
                if (blocks.Contains(this))
                {
                    return;
                }

                //add movment to block(s)
                drift = 0;
                drift = drift + _rdm.Next(-1, 2);
                localSize.Y += drkVEL;
                localSize.X += drift;
            }
        }

        /// <summary>
        /// overide to add the square then show rectangle
        /// invoke the base method and add new rectangle 
        /// </summary>
        /// <param name="drawer"></param>
        public override void ShowBlock(CDrawer drawer)
        {
            //invoke base method and add rect in desired color
            base.ShowBlock(drawer);
            drawer.AddRectangle((int)localSize.X, (int)localSize.Y, (int)localSize.Width, (int)localSize.Height, Color.Pink);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class colorBlock:FallingBlock
    {
        const float clrVEL = 3;
        private Color myColor = RandColor.GetColor();

        /// <summary>
        /// set block size
        /// </summary>
        /// <param name="pointF"></param>
        public colorBlock(PointF pointF) : base(pointF)
        {
            localSize.Width = 60;
            localSize.Height = 30;
        }

        /// <summary>
        /// ovveride base move method to add more aspects to method
        /// invoke base move method (for movement)
        /// </summary>
        /// <param name="blocks"></param>
        public override void Move(List<Block> blocks)
        {
            //fo block movment
            base.Move(blocks);
            int fade = myColor.A;

            //color fades to white
            if (fade>0)
            {               
                fade -= (int)clrVEL;
                myColor = Color.FromArgb(fade, myColor.R, myColor.G, myColor.B);
            }
        }

        /// <summary>
        /// overide to add the square then show rectangle
        /// invoke the base method and add new rectangle  
        /// </summary>
        /// <param name="drawer"></param>
        public override void ShowBlock(CDrawer drawer)
        {
            //invoke base method and add rect in my color
            base.ShowBlock(drawer);
            drawer.AddRectangle((int)localSize.X, (int)localSize.Y, (int)localSize.Width, (int)localSize.Height, myColor);
        }
    }
}
