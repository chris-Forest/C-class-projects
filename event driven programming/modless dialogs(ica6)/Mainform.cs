//*********************************************************************
//Program:    ICA6 – modeless drawing
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
using GDIDrawer;

namespace ica6
{
    public partial class Mainform : Form
    {
        CDrawer _draw = new CDrawer();  //create drawwindow
        SizeForm MYSizeDialog = null;   // size delegate refrence
        ColorForm MYColorDialog = null; // color delegate refrence
        Color _shapeColor;              //  used to set shape color made in colorform
        int _size;                      // used to set shape sie made in sizeform

        public Mainform()
        {
            InitializeComponent();
        }

        //allow mouse to draw in gdi window
        private void Mainform_Load(object sender, EventArgs e)
        {
            _draw.MouseLeftClick += this.GDI_MouseClick;
        }

        //********************************************************************************************
        //Method:     private void GetSize(int size)
        //Purpose:    sets _size to selected size in MYSizeDialog
        //            displays SizeLabel to size selected in MYSizeDialog
        //Parameters: int size is size made in MYSizeDialog
        //*********************************************************************************************
        private void GetSize(int size)
        {
            _size = size;
            SizeLabel.Text = size.ToString();
        }

        //********************************************************************************************
        //Method:     private void ColorGet(Color c)
        //Purpose:    sets _shapeColor to selected color in MYColorDialog
        //            sets DrawColorBox to same value
        //Parameters: Color c is color selected in MYColorDialog
        //*********************************************************************************************
        private void ColorGet(Color c)
        {
            _shapeColor = c;
            DrawColorBox.BackColor = c;
        }

        // occurs on every mouse click
        // draws shape where mouse is clicked
        public void GDI_MouseClick(Point pos, CDrawer cd)
        {
            _draw.AddCenteredEllipse(pos, _size, _size, _shapeColor);
        }

        // occurs when colorDialogBox is Checked
        // create ColorForm dialog
        // call back to deleagates in ColorForm
        // checkbox is cleard when dialog window is closed 
        private void colorDialogBox_CheckedChanged(object sender, EventArgs e)
        {
            // if check open ColorForm dialog
            if (colorDialogBox.Checked)
            {
                // if set to null create and open window for color adjusting
                if (MYColorDialog == null)
                {
                    MYColorDialog = new ColorForm();
                    MYColorDialog._GetColor = new delGetShapeColor(ColorGet);
                    MYColorDialog._Close = new delColorClose(ColorClearCheckbox);
                }
                MYColorDialog.Show();
            }
            //if window has been cleared, hide the dialog
            else
            { 
                MYColorDialog.Hide();
            }
        }

        // occurs when izeDialogBox is Checked
        // create SizeForm dialog
        // call back to deleagates in SizeForm
        // checkbox is cleard when dialog window is closed 
        private void SizeDialogBox_CheckedChanged(object sender, EventArgs e)
        {
            // if check open SizeForm dialog
            if (SizeDialogBox.Checked)
            {
                // if set to null create and open window for size adjusting
                if (MYSizeDialog == null)
                {
                    MYSizeDialog = new SizeForm();
                    MYSizeDialog._size = new delSize(GetSize);
                    MYSizeDialog._Close = new delSizeClose(SizeClearCheckbox);
                }
                MYSizeDialog.Show();
            }
            //if window has been cleared, hide the dialog
            else
            {
                MYSizeDialog.Hide();
            }
        }
        //********************************************************************************************
        //Method:  private void SizeClearCheckbox()
        //Purpose: callback to clear the checkbox
        //*********************************************************************************************
        private void SizeClearCheckbox()
        {
            SizeDialogBox.Checked = false;
        }

        //********************************************************************************************
        //Method:  private void ColorClearCheckbox()
        //Purpose: callback to clear the checkbox
        //*********************************************************************************************
        private void ColorClearCheckbox()
        {
            colorDialogBox.Checked = false;
        }
    }
}
