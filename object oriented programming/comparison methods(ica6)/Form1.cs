//Submission Code : 1201_2300_A06
//Chris Forest
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Diagnostics.Trace;
using GDIDrawer;

namespace chris_ica05// is ica06
{
    public partial class ica6 : Form
    {
        private List<Ball> _balls = new List<Ball>();
        float _rad = -50;//user Radius value
        public ica6()
        {            
            InitializeComponent();
            ADDbutton.Click += AddBalls;
            MouseWheel += scrool_MouseWheel;
            KeyDown += Minus_KeyDown;
            KeyPreview = true;
            //universal btn check
            RadiusRadioButton.Click += UniversalRadioButton_Click;
            DisRadioButton.Click += UniversalRadioButton_Click;
            ClrRadioButton.Click += UniversalRadioButton_Click;            
        }

        private void AddBalls(object sender, EventArgs e)
        {
            float counter_balls = 0;
            float count_discards = 0;

            while (counter_balls < 25 && count_discards < 1000)// if less than 25 add blocks and les than 1000 discards
            {
                Ball bally = new Ball(_rad);
                if(_balls.IndexOf(bally)<0)
                {
                    _balls.Add(bally);
                    ++counter_balls;
                }
                else
                {
                    ++count_discards;
                    progressBar1.Value = (int)count_discards;
                }
                Ball.Loading = true;
                for (int i = 0; i < _balls.Count; i++)
                {
                    _balls[i].ShowBall();
                }
                Ball.Loading = false;                
            }
            this.Text = "loaded " + counter_balls.ToString() + " distinct blocks with " + count_discards.ToString() + " discards";
        }

        private void UniversalRadioButton_Click(object sender, EventArgs e)
        {
            if (!(sender is RadioButton select)) return;

            //use radius sort method
            if(ReferenceEquals(sender,RadiusRadioButton))
            {
                if(select.Checked)
                {
                    //sort
                    _balls.Sort();
                    Ball.Loading = true;
                    for (int i = 0; i < _balls.Count; i++)
                    {                        
                        _balls[i].ShowBall();
                        Thread.Sleep(1);
                        Ball.Loading = false;
                    }
                }
            }

            //use distance sort method
            if (ReferenceEquals(sender, DisRadioButton))
            {
                if (select.Checked)
                {
                    _balls.Sort(Ball.CompareByDistance);
                    Ball.Loading = true;
                    for (int i = 0; i < _balls.Count; i++)
                    {
                        _balls[i].ShowBall();
                        Thread.Sleep(1);
                        Ball.Loading = false;
                    }                    
                }
            }

            //use color sort method
            if (ReferenceEquals(sender, ClrRadioButton))
            {
                if (select.Checked)
                {
                    _balls.Sort(Ball.CompareByColor);
                    Ball.Loading = true;
                    for (int i = 0; i < _balls.Count; i++)
                    {
                        _balls[i].ShowBall();
                        Thread.Sleep(1);
                        Ball.Loading = false;
                    }                    
                }
            }
        }

        //clear list and window
        private void Minus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.OemMinus)
            {
                _balls.Clear();
                Ball.Loading = true;
                Ball.Loading = false;
            }
        }

        // increment radius with mouse wheel by +/-1 and update button text
        private void scrool_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
                _rad = _rad - 1;
                // go lower
            if (e.Delta > 0)
                _rad = _rad + 1;//go higher
            ADDbutton.Text = $"Add Exclusive Balls ({_rad}px)";//radius?
        }
    }
}
