using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chris_ica13
{
    public partial class Form1 : Form
    {
        private myDrawer Rectdrawer = null;
        private placement posDrawer = null;
        private myPic picture = null;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
        }

        /// <summary>
        /// based on a keystroke
        /// set a basic gdi window postion in relation top form postion
        /// draw a set amount of squares at random in a different window 
        /// or show a greay scaled picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Rectdrawer?.Close();
            posDrawer?.Close();
            picture?.Close();
            Rectdrawer = null;
            posDrawer = null;
            picture = null;

            switch (e.KeyCode)
            {
                // produce a basic gdi windo in relation to an enum being used(postion in relation to form app postion) 
                case Keys.E:
                    posDrawer = new placement(500, 300, this, placement.EPosition.eRight);
                    break;
                case Keys.S:
                    posDrawer = new placement(500, 300, this, placement.EPosition.eBelow);
                    break;
                case Keys.D:
                    posDrawer = new placement(500, 300, this, placement.EPosition.eBelowRight);
                    break;
                //draw set amount of squares in a gdi window at random spots in window
                case Keys.R:
                    Rectdrawer = new myDrawer();
                    Activate();
                    break;
                // shows a grey scaled picture(postion in relation to form app postion) 
                case Keys.P:
                    picture = new myPic(this);
                    break;
            }
        }
    }
}
