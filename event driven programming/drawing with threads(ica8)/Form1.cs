//*********************************************************************
//Program:    ica8- multithredaing with gdi
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
using System.Threading;
using System.Windows.Forms;
using GDIDrawer;

namespace ica8
{
    public delegate void delColor(int x,int y,Color c);
    public partial class Form1 : Form
    {
        const int WIDTH = 800;  // width of gdi window
        const int HEIGHT = 600; // heigth of gdi window
        static CDrawer _draw;   // initialize gdi wndow
        Thread _wander;         // thred to run in wander method

        //struct for starting point
        public struct WanderData
        {
            public int pCount;  // count number of pixels to be drawn
            public Point start; // start point of thred 
            public int x;       // to be use for velocicty x posistions
            public int y;       // to be use for velocicty y pososiotins
        }
        public Form1()
        {
            InitializeComponent();

            _draw = new CDrawer(WIDTH, HEIGHT); // make gdi window
            timer1.Start();                     // allow cliking in gdi window
        }

        // occurs on evey mouse click
        // draw thred based on where you clicked in gdi window
        // amount of pixels drawn baed on trackbar value
        // call wander method to to start drawing
        // set to backgground
        private void timer1_Tick(object sender, EventArgs e)
        {
            Point click;                              // start thred on mouse click
            WanderData wanderdata = new WanderData(); // varaible for struct

            // draw thred based on where you clicked in gdi window
            if (_draw.GetLastMouseLeftClick(out click))
            {
                wanderdata.pCount = trackBar1.Value;
                wanderdata.x = click.X;
                wanderdata.y = click.Y;
                _wander = new Thread(new ParameterizedThreadStart(Wander));
                _wander.IsBackground = true;
                _wander.Start(wanderdata);
            }
        }

        //********************************************************************************************
        //Method:     private void Wander(object obj)
        //Purpose:    thread operation/ get new x,y/ get rdm color
        //            displays SizeLabel to size selected in MYSizeDialog
        //Parameters: object obj - is inital coordinates
        //                         pixels amount set by trackbar
        //*********************************************************************************************
        private void Wander(object obj)
        {
            Random rdmVel = new Random(); // create a rdm generator for velocity x,y posistions
            int xPos;                     // hold x cordinates
            int yPos;                     // hold y cordinates

            // if object is in struct start running program
            if(obj is WanderData)
            {
                // create struct varaible
                WanderData wan = (WanderData)obj;

                // coordinates to be passed through from starting point
                xPos = wan.x;
                yPos = wan.y;

                // get radom colors for thread
                Color pickOne = RandColor.GetColor();

                // loop thruogh as many pixels as diceid from trackbar value 
                for (int x = 0; x < wan.pCount; x++)
                {
                    // draw within gdi window
                    if (xPos >= 0 && xPos <= WIDTH - 1 && yPos >= 0 && yPos <= HEIGHT - 1)
                    {
                        //send parameters through deleagete to 
                        try
                        {
                            Invoke(new delColor(changePixel), xPos, yPos, pickOne);
                            Thread.Sleep(1);
                        }
                        // if obj is dispoed, error
                        catch (ObjectDisposedException error)
                        {
                            MessageBox.Show(error.Message, "ahhh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    // if positioning outside if window 
                    //keep running until its insdie of window
                    else
                        x--;
                    // get rdm locations for x and y velocitys for next loop
                    xPos += rdmVel.Next(-1, 2);
                    yPos += rdmVel.Next(-1, 2);
                }
            }            
        }

        //********************************************************************************************
        //Method:     private void changePixel(int x,int y,Color Here)
        //Purpose:    changes amount of pixels and what color they are
        //            based on a trackbar value and where user clicked
        //Parameters: int xPos- amount of pixels to be drawn
        //            int yPos- amount of pixels to be drawn
        //            Color here- color of the pixels
        //*********************************************************************************************
        private void changePixel(int xPos,int yPos,Color Here)
        {
            // change pixels from what is set in wanderer
            _draw.SetBBPixel(xPos, yPos, Here);
        }
    }
}
