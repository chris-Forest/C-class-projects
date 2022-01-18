// Project : sudoku
// By Chris Forest
// ///////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace Sudoku_lab01_
{
    public partial class Form1 : Form
    {
        private static int[,] _sudoku = new int[9, 9]; //2d array to laod puzzles
        int[,] _store = new int[9, 9];                 //store the soled puzzle
        int _row=9, _col=9;                            // ints to run throught txt files and display puzzles
        bool _good;                                    // bool for if puzzle is finished
        bool _solved;                                  // bool to check for a solved puzzle

        public Form1()
        {
            InitializeComponent();
            _loadPuzMenuItem.Click += _loadPuzzle_Click;      //binder for loading sudoku puzzles menu strip item
            _solvePuzzleMenuItem.Click += _solvePuzzle_Click; //binder for solving sudoku uzzles menu strip item
            _SudokuGridView.ColumnCount = 9;                  //set column count in datagrid
            _SudokuGridView.ColumnHeadersVisible = false;     //hide header blocks for the columns in gridview
            _SudokuGridView.RowHeadersVisible = false;        //hide header clocks for rows in gridview
        }      

        //  //////////////////////////////////////////////////////
        //  event  to solve puzzle
        //  done with helper ValidSpot and solve
        //  //////////////////////////////////////////////////////
        private void _solvePuzzle_Click(object sender, EventArgs e)
        {
            //_solvePuzzleMenuItem.Enabled = false;

            // set puzzle to not solved,size array to grid
            _solved = false;
            _sudoku = new int[_row, _col];

            //copy solved puzzle to array
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _sudoku[i, j] = _store[i, j];
                }
            }
            //start at 0,0 in grid
            solve(0, 0);
            //if puzzle not be solved
            if(!_solved)
            {
                MessageBox.Show("too bad not solvable");
                _toolStripStatus.Text = "puzzle not solvable";
            }
        }

        //  //////////////////////////////////////////////////////
        //  main load method
        //  load desired puzzle
        //  //////////////////////////////////////////////////////
        private void _loadPuzzle_Click(object sender, EventArgs e)
        {
            //make open dailog, set the filterand path
            OpenFileDialog getPuzzle = new OpenFileDialog();
            getPuzzle.Filter = "Puzzle Files(*.txt)|*.txt|All files(*.*)|*.*";
            getPuzzle.FilterIndex = 2;
            getPuzzle.FileName = "*.txt";
            getPuzzle.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //open dialog box,check to see if its valid and display it, otherwise do nothing
            if (getPuzzle.ShowDialog() == DialogResult.OK)
            {
                //call helper method that load puzzle and check if its valid, 
                //then display it and show waht file is loaded
                LoadPuzzle(getPuzzle.FileName);
                ShowPuzzle(_sudoku);
                _toolStripStatus.Text = "Loaded Puzzle: " + getPuzzle.SafeFileName;                   
            }
            else
                return;
        }

        //  //////////////////////////////////////////////////////
        //  helper method to check the loaded puzzle
        //  also accepts file name as a string
        //  //////////////////////////////////////////////////////
        private bool LoadPuzzle(string name)
        {
            string puzzle; //string to load files
            int row = 0;   // ints to run through file and set them in the data grid
            int col = 0;            
            char[] lines = { '[',']','\n','\r',','};//filter out unwanted items in txt file

            //check if the file exists
            if(!File.Exists(name))
            {
                MessageBox.Show($"{name},not here");
                _toolStripStatus.Text = $"file:{name},not here";
                return false;
            }
            //load puzzle file
            // remove unwanted characters in txt file
            //itterate through file and populate gridview
            try
            {
                puzzle=File.ReadAllText(name);                
                string[] line = puzzle.Split(lines,StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < line.Length; i++)
                {
                    if(line[i].Length==1)
                    {
                        _sudoku[row,col] = Convert.ToInt32(line[i]);
                        row++;
                        if (row == 9)
                        {
                            row = 0;
                            col++;
                        }                            
                    }                    
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "err", MessageBoxButtons.OK,MessageBoxIcon.Error);
                _toolStripStatus.Text = err.Message;
                return false;
            }
            return true;
        }

        //  //////////////////////////////////////////////////////
        //  main method to show puzzles
        //  puzzle loads with design astetics 
        //  //////////////////////////////////////////////////////
        private void ShowPuzzle(int[,] puz)
        {          
            //string array to display numbers in txt file
            string[] theNumbers = new string[_col];

            //clar grid before adding to it
            _SudokuGridView.Rows.Clear(); 
            
            //add values to table
            for (int row = 0; row < _row; row++)
            {
                //get column values
                for (int column = 0; column < _col; column++)
                {                  
                    //convet zeros to spaces
                    if (_sudoku[row, column].ToString().Equals("0"))
                        theNumbers[column] = "";
                    else
                        theNumbers[column] = puz[row, column].ToString();//add rows
                    _SudokuGridView.Rows[row].Cells[column].Style.BackColor = Color.Orange;//**********
                }
                //fill grid and set size
                _SudokuGridView.Rows.Add(theNumbers);                
            }
            
            for (int i = 0; i < 9; i++)
            {
                DataGridViewColumn colum = _SudokuGridView.Columns[i];
                colum.Width = (int)(_SudokuGridView.Width / 9f);
                DataGridViewRow row = _SudokuGridView.Rows[i];
                row.Height = (int)(_SudokuGridView.Width / 9f);                
            }

            _SudokuGridView.Width = _SudokuGridView.Columns[1].Width * 9;
            _SudokuGridView.DefaultCellStyle.Font = new Font("Arial", 20f, GraphicsUnit.Pixel);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _SudokuGridView.Rows[i].Cells[j].Style.BackColor = Color.Orange;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    _SudokuGridView.Rows[i].Cells[j].Style.BackColor = Color.LightBlue;
                    _SudokuGridView.Rows[j].Cells[i].Style.BackColor = Color.LightBlue;
                }
            }

            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    _SudokuGridView.Rows[i].Cells[j].Style.BackColor = Color.Orange;
                }
            }
            _SudokuGridView.Refresh();
        }

        //  //////////////////////////////////////////////////////
        //  checks to see if value in cell in puzzle s valid
        //  and can be set in cell
        //  //////////////////////////////////////////////////////
        private bool ValidSpot(int row, int column, int val)
        {
            //check rows and colums
            for (int i = 0; i < 9; i++)
            {
                if (val == _sudoku[row, i])
                {
                    _good = false;
                    return false;
                }
                if (val == _sudoku[i, column])
                {
                    _good = false;
                    return false;
                }
            }

            //check each 3x3 grid
            //top 3 rowsXall columns
            if (row < 3)
            {
                //check top left 3x3
                if (column < 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (val == _sudoku[i, j])
                            {
                                _good = false;
                                return false;
                            }
                        }
                    }
                }

                //check top mid 3x3
                if (column < 6 && column > 2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            if (val == _sudoku[i, j])
                            {
                                _good = false;
                                return false;
                            }
                        }
                    }
                }

                //check top right 3x3
                if (column > 5)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            if (val == _sudoku[i, j])
                            {
                                _good = false;
                                return false;
                            }
                        }
                    }
                }
            }

            //check mid 3 rows
            if (row < 6 && row > 2)
            {
                //check mid left 3x3
                if (column < 3)
                {
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (val == _sudoku[i, j])
                            {
                                _good = false;
                                return false;
                            }
                        }
                    }
                }

                //check center 3x3
                if (column < 6 && column > 2)
                {
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            if (val == _sudoku[i, j])
                            {
                                _good = false;
                                return false;
                            }
                        }
                    }
                }

                //check mid right 3x3
                if (column > 5)
                {
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            if (val == _sudoku[i, j])
                            {
                                _good = false;
                                return false;
                            }
                        }
                    }
                }
            }

            // check btm 3 rows
            if (row > 5)
            {
                //check bottom left 3x3
                if (column < 3)
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (val == _sudoku[i, j])
                            {
                                _good = false;
                                return false;
                            }
                        }
                    }
                }

                //check bottom mid 3x3
                if (column < 6 && column > 2)
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            if (val == _sudoku[i, j])
                            {
                                _good = false;
                                return false;
                            }
                        }
                    }
                }
                
                //check bottom right 3x3
                if (column > 5)
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            if (val == _sudoku[i, j])
                            {
                                _good = false;
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }


        //  //////////////////////////////////////////////////////
        //  main method to solve puzzle
        //  doe recursivly
        //  //////////////////////////////////////////////////////
        private void solve(int row, int col)
        {
            bool _ifvalid; //bool to check cell is filled or not

            // check the boundaries of sudoku grid
            if (row < 9)
            {
                //run if cell =0 in loaded puzzle
                if (_store[row, col] == 0)
                {
                    //check numbers1-9 can be stored in cell
                    for (int i = 0; i < 10; i++)
                    {
                        //reset bool for each itteration
                        _ifvalid = true;

                        //check if value is in a valid spot in puzzle
                        if (_ifvalid)
                            _ifvalid = ValidSpot(row, col, i);

                        //if check passes
                        if (_ifvalid)
                        {
                            _good = true;
                            _sudoku[row, col] = i;

                            //if on lest cell in row move to next or column
                            if (col == 8)
                                solve(row + 1, 0);
                            else
                                solve(row, col + 1);
                            if (_solved)
                                return;
                        }
                    }
                    //if check fails set cell to zero
                    _sudoku[row, col] = 0;
                }

                //if puzzle cell had a value, run
                else
                {
                    //if on lest cell in row move to next or column
                    if (col == 8)
                        solve(row + 1, 0);
                    else
                        solve(row, col + 1);
                }                
            }

            //if made to last cell
            else
            {
                if (_good)// if puzzle is good wrap up
                {
                    //show solved puzzle
                    ShowPuzzle(_sudoku);
                    _toolStripStatus.Text = "Loaded puzzle solved";
                    _solved = true;
                    return;
                }                
            }            
            return;
        }       
    }
}
