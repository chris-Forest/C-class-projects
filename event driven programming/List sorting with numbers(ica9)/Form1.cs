//*********************************************************************
//Program:    NICA09 – invoking
//Author:     Chris Forest
//Class:      CNT2f
//Instructor: Kevin More
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
using System.Threading;

namespace nica9
{
    //declare the delegate datatype for updating the control
    delegate void DelVoidInt(int num);

    public partial class Form1 : Form
    {
        Thread _thread = null; // reference to the running thread
        bool _running = true;  // controls stopping the thread loop 

        public Form1()
        {
            InitializeComponent();
            STPButton.Enabled = false; // disable stop button when program loads
        }

        //********************************************************************************************
        //Method:  private void cbUpdateProgress(int num)
        //Purpose: updtae the progress bar for how far in the thred you are
        //*********************************************************************************************
        private void cbUpdateProgress(int num)
        {
            progressBar1.Value = num;
        }

        //********************************************************************************************
        //Method:     private void AddListBox(int num)
        //Purpose:    add number ti listbox
        //Parameters: int num- for adding random numbers (between 0-10000)set by a numupdown(between 1000-100000)
        //*********************************************************************************************
        private void AddListBox(int num)
        {
            DataBox.Items.Add(num);
        }
        //********************************************************************************************
        //Method:  private void SortList()
        //Purpose: sort all items in list box
        //*********************************************************************************************
        private void SortList()
        {
            int current = Convert.ToInt32(DataBox.Items.Count); // set current items in list 
            int temp = Convert.ToInt32(DataBox.Items[0]);       // temp varaible to store list and swap them later on for sorting 
            int count1, count2;                                 // count varaibles for looping through list

            // loop for hihg numbers
            for(count1=0;count1< current; count1++)
            {
                //loop for lower numbers
                for(count2=count1+1;count2< current; count2++)
                {
                    // if current item is higher that second item swap in acending order
                    if(Convert.ToInt32(DataBox.Items[count1])> Convert.ToInt32(DataBox.Items[count2]))
                    {
                        temp = Convert.ToInt32(DataBox.Items[count1]);
                        (DataBox.Items[count1]) = Convert.ToInt32(DataBox.Items[count2]);
                        (DataBox.Items[count2]) = temp;
                    }
                }
            }
        }

        private void Threading(object obj)
        {
            int counter = 0;
            Random rdm = new Random();

            if (obj is int max)
            {
                //the thread loop, loop until Stop pressed or max value
                while (_running && counter <= max)
                {
                    //invoke might throw ObjectDisposedException
                    try
                    {
                        //invoke on the progressbar to update with loop count
                        DataBox.Invoke(new DelVoidInt(AddListBox), rdm.Next(0,10001));
                        progressBar1.Invoke(new DelVoidInt(cbUpdateProgress), counter);
                    }
                    catch (ThreadStateException ex)
                    {
                        MessageBox.Show(ex.Message, "Using Invoke");
                    }

                    //update the loop count
                    ++counter;

                    //brief delay to slow down the thread
                    Thread.Sleep(2);
                }
            }
            //argument was not type int, exit the thread
            else
            {
                MessageBox.Show("Can't run the thread!", "Using Invoke");
            }
        }

        //generate button launches the thread and passes in the number of times to loop
        private void GENbutton_Click(object sender, EventArgs e)
        {
            GENbutton.Enabled = false;  // disable generate button
            SortButton.Enabled = false; // disable sort button
            STPButton.Enabled = true;   // enable stop button

            //create the thread with a parameter to pass in the int loop count value
            _thread = new Thread(new ParameterizedThreadStart(Threading));

            //make it a background thread
            _thread.IsBackground = true;

            //allow the thread loop to run
            _running = true;

            // update progress bar for thread start
            progressBar1.Maximum = (int)numUpDown.Value;

            //launch the thread with the int number of times to loop
            _thread.Start((int)numUpDown.Value);
            
        }

        // sort alll current values in list 
        private void SortButton_Click(object sender, EventArgs e)
        {
            SortList();
        }

        // occurs everytime when pressed
        // stop the thread and enable generate and sort buttons while disableing stopbutton
        private void STPButton_Click(object sender, EventArgs e)
        {
            _running = false;
            GENbutton.Enabled = true;
            SortButton.Enabled = true;
            STPButton.Enabled = false;
        }

    }
}
