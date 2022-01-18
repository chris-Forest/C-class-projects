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
using System.Runtime.Remoting.Contexts;
//Submission Code : 1201_2300_A02
//Chris Forest
namespace Chris_ica02
{
    public partial class Form1 : Form
    {
        List<ball> _balls = new List<ball>();
        Timer _timer = new Timer();
        public CDrawer _cDrawer;
        Point ctr;        
        public Form1()
        {
            InitializeComponent();
            _cDrawer = new CDrawer();
            _cDrawer.ContinuousUpdate = false;
            OpacityTrackBar.ValueChanged += OpacityTrackBar_ValueChanged;
            XtrackBar.ValueChanged += XtrackBar_ValueChanged;
            YtrackBar.ValueChanged += YtrackBar_ValueChanged;
            _timer.Tick += _timer_Tick;
            _timer.Interval = 20;
            _timer.Enabled = true;
            YtrackBar.Value = _balls.Count;
        }

        /// <summary>
        /// balls will move with this
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            //left click add ball sing point val
            if(_cDrawer.GetLastMouseLeftClick(out ctr))
            {
                _balls.Add(new ball(ctr));
            }

            //right click clear
            //clear collections and render gdi to show no shapes
            if (_cDrawer.GetLastMouseRightClick(out ctr))
            {
                _balls.Clear();
                _cDrawer.Clear();
                _cDrawer.Render();
            }

            //clear and call methods in respective loop
            _cDrawer.Clear();        
            //move balls in collection
            for (int i = 0; i < _balls.Count; i++)
                _balls[i].MoveBall(_cDrawer);            

            //display every ball in lisy collection
            foreach (var item in _balls)            
                item.ShowBall(_cDrawer);
            _cDrawer.Render();

            //ball position in list
            //does for all balls
            for (int i = 0; i < _balls.Count; i++)
            {
                this.Text=_balls[i].ToString();
            }
        }

        //adjust y velocity for one ball or all balls
        private void YtrackBar_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = YtrackBar.Value.ToString();

            //if checked all balls move
            if (AllBalls.Checked)
            {
                for (int i = 0; i < _balls.Count; i++)
                {
                    _balls[i].YVel = YtrackBar.Value;
                }
            }

            //last ball created ball moves
            else
            {
                ball list = _balls.LastOrDefault();
                list.YVel = YtrackBar.Value;
            }
        }

        //adjust x velocity for all balls ore one ball
        private void XtrackBar_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = XtrackBar.Value.ToString();

            //if checked all balls move
            if (AllBalls.Checked)
            {                
                for (int i = 0; i < _balls.Count; i++)
                {
                    _balls[i].XVel = XtrackBar.Value;
                }
            }

            //only last made ball moves
            else
            {
                ball list = _balls.LastOrDefault();
                list.XVel = XtrackBar.Value;
            }
        }

        //adjust color opacicty for all balls or just one ball
        private void OpacityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = OpacityTrackBar.Value.ToString();

            //if checked all balls opacity changes
            if (AllBalls.Checked)
            {
                for (int i = 0; i < _balls.Count; i++)
                {
                    _balls[i].opacity = OpacityTrackBar.Value;
                }
            }

            //only last created ball moves
            else
            {
                ball list = _balls.LastOrDefault();
                list.opacity = OpacityTrackBar.Value;
            }
        }
    }
}
