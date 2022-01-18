//Submission Code : 1201_2300_A17
// chris forest

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chris_ica17
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        List<BaseShape> Shapes = new List<BaseShape>();

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(10, 10);

            BaseShape._canvas = new Chris_Drawer.myPic(Properties.Resources._2bscetch);
            BaseShape._canvas.Position = new Point(this.Width, this.Height-272);
            this.KeyDown += Form1_KeyDown;
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        //gets everything to move around and function
        private void Timer_Tick(object sender, EventArgs e)
        {
            BaseShape._canvas.Clear();
            Shapes.ForEach(s => s.Move());

            //remove
            Shapes.RemoveAll(r => (r as IMortal)?.step()??false);

            //itterate through collection and animate shapes
            foreach (IAnimate item in Shapes.Where(arg => arg is IAnimate))
                item.Animate(BaseShape._canvas);

            //mave shapes and display them
            Shapes.ForEach(s => s.Move());
            Shapes.ForEach(Shape => Shape.Paint());
            BaseShape._canvas.Render();
        }

        //add shape based on keystroke
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point where;
            if(BaseShape._canvas.GetLastMousePosition(out where))
            {
                if (e.KeyCode==Keys.S)
                {
                    Shapes.Add(new Snake(where, BaseShape._rnd.Next(19, 61)));
                }
                if(e.KeyCode==Keys.B)
                {
                    Shapes.Add(new Blob(where, BaseShape._rnd.Next(29, 51)));
                }
            }
            if(e.KeyCode==Keys.C)
            {
                Shapes.Clear();
            }
        }
    }
}
