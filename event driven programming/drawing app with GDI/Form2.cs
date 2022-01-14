//*********************************************************************
//Program:    ica3- draw a shape in gdi with dialogs
//Author:     Chris Forest
//*********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ica3_1600
{
    public partial class shapeForm : Form
    {
        int _shape;
        bool bCheck;
        
        public int ShapeSelction // gets and set shpe chosen by user
        {
            get 
            {
                if (SquareRadioButton.Checked)
                    return 1;
                else
                    return 0;           
            }
            set
            {
                if (value == 1)
                    SquareRadioButton.Checked = true;
                else 
                    CircleRadioButton.Checked = true;
                 
            }
        }

        public bool border // gets and sets weither a border is selected or not
        {
            get
            {
                if (BorderBox.Checked)
                    return true;
                else
                    return false;
            }
            set
            {
                if(value)
                {
                    BorderBox.Checked = true;
                }
                else
                {
                    BorderBox.Checked = false;
                }
            }
        }
        
        public shapeForm()
        {
            InitializeComponent();
        }

        //runs everytime when pressed
        // saves settings of window when pressed
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        //runs everytime when pressed
        // ignorse any settings made in window
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        //runs everytime when pressed
        // set to squre when checked
        private void SquareRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(SquareRadioButton.Checked == true)
            {
                _shape = 1;
            }
        }

        //runs everytime when pressed
        //set to circle whrn checked
        private void CircleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(CircleRadioButton.Checked==true)
            {
                _shape = 0;
            }
        }

        //runs everytime when pressed
        // add border when selected
        private void BorderBox_CheckedChanged(object sender, EventArgs e)
        {
            if(BorderBox.Checked==true)
            {
                bCheck = true;
            }
            else
            {
                bCheck = false;
            }
        }
    }
}
