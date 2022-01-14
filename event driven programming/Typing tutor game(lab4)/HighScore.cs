using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class HighScore : Form
    {
        public HighScore()
        {
            InitializeComponent();
        }

        //property for getting the players name from the textbox and returning it to the main form
        public string PlayerName { get { return textBox1.Text; } }

        //occurs when the ok button is pressed, returns the DialogResult of OK
        private void OKbutton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //occurs when the cancel button is pressed, returns the DialogResult of Cancel
        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
