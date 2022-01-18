//Submission Code : 1201_2300_A05
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
using static System.Diagnostics.Trace;
using GDIDrawer;

namespace chris_ica05
{
    class Ball : IComparable
    {
        private static CDrawer drawer;
        private static Random _rdm = new Random();
        private float _radius;
        public float radius { set { _radius = Math.Abs(value); } }//keep positive
        private Color _Color;
        private PointF ballCenter;

        //control drawing of shapes
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

        //used for sorting
        public enum ESortType
        { eRadius, eDistance, eColor }
        public static ESortType sortType { get; set;} 

        //static ctor
        static Ball()
        {
            drawer = new CDrawer();
            drawer.BBColour = Color.White;
            drawer.ContinuousUpdate = false;
        }

        //instance ctor
        //rdm start point,clr and set raduis size in main form
        //keep balls in window
        public Ball(float rad)
        {
            radius = rad;
            _Color = RandColor.GetColor();
            ballCenter.X = (float)(_rdm.NextDouble()*drawer.ScaledWidth);
            ballCenter.Y = (float)(_rdm.NextDouble()*drawer.ScaledHeight);
        
            if (ballCenter.X < _radius)
                ballCenter.X = _radius;

            if (ballCenter.X > drawer.ScaledWidth - _radius)
                ballCenter.X = drawer.ScaledWidth - _radius;

            if (ballCenter.Y < _radius)
                ballCenter.Y = _radius;

            if (ballCenter.Y > drawer.ScaledHeight - _radius)
                ballCenter.Y = drawer.ScaledHeight - _radius;
        }

        /// <summary>
        /// display circles
        /// </summary>
        public void ShowBall()
        {
            if (_radius == 0)
                drawer.AddCenteredEllipse((int)ballCenter.X, (int)ballCenter.Y, ((int)_radius * 2) + 1, ((int)_radius * 2) + 1, _Color);
            else
                drawer.AddCenteredEllipse((int)ballCenter.X, (int)ballCenter.Y, (int)_radius * 2, (int)_radius * 2, _Color);
        }

        /// <summary>
        /// get distance between 2 circles
        /// Return the true distance to the argument ball from the invoking ball. with float
        /// </summary>
        /// <param name="ball"></param>
        /// <returns></returns>
        public float GetDistance(Ball ball)
        {
            return (float)Math.Sqrt(Math.Pow(ballCenter.X - ball.ballCenter.X, 2) + Math.Pow(ballCenter.Y - ball.ballCenter.Y, 2));
        }

        /// <summary>
        /// equals override for comparing cilcle radi 
        /// to find min distance to get as close as possible
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {    
            if (!(obj is Ball ball))
                return false;

            // my radius + his radius
            float minDis = this._radius + ball._radius;
            return this.GetDistance(ball)<minDis;
        }

        //not used just so no complaining
        public override int GetHashCode()
        {
            return 1;
        }

        /// <summary>
        /// //not used just so no complaining
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (!(obj is Ball arg))
                throw new ArgumentException("not a valid ball,null");

            //sort by color
            if (sortType == ESortType.eColor)
                return this._Color.ToArgb().CompareTo(arg._Color.ToArgb());            

            //sort by radius
            if (sortType == ESortType.eRadius)
                return (int)(this._radius - (arg._radius));

            //sort by distance from orign
            if (sortType == ESortType.eDistance)
                //make ball set center //GetDistance(orign)
                return (int)(Math.Sqrt(Math.Pow(this.ballCenter.X, 2) + Math.Pow(this.ballCenter.Y, 2)) - Math.Sqrt(Math.Pow(arg.ballCenter.X, 2) + Math.Pow(arg.ballCenter.Y, 2)));

            return 0;
        }
    }
}
