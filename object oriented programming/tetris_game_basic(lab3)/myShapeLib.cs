//Submission Code : 1201_2300_L03
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

namespace chris_lab3
{
    class block
    {
        private static CDrawer _drawer = null;
        public static CDrawer drawer { get { return _drawer; } set { _drawer?.Clear(); _drawer = value; } }
        public static Random _rdm { get; private set; }
        private Point _bLocal;
        public Point bLocal { get { return _bLocal; } }//manual get only property for this member.
        private Color myColor;

        //accepts point representing the parent’s origin home
        //Point representing this Block’s offset and a color
        public block(Point home, Point bOffset, Color bColor)
        {
            //set og location based on parent point
            //apply offset spefic to this block, set color

            _bLocal = home;
            _bLocal.Offset(bOffset);
            myColor = bColor;            
        }

        //copy ctor
        public block(block block)
        {
            _bLocal = block._bLocal;
            myColor = block.myColor;
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is block arg))
                return false;
            return _bLocal== arg._bLocal;
        }
        
        public override int GetHashCode()
        {
            return 1;
        }

        //Apply the offset to your location.
        public void move(Point offsetDirect)
        {
            _bLocal.Offset(offsetDirect);
        }

        //
        public void ShowBlock()
        {
            _drawer.AddCenteredRectangle(_bLocal, 1, 1, myColor);
        }

        //
        public void ShowBlock(CDrawer nextB)
        {
            nextB.AddCenteredRectangle(_bLocal, 1, 1, myColor);
        }

        public void rotate(Point shapeOG)
        {
            int blockXPoint;

            //The process is to negate the offset
            //moving the block back around the true origin(0,0)
            //tranlate to(-x,-y) before we can rotate
            _bLocal.X += -shapeOG.X;
            _bLocal.Y += -shapeOG.Y;

            //then apply the Rotation
            blockXPoint = _bLocal.X;
            _bLocal.X = _bLocal.Y;
            _bLocal.Y = -blockXPoint;

            //bring back to orginal point
            _bLocal.X += shapeOG.X;
            _bLocal.Y += shapeOG.Y;
        }

        //3 predicates
        //shift left true if not out of bounds to the left
        public static bool CantShiftLeft(block block)//TODO keep moving when hit wall
        {
            //if (!(block is block arg)) return false;
            return block._bLocal.X <0;
        }

        //shift right true if not out of bounds to the roght
        public static bool CantShiftRight(block block)//TODO keep moving when hit wall
        {
            //if (!(block is block arg)) return false;
            return block._bLocal.X > drawer.ScaledWidth-1;
        }

        //fall: true if not out of bounds at the bottom
        public static bool cantfall(block block)
        {
            //if (!(block is block arg)) return false;
            return block._bLocal.Y > drawer.ScaledHeight - 1;//|| block._bLocal.X > drawer.ScaledWidth || block._bLocal.X > 0;
        }
    }

    class shape
    {
        static Random _rdm = new Random();
        readonly Point downOffdet = new Point(0, 1);
        readonly Point leftOffdet=new Point(-1,0);
        readonly Point rightOffdet=new Point(1,0);
        
        public static CDrawer makeShape { get; set; }//?

        public enum sType { square,line,lBlock,Tblock};
        public sType sahpeType { get; private set; }

        public bool isFalling { get; set; }

        private Point _sLocal=new Point(0,0);
        public Point sLocal { get { return _sLocal; } }//manual get only property for this member.
        public List<block> blocks = new List<block>();
        Color myColor;

        //predicate rt true if shpae is falling
        public static bool Falling(shape shape)
        {
            if (!(shape is shape arg)) return false;
            return shape.isFalling;
        }

        //
        public shape(Point bLocal)
        {           
            isFalling = true;
            myColor = RandColor.GetColor();            
            _sLocal = bLocal;

            //assign rdm enum type 
            sahpeType = (sType)_rdm.Next(0,4);

            //origin
            blocks.Add(new block(bLocal, new Point(0, 0), myColor));
            //based on type create and add blocks
            switch (sahpeType)
            {
                case sType.square:
                    //add blocks to make shape                    
                    blocks.Add(new block(bLocal, leftOffdet, myColor));
                    blocks.Add(new block(bLocal, downOffdet, myColor));
                    blocks.Add(new block(bLocal, new Point(-1,1), myColor));
                    break;
                case sType.line:
                    // add shape
                    blocks.Add(new block(bLocal, downOffdet, myColor));
                    blocks.Add(new block(bLocal, new Point(0, 2), myColor));
                    blocks.Add(new block(bLocal, new Point(0, 3), myColor));
                    break;
                case sType.lBlock:
                    // add shape
                    blocks.Add(new block(bLocal, downOffdet, myColor));
                    blocks.Add(new block(bLocal, new Point(0, 2), myColor));
                    blocks.Add(new block(bLocal, rightOffdet, myColor));
                    break;
                case sType.Tblock:
                    blocks.Add(new block(bLocal, leftOffdet, myColor));
                    blocks.Add(new block(bLocal, downOffdet, myColor));
                    blocks.Add(new block(bLocal, rightOffdet, myColor));
                    break;
                default:
                    //error here
                    break;
            }
        }

        //copy ctor args of shape and point
        //Initialize all member fields to the Shape argument
        public shape(Point bOffset,shape spe)
        {
            //initalize all member fields to shape arg
            isFalling = spe.isFalling;
            _sLocal = spe._sLocal;
            sahpeType = spe.sahpeType;
            spe.blocks.ForEach(mem=>blocks.Add(new block(mem)));
            //invoke Move() with the offset to shift the Shape to the desired location
            move(bOffset);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is shape arg))//shape
                return false;

            //rt true if there is an overlap
            return blocks.Intersect(arg.blocks).Count() > 0;
        }

        public override int GetHashCode()
        {
            return 1;
        }

        //move method
        public void move(Point offsetDirect)
        {
            foreach (block item in blocks)
            {
                item.move(offsetDirect);
            }
        }

        //show shape method
        public void ShowShape()
        {
            foreach (block item in blocks)
            {
                item.ShowBlock();
            }
        }

        public void Rotate()
        {
            blocks.ForEach(b => b.rotate(blocks[0].bLocal));
        }

        //drop method
        public void Drop(List<block> sBlocks)//the floor
        {
            //if not fall rt
            if (!isFalling)
                return;

            shape colision = new shape(downOffdet, this);

            //if can't fall set falling to fasle and add to list
            if (colision.blocks.Any(block.cantfall))
            {
                isFalling = false;
                blocks.ForEach(blk => sBlocks.Add(blk));//TODO chage dis to foreach of blocks normal way if i choose to
            }
            
            if (colision.blocks.Intersect(sBlocks).Count()>0) //fix with not origin
            {
                isFalling = false;
                //add shapes toblocks floor
                blocks.ForEach(blk => sBlocks.Add(blk));
            }
            else//if no overlap move down
            {
                move(downOffdet);
            }           
        }

        //shift left merthod
        public void shiftLeft(List<block> sBlocks)//the floor
        {
            if (!isFalling)
                return;

            shape colision = new shape(leftOffdet, this);

            if (colision.blocks.Exists(block.CantShiftLeft) || colision.blocks.Exists(block.CantShiftRight))
            {
                Drop(sBlocks);
                return;
            }
            
            if (colision.blocks.Intersect(sBlocks).Count() > 0)
            {
                //isFalling = false;
                //add shapes toblocks floor
                //blocks.ForEach(blk => sBlocks.Add(blk));
                Drop(sBlocks);
                return;
            }
            move(leftOffdet);

            //if can't fall or go left  set falling to fasle and add to list
            //if (colision.blocks.Any(block.CantShiftLeft))
            //{
            //    isFalling = true;
            //    move(leftOffdet);//was right
            //}

            //if (colision.blocks.Intersect(sBlocks).Count() > 0)
            //{
            //    isFalling = false;
            //    //add shapes toblocks floor
            //    blocks.ForEach(blk => sBlocks.Add(blk));
            //}
            ////not need this?
            //else
            //{
            //    move(leftOffdet);
            //}
        }

        //shift right method 
        public void shiftRight(List<block> sBlocks)//the floor
        {
            if (!isFalling)
                return;

            shape colision = new shape(rightOffdet, this);

            if (colision.blocks.Exists(block.CantShiftLeft) || colision.blocks.Exists(block.CantShiftRight))
            {
                Drop(sBlocks);
                return;
            }

            if (colision.blocks.Intersect(sBlocks).Count() > 0)
            {
                //isFalling = false;
                //add shapes toblocks floor
                //blocks.ForEach(blk => sBlocks.Add(blk));
                Drop(sBlocks);
                return;
            }
            move(rightOffdet);

            //if can't fall or go right set falling to fasle and add to list
            //if (colision.blocks.Any(block.CantShiftRight))
            //{
            //    isFalling = false;
            //    move(leftOffdet);
            //}

            //if (colision.blocks.Intersect(sBlocks).Count() > 0)
            //{
            //    isFalling = false;
            //    //add shapes toblocks floor
            //    blocks.ForEach(blk => sBlocks.Add(blk));
            //}
            //else
            //{
            //    move(rightOffdet);
            //}
        }       
    }   
}
