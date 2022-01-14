//**************************************************************************************************************************
//Program:    ICA2 - text saving/opening
//Author:     Chris Forest
//Class:      CNT2F
//Instructor: Kevin More
//**************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ICA2
{
    public partial class Form1 : Form
    {
        private bool txtChanged = false; // boolean if file has changed text or not 

        public Form1()
        {
            InitializeComponent();
        }

        // when loaded title is cleared
        //and when saved file(s) are loaded save name is displayed
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "";// clears form title
        }

        // when textbox is changed bool varaible changes to true
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            txtChanged = true;
        }

        //event happens when open file is pressed
        // if text box has changed or not been saved since last edit
        // it will ask to save, if not it will prompt the open window
        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();                  // creates an open dialog window
            open.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; // filters what file to show in dialog box
            open.FilterIndex = 2;                                        // sets which filter opyin is shown first
            open.RestoreDirectory = true;                                // directory is restored when the dialog box is closed. 
            open.FileName = "*.txt";                                     // nmae of file that is opened

            // if textbox was changed since last save prompt to ask for a save dialog box
            if (txtChanged)
            {
                // promppt for result to save or not
                var result = MessageBox.Show("do you want to save current file?", "save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // if yes to save, save file
                if (result == DialogResult.Yes)
                {
                    SaveButton_Click(sender, e);
                }
            }

            // if no to save current file prompt to open new file. with error checking
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader read = new StreamReader(open.FileName);
                    this.textBox.Text = read.ReadToEnd();
                    this.Text = open.SafeFileName;
                    read.Close();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        // event occurs when save is pressed
        // checks if file has ".txt" in its name
        // if not ask to save file
        // otherwise save automatcially
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();                  // save dialog window can be opemed 
            save.FileName = "*.txt";                                     // nmae of file that is saved
            save.RestoreDirectory = true;                                // directory is restored when the dialog box is closed
            save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; // filters what files can be saved as in dialog box
            save.DefaultExt = "txt";                                     // sets default save flie as 

            //if file doen't have ".txt" save file with name
            if(!this.Text.Contains("*.txt"))
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter write = new StreamWriter(save.FileName);
                    write.Write(this.textBox.Text);
                    write.Close();
                }
            }
        }

        // event happens when closing in anyway
        // checks if textbox has text 
        //ask user if they want to save file before exiting
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(txtChanged)
            {
                if (MessageBox.Show("exit without saving?", "exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
