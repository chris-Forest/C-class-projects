// Submission Code : 1201_2300_A14
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
        public override bool Equals(object obj)
        {
            if (!(obj is Ball arg))
                return false;
            float dis = (float)Math.Sqrt(Math.Pow(ballCenter.X - arg.ballCenter.X, 2) + Math.Pow(ballCenter.Y - arg.ballCenter.Y, 2));
            float mindis = this.radius + arg.radius;
            //dis < this.radius * 2
            return dis < mindis;//or <mindis
            //return radius == arg.radius;// radius*2? 
        }
        public override int GetHashCode()
        {
            return 1;
        }
        public void Move(CDrawer cDrawer)
        {
            ballCenter.X += xVel;
            ballCenter.Y += yVel;

            if(ballCenter.X-radius<0)
            {
                xVel = -xVel;
                ballCenter.X = 0 + radius;
            }
            if (ballCenter.X + radius > cDrawer.ScaledWidth)
            {
                xVel = -xVel;
                ballCenter.X = cDrawer.ScaledWidth- radius;
            }
            if (ballCenter.Y - radius < 0)
            {
                yVel = -yVel;
                ballCenter.Y = 0 + radius;
            }
            if (ballCenter.Y +radius> cDrawer.ScaledHeight)
            {
                yVel = -yVel;
                ballCenter.Y = cDrawer.ScaledHeight- radius;
            }
        }
        
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
