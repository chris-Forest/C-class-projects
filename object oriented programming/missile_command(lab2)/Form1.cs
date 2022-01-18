//Submission Code : 1201_2300_L02
//chris Forest
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;


namespace Chris_lab2
{
    public partial class Form1 : Form
    {
        List<missile> foemissiles = new List<missile>();     //list to track enemy missiles
        List<missile> friendlyMissile = new List<missile>(); //list to track friendly missiles
        CDrawer CDrawer = null;                              //make cDrawaer
        private int lives = 5;                               //field for user lives
        private int score = 0;                               //field for users score
        private double missilsIN = 0;                        //field for enemy incoming missiles 
        private int gone = 0;                                //
        private double friendlyIN = 0;                       //field for frienfly incoming missiles
        private double KD=0.0;                               //field for user k/d ratio
        enum eGameState { Paused, Unstarted, Over, Running };//enum to track game current state
        eGameState currentState;                             //enum member for game state

        /// <summary>
        /// update form title,start timer for gdi interaction
        /// make events for user interaction
        /// set inital game state, set up cdrawer
        /// add text in gdi for prompt to start game
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Text = "Missile Comand";
            timer1.Interval = 100;
            timer1.Tick += Timer_Tick;
            timer1.Enabled = false;
            start.Click += Start_Click;
            CDrawer = new CDrawer();
            missile.drawer = CDrawer;
            currentState = eGameState.Unstarted;
            CDrawer.AddText("press start to begin", 45, Color.Cyan);
        }

        /// <summary>
        /// when pressed game starts
        /// set new game state and render in missles and other details
        /// set default lives, 0 score, incoming missiles,explosion radius and timer interval setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, EventArgs e)
        {
            currentState = eGameState.Running;
            score = 0;
            lives = 5;
            boomTrackBar.Value = 50;
            missilesUpDown.Value = 5;
            intervalUpDown.Value = 100;
            foemissiles.Clear();
            friendlyMissile.Clear();
            missile.Loading = true;
            timer1.Start();
            timer1.Enabled = true;           
            missile.Loading = false;           
        }

        /// <summary>
        /// the main event for game code
        /// does everything needed for game to run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Point pt;           
            missile.boomRadius = boomTrackBar.Value;
            labelBommVal.Text = boomTrackBar.Value.ToString();

            //add enemy missiles to list and update label
            if (foemissiles.Count < missilesUpDown.Value)
            {
                missile newMissile = new missile();
                foemissiles.Add(newMissile);
                missilsIN += 1;
            }            

            //colilsion check
            List<missile> colided = friendlyMissile.Intersect(foemissiles).ToList();
            
            //remove all colided missiles
            //also update score and update counter for removed missiles
            foreach (missile item in colided)
            {
                while (foemissiles.Remove(item))
                { 
                    score += 100;
                    gone+=1;
                }
            }            

            //remove any missiles outside of boundaries 
            friendlyMissile.RemoveAll(missile.Explosion);
            missile.Loading = true;            
            foemissiles.RemoveAll(missile.boundaryCheckLeftRIght);

            // if missile reaches bottom of gdi lives --
            if (foemissiles.RemoveAll(missile.BoundaryCheckUpDown) >= 1)
            {
                lives -= 1;
            }

            // and a "bunker" where frindly misslies spawn
            CDrawer.AddCenteredRectangle(CDrawer.ScaledWidth / 2, CDrawer.ScaledHeight, 30, 30, Color.Green);
            CDrawer.AddText($"Lives {lives} Score {score}", 60, Color.Cyan);

            // update labels
            labelmissIN.Text = missilsIN.ToString();
            labelDestroyed.Text = gone.ToString();
            labelFriend.Text = friendlyIN.ToString();
            labelKD.Text = KD.ToString();

            //update k/d ratio as long as there is at least 1 missle on screen
            if (friendlyIN>0)
                KD= (double)Math.Round(Convert.ToDecimal((missilsIN / friendlyIN) ),2);
           
            missile.Loading = false;//start rending in missiles and effects

            //movment for enemy missiles
            foreach (missile item in foemissiles)
            {
                item.move();
                item.DrawMissiles();
            }

            //movment for friendly missiles
            foreach (missile item in friendlyMissile)
            {
                //bool for friend?
                item.move();
                item.DrawMissiles();
            }

            //on a left click spawn a friendly missile and update label
            if (CDrawer.GetLastMouseLeftClick(out pt))
            {
                friendlyMissile.Add(new missile(pt));
                friendlyIN++;
            }
            
            //when adjusting timerinterval stop the game
            //adjust interval and resume game
            if (timer1.Enabled)
                timer1.Stop();
            this.timer1.Interval = (int)intervalUpDown.Value;
            timer1.Start();

            //if a game over happens
            //set game over state, stop the timer 
            //and display game over text
            if(currentState==eGameState.Over)
            {
                currentState = eGameState.Unstarted;
                timer1.Enabled = false;
                timer1.Stop();
                missile.Loading = true;                
                CDrawer.AddText("GAME OVER", 60, Color.Cyan);
                missile.Loading = false;
            }

            //if lives 0 game is over
            if (lives == 0)
                currentState = eGameState.Over;           
        }


        /// <summary>
        /// just reset all of your values including the lists
        /// and start game again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reset_click(object sender, EventArgs e)
        {
            score = 0;
            lives = 5;
            boomTrackBar.Value = 50;
            missilesUpDown.Value = 5;
            intervalUpDown.Value = 100;
            foemissiles.Clear();
            friendlyMissile.Clear();
            missile.Loading = true;
            CDrawer.AddText("GAME reset ", 60, Color.Cyan);
            missile.Loading = false;
        }

        /// <summary>
        /// pause game and press same button to resume game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pause_click(object sender, EventArgs e)
        {
            //if current state is not paused 
            //update button text and game state
            //and start/continue the game
            if (currentState == eGameState.Paused)
            {
                pauseBtn.Text = "pause";
                currentState = eGameState.Running;
                timer1.Start();
            }

            //if current state is paused 
            //update button text, game state
            //and show text to indicate game is paused             
            //and pause the game
            //hide everything currently in gdi window
            //and re-display it after game is resumed
            else
            {
                pauseBtn.Text = "continue";
                currentState = eGameState.Paused;
                timer1.Stop();
                missile.Loading = true;
                CDrawer.AddText("Game Paused", 60, Color.Cyan);
                missile.Loading = false;
            }
        }
    }
}
