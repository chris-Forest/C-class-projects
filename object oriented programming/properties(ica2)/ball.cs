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
//Submission Code : 1201_2300_A02
//Chris Forest
namespace Chris_ica02
{
    class ball
    {
        private static Random _rdm = new Random();
        private Point _location;
        // for center of ball, get only property
        public Point Center { get { return _location; } }
        private int _x,_y;
        public int XVel { set { _x=value; } }

        //force y velocity between -10 and 10
        public int YVel 
        {
            set
            {
                if (value < -10)
                    value = -10;
                if (value > 10)
                    value = 10;
                _y=value; 
            } 
        }

        private Color _ballColor;
        public int opacity { private get; set; }
        public readonly int ballRadius;
        
        public ball(Point center)
        {
            _location = center;
            ballRadius = 40;
            opacity = 128;
            _ballColor = RandColor.GetColor();
            XVel = _rdm.Next(-10, 11);
            YVel = _rdm.Next(-10, 11);
        }

        //get the ball(s) to move
        public void MoveBall(CDrawer cDrawer)
        {
            _location.X = _location.X + _x;
            _location.Y = _location.Y + _y;
            if ((_location.X < ballRadius) || (_location.X > cDrawer.ScaledWidth-ballRadius))
                _x = -_x;
            if ((_location.Y < ballRadius) || (_location.Y > cDrawer.ScaledHeight-ballRadius))
                _y = -_y;
        }

        //display the ball(s)
        public void ShowBall(CDrawer cDrawer)
        {
            cDrawer.AddCenteredEllipse(Center, ballRadius*2, 2*ballRadius, Color.FromArgb(opacity,_ballColor));
            cDrawer.Render();
        }

        //update form title with string ith current last ball posistion or all balls
        public override string ToString()
        {
            //this.Text = ctr.X.ToString()+ctr.Y.ToString()+ "-Vel:"+XtrackBar.Value.ToString()+", "+YtrackBar.Value.ToString()+" ,opacity:"+OpacityTrackBar.Value.ToString();
            return "[{"+_location.ToString()+"}]" + " - vel: "+_x.ToString()+", " + _y.ToString()+" opacity : " + opacity.ToString();
        }
    }
}
