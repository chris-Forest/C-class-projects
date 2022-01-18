//Submission Code : 1201_2300_A15
//chris forest
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using Chris_Drawer;

namespace chris_ica15
{
    public partial class Form1 : Form
    {
        myPic Pic = null;
        Keys state;
        List<Block> blocks = new List<Block>();
        private Thread MoveTH;
        private Thread ShowTH;
        private Thread Input;

        public Form1()
        {
            InitializeComponent();

            //load a picture from resouices and set it to myPics image
            Pic = new myPic(Properties.Resources.home, this);
            Pic.ContinuousUpdate = false;            

            //start threads for movment, input and showing whats happening in gdi windows
            MoveTH = new Thread(new ThreadStart(MoveThread));
            MoveTH.IsBackground = true;
            MoveTH.Start();
            ShowTH = new Thread(new ThreadStart(ShowThread));
            ShowTH.IsBackground = true;
            ShowTH.Start();
            Input = new Thread(new ThreadStart(InputThread));
            Input.IsBackground = true;
            Input.Start();
           
            Pic.KeyboardEvent += Pic_KeyboardEvent;
            KeyPreview = true;            
        }   

        /// <summary>
        /// this thread method gets the inserted blocks to move
        /// </summary>
        private void MoveThread()
        {
            while(true)
            {
                lock(blocks)
                {
                    foreach (Block item in blocks)
                    {
                        item.Move(blocks);
                    }
                }               
                Thread.Sleep(100);
            }           
        }
        
        /// <summary>
        /// this thread method renders and displays block in the gdi window
        /// </summary>
        private void ShowThread()
        {
            while(true)
            {
                Pic.Clear();
                lock(blocks)
                {
                    foreach (Block item in blocks)
                    {
                        item.ShowBlock(Pic);
                    }
                }               
                Pic.Render();
                Thread.Sleep(100);
            }          
        }

        /// <summary>
        /// this thread method allows the user to insert a desired block
        /// from a specfic key input
        /// </summary>
        private void InputThread()
        {
            Point current = new Point();
            while (true)
            {
                Thread.Sleep(50);//for loop at 50 ms
                lock(blocks)
                {
                    //add a falling block
                    if (state == Keys.F)
                    {
                        Pic.GetLastMousePosition(out current);
                        FallingBlock fallingBlock = new FallingBlock(current);
                        blocks.Add(fallingBlock);
                        state = Keys.None;
                    }

                    //add drunk block
                    if (state == Keys.D)
                    {
                        Pic.GetLastMousePosition(out current);
                        drunkBlocK drunkBlocK = new drunkBlocK(current);
                        blocks.Add(drunkBlocK);
                        state = Keys.None;
                    }

                    //add color block
                    if (state == Keys.C)
                    {
                        Pic.GetLastMousePosition(out current);
                        colorBlock colorBlock = new colorBlock(current);
                        blocks.Add(colorBlock);
                        state = Keys.None;
                    }

                    //remove all 'outside' blocks from list
                    if (state == Keys.Escape)
                    {
                        blocks.RemoveAll(blocks => blocks.outside);
                    }

                    //clear gdi window of blocks
                    if (state == Keys.F1)
                    {
                        blocks.Clear();
                        Pic.Clear();
                        Pic.Render();
                    }
                }               
            }            
        }

        /// <summary>
        /// keep track of current key state(s)
        /// </summary>
        /// <param name="bIsDown"></param>
        /// <param name="keyCode"></param>
        /// <param name="dr"></param>
        private void Pic_KeyboardEvent(bool bIsDown, Keys keyCode, CDrawer dr)
        {
            if (keyCode == Keys.F)
            {
                state = keyCode;
            }

            if (keyCode == Keys.D)
            {
                state = keyCode;
            }

            if (keyCode == Keys.C)
            {
                state = keyCode;
            }

            if (keyCode == Keys.Escape)
            {
                state = keyCode;
            }

            if (keyCode == Keys.F1)
            {
                state = keyCode;
            }
        }
    }
}
