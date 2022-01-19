//1202_CMPE2800_MMC
//Ezekiel Enns
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
using System.Reflection;
using System.Text.RegularExpressions;

#region project functionlity(notes)
/* PARTS
 * datagrid view
 *      get table as a file, populate grid view
 *      only req to get elements for 1-99 inclusive(can go above this)     
 *      results in datagrid view must come from anonmous types made by linq expressions
 *      
 * buttons
 *      sorts grid view
 *      buttons will clear inputs and ovveride all current outputs
 *      
 * isolate in datagridview to show specfic elements being called from chem formula
 *      2 - outlines
 *          0-state 
 *          1-calculation
 *      
 * two states to calculator
 * zero state:
 *      Atomic number, 
 *      Name Symbol, 
 *      Mass
 *      
 * calc state:
 *      Element
 *      Count
 *      Mass per 1
 *      Total mass per element count(count*mass=total mass) 
 * 
 * Checmical Search
 * 
 *      use of regex class is needed here
 *      takes formula and parses it (elemets in use and there counts)
 *      formula is taken and aprox molar mass is calculated
 *      using color codeing for molar mass textBox display indicating success(green)/failure(red)
 *    
 * apply aprox. molar mass formula
 *      Molar mass= Mass of substance(in grams)/ number of mole of a substance *      
 *
 */
#endregion 

namespace Chris_Zeek_MMC
{
    public partial class Form1 : Form
    {
        private List<atom> _pTableDic = new List<atom>();


        public Form1()
        {
            InitializeComponent();
            loadConfig();
            NameButton.Click += SortOhMatic;
            SymButton.Click += SortOhMatic;
            AtomicNumButton.Click += SortOhMatic;
            ChemFormTextBox.TextChanged += ChemFormTextBox_TextChanged;
        }

        #region events
        /// <summary>
        /// runs regex parse everytime input is added,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChemFormTextBox_TextChanged(object sender, EventArgs e)
        {
            //removing anything that dose not have use

            //creating a dictionary based on regex finds
            Regex rx = new Regex(@"(?'sym'([A-Z][a-z])|[A-Z])((?'moles'\d+)|(?=[A-Z])|$)");
            Dictionary<string, int> foundDic = new Dictionary<string, int>();
            string value = ChemFormTextBox.Text;
            foreach (Match item in rx.Matches(value))
            {
                string sym = item.Groups["sym"].Value;
                int moles = 0;
                if (item.Groups["moles"].Length > 0)
                    moles = int.Parse(item.Groups["moles"].Value);
                else
                    moles = 1;

                if (foundDic.ContainsKey(sym))
                    foundDic[sym] += moles;
                else
                    foundDic.Add(sym, moles);
            }

            //this determins weather everything fit into the regex above
            value = rx.Replace(value, "");

            //joining found dic with matches from elements to make new dic that contains all info needed for info
            var Elements = from f in foundDic
                           join A in _pTableDic on f.Key equals A.Symbol
                           select new
                           {
                               sym = f.Key,
                               name = A.Name,
                               count = f.Value,
                               mass = A.Mass,
                               tMass = A.Mass * f.Value
                           };

            DGV.Rows.Clear();

            //when a value is invalid it will turn red and show the user the table
            if (ChemFormTextBox.Text.Trim().Length == 0 || value.Length != 0 || foundDic.Count() != Elements.Count())
            {
                //setting colors
                ChemFormTextBox.BackColor = Color.Red;
                //so this is a common glitch that happens, if you just change 
                //the bkg color of a readonly it allows you to change the for color
                MassTextBox.BackColor = Color.White;
                MassTextBox.ForeColor = Color.Gray;

                //if the header is not set we know this needs to happen
                if (DGV.Columns[0].HeaderText != "AtomicNumber")
                {
                    DGV.Columns[0].HeaderText = "AtomicNumber";
                    DGV.Columns[1].HeaderText = "Name";
                    DGV.Columns[2].HeaderText = "Symbol";
                    DGV.Columns[3].HeaderText = "Mass";

                    foreach (atom item in _pTableDic)
                        DGV.Rows.Add(item.getDGVrows);
                }
            }

            //when everything is valid it will work
            else
            {
                //setting colors
                MassTextBox.ForeColor = Color.Green;
                MassTextBox.BackColor = Color.White;
                ChemFormTextBox.BackColor = Color.White;

                //adding the new sorted rows
                if (DGV.Columns[0].HeaderText != "Elements")
                {
                    DGV.Columns[0].HeaderText = "Elements";
                    DGV.Columns[1].HeaderText = "Count";
                    DGV.Columns[2].HeaderText = "Mass";
                    DGV.Columns[3].HeaderText = "TotalMass";
                }

                //calculating mass
                double ct = 0;
                foreach (var item in Elements)
                {
                    DGV.Rows.Add(item.name, item.count, item.mass, item.tMass);
                    ct += item.mass * item.count;
                }
                MassTextBox.Text = $"{ct} g/mol";
            }
        }

        /// <summary>
        /// loads a config file into a data grid view 
        /// and sets data grid view to display it
        /// </summary>
        private void SortOhMatic(object sender, EventArgs e)
        {
            if (sender is Control arg)
            {
                IOrderedEnumerable<atom> sort;

                //since the previous event handlers were just diffrent by this line
                //it makes more sense to compact this simulare functionality all into one
                switch (arg.Name)
                {
                    case "SymButton":
                        sort = from row in _pTableDic orderby row.Symbol.Length, row.Symbol select row;
                        break;
                    case "AtomicNumButton":
                        sort = from row in _pTableDic orderby row.aNum select row;
                        break;
                    case "NameButton":
                    default:
                        sort = from row in _pTableDic orderby row.Name select row;
                        break;
                }

                ChemFormTextBox.Clear();
                DGV.Rows.Clear();

                //adding the new sorted rows, dam i love linq
                foreach (var item in sort)
                    DGV.Rows.Add(item.getDGVrows);
            }
        }
        #endregion

        private void loadConfig()
        {
            //making sure we dont initalize it twice
            if (_pTableDic.Count == 0)
            {
                //row tracker
                int i = 0;
                var data = from column in Properties.Resources.configData.Replace("\r\n", "").Split(',')
                               //grouping all columns by groups of 4
                           group column by (i++ / 4) into rows
                           //only selecting ones who have 4 rows
                           where rows.Count() == 4
                           select new atom(Convert.ToInt32(rows.ElementAt(0)), rows.ElementAt(1), rows.ElementAt(2), Convert.ToDouble(rows.ElementAt(3)));

                //converting data set into dic
                _pTableDic = data.ToList<atom>();

                //making taking all atoms in data set and throwing them in to dgv
                foreach (atom item in data)
                {
                    DGV.Rows.Add(item.getDGVrows);
                }
            }
        }
    }
    /// <summary>
    /// a class that contains all the information for a atom
    /// </summary>
    public class atom
    {
        public string Name, Symbol;
        public int aNum;
        public double Mass;

        //getting Data grid view rows
        public string[] getDGVrows { get => new string[] { aNum.ToString(), Name, Symbol, Mass.ToString() }; }

        public atom(int anum, string name, string symbol, double mass)
        {

            aNum = anum;
            Name = name;
            Symbol = symbol;
            Mass = mass;
        }
    }
}
