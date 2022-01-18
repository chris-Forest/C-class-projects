//Submission Code : 1201_2300_A17
// chris forest

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chris_Drawer;
using GDIDrawer;

namespace chris_ica17
{
    public abstract class BaseShape
    {
        public static myPic _canvas { get; set; } // Change to your PicDrawer
        public static Random _rnd { get; private set; }
        private Point _pt { get; set; } // Center of Shape
        public Color _color { get; private set; } // Color of Shape
        private double _dir = 0; // Radians vector of direction
        private double _vel = 5; // Movement velocity

        static BaseShape()
        {
            _rnd = new Random(0);
        }

        public BaseShape(Point pt, Color c)
        {
            _pt = pt;
            _color = c;
            // 0 is right, then counter-clockwise, in radians
            _dir = _rnd.NextDouble() * 2 * Math.PI;
        }

        public Point Move() // NVI - public Move()
        {
            return VirtualMove(); // invokes VirtualMove()
        }

        public void Paint() // NVI - public Paint()
        {
            VirtualPaint(); // invokes VirtualPaint()
        }

        protected virtual Point VirtualMove()
        {
            // Adjust current direction by small random amount
            _dir = _dir + (_rnd.NextDouble() * 0.8 - 0.4);
            // Calculate new X, Y based on direction and velocity
            int iNewX = _pt.X + (int)(_vel * Math.Cos(_dir));
            int iNewY = _pt.Y - (int)(_vel * Math.Sin(_dir));
            // Bounce by adding 90 degrees to direction
            if (iNewX < 0 || iNewX >= _canvas.ScaledWidth)
            {
                _dir += Math.PI / 2;
                iNewX = _pt.X;
            }
            if (iNewY < 0 || iNewY >= _canvas.ScaledHeight)
            {
                _dir += Math.PI / 2;
                iNewY = _pt.Y;
            }
            _pt = new Point(iNewX, iNewY); // Save and return new Point
            return _pt;
        }
        protected abstract void VirtualPaint();
    }


    // nvi interface to get objects to move
    interface IAnimate
    {
        void Animate(CDrawer drawer);
    }

    //nvi interface to see if objects can die
    interface IMortal
    {
        bool step();
    }

    /// <summary>
    /// derived class to make snake like objects
    /// </summary>
    class Snake : BaseShape,IMortal 
    {
        //create a list of points to form a snake
        private LinkedList<Point> _points = new LinkedList<Point>();

        // for length of snake and how long it will last in gdi window
        int _length;
        int lives;

        //set snake length and lives count
        public Snake(Point point,int length):base(point,Color.Red)
        {
            _length = length;
            lives = length * 10;
        }

        //everytime method is called 
        //reduce lives count
        public bool step()
        {
            lives--;

            //if lives count is greater than 0
            if (lives > 0)
                return false;

            //otherwise rt true and keep snake going
            return true;
        }

        protected override Point VirtualMove()
        {
            //add the returned point to the front of our linked list
            _points.AddFirst(base.VirtualMove());

            //If list is longer than our length, remove the last node.
            if (_points.Count > _length)
                _points.RemoveLast();

            //does not matter
            return Point.Empty;
        }

        //join linked list of points together to make a snake
        protected override void VirtualPaint()
        {
            float conter = _length;

            //Add an ellipse at our “first” point of size 3 in red. Iterate through the rest of our linkedlist
            for (LinkedListNode<Point> linkedPoints = _points.First; linkedPoints!=null;linkedPoints=linkedPoints.Next)
            {
                _canvas.AddCenteredEllipse(linkedPoints.Value.X, linkedPoints.Value.Y, 3, 3, Color.Red);
                _canvas.AddCenteredEllipse(linkedPoints.Value.X, linkedPoints.Value.Y, 2, 2, Color.Yellow);

                //connecting the (linkedlist) points with a color whose Alpha is defined by (255 * CountDown / LIstLength )
                if (linkedPoints.Next != null)
                    _canvas.AddLine(linkedPoints.Value.X, linkedPoints.Value.Y, linkedPoints.Next.Value.X, linkedPoints.Next.Value.Y,
                                                                                Color.FromArgb((int)(255*(conter / _length)) ,Color.Red));
            }            
        }
    }

    /// <summary>
    /// derived class to make blob(circles) like objects
    /// </summary>
    class Blob :BaseShape,IAnimate
    {
        private double _rad;
        Point location;
        double animate;

        //set radius size and 
        public Blob(Point point, double radius) : base(point, Color.Blue)
        {
            _rad = radius;
            animate = 0;
        }

        //set angle to which the blob animates(oscillates)
        public void Animate(CDrawer drawer)
        {
            //increment the animation angle by 1/8 PI.
            animate += Math.PI / 8;
        }

        //set a start point for the blob to start moving from
        protected override Point VirtualMove()
        {
            location=base.VirtualMove();
            return location;
        }

        //add a circle that oscillates based on a
        protected override void VirtualPaint()
        {
            _rad = _rad + (Math.Cos(animate)/2);
            //_rad = _rad + (Math.Cos(animate) * _rad / 2);
            
            _canvas.AddCenteredEllipse(location, (int)_rad, (int)_rad, Color.Blue);
            _canvas.AddCenteredEllipse(location, 2, 2, Color.Yellow);
        }
    }
}
