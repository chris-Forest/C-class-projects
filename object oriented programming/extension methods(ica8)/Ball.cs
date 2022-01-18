// Submission Code : 1201_2300_A08
//Chris Forest

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace chris_ica8
{
    class Ball
    {
        private static Random _rdm=new Random();
        private PointF ballCenter;
        private float xVel, yVel;
        private int radius;
        public Color _BallColor { get; set; }

        public Ball(PointF point,Color color)
        {
            ballCenter = point;
            _BallColor = color;

            //velocity
            xVel = -5 + (5 - (-5)) * (float)_rdm.NextDouble();
            yVel = -5 + (5 - (-5)) * (float)_rdm.NextDouble();
            radius = _rdm.Next(20, 51);
        }

        //override method for detection min collsion distance between balls 
        public override bool Equals(object obj)
        {
            if (!(obj is Ball arg))
                return false;
            float dis = (float)Math.Sqrt(Math.Pow(ballCenter.X - arg.ballCenter.X, 2) + Math.Pow(ballCenter.Y - arg.ballCenter.Y, 2));
            float mindis = this.radius + arg.radius;
            return dis < mindis;
        }

        public override int GetHashCode()
        {
            return 1;
        }

        /// <summary>
        /// get balls to move and bounce around in gdi windows
        /// </summary>
        /// <param name="cDrawer"></param>
        public void Move(CDrawer cDrawer)
        {
            ballCenter.X += xVel;
            ballCenter.Y += yVel;

            //bounce off left wall
            if(ballCenter.X-radius<0)
            {
                xVel = -xVel;
                ballCenter.X = radius;
            }

            //bounce off right wall
            if (ballCenter.X + radius > cDrawer.ScaledWidth)
            {
                xVel = -xVel;
                ballCenter.X = cDrawer.ScaledWidth- radius;
            }

            //bounce off top wall
            if (ballCenter.Y - radius < 0)
            {
                yVel = -yVel;
                ballCenter.Y = radius;
            }

            //bounce off bottom wall
            if (ballCenter.Y +radius> cDrawer.ScaledHeight)
            {
                yVel = -yVel;
                ballCenter.Y = cDrawer.ScaledHeight- radius;
            }
        }
        
        //show balls and text in gdi window
        public void Show(CDrawer cDrawer,int add)
        {
            Color comp = Color.FromArgb(_BallColor.ToArgb() ^ 0x00fffffff);
            add++;
            cDrawer.Render();
            cDrawer.AddCenteredEllipse((int)ballCenter.X, (int)ballCenter.Y, radius * 2, radius * 2, _BallColor);
            cDrawer.AddText($"{add}", 14, new Rectangle(new Point((int)ballCenter.X, (int)ballCenter.Y), new Size(0,0)), comp);
        }
    }
}
