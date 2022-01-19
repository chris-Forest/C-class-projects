//Submission code 1202_CMPE2800_A03
//Chris Forest

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

namespace chris_ica03_var
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OPENbutton.Click += OPENbutton_Click;
        }

        private void OPENbutton_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; // filters what file to show in dialog box
            open.FilterIndex = 2;                                        // sets which filter opyin is shown first
            open.RestoreDirectory = true;                                // directory is restored when the dialog box is closed. 
            open.FileName = "*.txt";
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            if (open.ShowDialog()==DialogResult.OK)
            {
                //put contents of file to a string
                var read = new StreamReader(open.FileName).ReadToEnd().Split('\n','\r').ToList();
                //remove all whitespace
                read.RemoveAll(ws => ws.Trim() == "");

                //sum ascii val dictionary keyed by lines from file
                var dic = read.Distinct().ToDictionary(kk => kk, v => v.Sum(s => s));

                //pull sumed values from previous ToDictionary method as a new list of strings
                var dic2 = dic.Values.Distinct().ToDictionary(k => k, k => new List<string>());
                foreach (var item in dic)
                {
                    if(dic2.ContainsKey(item.Value))
                    {
                        dic2[item.Value].Add(item.Key);
                    }
                }
                //order list by key
                var sortV = dic2.OrderBy(k => k.Key);

                //display outputs to rich text box
                richTextBox1.Text += $"Lowest ascii sum: {sortV.First().Key}\n" +
                    $"lowest string : {sortV.First().Value.Min()}\n" +
                    $"higest ascii sum: {sortV.Last().Key}\n" +
                    $"highest string : {sortV.Last().Value.Max()} " +
                    $"/ {new string(sortV.Last().Value.Max().OrderBy(c=>c).ToArray())}\n" +
                    $"biggest Collestion count : {sortV.Max(m=>m.Value.Count())} " +
                    $"- ascii sum : {sortV.Single(mbox=>mbox.Value.Count()==sortV.Max(m => m.Value.Count())).Key}";

            }
        }
    }
}
