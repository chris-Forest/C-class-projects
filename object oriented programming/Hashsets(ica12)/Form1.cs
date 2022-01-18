using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using static System.Console;

// HashCode Specifications :
//
// offsetHash : calculated as Y * 1000 + X
// multiplyHash : calculated as Y * X
// additionHash : calculated as Y + X
// fixedHash - not calculated : 1


namespace ica13_HashsetProfile
{
    public partial class Form1 : Form
    {
        CDrawer _can = new CDrawer(1000, 1000, false);
        HashSet<CTile> _tiles = new HashSet<CTile>();
        Stopwatch _stopwatch = new Stopwatch();
        Random _rnd = new Random(0);
        public Form1()
        {
            InitializeComponent();
            Text = "ica12 HashSet Profiler";
            // Set button event callbacks with Tag values
            _btnPopSeq.Tag = -1; // sequential run
            _btnPopSeq.Click += _btnPopulate_Click;
            _btnPop0.Tag = 0;
            _btnPop0.Click += _btnPopulate_Click;
            _btnPop1.Tag = 1;
            _btnPop1.Click += _btnPopulate_Click;
            _btnPop2.Tag = 2;
            _btnPop2.Click += _btnPopulate_Click;
            _btnPop3.Tag = 3;
            _btnPop3.Click += _btnPopulate_Click;
        }

        private void _btnPopulate_Click(object sender, EventArgs e)
        {
            if (!(sender is Button b)) return; // not a button, done
            if (!(b.Tag is int tag)) return; // tag object not an int, done
            _tiles.Clear();
            int numCols = _can.ScaledWidth / CTile._TileSize; // Width of CDrawer in CTiles
            int maxTiles = _can.ScaledHeight / CTile._TileSize * _can.ScaledWidth / CTile._TileSize;// Total tiles, you calculate to get started, hint : your expression should evaluate to 40_000

            _rnd = new Random(0);

            // sequential test, add column by column, row by row, typewriter style
            if (tag < 0) 
            {
                _can.Clear();
                CTile.ResetStats();
                int iDups = 0;
                int col = 0;
                _stopwatch.Restart();
                while (_tiles.Count < maxTiles)
                {
                    CTile t = new CTile(col % numCols, col / numCols); // sequence col, row
                    col++;
                    if (!_tiles.Contains(t))
                    {
                        _tiles.Add(t);
                        t.Render(_can);
                        _can.Render();
                    }
                    else
                        iDups++;
                }
                _stopwatch.Stop();

                WriteLine($"Equals calls : {CTile._CompCount}");
                WriteLine($"GetHashCode calls : {CTile._HashCount}");
                WriteLine($"Dups : {iDups}");
                WriteLine($"Elapsed : {_stopwatch.ElapsedMilliseconds}ms");
            }
            // Not sequential Add, Random Tile location Add
            else
            {
                _can.Clear();
                CTile.ResetStats();
                CTile._HashTest = tag; // switch the GetHashCode Algorithm/statement
                int iDups = 0;
                int col = 0;
                _stopwatch.Restart();
                while (_tiles.Count < maxTiles)
                {
                    CTile t = new CTile(_rnd.Next(numCols), _rnd.Next(numCols));
                    col++;
                    if (!_tiles.Contains(t))
                    {
                        _tiles.Add(t);
                        t.Render(_can);
                        _can.Render();
                    }
                    else
                        iDups++;
                }
                _stopwatch.Stop();

                WriteLine($"Equals calls : {CTile._CompCount}");
                WriteLine($"GetHashCode calls : {CTile._HashCount}");
                WriteLine($"Dups : {iDups}");
                WriteLine($"Elapsed : {_stopwatch.ElapsedMilliseconds}ms");
            }
        }
    }
    public class CTile
    {
        public const int _TileSize = 5;
        private int _X;
        private int _Y;
        public static UInt64 _CompCount { get; private set; } // Equals() call count
        public static UInt64 _HashCount { get; private set; } // GetHashCode() call count
                                                              // See : GetHashCode - User Sets, function returns calculated hash expressions based on this selection
        public static int _HashTest { get; set; } = 0;
        public static void ResetStats()
        {
            _CompCount = _HashCount = 0;
        }
        //initialze tile sizes
        public CTile(int iCol, int iRow)
        {
            if (_TileSize < 2)
                throw new ArgumentException("The tile size must be >= 2");
            _X = iCol;
            _Y = iRow;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is CTile arg))
                return false;
            ++_CompCount;
            return _X.Equals(arg._X) && _Y.Equals(arg._Y);
        }
        public override int GetHashCode()
        {
            int results = 0;
            ++_HashCount;
            // for each _HashTest value, return the computed HashCode
            switch (_HashTest)
            {
                //offset
                case 0:                    
                    results = _Y * 1000 + _X;
                    break;
                //multiply
                case 1:
                    results = _Y * _X;
                    break;
                //add
                case 2:
                    results = _Y + _X;
                    break;
                //fixed
                case 3:
                    results = 1;
                    break;
            }
            return results;
        }
        public void Render(CDrawer dr)
        {
            dr.AddRectangle(_X * _TileSize, _Y * _TileSize, _TileSize - 1, _TileSize - 1, Color.Red);
        }
    }
}