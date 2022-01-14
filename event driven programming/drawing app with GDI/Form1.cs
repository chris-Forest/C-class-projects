//*********************************************************************
//Program:    ica3- draw a shape in gdi with dialogs
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
using GDIDrawer;

namespace ica3_1600
{
    public partial class Form1 : Form
    {
        private bool _shape;                         // check if square or circle radio button is selected
        private bool _borderCheck;                   // check if border box is checked
        int _iShape;                                 // number used to pick between shapes
        CDrawer _draw = new CDrawer();               //create the drawer window 
        Color _color;                                //drawing color
        bool _bColorSet = false;                     // set the desired color 


        public Form1()
        {
            InitializeComponent();
        }

        //runs everytime when pressed
        // when butoon is clicked window is opened and shape will be selected color
        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog(); // create color dialog window

            if (color.ShowDialog()==DialogResult.OK)
            {
                _color = color.Color;
                _bColorSet = true;
            }
        }

        //runs everytime when pressed
        // when clicked window opens 
        // desiered shape can be selected with or without a border
        private void ShapeButton_Click(object sender, EventArgs e)
        {
            shapeForm shape = new shapeForm(); //create color dialog window

            shape.ShapeSelction = _iShape; // remember what it was checked as
            shape.border = _borderCheck;   // remember what it was checked as

            // if ok is pressed set setting made/changed 
            if (DialogResult.OK == shape.ShowDialog())
            {
                _iShape = shape.ShapeSelction;
                _shape = true;
                _borderCheck = shape.border;
            }
        }

        //runs everytime when pressed
        // prevents user from drawing in gdi window
        private void StopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled=false;
        }

        //runs everytime when pressed
        // when pressed lets user draw in gdi window
        private void STARTbutton_Click(object sender, EventArgs e)
        {
            timer1.Enabled=true; // lets user draw in gdi window
        }

        //runs everytime when pressed
        // when enabled draw on moseclick with desied shape
        private void timer1_Tick(object sender, EventArgs e)
        {
            Point click;                                 // tracks mouse clicks to draw shape
            _draw.GetLastMouseLeftClick(out click);      // draw on mouse click

            if (_bColorSet && _shape)
            {
                if (_iShape == 1)
                {
                    if (_borderCheck)
                    {
                        _draw.AddCenteredRectangle(click.X, click.Y, 50, 50, _color, 2, Color.White);
                        _draw.Render();
                    }
                    else
                    {
                        _draw.AddCenteredRectangle(click.X, click.Y, 50, 50, _color);
                        _draw.Render();
                    }
                }
                if (_iShape == 0)
                {
                    if (_borderCheck)
                    {
                        _draw.AddCenteredEllipse(click.X, click.Y, 50, 50, _color, 2, Color.White);
                        _draw.Render();
                    }
                    else
                    {
                        _draw.AddCenteredEllipse(click.X, click.Y, 50, 50, _color);
                        _draw.Render();
                    }
                }
            }
            else
            {
                if (!_borderCheck && !_shape)
                    MessageBox.Show("Error: Properties have not been set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
