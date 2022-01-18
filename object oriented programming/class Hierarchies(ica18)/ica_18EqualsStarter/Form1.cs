// ica18 - Equals Starter
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

namespace ica_18EqualsStarter
{
    public partial class Form1 : Form
    {
        private static Random _rnd = new Random();
        List<Shape> shapes = new List<Shape>();

        private static CDrawer _drawer = null;
        public Form1()
        {
            _drawer = new CDrawer(1024, 768, false);
            InitializeComponent();
            Text = "ica18-Equals Starter";

            _btnPopulate.Text = "Populate";
            _btnPopulate.Click += _btnPopulate_Click;

            _btnDistinct.Text = "Distinct";
            _btnDistinct.Click += _btnDistinct_Click;
        }

        //on button click provide a distinct set of shapes
        private void _btnDistinct_Click(object sender, EventArgs e)
        {
            shapes = shapes.Distinct().ToList();
            _drawer.Clear();
            render();
            _drawer.Render();
        }

        //on button click it will add 100 of each shape to the list,
        //random positions for each shape, and use random sizes
        private void _btnPopulate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                {
                    int l = _rnd.Next(1, 11) * 10;
                    int x = _rnd.Next(l, _drawer.ScaledWidth - l);
                    int y = _rnd.Next(l, _drawer.ScaledHeight - l);
                    shapes.Add(new Square(new Point(x, y), l));
                }
                {
                    int l = _rnd.Next(1, 11) * 10;
                    int x = _rnd.Next(l, _drawer.ScaledWidth - l);
                    int y = _rnd.Next(l, _drawer.ScaledHeight - l);
                    shapes.Add(new Circle(new Point(x, y), l));
                }
            }
            _drawer.Clear();
            render();
            _drawer.Render();
        }

        //render shapes
        private void render()
        {
            foreach (Shape shape in shapes)
            {
                shape.Render(_drawer);
            }
        }
    }
}
