using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abstraction
{
    public class InputAbstraction
    {
        //Int to hold controller selection
        public int ChosePlayerContorls;

        public bool Up { get; set; }

        public bool Down { get; set; }

        public bool Pause { get; set; } = false;
        public bool start { get; set; }

        //Public Constructor
        public InputAbstraction(int PickContorls)
        {
            ChosePlayerContorls = PickContorls;
        }

        public void press_KeyDown(object sender, KeyEventArgs e)
        {
            //WASD Keys is selected
            if (ChosePlayerContorls == 0)
            {
                if (e.KeyCode == Keys.W)
                {
                    System.Diagnostics.Trace.WriteLine($"Pressed W");
                    Up = true;
                }
                if (e.KeyCode == Keys.S)
                {
                    System.Diagnostics.Trace.WriteLine($"Pressed S");
                    Down = true;
                }
                if (e.KeyCode == Keys.P)
                {
                    System.Diagnostics.Trace.WriteLine($"Pressed R");
                    if (Pause == false)
                    {
                        Pause = true;
                    }
                    else if (Pause == true)
                    {
                        Pause = false;
                    }
                }
            }

            //Keys is selected
            if (ChosePlayerContorls == 1)
            {
                if (e.KeyCode == Keys.Up)
                {
                    Up = true;
                }

                if (e.KeyCode == Keys.Down)
                {
                    Down = true;
                }

                if (e.KeyCode == Keys.P)
                {
                    //to pause
                    if (Pause == false)
                    {
                        Pause = true;
                    }
                    else if (Pause == true)
                    {
                        Pause = false;
                    }
                }
            }
        }

        public void release_KeyUp(object sender, KeyEventArgs e)
        {
            if (ChosePlayerContorls == 0)
            {
                if (e.KeyCode == Keys.W)
                {
                    System.Diagnostics.Trace.WriteLine($"W not pressed");
                    Up = false;
                }
                if (e.KeyCode == Keys.S)
                {
                    System.Diagnostics.Trace.WriteLine($"S not pressed");
                    Down = false;
                }
            }

            if (ChosePlayerContorls == 1)
            {
                if (e.KeyCode == Keys.Up)
                {
                    System.Diagnostics.Trace.WriteLine($"I not pressed");
                    Up = false;
                }
                if (e.KeyCode == Keys.Down)
                {
                    System.Diagnostics.Trace.WriteLine($"K not pressed");
                    Down = false;
                }
            }
        }
        // if eithier player decides to use a mouse as input
        public void Player_MouseMove(object sender, MouseEventArgs e)
        {
            if (ChosePlayerContorls == 2)
            {
                //mouse pos top 1/3 go up
                if (e.Y <= 200)
                {
                    Up = true;
                }
                else
                {
                    Up = false;
                }
                //mouse pos btm 1/3 go down
                if (e.Y > 300)
                {
                    Down = true;
                }
                else
                {
                    Down = false;
                }

                //start game
                if (e.Button == MouseButtons.Left)
                {
                    start = true;
                    System.Diagnostics.Trace.WriteLine("left click from abs");
                }

                //special-do something on screen
                if (e.Button == MouseButtons.Right)
                {
                    System.Diagnostics.Trace.WriteLine("right click from abs");
                }
            }
        }

    }

}
