//Submission Code : 1201_2300_A03
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

namespace Chris_ica03
{
    class Ball
    {
        private static Random _rdm = new Random();
        private static CDrawer _drawer = null;

        //radius property and field
        private static int _radius;
        public static int rad { set { _radius =Math.Abs(value); } }

        private Color _ballColor;//set ball color
        private Point _location; //get ball location

        //velocity properties ans fields
        private int _x, _y;
        public int XVel { set { _x = value; } }
        public int YVel { set { _y = value; } }
        private int _iAlive;// life span of ball

        //property for rendering the balls
        public static bool Loading 
        {
            set 
            {
                if (value)
                    _drawer.Clear();
                else
                    _drawer.Render();
            } 
        }

        //static ctor
        static Ball()
        {
            _drawer = new CDrawer(_rdm.Next(600, 901), _rdm.Next(500, 801), false);
            _radius = _rdm.Next(10, 81);
        }

        //instance ctor
        //get rdm ball color, set rdm postion,and rdm velocity
        public Ball()
        {
            _ballColor = RandColor.GetColor();
            XVel = _rdm.Next(-10, 11);
            YVel = _rdm.Next(-10, 11);
            // initalize location to rdm point    
            _location.X = _rdm.Next(0+_radius, _drawer.ScaledWidth - _radius);
            _location.Y = _rdm.Next(0+_radius, _drawer.ScaledHeight - _radius);
        }

        /// <summary>
        /// display ball(s)
        /// </summary>
        public void ShowBall()
        {
            //crashed when zero//prevnted
            if (_radius == 0)
                _drawer.AddCenteredEllipse(_location.X, _location.Y, _radius*2, _radius*2, Color.FromArgb(_iAlive, _ballColor));
            else
                _drawer.AddCenteredEllipse(_location.X, _location.Y, _radius * 2, _radius * 2, Color.FromArgb(_iAlive, _ballColor));
        }

        /// <summary>
        /// get the balls to move
        /// </summary>
        public void MoveBall()
        {
            _iAlive--;

            //if amount of active balls are less then 1
            // set a new random location,
            // set_iAlive to a random value between 50 and 127
            if (_iAlive < 1)
            {
                _iAlive = _rdm.Next(50, 128);
            }
           
            //balls movement
            _location.X = _location.X + _x;
            _location.Y = _location.Y + _y;

            //keep in drawer window 
            // this for range change to edge of gdi screen
            // Left wall
            if (_location.X < 0)  
            {
                _x = -_x;
                _location.X = 0 + _radius;
            }

            //right
            if (_location.X > _drawer.ScaledWidth)
            { 
                _x = -_x; 
                _location.X = _drawer.ScaledWidth - _radius; 
            }

            //up
            if (_location.Y < 0)
            { 
                _y = -_y; 
                _location.Y = 0 + _radius; 
            }

            //bottom
            if (_location.Y > _drawer.ScaledHeight)
            {
                _y = -_y; 
                _location.Y = _drawer.ScaledHeight - _radius;
            }
        }

        //string override for radius size
        public override string ToString()
        {
            return "size=" + _radius.ToString();
        }
    }
}
