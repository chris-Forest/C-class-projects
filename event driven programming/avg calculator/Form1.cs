using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA1
{
    public partial class Form1 : Form
    {
        double crntAvgSum;
        double totalVals;

        public Form1()
        {
            InitializeComponent();
            Text = "Ica-1";
        }

        /// <summary>
        /// on click take textbox value, add it to total average sum and track a current average 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AVG_Click(object sender, EventArgs e)
        {
            string input = ValtextBox.Text;//set textbox to string to convert it to a double
            double inputNum;//placeholder to take texbox string and convert it to a double

            //if textbox cannot be convertedto a valid double,
            //display a messgbox indicating the error,then clear textbox and focus on textbox
            if(!double.TryParse(input,out inputNum))
            {
                MessageBox.Show("Not a valid number");
                ValtextBox.Clear();
                ValtextBox.Focus();
            }
            //else if it is a valid number-add to avg sum and add to total number of values inputed
            //after valid entry, clear txtbox and focus on textbox
            else
            {
                totalVals++;               
                crntAvgSum = (inputNum + crntAvgSum) / totalVals;
                AVGCount.Text = crntAvgSum.ToString("0.0");                
                ValCount.Text = totalVals.ToString();
                ValtextBox.Clear();
                ValtextBox.Focus();
            }
        }

        /// <summary>
        /// on click reset and clear all values and focus on textbox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_reset_Click(object sender, EventArgs e)
        {
            ValtextBox.Clear();
            ValtextBox.Focus();
            crntAvgSum = 0;
            totalVals = 0;
            AVGCount.Text = "0";
            ValCount.Text = "0";
        }
    }
}
