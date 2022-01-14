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

namespace Assignment_7
{
    public partial class Form1 : Form
    {
        CDrawer _Canvas = new CDrawer();                    //creates GDI window
        private Color[,] _fillColor = new Color[80, 60];    //2D color array with locations of GDI window
        private Color _selectedColor;                       //color selected by user

        public Form1()
        {
            InitializeComponent();
        }

        //when fill color button is clicked, color dialog will
        //appear and user can select a color
        private void fillColorBtn_Click(object sender, EventArgs e)
        {
            //if user presses ok on color dialog
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //store chosen color
                _selectedColor = colorDialog1.Color;

                //display chosen color in a picture box
                colorBox.BackColor = _selectedColor;
            }
        }

        //when fill button is clicked, start a timer
        private void fillBtn_Click(object sender, EventArgs e)
        {
            //start a timer
            timer1.Start();
        }

        //whenever the timer ticks check for a left click,
        //in the GDI window, and call the FloodFill method
        private void timer1_Tick(object sender, EventArgs e)
        {
            Point mouseClick;   //Point variable to determine mouseclick

            //if user left cliked in GDI window
            if (_Canvas.GetLastMouseLeftClickScaled(out mouseClick))
            {
                //call FloodFill method
                FloodFill(mouseClick.X, mouseClick.Y, Color.Black, _selectedColor);
            }
        }

        //when the form is loaded, set the GDI window scale
        //to 10, and set the default color to green
        private void Form1_Load(object sender, EventArgs e)
        {
            //set GDI window scale to 10
            _Canvas.Scale = 10;

            //call FloodFill method
            _selectedColor = Color.Green;
            colorBox.BackColor = _selectedColor;
        }

        //whenever user presses the generate button, fill the GDI window
        //at randomly selected locations with the user choice from trackbar
        private void generateBtn_Click(object sender, EventArgs e)
        {
            int nIterate1 = 0;              //iterate var 1 for 2D array
            int nIterate2 = 0;              //iterate var 2 for 2D array
            int xPos = 0;                   //xPos of GDI window
            int yPos = 0;                   //yPos of GDI window
            int fillCount = 0;              //determine how many pixels to fill in
            Random rnd = new Random();      //random number generator

            //2 for loops to iterate through 2D array
            for (nIterate1 = 0; nIterate1 < 80; nIterate1++)
            {
                for (nIterate2 = 0; nIterate2 < 60; nIterate2++)
                {
                    //set color to black
                    _fillColor[nIterate1, nIterate2] = Color.Black;
                }
            }

            //2 for loops to iterate through 2D array
            for (nIterate1 = 0; nIterate1 < 80; nIterate1++)
            {
                //create red border for left and right of GDIwindow
                _fillColor[nIterate1, 0] = Color.Red;
                _fillColor[nIterate1, 59] = Color.Red;

                for (nIterate2 = 0; nIterate2 < 60; nIterate2++)
                {
                    //create red border for top and bottom of GDI window
                    _fillColor[0, nIterate2] = Color.Red;
                    _fillColor[79, nIterate2] = Color.Red;
                }
            }

            //set number of pixels to fill from trackbar
            fillCount = blockTrackbar.Value;

            //for loop to iterate through 2D array
            for (nIterate1 = 0; nIterate1 < fillCount; nIterate1++)
            {
                //choose random x and y values to fill
                xPos = rnd.Next(1, 79);
                yPos = rnd.Next(1, 59);

                //fill 2D array with randomly chosen x and y values
                _fillColor[xPos, yPos] = Color.Red;
            }

            //2 for loops to iterate through 2D array
            for (nIterate1 = 0; nIterate1 < 80; nIterate1++)
            {
                for (nIterate2 = 0; nIterate2 < 60; nIterate2++)
                {
                    //set pixels in GDI window from randomly selected locations to red color
                    _Canvas.SetBBScaledPixel(nIterate1, nIterate2, _fillColor[nIterate1, nIterate2]);
                }
            }
        }

        //***********************************************************************************************
        //Method:       private void FloodFill(int x, int y, Color targetColor, Color replaceColor)
        //Purpose:      Fills selected area in GDI window with chosen color
        //Parameters:   int x - xPos within GDI window
        //              int y - yPos within GDI window
        //              Color targetColor - color to be filled in GDI window
        //              Color replaceColor - selected color to replace target color
        //Returns:      void
        //***********************************************************************************************
        private void FloodFill(int x, int y, Color targetColor, Color replaceColor)
        {
            //if fillcolor is not black 
            if (_fillColor[x, y] != targetColor)
            {
                //return
                return;
            }

            //if fillcolor is the selected color
            if (_fillColor[x, y] == replaceColor)
            {
                //return
                return;
            }

            //set fillcolor to selected color
            _fillColor[x, y] = replaceColor;

            //set pixel to selected color
            _Canvas.SetBBScaledPixel(x, y, replaceColor);

            //check to the left of selected pixel
            FloodFill(x - 1, y, targetColor, replaceColor);

            //check to the right of selected pixel
            FloodFill(x + 1, y, targetColor, replaceColor);

            //check to the bottom of selected pixel
            FloodFill(x, y - 1, targetColor, replaceColor);

            //check to the top of selected pixel
            FloodFill(x, y + 1, targetColor, replaceColor);

            //return
            return;
        }
    }
}
