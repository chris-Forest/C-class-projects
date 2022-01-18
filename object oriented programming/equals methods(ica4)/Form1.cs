//Submission Code : 1201_2300_A04
// Chris Forest

using GDIDrawer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Diagnostics.Trace;

namespace chris_ica04
{
    public partial class Form1 : Form
    {
        List<Block> blocks = new List<Block>();
        int blockSize = 0;
        public Form1()
        {
            InitializeComponent();
            SizetrackBar.Scroll += Size_Scroll;
            ADDbutton.Click += ADDbutton_Click;            
        }

        /// <summary>
        /// after size is set 
        /// button will add squares
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ADDbutton_Click(object sender, EventArgs e)
        {
            //set tracking ints
            int counter_blocks = 0;
            int count_discards = 0;

            // if less than 25 add blocks and les than 1000 discards
            while (counter_blocks < 25 && count_discards < 1000)
            {                
                Block blocky = new Block(blockSize);

                //if not found add blocks
                if (blocks.IndexOf(blocky) < 0)
                {
                    blocks.Add(blocky);
                    ++counter_blocks;                    
                }

                // discard
                else
                {
                    ++count_discards;
                    //track discarded blocks with progressbar 
                    progressBar.Value = count_discards;
                }

                Block.Loading = true;

                for (int i = 0; i < blocks.Count; i++)
                {
                    blocks[i].AddBlock();
                }
                //show my blocks
                Block.Loading = false;               
            }
            //show in title discards and adds(text title) 
            this.Text = "loaded " + counter_blocks.ToString() + " distinct blocks with " + count_discards.ToString() + " discards";
        }

        /// <summary>
        /// adjust block size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Size_Scroll(object sender, EventArgs e)
        {
            labelVal.Text = SizetrackBar.Value.ToString();
            blockSize = SizetrackBar.Value;
        }
    }
}
