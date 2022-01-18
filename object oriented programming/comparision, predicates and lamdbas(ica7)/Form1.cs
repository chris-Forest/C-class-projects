//Submission Code : 1201_2300_A07
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

namespace Chris_ica7
{
    public partial class Form1 : Form
    {
        List<Bar> bars = new List<Bar>();
        public Form1()
        {
            InitializeComponent();
            trackBar.Minimum = 10;
            trackBar.Maximum = 190;
            trackBar.Scroll += Width_Scroll;
            PopulateButton.Click += PopulateButton_Click;
            Clrbutton.Click += Clrbutton_Click;
            WidthButton.Click += WidthButton_Click;
            DecButton.Click += DecButton_Click;
            WidClrButton.Click += WidClrButton_Click;
            BrightButton.Click += BrightButton_Click;
            LessButton.Click += LongerButton_Click;
            MouseMove += _MouseMoves;
        }

        /// <summary>
        /// adjust the removel amount size for longer than button
        /// and display bthe number on the longer than xx button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Width_Scroll(object sender, EventArgs e)
        {
            int tb = trackBar.Value / 10 * 10;
            trackBar.Value = tb;
            LessButton.Text = $"Longer Than {trackBar.Value}";
        }

        /// <summary>
        /// update trackbar and text on longer than button based on trackbar postion
        /// </summary>
        private void updateTB()
        {
            if(bars.Count>0)
            {
                trackBar.Minimum = bars.Min(x => x.width);
                trackBar.Maximum = bars.Max(x => x.width);
                trackBar.Value = trackBar.Minimum + ((trackBar.Maximum - trackBar.Minimum) / 2);
                LessButton.Text = $"Longer Than {trackBar.Value}";
            }
        }

        /// <summary>
        /// diplay bars when promted to
        /// </summary>
        private void ShowBars()
        {
            Bar.drawer.Clear();
            Point point = new Point(0, 0);
            foreach  (Bar item in bars)
            {
                // if a bar will not fit on a line 
                //wrap it to the next line
                if(point.X+item.width>Bar.drawer.ScaledWidth)
                {
                    //wrapping
                    point.X = 0;
                    point.Y += Bar.Height;
                }
                //show the bars and udate x postion
                item.ShowBar(point);
                point.X += item.width;
            }
            Bar.drawer.Render(); //render bars in  drawer
        }

        /// <summary>
        /// on click display a random set of bars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopulateButton_Click(object sender, EventArgs e)
        {
            bars.Clear();
            int rSum =0;//runing sum        
            int area = Bar.drawer.ScaledWidth * Bar.drawer.ScaledHeight;

            //While your running sum is less than 80% of the ( scaled Area / bar Height )
            //create a Bar and if it doesn't currently exist in the list add it and update your running sum
            while (rSum< (0.8*area / Bar.Height ))
            {
                Bar bared = new Bar();
                if (bars.IndexOf(bared) < 0)
                {
                    bars.Add(bared);
                    rSum += bared.width;
                }
            }
            ShowBars();
            updateTB();
        }

        //sort by color
        private void Clrbutton_Click(object sender, EventArgs e)
        {
            bars.Sort();
            ShowBars();
        }

        //sort by width
        private void WidthButton_Click(object sender, EventArgs e)
        {
            bars.Sort(Bar.CompareWidth);
            ShowBars();
        }
        //sort by width in decending order
        private void DecButton_Click(object sender, EventArgs e)
        {
            //lambda
            bars.Sort((left, right) => right.width.CompareTo(left.width)); //sort by desc width?
            ShowBars();
        }

        //sort by width then color(asending)
        private void WidClrButton_Click(object sender, EventArgs e)
        {
            bars.Sort(Bar.CompareWidthClr);
            ShowBars();
        }

        //remove bars based on a set brightness comparsion from a predicate method
        private void BrightButton_Click(object sender, EventArgs e)
        {
            this.Text = $"Removed{bars.RemoveAll(Bar.Bright)} Bars";
            ShowBars();
            updateTB();
        }

        //remove all bars based on the trackbar number from a predicate method
        //(displayed in button text)
        private void LongerButton_Click(object sender, EventArgs e)
        {
            this.Text = $"Removed{bars.RemoveAll(x=>x.width>trackBar.Value)} Bars";
            ShowBars();
            updateTB();
        }

        //based on mouse position in main ui window 
        //highlight bars close to that x postion
        private void _MouseMoves(object sender, MouseEventArgs e)
        {
            bars.ForEach(x => x.Highlight = false);
            bars.FindAll(x => Math.Abs(x.width - e.X) < 10).ForEach(x => x.Highlight = true);
            ShowBars();
        }
    }
}
