//*********************************************************************
//Program:    ica4- lists with binary numbers
//Author:     Chris Forest
//*********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ica4
{
    public partial class Form1 : Form
    {
        List<byte> _byteList = new List<byte>(); // create a list of bytes
        private int _onesTotal = 0;              // count tottal ones with each button input
        private int _count;                      // loop through lst an bit number accordigly

        public Form1()
        {
            InitializeComponent();
        }

        //occurs when any key input is occured
        //show what key input has occured
        //add key input to list and convert in to a binary number
        // display total ones from each key input made to onesTotalLabel
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyResult.Text = e.KeyCode.ToString();
            listBox.Items.Add(Convert.ToString(e.KeyValue, 2).PadLeft(8, '0'));
            _byteList.Add(Convert.ToByte(e.KeyValue));

            // itterate through displayed binary number counting all the ones in the list
            for (_count = 0; _count < 8; _count++)
            {
                //if 1's are detectred in keyinput add to total ones
                if ((_byteList[_byteList.Count - 1] & 1 << _count) > 0)
                    _onesTotal++;
            }
            onesTotalLabel.Text = _onesTotal.ToString();
        }

        //occurs every time a different list item is clicked
        // check through list item for logest run of ones and store it in runResultLabel
        // display logest run of on for which ever list item is selected at anytime
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int longestRun = 0; // the longest run of ones in a specific bit
            int currentRun = 0; // the current highest stored run of ones from an input

            // count longest run for selected index in list
            try
            {
                //itterate through loop checking each byte posistion for a 0 or a 1
                for (_count = 0; _count < 8; _count++)
                {
                    // if byte number is 0 and current number being checked is 1 add to currnt total run of ones
                    if ((_byteList[listBox.SelectedIndex] & (0x01 << _count)) != 0)
                    {
                        // if set bit is one add to currentRun
                        currentRun++;

                        // update longestRun if new longest run is made
                        if (longestRun < currentRun)
                            longestRun = currentRun;
                    }

                    // if bit is 0 set currentRun to zero
                    else
                        currentRun = 0;
                }

                // display longest ruon to runResultLabel
                runResultLabel.Text = longestRun.ToString();
                longestRun = 0;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
