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
    public partial class GameDifficulty : Form
    {
        public GameDifficulty()
        {
            InitializeComponent();
        }

        public Difficulty selection
        {
            get
            {
                // get difficulty chosed by user
                if (EASYradioButton.Checked)
                    return Difficulty.easy;
                else if (MEDradioButton.Checked)
                    return Difficulty.mediun;
                else if (HARDradioButton.Checked)
                    return Difficulty.hard;
                else
                    return 0;
            }
            set
            {
                //set difficulty and pass it to main form
                switch (value)
                {
                    case Difficulty.easy:
                        EASYradioButton.Checked = true;
                        break;
                    case Difficulty.mediun:
                        MEDradioButton.Checked = true;
                        break;
                    case Difficulty.hard:
                        HARDradioButton.Checked = true;
                        break;
                }
            }
        }

        //occurs when the ok button is pressed, returns dialog result of ok
        private void OKbutton_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.OK;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        //occurs when the cancel button is pressed, returns dialog result of cancel
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
