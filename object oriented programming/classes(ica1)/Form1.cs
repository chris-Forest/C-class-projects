using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//Submission Code : 1201_2300_A01
// ica01-Chris Forest
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace Chris_ica01
{
    public partial class Form1 : Form
    {
        Timer _timer = new Timer();
        public CDrawer _cDrawer;
        List<TrekLamps> _trekLampsList = new List<TrekLamps>(); // refrence to get class items here in main

        public Form1()
        {
            InitializeComponent();
            _cDrawer = new CDrawer(900, 500,false);
            _cDrawer.Scale = 50;
            _cDrawer.BBColour = Color.Black;
            _timer.Tick += _timer_Tick;
            _timer.Interval = 100;
            _timer.Start();
            KeyDown += Form_KeyDown;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            Random _Randomer = new Random();
            // call default trek constructor
            if (e.KeyCode == Keys.F1)
            {
                _trekLampsList.Add(new TrekLamps());
            }

            // call custom constructor: clr orange, 180 threshold,border n/a
            if (e.KeyCode == Keys.F2)
            {
                _trekLampsList.Add(new TrekLamps(180,Color.Orange, 2));
            }

            // custom constructor with rdm color,rdm #60-220, border 4
            if (e.KeyCode == Keys.F3)
            {
                _trekLampsList.Add(new TrekLamps((byte)_Randomer.Next(20, 221),RandColor.GetColor(), 4 ));
            }

            //remove the last added treklight
            if (e.KeyCode == Keys.Escape)
            {
                //if have squares-> remove them else do nothing
                if (_trekLampsList.Count > 0)
                    _trekLampsList.RemoveAt(_trekLampsList.Count - 1);
                else
                    return;
            }
        }

        /// <summary>
        /// render the lights on gdi window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            _cDrawer.Clear();
            foreach (var item in _trekLampsList)
            {
                item.Tick();
            }
            for (int i = 0; i < _trekLampsList.Count; i++)
            {
                _trekLampsList[i].RenderLamp(_cDrawer, i);
            }
            _cDrawer.Render();
        } 
    }
}
