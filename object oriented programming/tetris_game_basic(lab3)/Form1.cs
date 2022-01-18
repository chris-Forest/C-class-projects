//Submission Code : 1201_2300_L03
//Chris Forest
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
using System.Diagnostics;

namespace chris_lab3
{
    public partial class Form1 : Form
    {
        Stopwatch sw = new Stopwatch();
        Queue<shape> Qshapes = new Queue<shape>();
        shape pickShape = null;
        List<block> floor = new List<block>();
        CDrawer next = new CDrawer(250,150);
        
        bool upState;//rotates
        bool downState;
        bool leftState;
        bool rightState;
        int level;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(10, 10);
            next.Position = new Point(Width, Height - 449);
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            sw.Start();
            button_play.Click += playGame_Click;           
            timer1.Tick += Timer_Tick;
            next.Scale = 50;//size of shapes
        }    
        
        //lots of checking here
        private void Timer_Tick(object sender, EventArgs e)
        {
            shape nextShape=null;
            
            if (block.drawer == null)
                return;

            // down is pressed or 1000ms has pased, drop
            if(sw.ElapsedMilliseconds>=1000||downState==true)
            {
                if (pickShape.isFalling == false && Qshapes.Count > 0)
                {
                    pickShape = Qshapes.Dequeue();
                    next.Clear();
                    if (Qshapes.Count() > 1)
                        nextShape = new shape(Point.Empty, Qshapes.Peek());
                    else
                    {
                        level *= 2;
                        Qshapes = new Queue<shape>();
                        for (int i = 0; i < 20; i++)
                        {
                            //get rdm shape in queue
                            Qshapes.Enqueue(new shape(new Point(block.drawer.ScaledWidth / 2, 0)));
                        }
                        floor.Clear();

                        pickShape = Qshapes.Dequeue();
                    }
                }
                pickShape.Drop(floor);

                //crashes games adter first block hits bottom
                //if shape done falling set to null
                //if(pickShape.isFalling==false)
                //    pickShape = null;

                sw.Reset();
                sw.Start();
            }

            //not working for me idk why
            //preform key processing
            if (upState == true) { pickShape.Rotate(); upState = false; }
            if (leftState == true) { pickShape.shiftLeft(floor); leftState = false; }
            if (rightState == true) { pickShape.shiftRight(floor); rightState = false; }
            if (downState == true) { pickShape.Drop(floor); downState = false; }

            block.drawer.Clear();
            
            if(pickShape!=null)pickShape.ShowShape();
            floor.ForEach(show => show.ShowBlock());
            nextShape?.blocks.ForEach(nxt => nxt.ShowBlock(next));            
            block.drawer.Render();
            
        }

        private void playGame_Click(object sender, EventArgs e)
        {
            //adjust based on scale
            block.drawer = new CDrawer(500, 1000);
            block.drawer.Position = new Point(Width, Height - 449);
            block.drawer.KeyboardEvent += Drawer_KeyboardEvent;
            block.drawer.Scale=(int)numUpDownCol.Value;  
            //timer1.Interval = 300;
            timer1.Enabled = true;
            timer1.Start();

            Qshapes = new Queue<shape>();
            for (int i = 0; i < 20; i++)
            {
                //get rdm shape in queue
                Qshapes.Enqueue(new shape(new Point(block.drawer.ScaledWidth / 2, 0)));
            }
            floor.Clear();
           
            pickShape = Qshapes.Dequeue();
        }

        private void Drawer_KeyboardEvent(bool bIsDown, Keys keyCode, CDrawer dr)
        {
            //rotates
            if (keyCode == Keys.Up) { upState = true; }

            if (keyCode == Keys.Down) { downState = true; }

            if (keyCode == Keys.Left) { leftState = true; }

            if (keyCode == Keys.Right) { rightState = true; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //rotates
            if (e.KeyCode == Keys.Up) { upState = false; }

            //
            if (e.KeyCode == Keys.Down) { downState = false; }

            //
            if (e.KeyCode == Keys.Left) { leftState = false; }

            //
            if (e.KeyCode == Keys.Right) { rightState = false; }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //rotates
            if (e.KeyCode == Keys.Up) { upState = true; }

            if (e.KeyCode == Keys.Down) { downState = true; }

            if (e.KeyCode == Keys.Left) { leftState = true; }

            if (e.KeyCode == Keys.Right) { rightState = true; }
        }
    }
}
