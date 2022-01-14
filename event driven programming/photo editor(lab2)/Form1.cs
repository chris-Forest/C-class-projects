//*********************************************************************
//Program:    Lab 2 – picture editor
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

namespace lab2
{
    public partial class Form1 : Form
    {
        private const int _MAXPIXEL = 255; // max value for a pixel color component
        private const int _MINPIXEL = 0;   // min value for a pixel color component
        private int _count1;               // count the pixels in loop
        private int _count2;               // count the pixels in loop
        private int _Alpha;                // individual Alpha(transparency) color value for picture modification
        private int _Red;                  // individual R color value for picture modification   
        private int _Green;                // individual G color value for picture modification
        private int _Blue;                 // individual B color value for picture modification
        private Color _colorPixel1;        // values for the original pictues pixels  
        private Color _colorPixel2;        // values for the modified pictues pixels
        private Bitmap _Image;             // stores loaded image that will be edtied 
        
        public Form1()
        {
            InitializeComponent();
            Transformbutton.Enabled = false;
            this.Text = "";
        }
        // set contrast to default
        
        //occurs everytime when pressed
        // loads a picture file with error checking
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.RestoreDirectory = true;
            open.FilterIndex = 2;
            open.Filter = "image files (*.bmp,*.jpg,*.jpeg,*.png)|*.jpg; *.bmp; *.png; *.jpeg|All files (*.*)|*.*";
            open.FileName = "*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                Transformbutton.Enabled = true;
                try
                {
                    _Image = new Bitmap(open.FileName);
                    pictureBox.Image = _Image;
                    this.Text = open.SafeFileName;
                    progressBar.Maximum = _Image.Width * _Image.Height;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        //occurs everytime when trackbar is adjusted and transform button is pressed
        //tracks colorsvalue for each modification function
        //adjusts labels accordingly to what modificaton is being used
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            // if contrast is selected change all labels 
            if (ContrastRadioButton.Checked)
            {
                leftLabel.Text = "Less";
                midLabel.Text = trackBar.Value.ToString();
                RightLabel.Text = "More";
            }

            // if black and white is selected change all labels 
            if (BlkToWhiteRadioButton.Checked)
            {
                leftLabel.Text = "Less";
                midLabel.Text = trackBar.Value.ToString();
                RightLabel.Text = "More";
            }

            // if tint is selected change all labels 
            if (TintRadioButton.Checked)
            {
                leftLabel.Text = "Red";
                midLabel.Text = "0";
                if (trackBar.Value > 50)
                    midLabel.Text = $"To Green {trackBar.Value-50}";
                else if (trackBar.Value < 50)
                    midLabel.Text = $"To Red {50-trackBar.Value}";
                RightLabel.Text = "Green";
            }

            // if noise is selected change all labels 
            if (NoiseRadioButton.Checked)
            {
                leftLabel.Text = "Less";
                midLabel.Text = trackBar.Value.ToString();
                RightLabel.Text = "More";
            }
        }

        //********************************************************************************************
        //Method:  private void Contrast()
        //Purpose: adjust the contast in accordance with a trackbar
        //         if color value is higher that 128 it will increase color strenght by 1/5th
        //         if color value is lower that 128 it will decrease color strenght by 1/5th
        //Returns: void- returns no value
        //*********************************************************************************************
        private void Contrast()
        {
            int ratioStrength = (trackBar.Value / 5); // adjust contrast in accordance of 1/5 the value of the trackbar
            
            // go through all pixels in loaded image
            for (_count1 = 0; _count1 < _Image.Width; _count1++)
            {
                for (_count2 = 0; _count2 < _Image.Height; _count2++)
                {
                    //progressbar increments up to max
                    progressBar.Value++;

                    // get color of pixels and component value
                    _colorPixel1 = _Image.GetPixel(_count1, _count2);
                    _Alpha = (int)_colorPixel1.A;
                    _Red = (int)_colorPixel1.R;
                    _Green = (int)_colorPixel1.G;
                    _Blue = (int)_colorPixel1.B;

                    // test A pixeles relative to 128, adjust and test for range
                    if (_colorPixel1.A > 128)
                    {
                        _Alpha += ratioStrength;
                        if (_Alpha > _MAXPIXEL)
                            _Alpha = _MAXPIXEL;
                    }
                    else if (_colorPixel1.A < 128)
                    {
                        _Alpha -= ratioStrength;
                        if (_Alpha < _MINPIXEL)
                            _Alpha = _MINPIXEL;
                    }

                    //test red pixeles relative to 128, adjust and test for range
                    if (_colorPixel1.R > 128)
                    {
                        _Red += ratioStrength;
                        if (_Red > _MAXPIXEL)
                            _Red = _MAXPIXEL;
                    }
                    else if (_colorPixel1.R < 128)
                    {
                        _Red -= ratioStrength;
                        if (_Red < _MINPIXEL)
                            _Red = _MINPIXEL;
                    }

                    //test green pixeles relative to 128, adjust and test for range
                    if (_colorPixel1.G > 128)
                    {
                        _Green += ratioStrength;
                        if (_Green > _MAXPIXEL)
                            _Green = _MAXPIXEL;
                    }
                    else if (_colorPixel1.G < 128)
                    {
                        _Green -= ratioStrength;
                        if (_Green < _MINPIXEL)
                            _Green = _MINPIXEL;
                    }

                    //test blue pixeles relative to 128, adjust and test for range
                    if (_colorPixel1.B > 128)
                    {
                        _Blue += ratioStrength;
                        if (_Blue > _MAXPIXEL)
                            _Blue = _MAXPIXEL;
                    }
                    else if (_colorPixel1.B < 128)
                    {
                        _Blue -= ratioStrength;
                        if (_Blue < _MINPIXEL)
                            _Blue = _MINPIXEL;
                    }

                    // get the modifyed picture ,set it to new color values
                    _colorPixel2 = new Color();
                    _colorPixel2 = Color.FromArgb(_Alpha, _Red, _Green, _Blue);
                    _Image.SetPixel(_count1, _count2,_colorPixel2);
                }
            }
            // return chamged color image
            // reset progress bar to zero to run another modification
            pictureBox.Image = _Image;
            progressBar.Value = 0;

        }

        //********************************************************************************************
        //Method:     private void BlackAndWhite()
        //Purpose:    adjust picture black/white balance with trackbar
        //Parameters: none
        //Returns:    void- returns no value
        //*********************************************************************************************
        private void BlackAndWhite()
        {
            double average;                                //adjust this for avg before min/max range
            double ratioStrength = (trackBar.Value / 100); // adjust rsolution in accordance of 1/100 the value of the trackbar
            double _Alpha;                                 // individual Alpha(transparency) color value for picture modification
            double _Red;                                   // individual R color value for picture modification   
            double _Green;                                 // individual G color value for picture modification
            double _Blue;                                  // individual B color value for picture modification

            for (_count1 = 0; _count1 < _Image.Width; _count1++)
            {
                for (_count2 = 0; _count2 < _Image.Height; _count2++)
                {
                    //progressbar increments up to max
                    progressBar.Value++;

                    // get color of pixels and component value
                    _colorPixel1 = _Image.GetPixel(_count1, _count2);
                    _Alpha = (int)_colorPixel1.A;
                    _Red = (int)_colorPixel1.R;
                    _Green = (int)_colorPixel1.G;
                    _Blue = (int)_colorPixel1.B;
                    average = (_Alpha + _Red + _Green + _Blue) / 4;

                    // set min and max for alpha color value
                    if (_Alpha > average)
                        _Alpha -= (_Alpha - average) * (ratioStrength);
                    else if(_Alpha<average)
                        _Alpha -= (average - _Alpha) * (ratioStrength);
                    if (_Alpha > _MAXPIXEL)
                    {
                        _Alpha = _MAXPIXEL;
                    }
                    else if (_Alpha < _MINPIXEL)
                    {
                        _Alpha = _MINPIXEL;
                    }

                    // set min and max for red color value
                    if (_Red > average)
                        _Red -= (_Red - average) * (ratioStrength);
                    else if (_Red < average)
                        _Red -= (average - _Red) * (ratioStrength);
                    if (_Red > _MAXPIXEL)
                    {
                        _Red = _MAXPIXEL;
                    }
                    else if (_Red < _MINPIXEL)
                    {
                        _Red = _MINPIXEL;
                    }

                    // set min and max for green color value
                    if (_Green > average)
                        _Green -= (_Green - average) * (ratioStrength);
                    else if (_Alpha < average)
                        _Alpha -= (average - _Green) * (ratioStrength);
                    if (_Green > _MAXPIXEL)
                    {
                        _Green = _MAXPIXEL;
                    }
                    else if (_Green < _MINPIXEL)
                    {
                        _Green = _MINPIXEL;
                    }

                    // set min and max for blue color value
                    if (_Blue > average)
                        _Blue -= (_Blue - average) * (ratioStrength);
                    else if (_Alpha < average)
                        _Blue -= (average - _Blue) * (ratioStrength);
                    if (_Blue > _MAXPIXEL)
                    {
                        _Blue = _MAXPIXEL;
                    }
                    else if (_Blue < _MINPIXEL)
                    {
                        _Blue = _MINPIXEL;
                    }

                    // get the modifyed picture ,set it to new color values
                    _colorPixel2 = new Color();
                    _colorPixel2 = Color.FromArgb((int)_Alpha, (int)average, (int)average, (int)average);
                    _Image.SetPixel(_count1, _count2, _colorPixel2);
                }
            }
            // return chamged color image
            // reset progress bar to zero to run another modification
            pictureBox.Image = _Image;
            progressBar.Value = 0;
        }

        //********************************************************************************************
        //Method:     private void Tint()
        //Purpose:    adjust picture red or green balance with trackbar
        //Parameters: none
        //Returns:    void- returns no value
        //*********************************************************************************************
        private void Tint()
        {
            for (_count1 = 0; _count1 < _Image.Width; _count1++)
            {
                for (_count2 = 0; _count2 < _Image.Height; _count2++)
                {
                    //progressbar increments up to max
                    progressBar.Value++;

                    // get color of pixels and component value
                    _colorPixel1 = _Image.GetPixel(_count1, _count2);
                    _Alpha = (int)_colorPixel1.A;
                    _Red = (int)_colorPixel1.R;
                    _Green = (int)_colorPixel1.G;
                    _Blue = (int)_colorPixel1.B;

                    // if trackbar is less than 50
                    //readjust red and green color values 
                    if (trackBar.Value < 50)
                    {
                        _Red += 50 - trackBar.Value;
                        if (_Red > _MAXPIXEL)
                            _Red = _MAXPIXEL;
                        else if(_Red<_MINPIXEL)
                            _Red = _MINPIXEL;
                    }
                    else if (trackBar.Value > 50)
                    {
                        _Green += trackBar.Value - 50;
                        if (_Green > _MAXPIXEL)
                            _Green = _MAXPIXEL;
                        else if(_Green<_MINPIXEL)
                            _Green = _MINPIXEL;
                    }

                    // get the modifyed picture and set it to new color values
                    _colorPixel2 = new Color();
                    _colorPixel2 = Color.FromArgb(_Alpha,_Red,_Green,_Blue);
                    _Image.SetPixel(_count1, _count2, _colorPixel2);
                }
            }
            // return chamged color image
            // reset progress bar to zero to run another modification
            pictureBox.Image = _Image;
            progressBar.Value = 0;
        }

        //********************************************************************************************
        //Method:     private void Noise()
        //Purpose:    pick random valuse for color pixels 
        //Parameters: none
        //Returns:    void- returns no value
        //*********************************************************************************************
        private void Noise()
        {
            Random random = new Random(); // set randomizer

            for (_count1 = 0; _count1 < _Image.Width; _count1++)
            {
                for (_count2 = 0; _count2 < _Image.Height; _count2++)
                {
                    //progressbar increments up to max
                    progressBar.Value++;

                    // get color of pixels and component value
                    _colorPixel1 = _Image.GetPixel(_count1, _count2);
                    _Alpha = (int)_colorPixel1.A;
                    _Red = (int)_colorPixel1.R;
                    _Green = (int)_colorPixel1.G;
                    _Blue = (int)_colorPixel1.B;

                    // rendomize each color value between the min and max of the slider posistion
                    // and add it to the color value
                    _Alpha += random.Next(-trackBar.Value,trackBar.Value);
                    _Red += random.Next(-trackBar.Value, trackBar.Value);
                    _Green += random.Next(-trackBar.Value, trackBar.Value);
                    _Blue += random.Next(-trackBar.Value, trackBar.Value);

                    // set min and max for alpha color value
                    if (_Alpha > _MAXPIXEL)
                    {
                        _Alpha = _MAXPIXEL;
                    }
                    else if (_Alpha < _MINPIXEL)
                    {
                        _Alpha = _MINPIXEL;
                    }

                    // set min and max for red color value
                    if (_Red > _MAXPIXEL)
                    {
                        _Red = _MAXPIXEL;
                    }
                    else if (_Red < _MINPIXEL)
                    {
                        _Red = _MINPIXEL;
                    }

                    // set min and max for green color value
                    if (_Green > _MAXPIXEL)
                    {
                        _Green = _MAXPIXEL;
                    }
                    else if (_Green < _MINPIXEL)
                    {
                        _Green = _MINPIXEL;
                    }

                    // set min and max for blue color value
                    if (_Blue > _MAXPIXEL)
                    {
                        _Blue = _MAXPIXEL;
                    }
                    else if (_Blue < _MINPIXEL)
                    {
                        _Blue = _MINPIXEL;
                    }

                    // get the modifyed picture and set it to new color values
                    _colorPixel2 = new Color();
                    _colorPixel2 = new Color();
                    _colorPixel2 = Color.FromArgb(_Alpha, _Red, _Green, _Blue);
                    _Image.SetPixel(_count1, _count2, _colorPixel2);
                }
            }
            // return chamged color image
            // reset progress bar to zero to run another modification
            pictureBox.Image = _Image;
            progressBar.Value = 0;
        }
        //occurs everytime when pressed
        //transforms image depending on what method is selected
        private void Transformbutton_Click(object sender, EventArgs e)
        {
            if (ContrastRadioButton.Checked)
            {
                Contrast();
            }

            if (BlkToWhiteRadioButton.Checked)
            {
                BlackAndWhite();
            }

            if (TintRadioButton.Checked)
            {
                Tint();
            }

            if (NoiseRadioButton.Checked)
            {
                Noise();
            }
        }
    }
}
