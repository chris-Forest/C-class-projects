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
using System.Threading;
using System.Windows.Forms;
using static System.Diagnostics.Trace;
using GDIDrawer;

namespace Chris_ica03
{
    public partial class Form1 : Form
    {
        List<Ball> _Balls = new List<Ball>();
        public CDrawer CDrawer;
        private Thread show;
        bool run = true;
        public Form1()
        {
            InitializeComponent();
            trackBarRadius.Scroll += TrackBarRadius_Scroll;
            KeyDown += Form1_KeyDown;
            KeyPreview = true;
            show = new Thread(new ThreadStart(thread));
            show.IsBackground = true;
            show.Start();
        }

        /// <summary>
        /// thred method to be always runnig on statup
        /// shows the balls and moves them
        /// </summary>
        private void thread()
        {
            while (run)//bool made in main
            {
                Ball.Loading = true;
                lock (_Balls)
                {
                    foreach (var item in _Balls)
                    {
                        item.MoveBall();
                        item.ShowBall();
                    }
                }
                Ball.Loading = false;
                Thread.Sleep(25);
            }
        }

        /// <summary>
        /// event handler for adding and removing balls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //key code to add balls
            if(e.KeyCode==Keys.Add)
            {
                //add 5 balls
                lock (_Balls)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        _Balls.Add(new Ball());
                    }
                }
            }

            //clear all balls on screen
            if (e.KeyCode==Keys.Escape)
            {
                lock(_Balls)
                {
                    _Balls.Clear();
                }
            }
        }

        /// <summary>
        /// event handler foradjusting trackbar radius size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackBarRadius_Scroll(object sender, EventArgs e)
        {
            lock (_Balls)
            {                
                for (int i = 0; i < _Balls.Count; i++)
                {
                    Ball.rad = trackBarRadius.Value;
                    Text = "Size =" + trackBarRadius.Value.ToString();
                }
            }
        }
    }
}
