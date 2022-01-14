//*********************************************************************
//Program:    ICA6 – modeless drawing
//Author:     Chris Forest
//Class:      CNT2f
//Instructor: Kevin More
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
    public delegate void delGetShapeColor(Color c);
    public delegate void delColorClose();

    public partial class ColorForm : Form
    {
        public delGetShapeColor _GetColor = null;
        public delColorClose _Close = null;

        public ColorForm()
        {
            InitializeComponent();
        }

        // color numbers gets set and sent to main
        public int ColorVal
        {
            set
            {
                RedTrackBar.Value = value;
                BlueTrackBar.Value = value;
                GreenTrackBar.Value = value;
            }
        }
        //********************************************************************************************
        //Method:     public void ColorChange()
        //Purpose:    set color for shape and send it to main form
        //*********************************************************************************************
        public void ColorChange()
        {
            ColorBox.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value);
            _GetColor.Invoke(Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value));
        }

        //adjust red color value and set it 
        // in accordensce to its user set value
        private void RedTrackBar_Scroll(object sender, EventArgs e)
        {
            ColorChange();
        }

        //adjust green color value and set it 
        // in accordensce to its user set value
        private void GreenTrackBar_Scroll(object sender, EventArgs e)
        {
            ColorChange();
        }

        //adjust reblued color value and set it 
        // in accordensce to its user set value
        private void BlueTrackBar_Scroll(object sender, EventArgs e)
        {
            ColorChange();
        }

        //the modeless dialog is closing, intercept it and hide it
        private void ColorForm_FormClosing(object sender, FormClosingEventArgs e)
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
