//Submission code 1202_CMPE2800_L03
//Chris Forest

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace chris_lab03_pixelPenitration
{
    public partial class Form1 : Form
    {
        private Random random = new Random();//set random point for multiple shapes being drawn at one click
        float radius = 5;//default shape size

        // create a context for the double-buffering
        private BufferedGraphicsContext _bgc = new BufferedGraphicsContext();
        // need a actual graphics to create and allocate in shapes and more
        private BufferedGraphics _bg = null;

        List<ShapeBase> GetShapes = new List<ShapeBase>();// get shapes and add them to be displayed
        List<Region> saveIntersects = new List<Region>();//save any intersected point to this collection
        Dictionary< Stopwatch, Region> colided = new Dictionary< Stopwatch, Region>();// to remove intersected shape  after x ms

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 25;
            ShapeBase._fRadius = radius;//assigns the radius to shapebase radius
            this.Text = $"PPP - shape size = {radius}";
            MouseWheel += Form1_MouseWheel;
        }

        /// <summary>
        /// adjust shape size on mouse wheel scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            //only alter size if collection is empty&&rebulid triangle with updated size 
            if (GetShapes.Count > 0)
                return;               

            //decrease radius
            if (e.Delta < 0)
            {
                radius = radius - 1;

                //if radius falls to below 5 force it to 5
                if (radius < 5)
                {
                    radius = 5;
                }

                ShapeBase._fRadius = radius;
            }

            //increase radius
            if (e.Delta > 0)
            {
                radius = radius + 1;
                ShapeBase._fRadius = radius;
            }

            //rebuild the triangle with a new size
            Triangle.RebuildModel();            

            this.Text = $"PPP - shape size = {radius}";
        }

        /// <summary>
        /// given what keys are pressed and what mosue button is pushed, take action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            PointF Click = new PointF(); //for shapes spawed at random points
            PointF ClickOnce = new PointF(e.X, e.Y);//for shapes spawed at mouse click point

            if (e.Button == MouseButtons.Left && !(Control.ModifierKeys == Keys.Control) && !(Control.ModifierKeys == Keys.Shift))
            {
                //add 1 triangle
                GetShapes.Add(new Triangle(ClickOnce));
            }

            if (e.Button == MouseButtons.Right && !(Control.ModifierKeys == Keys.Control) && !(Control.ModifierKeys == Keys.Shift))
            {
                //add 1 rock
                GetShapes.Add(new Rock(ClickOnce));
            }

            //add 1000 triangles at rdm positions on shit+left mouse click
            if (Control.ModifierKeys==Keys.Shift && (e.Button == MouseButtons.Left))
            {                
                for (int i = 0; i < 1000; i++)//1000
                {
                    //works but some do not spwan in range
                    Click.X = random.Next(1, (int)(Width - radius*2));
                    Click.Y = random.Next(1, (int)(Height -radius*2));                    
                    GetShapes.Add(new Triangle(Click));
                }
            }

            //add 1000 rocks on shit+right mouse click
            if (Control.ModifierKeys == Keys.Shift && (e.Button == MouseButtons.Right))
            {                
                for (int i = 0; i < 1000; i++)//1000
                {
                    //works but some do not spwan in range
                    Click.X = random.Next(1, (int)(Width - radius*2));
                    Click.Y = random.Next(1, (int)(Height - radius*2));
                    GetShapes.Add(new Rock(Click));
                }
            }

            //clear all collections
            if (Control.ModifierKeys == Keys.Control&& e.Button == MouseButtons.Left)
            {
                GetShapes.Clear();
            }
        }

        /// <summary>
        /// set BufferedGraphics to form area graphics to enable stuff to be drawn
        /// loop through collection to move shapes and render them as well as check for collisions
        /// and display number of shapes on screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {            
            _bg = _bgc.Allocate(CreateGraphics(), ClientRectangle);
            Rectangle tr = ClientRectangle;//gets size of form for boundary checks
            Graphics gr = _bg.Graphics;

            gr.Clear(Color.FromKnownColor(KnownColor.Control));

            //compare shapes to eachother
            for (int i = 0; i < GetShapes.Count; i++)//this is the first index value
            {
                //shape movment, passing in boundaries
                GetShapes[i].Tick(tr.Size);
                Region A = new Region(GetShapes[i].GetPath());

                for (int j = 0; j < GetShapes.Count; j++)//this is the next index value
                {
                    //skip if indexs are same
                    if (i == j)
                        continue;

                    //dist checks the between 2 shape center points to see if a comparison is needed
                    //return true is shapes are close enough to compare and can possibly collide
                    if (GetShapes[i].Dist(GetShapes[i].location,GetShapes[j].location))
                    {
                        GetShapes[i].IsMarkedForCompare = true;
                        GetShapes[j].IsMarkedForCompare = true;
                        //create region for shape                        
                        Region B = new Region(GetShapes[j].GetPath());

                        //a get the point where a and b intersect
                        A.Intersect(B);

                        //save current intersect point to a collection to remove it later on
                        saveIntersects.Add(A);

                        //if there are intersects mark them to be removed
                        if (!A.IsEmpty(_bg.Graphics))
                        {
                            //mark for death shapes
                            GetShapes[i].IsMarkedForDeath = true;
                            GetShapes[j].IsMarkedForDeath = true;

                            //start a new stopwatch for each intersect of shapes
                            colided.Add(Stopwatch.StartNew(),A);
                        }                        
                    }
                    GetShapes[j].IsMarkedForCompare = false;
                }

                //render shapes
                GetShapes[i].Render(gr);
                GetShapes[i].IsMarkedForCompare = false;
            }

            //remove all shapes marked for death
            GetShapes.RemoveAll(s => s.IsMarkedForDeath);

            //display the collided shape of intersected shapes
            foreach (KeyValuePair<Stopwatch, Region> c in colided)
            {
                gr.FillRegion(new SolidBrush(Color.Red), c.Value);
            }

            //remove the collided shape of intersected shapes after "x" Milliseconds
            Stopwatch[] removeShapes = colided.Keys.ToArray();
            foreach(Stopwatch shape in removeShapes)
            {
                if (shape.ElapsedMilliseconds > 2500)
                    colided.Remove(shape);
            }
            
            //show current count of shapes on screen
            gr.DrawString($"ShapeCount: {GetShapes.Count}", new Font(FontFamily.GenericSansSerif, 20), new SolidBrush(Color.Red), new PointF((this.Size.Width/2)-100, (this.Size.Height / 2)-50));

            // flip backbuffer to primary -otherwise you don't msee anything
            //render shapes to graphics to show on form area
            _bg.Render();                
        }

        /// <summary>
        /// enable the timer to display shapes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
