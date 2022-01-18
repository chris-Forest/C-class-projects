// Submission Code : 1201_2300_A14
//Chris Forest
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chris_ica13;// to use class lib made in ica13 adjusted for this ica
using GDIDrawer;

namespace chris_ica8
{
    public partial class Form1 : Form
    {
        List<Ball> _collidedBalls = new List<Ball>();
        List<Ball> _greenList = new List<Ball>();
        List<Ball> _blueList = new List<Ball>();
        myPic _greenBlueGDI = null;
        myDrawer _collidedGDI = null;
        Timer _timer = new Timer();
        int fade=0;

        /// <summary>
        /// initilaize gdi drawers and there positions
        /// and drawing ball events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            _greenBlueGDI = new myPic(chris_ica14.Properties.Resources.home, this);//main, green/blue balls
            _greenBlueGDI.SetPosition(placement.EPosition.eRight, this);
            //drawer position above colided gdi window
            _greenBlueGDI.ContinuousUpdate = false;

            _collidedGDI = new myDrawer(_greenBlueGDI.ScaledWidth,_greenBlueGDI.ScaledHeight);//secondary, red balls
            _collidedGDI.Position = new Point(_greenBlueGDI.Position.X,_greenBlueGDI.Position.Y+_greenBlueGDI.m_ciHeight+30);
            _collidedGDI.ContinuousUpdate = false;

            _greenBlueGDI.MouseLeftClick += _greenBlueGDI_MouseLeftClick;
            _greenBlueGDI.MouseRightClick += _greenBlueGDI_MouseRightClick;
        }

        public Form1()
        {
            InitializeComponent();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 20;
            _timer.Enabled = true;
        }
      
        /// <summary>
        /// invoke action of adding bluse balls on right click
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dr"></param>
        private void _greenBlueGDI_MouseRightClick(Point pos, CDrawer dr)//add blue ball
        {
            Invoke(new Action( () => { AddBlueBall(pos); } ));
        }

        /// <summary>
        /// method to draw blue balls in gdi window
        /// </summary>
        /// <param name="pos"></param>
        private void AddBlueBall(Point pos)
        {
            Ball BlueBall = new Ball(pos, Color.Blue);
            if (_blueList.IndexOf(BlueBall) < 0)
            {
                //insert
                _blueList.Insert(0, BlueBall);
            }
        }

        /// <summary>
        /// invoke action of adding bluse balls on left click
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dr"></param>
        private void _greenBlueGDI_MouseLeftClick(Point pos, CDrawer dr)//add green ball
        {
            Invoke(new Action(() => { AddGreenBall(pos); }));
        }

        /// <summary>
        /// method to draw green balls in gdi window
        /// </summary>
        /// <param name="pos"></param>
        private void AddGreenBall(Point pos)
        {
            Ball greenBall = new Ball(pos, Color.Green);
            if (!(_greenList.Contains(greenBall)))
            {
                _greenList.Add(greenBall);
            }
        }

        /// <summary>
        /// timer tick event to get the balls to move around in gdi window area(stays in bounds)
        /// as well as register collisions between green and blue balls to new collision list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            //collide list
            List<Ball> colideBG = new List<Ball>();
        
            //add balls in colided list to gdi window
            foreach (Ball item in _collidedBalls)
            {
                item.Move(_collidedGDI);                
            }

            //main cdrawer with green and blue balls
            foreach (Ball item in _blueList)
            {
                item.Move(_greenBlueGDI);
            }
            foreach (Ball item in _greenList)
            {
                item.Move(_greenBlueGDI);
            }

            //take collided green and blue balls and add them to the colided list
            colideBG = _greenList.Intersect(_blueList).ToList();

            //remove collided green and blue balls
            foreach (Ball item in colideBG)
            {                
                _blueList.RemoveAll(blue=>blue.Equals(item));
                _greenList.RemoveAll(green => green.Equals(item));
                //set colided balls color to red
                item._BallColor = Color.Red;
            }

            // set temp collide list to with exsisting collide list
            //using one or more of Concat(),Union(), Distinct()
            _collidedBalls = new List<Ball>(_collidedBalls.Union(colideBG));        

            //clear gdi windows and add background text
            _greenBlueGDI.Clear();
            _collidedGDI.Clear();
            _greenBlueGDI.AddText($"Blue: {_blueList.Count} Green: {_greenList.Count}", 40,Color.White);

            //color colid number when colisions happen
            //have the count background text “lightup” and fade back to normal over a few timer cycles
            //Collided(Red ) CDrawer, if a collision occurred,
            //have the count background text “lightup” and fade back to normal over a few timer cycles –
            //figure out what looks good.You may not modify the Ball class.  
            //show a fade for when a collision happens
            if (colideBG.Count > 0)
            {
                _collidedGDI.AddText($"{_collidedBalls.Count}", 60, Color.Yellow);
                fade = 255;//global int
            }
            else
            {
                fade -= 25;
                if (fade < 0)
                    fade = 0;
                _collidedGDI.AddText($"{_collidedBalls.Count}", 60, Color.FromArgb(fade, 255, 255, 0));// to white from yellow
            }

            //for loop from each green/blue balls lists, showing them in gdi window. same for collison list-call show method
            for (int i = 0; i < _blueList.Count; i++)
            {
                _blueList[i].Show(_greenBlueGDI, i);
                _greenBlueGDI.Render();
            }
            for (int i = 0; i < _greenList.Count; i++)
            {
                _greenList[i].Show(_greenBlueGDI, i);
                _greenBlueGDI.Render();
            }
            for (int i = 0; i < _collidedBalls.Count; i++)
            {
                _collidedBalls[i].Show(_collidedGDI, i);
                _collidedGDI.Render();
            }                     
        }       
    }
}
