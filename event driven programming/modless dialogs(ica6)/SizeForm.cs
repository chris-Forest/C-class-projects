//*********************************************************************
//Program:    ICA6 – modeless drawing
//Author:     Chris Forest
//*********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ica6
{
    // create delegate types
    public delegate void delSize(int n); 
    public delegate void delSizeClose(); 

    public partial class SizeForm : Form
    {
        //create delegate varaibles
        public delSize _size = null;       
        public delSizeClose _Close = null; 

        public SizeForm()
        {
            InitializeComponent();
        }

        // size gets set and sent to main
        public int shapeSize // gets size of shape from the trackbar
        {
            set { SizeTrackBar.Value = value; }
        }

        // the track bars chenged contents
        private void SizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            //determine that the delegate was setup by the main form
            if (_size != null)
                //update size to main form
                _size.Invoke(SizeTrackBar.Value);
        }

        //the modeless dialog is closing, intercept it and hide it
        private void SizeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check for the user pressing the close button
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //determine that the main form setup the delegate
                if (_Close != null)

                    //clear the checkobx in the main form
                    _Close();


                //prevent modeless dialog from being removed from memory
                e.Cancel = true;

                //hide the modeless dialog
                Hide();
            }
        }
    }
}
