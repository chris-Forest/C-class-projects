//Submission Code : 1201_2300_A11
//Chris forest
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Diagnostics.Trace; // Pull Trace static helpers local, ie. WriteLine()

namespace chris_ica11
{
    public partial class Form1 : Form
    {
        private Dictionary<byte, int> myDicTable = new Dictionary<byte, int>();
        private int freqAvg;
        private BindingSource _bs = new BindingSource(); // Used to wire DATA <> DataGridView

        public Form1()
        {
            InitializeComponent();
            DGV.DataSource = _bs;
            DGV.RowHeadersVisible = false;
            DGV.CellFormatting += DGV_CellFormatting;
            DGV.ColumnHeaderMouseClick += ColumnHeaderClick;
            LoadButton.Click += LoadButton_Click;
            Avgbutton.Click += Avgbutton_Click;
            Text="File-byte-o-tron";
        }      

        /// <summary>
        /// opens a file dialog window to a set location(my pictures) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadButton_Click(object sender, EventArgs e)
        {
            byte []pic;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);//set path to pictures

            //if dialog window ok is pressed
            //take action
            if(openFile.ShowDialog()==DialogResult.OK)
            {
                //set picture name and get byte data from loaded picture
                string path = openFile.FileName;
                pic = File.ReadAllBytes(path);

                //itterate through loaded picture
                for (int i = 0; i < pic.Length; i++)
                {
                    //if dictionary has key of byte, add to dictionary collection
                    if(myDicTable.ContainsKey(pic[i]))
                    {
                        myDicTable[pic[i]]++;
                    }
                    //otherwise dictionary is one
                    else
                    {
                        myDicTable[pic[i]] = 1;
                    }
                }
                //then show data in gridview
                ShowDictionary();
            }           
        }

        /// <summary>
        /// sort by key or value depending on what column us clicked on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumnHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //byte ordering(key)
            if (e.ColumnIndex==0)
            {               
                myDicTable= myDicTable.OrderBy(kvp => kvp.Key).ToDictionary(k=>k.Key,v=>v.Value);
            }

            //byte(key) ordering with freq(val) sort
            if (e.ColumnIndex == 1)
            {
                List<KeyValuePair<byte, int>> kvpList = new List<KeyValuePair<byte, int>>(myDicTable.ToList());
                kvpList.Sort((b, i) => b.Value.CompareTo(i.Value));
                myDicTable = kvpList.ToDictionary(k => k.Key, v => v.Value);                
            }
            //then show data in gridview
            ShowDictionary();
        }

        /// <summary>
        /// remove all dictionary entries that are less than the current frequency average
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Avgbutton_Click(object sender, EventArgs e)
        {
            myDicTable = myDicTable.Where(entry => entry.Value >= freqAvg).ToDictionary(k => k.Key, v => v.Value);

            //if no picture is loaded just retun to prevent crashing
            if (freqAvg == 0)
                return;

            //then show data in gridview
            ShowDictionary();
        }

        /// <summary>
        /// format data gridvew cell style accordingly 
        /// to above or below byte avg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex==1&&e.Value!=null)
            {
                //if cell value is less then the average bytes set background color to coral
                if ((int)e.Value < freqAvg)
                {
                    e.CellStyle.BackColor = Color.Coral;
                }
                //else background color is green for above avg bytes
                else
                    e.CellStyle.BackColor = Color.Green;
            }
        }

        /// <summary>
        /// after a picture is loaded or avg button is hit or colum header is sorted,
        /// display data accordingly again with this method
        /// </summary>
        private void ShowDictionary()
        {            
            freqAvg = (int)myDicTable.Average(x => x.Value);
            Avgbutton.Text = $"Average : {freqAvg}";//=null; ???first,then???
            _bs.DataSource = myDicTable.ToList();
            DGV.Columns[0].HeaderText = "Key";
            DGV.Columns[1].HeaderText = "Value";
            DGV.Columns[0].DefaultCellStyle.Format = "X2";
        }
    }
}
