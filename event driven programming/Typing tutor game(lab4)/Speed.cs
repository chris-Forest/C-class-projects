using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public delegate void DelAnimation(int speed); // del type to set speed
    public delegate void DelClose();             // del typ to check/uncheck checkbox when closing

    public partial class Speed : Form
    {
        public DelAnimation _animate = null; // del varaible to set speed
        public DelClose _close = null;       // del varaible to check/uncheck checkbox when closing

        public int speed { set { trackBar1.Value = value; } }


        public Speed()
        {
            InitializeComponent();
        }

        //occurs when the trackbar is scrolled, 
        //invokes the _animation and passes the trackbar value to mian
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _animate.Invoke(trackBar1.Value);
        }

        //occurs when the form is closing, 
        //instead of closing the form, 
        //just hide it instead and uncheck the box in the main form
        private void Speed_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check that the form is closing due to user input
            if (e.CloseReason==CloseReason.UserClosing)
            {
                //invoke the method to uncheck the box
                _close.Invoke();

                //cancel the closing of the form and hide it instead
                e.Cancel = true;
                Hide();
            }
        }
    }
}
