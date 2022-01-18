//Submission Code : 1201_2300_A06
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
using System.Runtime.InteropServices.WindowsRuntime;

namespace chris_ica05// is ica06
{
    class Ball : IComparable
    {
        private static CDrawer drawer;
        private static Random _rdm = new Random();
        private float _radius;
        public float radius { set { _radius = Math.Abs(value); } }
        private Color _Color;
        private PointF ballCenter;

        //gdi drawer render/clear window
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

        //set up drawer
        static Ball()
        {
            drawer = new CDrawer();
            drawer.BBColour = Color.White;
            drawer.ContinuousUpdate = false;
        }

        /// <summary>
        ///  rdm start point,clr and set raduis size in main form
        ///  keep balls in window
        /// </summary>
        /// <param name="rad"></param>
        public Ball(float rad)
        {
            radius = rad;
            _Color = RandColor.GetColor();
            ballCenter.X = (float)(_rdm.NextDouble()*drawer.ScaledWidth-0);
            ballCenter.Y = (float)(_rdm.NextDouble()*drawer.ScaledHeight-0);
            
            if (ballCenter.X < _radius)
                ballCenter.X = _radius;
            if (ballCenter.X > drawer.ScaledWidth- _radius)
                ballCenter.X = drawer.ScaledWidth - _radius;
            if (ballCenter.Y < _radius)
                ballCenter.Y = _radius;
            if (ballCenter.Y > drawer.ScaledHeight- _radius)
                ballCenter.Y = drawer.ScaledHeight - _radius;
        }

        /// <summary>
        /// darw circles
        /// </summary>
        public void ShowBall()
        {
            if(_radius==0)
                drawer.AddCenteredEllipse((int)ballCenter.X, (int)ballCenter.Y, ((int)_radius * 2)+1, ((int)_radius * 2)+1, _Color);
            else
                drawer.AddCenteredEllipse((int)ballCenter.X, (int)ballCenter.Y, (int)_radius*2, (int)_radius*2, _Color);
        }

        /// get distance between 2 circles
        /// Return the true distance to the argument ball from the invoking ball. with float
        public float GetDistance(Ball ball)//Return the true distance to the argument ball from the invoking ball. with float
        {
            return (float)Math.Sqrt(Math.Pow(ballCenter.X - ball.ballCenter.X, 2) + Math.Pow(ballCenter.Y - ball.ballCenter.Y, 2));
        }

        /// equals override for comparing cilcle radi 
        /// to find min distance to get as close as possible
        public override bool Equals(object obj)
        {    
            if (!(obj is Ball ball))
                return false;
            float minDis = this._radius + ball._radius;
            return this.GetDistance(ball)<minDis; // my radius + his radius
        }

        //not used just so no complaining
        public override int GetHashCode()
        {
            return 1;
        }

        //compare/ sort by radius(sorting)
        public int CompareTo(object obj)
        {
            if (!(obj is Ball arg))
                throw new ArgumentException("not a valid ball,null");
            return -1*(int)(this._radius - (arg._radius));//reverse?
        }

        //compare circles by distance(from orgin)(sorting)
        public static int CompareByDistance(Ball a, Ball b)
        {
            if (a == null && b == null) return 0;
            if (a == null) return -1;
            if (b == null) return 1;
            return -1*(int)(Math.Sqrt(Math.Pow(a.ballCenter.X, 2) + Math.Pow(a.ballCenter.Y, 2)) - Math.Sqrt(Math.Pow(b.ballCenter.X, 2) + Math.Pow(b.ballCenter.Y, 2)));
        }

        //compare by color(sorting)
        public static int CompareByColor(Ball a, Ball b)
        { 
            if (a == null && b == null) return 0;
            if (a == null) return -1;
            if (b == null) return 1;

            //sort by color
            if (-1*(a._Color.ToArgb().CompareTo(b._Color.ToArgb()))!=0)
                return -1 * a._Color.ToArgb().CompareTo(b._Color.ToArgb());
            if (-1 * (a._Color.ToArgb().CompareTo(b._Color.ToArgb())) == 0)
                return (int)(a._radius.CompareTo(b._radius)); 
            return 0;
        }
    }
}
