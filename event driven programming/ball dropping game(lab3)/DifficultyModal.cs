using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class SelectDifficulty : Form
    {
        public SelectDifficulty()
        {
            InitializeComponent();
        }

        public Difficulty DifficultySelect
        {
            get
            {
                // get difficulty chosed by user
                if (EasyRadioButton.Checked)
                    return Difficulty.easy;
                else if (MedRadioButton.Checked)
                    return Difficulty.mediun;
                else if (HardRadioButton.Checked)
                    return Difficulty.hard;

                // satisfy code paths
                else
                    return 0;
            }
            set 
            {
                //set difficulty and pass it to main form
                switch(value)
                {
                    case Difficulty.easy:
                        EasyRadioButton.Checked = true;
                        break;
                    case Difficulty.mediun:
                        MedRadioButton.Checked = true;
                        break;
                    case Difficulty.hard:
                        HardRadioButton.Checked = true;
                        break;
                }
            }
        }

        //occurs when the ok button is pressed, returns dialog result of ok
        private void OKbutton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //occurs when the cancel button is pressed, returns dialog result of cancel
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
