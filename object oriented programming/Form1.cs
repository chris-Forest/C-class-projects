// Submission Code : 1201_2300_A08
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
using GDIDrawer;

namespace chris_ica8
{
    public partial class Form1 : Form
    {
        List<Ball> _collidedBalls = new List<Ball>();
        List<Ball> _greenList = new List<Ball>();
        List<Ball> _blueList = new List<Ball>();
        CDrawer _greenBlueGDI = null, _collidedGDI = null;
        Timer _timer = new Timer();
        int fade=255;
        
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(10, 10);

            _greenBlueGDI = new CDrawer(800, 400);//main            
            Point GDIpos = new Point(this.Width, this.Height);
            GDIpos.X += _greenBlueGDI.ScaledWidth;
            GDIpos.Y += _greenBlueGDI.ScaledHeight;
            _greenBlueGDI.Position = new Point(this.Width, this.Height-250);

            //drawer position above colided gdi window
            _greenBlueGDI.ContinuousUpdate = false;

            //secondary window(red balls/green blue ball colision)
            _collidedGDI = new CDrawer(800, 400);
            _collidedGDI.Position = new Point(this.Width, _greenBlueGDI.ScaledHeight+50);
            _collidedGDI.ContinuousUpdate = false;

            _greenBlueGDI.MouseLeftClick += _greenBlueGDI_MouseLeftClick;
            _greenBlueGDI.MouseRightClick += _greenBlueGDI_MouseRightClick;
            _timer.Tick += _timer_Tick;
            _timer.Interval = 20;
            _timer.Enabled = true;
        }

        //upon click will add a blue ball based on mouse position in gdi window
        private void _greenBlueGDI_MouseRightClick(Point pos, CDrawer dr)//add blue ball
        {
            Invoke(new Action( () => { AddBlueBall(pos); } ));
        }

        //when called will add 1 blue ball
        private void AddBlueBall(Point pos)
        {
            Ball BlueBall = new Ball(pos, Color.Blue);
            if (_blueList.IndexOf(BlueBall) < 0)
            {
                _blueList.Insert(0, BlueBall);
            }
        }

        //upon click will add a green ball based on mouse position in gdi window
        private void _greenBlueGDI_MouseLeftClick(Point pos, CDrawer dr)//add green ball
        {
            Invoke(new Action(() => { AddGreenBall(pos); }));
        }

        //when called will add 1 green ball
        private void AddGreenBall(Point pos)
        {
            Ball greenBall = new Ball(pos, Color.Green);
            if (!(_greenList.Contains(greenBall)))
            {
                _greenList.Add(greenBall);
            }
        }

        //tick event to run program
        private void _timer_Tick(object sender, EventArgs e)
        {
            List<Ball> colideBG = null;

            //collide list(will be indicated with red balls)
            foreach (Ball item in _collidedBalls)
            {
                item.Move(_collidedGDI);                
            }

            //main cdrawer with green and blue balls
            //blue ball movment
            foreach (Ball item in _blueList)
            {
                item.Move(_greenBlueGDI);
            }

            //green ball movment
            foreach (Ball item in _greenList)
            {
                item.Move(_greenBlueGDI);
            }

            //add intersected balls to a temp collsion list
            colideBG = _greenList.Intersect(_blueList).ToList();

            //remove collided blue green balls and add a red ball indication that collsion
            foreach (Ball item in colideBG)
            {                
                _blueList.RemoveAll(blue=>blue.Equals(item));
                _greenList.RemoveAll(green => green.Equals(item));
                item._BallColor = Color.Red;
            }

            // set temp collide list to with exsisting collide list
            //using one or more of Concat(),Union(), Distinct()
            _collidedBalls = new List<Ball>(_collidedBalls.Union(colideBG));        

            //clear gdi windows and add background text
            _greenBlueGDI.Clear();
            _collidedGDI.Clear();
            _greenBlueGDI.AddText($"Blue: {_blueList.Count} Green: {_greenList.Count}", 60,Color.White);
           
            //when a collsion happens show in the secondary window
            //the text color change from yellow to white to indicate a collsion happened
            if (colideBG.Count > 0)
            {
                _collidedGDI.AddText($"{_collidedBalls.Count}", 60, Color.Yellow);
                fade = 0;//global int
            }
            else
            {
                fade += 25;
                if (fade > 255)
                    fade = 255;
                _collidedGDI.AddText($"{_collidedBalls.Count}", 60, Color.FromArgb(255, 255, fade));// to white from yellow
            }

            //for loops: for each green/blue balls lists, showing them in gdi. same for collison list-call show method
            //show blue balls in gdi and a number for recent addtion in collection
            for (int i = 0; i < _blueList.Count; i++)
            {
                _blueList[i].Show(_greenBlueGDI, i);
                _greenBlueGDI.Render();
            }

            //show green balls in gdi and a number for recent addtion in collection
            for (int i = 0; i < _greenList.Count; i++)
            {
                _greenList[i].Show(_greenBlueGDI, i);
                _greenBlueGDI.Render();
            }

            //show collided blue and green balls in red as a different collection
            //and a number for recent addtion in collection
            for (int i = 0; i < _collidedBalls.Count; i++)
            {
                _collidedBalls[i].Show(_collidedGDI, i);
                _collidedGDI.Render();
            }                   
        }
    }
}
