//Submission Code : 1201_2300_A01
// ica01-Chris Forest
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
using static System.Diagnostics.Trace;

namespace Chris_ica01
{
    class TrekLamps
    {
        /// <summary>
        /// fields neeed for program
        /// </summary>
        private Color _LampColor;
        private int _Border;
        private byte _byTick;
        private byte _byToggle;        

        //custom constructor
        //set fields to custom parameters 
        public TrekLamps(byte toggle,Color Lamp,int Border = 2)
        {
            _Border = Border;
            _LampColor = Lamp;
            _byToggle = toggle;
            Random _Randomer = new Random();
            _byTick = (byte)_Randomer.Next(0, 256);
        }

        //default consturctor
        public TrekLamps() : this(64,RandColor.GetColor(),6)
        {

        }

        //tick rate for flashing different colors
        public void Tick()
        {
            _byTick += 3;
        }

        /// <summary>
        /// render squares on gdi screen
        /// </summary>
        /// <param name="cDrawer"></param>
        /// <param name="lampNum"></param>
        public void RenderLamp(CDrawer cDrawer,int lampNum)
        {
            int row=lampNum % cDrawer.ScaledWidth;
            int column = lampNum / cDrawer.ScaledWidth;//ScaledHeight
            if (_byTick>_byToggle)
                cDrawer.AddRectangle(row, column, 1, 1,_LampColor,_Border,Color.Black);
            else
                cDrawer.AddRectangle(row, column, 1, 1, Color.Black, _Border, Color.Black);
            cDrawer.Render();
        }
    }
}
