//Submission Code : 1201_2300_A05
//Chris Forest
// Mark : 9/10, see comments, actually go and see them please..
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

namespace chris_ica05
{
    public partial class Form1 : Form
    {
        private List<Ball> _balls = new List<Ball>();
        float _rad = -50;//user Radius value
        public Form1()
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

        /// <summary>
        /// add balls on button click and new size is made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBalls(object sender, EventArgs e)
        {
            float counter_balls = 0;
            float count_discards = 0;

            while (counter_balls < 25 && count_discards < 1000)// if less than 25 add blocks and les than 1000 discards
            {
                //add ball based on adjusted radius
                Ball bally = new Ball(_rad);

                //add balls to collection
                if(_balls.IndexOf(bally)<0)
                {
                    _balls.Add(bally);
                    ++counter_balls;
                }
                //track discards
                else
                {
                    ++count_discards;
                    progressBar1.Value = (int)count_discards;
                }
                Ball.Loading = true;

                //display balls in collection
                for (int i = 0; i < _balls.Count; i++)
                {
                    _balls[i].ShowBall();
                }
                Ball.Loading = false;                
            }
            this.Text = "loaded " + counter_balls.ToString() + " distinct blocks with " + count_discards.ToString() + " discards";
        }

        //based on what radio button is clicked take action
        private void UniversalRadioButton_Click(object sender, EventArgs e)
        {
            if (!(sender is RadioButton select)) return;

            //sort by radius
            if(ReferenceEquals(sender,RadiusRadioButton))
            {
                if(select.Checked)
                {
                    Ball.sortType = Ball.ESortType.eRadius;

                    //****
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

            //sort by distance
            if (ReferenceEquals(sender, DisRadioButton))
            {
                if (select.Checked)
                {
                    Ball.sortType = Ball.ESortType.eDistance;

                    //****
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

            //sort by color
            if (ReferenceEquals(sender, ClrRadioButton))
            {
                if (select.Checked)
                {
                    Ball.sortType = Ball.ESortType.eColor;

                    //****
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
        }

        //clear window
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
