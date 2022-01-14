//*********************************************************************
//Program:    ica5 - drawing with keyboard events
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
using GDIDrawer;

namespace ica5
{
    public partial class Form1 : Form
    {
        const int _WIDTH = 30;                                   // window WIDTH constant   
        const int _HIGHT = 30;                                   // window HIGHT constant   
        CDrawer _canvas = new CDrawer(_WIDTH * 20, _HIGHT * 20); //sets Gdi drawer window range 
        private int _XPOS = 14;                                  // starting circle x possistion 
        private int _YPOS = 14;                                  // starting circle y possistion 
        Color _color;                                            // adjust color according to what key is pressed
        private int _border = 0;                                 // add border to shape
        private int _shapePos = 1;                                 // inital distance set between shapes

        public Form1()
        {
            InitializeComponent();
        }

        // occurs evertime program starts
        // when loaded gdi window is opened and initalized
        private void Form1_Load(object sender, EventArgs e)
        {
            _canvas.ContinuousUpdate = false;                          // allows objects to be drawn and animated cleanly 
            const int SCALE = 20;                                      // scale constant  
            _canvas.Scale = SCALE;                                     // sets pixels range for x and y
            _color = Color.Red;                                        // set default shape color to red

            // draw circle in center of draw window for starting point
            _canvas.AddEllipse(_XPOS, _YPOS, 1, 1, Color.Red);
            _canvas.Render();
        }

        //occurs evertime a key is pressed
        private void Pressed_KeyDown(object sender, KeyEventArgs e)
        {
            // if x is pressed and released program closes
            if (e.KeyCode == Keys.X)
            {
                this.Close();
                _canvas.Close();
            }

            // if up draw shpe 1 posistion up
            if (e.KeyCode == Keys.Up)
            {
                _YPOS -= _shapePos;
                drawStuff();
                range();
            }

            // if down draw shpe 1 posistion down
            else if (e.KeyCode == Keys.Down)
            {
                _YPOS += _shapePos;
                drawStuff();
                range();
            }

            // if left draw shpe 1 posistion left
            else if (e.KeyCode == Keys.Left)
            {
                _XPOS -= _shapePos;
                drawStuff();
                range();
            }

            // if right draw shpe 1 posistion right
            else if (e.KeyCode == Keys.Right)
            {
                _XPOS += _shapePos;
                drawStuff();
                range();
            }

            // move in arrow diretion 2 posistions 
            if (e.Shift)
            {
                // 2 pos inted of 1
                _shapePos = 2;
            }

            // move in arrow diretion 3 posistions 
            if (e.Control)
            {
                // 3 pos insted of 1
                _shapePos = 3;
            }

            // move in arrow diretion 4 posistions 
            if (e.Alt)
            {
                // 4 pos insted of 1
                _shapePos = 4; 
            }

            // if R is pressed set color to red
            if (e.KeyCode == Keys.R)
            {
                _color = Color.Red;
            }

            // if G is pressed set color to green
            if (e.KeyCode == Keys.G)
            {
                _color = Color.Green;
            }

            // if B is pressed set color to blue
            if (e.KeyCode == Keys.B)
            {
                _color = Color.Blue;
            }

            // draw border around shape
            if (e.KeyCode == Keys.F1)
            {
                _border = 1;
            }

            // reset to original shape distance
            if (e.KeyCode == Keys.Z)
                _shapePos = 2;
        }

        //********************************************************************************************
        //Method:     private void range()
        //Purpose:    keeep shape in window
        //*********************************************************************************************
        private void range()
        {
            // if x point less than 0 force it o 0
            if (_XPOS < 0)
                _XPOS = 0;
            // if x point more than max window size force it to 28
            if (_XPOS > 29)
                _XPOS = 29;
            // if y point less than 0 force it o 0
            if (_YPOS < 0)
                _YPOS = 0;
            // if y point more than max window size force it to 28
            if (_YPOS > 29)
                _YPOS = 29;
        }

        //********************************************************************************************
        //Method:     private void drawStuff()
        //Purpose:    draw shape in window
        //*********************************************************************************************
        private void drawStuff()
        {
            _canvas.AddEllipse(_XPOS, _YPOS, 1, 1, _color, _border, Color.White);
            _canvas.Render();
        }

        // occurs every time when a key is pressed then released
        private void releaseKeys_KeyUp(object sender, KeyEventArgs e)
        {
            // no border around shape
            if (e.KeyCode == Keys.F1)
                 _border = 0;

            // move in arrow diretion 2 posistions 
            if (e.KeyCode == Keys.ShiftKey)
            {
                // 2 pos inted of 1
                _shapePos = 1;
            }

            // move in arrow diretion 3 posistions 
            if (e.KeyCode == Keys.ControlKey)
            {
                // 3 pos insted of 1
                _shapePos = 1;
            }

            // move in arrow diretion 4 posistions 
            if (e.KeyCode == Keys.Menu)
            {
                // 4 pos insted of 1
                _shapePos = 1;
            }
        }
    }
}
