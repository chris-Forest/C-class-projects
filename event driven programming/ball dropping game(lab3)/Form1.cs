//*********************************************************************
//Program:    lab3- ballz dropped
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
using GDIDrawer;
using System.IO;

namespace lab3
{
    public enum Difficulty
    {
        easy=3,mediun,hard
    }

    public enum ballState
    {
        appered,gone
    }

    public struct ball
    {
        public Color color;
        public ballState state;
    }
    public partial class Ballz : Form
    {
        animation _modlessAnimation = null;
        CDrawer _draw;
        const int HEIGHT = 800;
        const int WIDTH = 800;
        const int BSIZE = 50;
        ball[,] _bArray;
        Difficulty _setting;
        int _speedAnimation = 10;
        Point _mouseClick;
        int _scoreTotal;
        string[] _leaderBoardFileName= { ".txt" };

        public Ballz()
        {
            InitializeComponent();

            SpeedLabel.Text = _speedAnimation.ToString();
            _bArray = new ball[WIDTH / BSIZE, HEIGHT / BSIZE];
            _setting = lab3.Difficulty.easy;
            //load leadrboard
        }

        //occurs when the animation check box is toggled,
        // creates dialog window and gets animation speed set in it
        private void ANIMEcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if the box was checked, show the dialog
            if (ANIMEcheckBox.Checked)
            {
                //if the dialog hasnt been created yet, create one and assign the delegates the proper methods
                if (_modlessAnimation == null)
                {
                    _modlessAnimation = new animation();
                    _modlessAnimation._animation = new Animationdel(SetSpeed);
                    _modlessAnimation._close = new Closedel(UncheckBox);
                    _modlessAnimation.speed = _speedAnimation;
                }
                // shoe dialog
                _modlessAnimation.Show();
            }
            // when box uncheck/closed
            else
                // hide it fro the user
                _modlessAnimation.Hide();
        }

        //occurs when the button is pressed
        //launches the difficulty selection screen, sets the difficulty
        private void PlayButton_Click(object sender, EventArgs e)
        {
            var SelectDifficulty = new SelectDifficulty(); // create difficulty modal

            // set difficulty made in modal
            SelectDifficulty.DifficultySelect = _setting;

            // show difficulty mdal and set set difficulty if ok is pressed
            if(DialogResult.OK==SelectDifficulty.ShowDialog())
            {
                //get the difficulty selection from the modalform
                _setting = SelectDifficulty.DifficultySelect;

                //load the leaderboard with the stats for the selected difficulty level
                LoadLeaders(_leaderBoardFileName[0]);

                // enable cliking in gdi window
                timer1.Start();

                // inital ize score
                _scoreTotal = 0;

                // create gdi window
                if (_draw == null)
                    _draw = new CDrawer(WIDTH, HEIGHT);

                // disable play button untol a game over
                PlayButton.Enabled = false;

                // set up ball to be in rdm places in gdi window
                Randomizer();
                Display();

                // close dialog
                SelectDifficulty.Close();
            }

        }

        //occurs every 100ms once the game has started
        // calls Alive balls to check for a game over
        // check for mouse clicks,update upon evey new mouse click
        private void timer1_Tick(object sender, EventArgs e)
        {
            // exeute when no balls are left in gdi window
            if (AliveBalls() == 0)
            {
                // stop timer, enable user to play again, dispaly game over msg
                timer1.Stop();
                PlayButton.Enabled = true;
                _draw.AddText("Game over", 60, Color.White);

                // call score to keep tarck of players curent score
                ScoreBoard();
            }

            //if a fresh mouse click is detected, call Drop for that location, total up the score and call StepDown
            else if (_draw.GetLastMouseLeftClick(out _mouseClick))
            {
                _scoreTotal += Pick();
                FallDown();
                scoreLabel.Text = _scoreTotal.ToString();
            }
        }

        //**************************************************************************************************
        //Method:  private string[] GetLbArray()
        //Purpose: creates a string array that will be used for saving leaderboard info
        //Returns: string[] lBArray - the array of string containing all info from the leaderboard
        //**************************************************************************************************
        private string[] GetLbArray()
        {
            string[] lBArray = new string[LeaderBoard.Items.Count]; //storse info in leaderboard 
            int index = 0;                                          // counts items in leaderboard

            //iterate through the leaderboard one item at a time 
            foreach (ListViewItem item in LeaderBoard.Items)
            {
                // add player info to leaderboard array
                lBArray[index] = item.Text + ";" + item.SubItems[1].Text + ";" + item.SubItems[2].Text;
                index++;
            }
            return lBArray;
        }

        //*********************************************************************************************************
        //Method:     private void SetSpeed()
        //Purpose:    sets the _animationSpeed using the value from the modeless dialog form,
        //            sets SpeedLabel.Text to the _animationSpeed value
        //Parameters: int speed - the value that is passed from the _animationDelegate in the modeless dialog form
        //*********************************************************************************************************
        private void SetSpeed(int speed)
        {
            _speedAnimation = speed;
            SpeedLabel.Text = _speedAnimation.ToString();
        }

        //**************************************************************************************
        //Method:  private void UncheckBox()
        //Purpose: used for unchecking the AnimationCheckbox when closing the modeless dialog
        //**************************************************************************************
        private void UncheckBox()
        {
            ANIMEcheckBox.Checked = false;
        }

        //********************************************************************************************************
        //Method:  private int BallsAlive()
        //Purpose: counts the number of alive balls in the _ballArray
        //Returns: int aliveBalls - the total number of balls left alive, used for checking the endgame condition
        //********************************************************************************************************
        private int AliveBalls()
        {
            int xPos;       //used for iterating through the _bArray x indexes
            int yPos;       //used for iterating through the _ballArray y indexes
            int bAlive = 0; //total # of balls alive

            //iterate through all array indexes
            for (xPos = 0; xPos < _bArray.GetLength(0);xPos++)
            {
                for (yPos = 0; yPos < _bArray.GetLength(1); yPos++)
                {
                    //if the current ball is alive, count it
                    if (_bArray[xPos, yPos].state == ballState.appered)
                        bAlive++;
                }
            }
            return bAlive;
        }

        //************************************************************************************
        //Method:  private void Randomizer()
        //Purpose: fills the Ball array with balls of random colors, all in the alive state
        //************************************************************************************
        private void Randomizer()
        {
            int xPos;                  //used for iterating through the _bArray x indexes
            int yPos;                  //used for iterating through the _bArray y indexes
            Random rdm = new Random(); // rdm generator for color
            Color[] colors             // array of cloors for the balls
                = { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange };

            //iterate through all array indexes
            for (xPos = 0; xPos < _bArray.GetLength(0); xPos++)
            {
                for (yPos = 0; yPos < _bArray.GetLength(1); yPos++)
                {
                    //set the ball state and color using the difficulty setting as the upper limit of the random number
                    _bArray[xPos, yPos].state = ballState.appered;
                    _bArray[xPos, yPos].color = colors[rdm.Next(0, (int)_setting)];
                }
            }
        }

        //************************************************************************************
        //Method:  private void Display()
        //Purpose: draws all alive Balls in the array in the GDI drawer window
        //************************************************************************************
        private void Display()
        {
            int xPos; //used for iterating through the _bArray x indexes
            int yPos; //used for iterating through the _bArray y indexes

            _draw.Clear();

            //iterate through all array indexes
            for (xPos = 0; xPos < _bArray.GetLength(0); xPos++)
            {
                for (yPos = 0; yPos < _bArray.GetLength(1); yPos++)
                {
                    //if the current ball is alive, draw it
                    if (_bArray[xPos, yPos].state == ballState.appered)
                        _draw.AddEllipse(xPos * BSIZE, yPos * BSIZE, BSIZE, BSIZE, _bArray[xPos, yPos].color);
                }
            }
        }

        //*******************************************************************************************
        //Method:  private int Pick()
        //Purpose: checks the state of the ball that was clicked on,
        //         if alive, call CheckBallPosistion to start recursivley removing all matching balls
        //Returns: int ballScore - the total score for this pick, based on number of balls removed
        //*******************************************************************************************
        private int Pick()
        {
            int ballScore = 0;                // total curnt score
            int xPos = _mouseClick.X / BSIZE; // the ball array index x pos
            int yPos = _mouseClick.Y / BSIZE; //the ball array index x pos

            //if the ball that was clicked on is alive, 
            //call CheckBalls starting at the present pos using the current ball color
            if (_bArray[xPos, yPos].state == ballState.appered)
                ballScore = CheckBallPosistion(xPos, yPos, _bArray[xPos, yPos].color);

            //assign 10 points per ball, and use the number of balls as an exponential bonus modifier
            ballScore *= 10 * ballScore;

            return ballScore;
        }

        //***********************************************************************************************************
        //Method:     private int CheckBallPosistion()
        //Purpose:    recusivley checks all adjacent balls for state and color,
        //            removes all matching balls and counts the number of balls removed in the click
        //Parameters: int xPos - the array index x coordinate to check the ball at
        //            int yPos - the array index y coordinate to check the ball at
        //            Color checkColor - the color of the ball that was clicked on that will be used for matching 
        //Returns:    int ballCount - the total number of balls that were removed in the pick, used for score keeping
        //***********************************************************************************************************
        private int CheckBallPosistion(int xPos, int yPos, Color checkColor)
        {
            int bCount = 0; // store # of balls of same color that have been picked

            // if x,y pos is out of bounds
            if (xPos < 0 || xPos > _bArray.GetLength(0) - 1 || yPos < 0 || yPos > _bArray.GetLength(1) - 1)
                return 0;

            // if a ball is gone
            if (_bArray[xPos, yPos].state == ballState.gone)
                return 0;

            // if balls are not the same color
            if (_bArray[xPos, yPos].color != checkColor)
                return 0;

            // if balls match remove all of the same color 
            else if (_bArray[xPos, yPos].color == checkColor)
            {
                _bArray[xPos, yPos].state = ballState.gone;
                bCount = 1;
            }

            // check all ball pos and total the bcount
            bCount += CheckBallPosistion(xPos + 1, yPos, checkColor);
            bCount += CheckBallPosistion(xPos , yPos + 1, checkColor);
            bCount += CheckBallPosistion(xPos - 1, yPos, checkColor);
            bCount += CheckBallPosistion(xPos, yPos - 1, checkColor);

            return bCount;
        }

        //*********************************************************************
        //Method:  private void FallDown()
        //Purpose: repeatedly calls StepDown until no more balls can drop down
        //*********************************************************************
        private void FallDown()
        {
            int droped; // checks if any balls were any balls fell down from last StepDown call

            do
            {
                // call StepDown, display newly aranged balls, pause for animation and speed delay
                droped = StepDown();
                Display();
                System.Threading.Thread.Sleep(_speedAnimation);

            } while (droped != 0);
            // continue progrm while there are still balls to be droped
        }

        //******************************************************************************************
        //Method:  private int StepDown()
        //Purpose: checks all ball States, if a ball is removed and the one above it is alive,
        //         the alive ball will drop down by being copied into the removed ball array index,
        //         the ball above will then be assigned the removed state
        //Returns: int droped - the number of balls that dropped in this pass of the method,
        //                            when 0 is returned, FallDown will stop calling this method
        //******************************************************************************************
        private int StepDown()
        {
            int xPos;       //used for iterating through the _ballArray x indexes
            int yPos;       //used for iterating through the _ballArray y indexes
            int droped = 0; //counts the number of balls dropped in the current pass of this method

            //iterate through all array indexes, from top to bottom, 
            //starting in the second row, as top row cant have anything fall into it
            for (yPos=1;yPos<_bArray.GetLength(1);yPos++)
                for(xPos=0;xPos<_bArray.GetLength(0);xPos++)
                {
                    // if current ball has been removed
                    if (_bArray[xPos, yPos].state == ballState.gone)
                    {
                        // if ball abve removed one is visable
                        if (_bArray[xPos, yPos-1].state == ballState.appered)
                        {
                            //copy the ball above into the current ball index, set above ball to gone, count the dropped ball
                            _bArray[xPos, yPos] = _bArray[xPos, yPos - 1];
                            _bArray[xPos, yPos - 1].state = ballState.gone;
                            droped++;
                        }
                    }
                }
            return droped;
        }

        //*************************************************************************************************
        //Method:  private void ScoreBoard()
        //Purpose: occurs at the end of the game, opens the scoreModal dialog to aquire a player name,
        //         Adds the current players stats to the leaderboard, then sorts the leaderboard 
        //*************************************************************************************************
        private void ScoreBoard()
        {
            var item = new ListViewItem(); //cretae list item to add to leaderboard
            var ScoreIN = new ScoreIN();// creste score modal,
            
            //show if  ok is pressed
            if (ScoreIN.ShowDialog()==DialogResult.OK)
            {
                //add the player name, score and difficulty to the item, and add the item to the leaderBoard
                item.Text = ScoreIN.PlayerName;
                item.SubItems.Add(_scoreTotal.ToString());
                item.SubItems.Add(_setting.ToString());
                LeaderBoard.Items.Add(item);

                // sort and sve any scores to file
                SortBoard(GetLbArray());
                SaveLeaderBoard(GetLbArray());
            }
        }

        //************************************************************************************************************
        //Method:     private void SortBoard()
        //Purpose:    sorts the leaderboard by player score, uses 2 parallel arrays in order to compare scores easier
        //            fills the leaderboard after sorting
        //Parameters: string[] leaderBoard - an array containing all leaderboard items in string format
        //************************************************************************************************************
        private void SortBoard(string[] leaderBoard)
        {
            int[] scoreArray = new int[LeaderBoard.Items.Count]; // store score
            int index = 0;                                       // for tterating
            int compare = 0;                                     // for itterating
            int score1;                                          // swap int array elements
            int score2;                                          // swap int array elements
            string one;                                          // swap string array elements
            string two;                                          // swap string array elements

            //iterate through the leaderboard and fill the score array
            foreach (ListViewItem item in LeaderBoard.Items)
            {
                //add only the players score to the scoreArray
                int.TryParse(item.SubItems[1].Text, out scoreArray[index]);
                index++;
            }

            //iterate through the score array and compare all elements against each other
            for (index=0;index<scoreArray.Length;index++)
                for(compare=1+index;compare<scoreArray.Length;compare++)
                {
                    //if the current index value is lower than the next,swap them
                    if (scoreArray[index]<scoreArray[compare])
                    {
                        //store the elements in both arrays at both indexes
                        score1 = scoreArray[index];
                        score2 = scoreArray[compare];
                        one = leaderBoard[index];
                        two = leaderBoard[compare];

                        //swap elemntes in botharays
                        scoreArray[index] = score2;
                        scoreArray[compare] = score1;
                        leaderBoard[index] = two;
                        leaderBoard[compare] = one;
                    }
                }
            // clear leaberborad and sdd new sotred scores to it
            LeaderBoard.Items.Clear();
            FillBoard(leaderBoard);
        }

        //**************************************************************************************************************
        //Method:     private void FillBoard()
        //Purpose:    fills the leaderboard with the stats in the provided string array
        //Parameters: string[] leaderBoard - the array containing all the score info to go into the leaderboard
        //**************************************************************************************************************
        private void FillBoard(string[] leaderBoard)
        {
            // will have player namne, difficulty plaed on  and score from LeaderBoard array
            ListViewItem item;

            // claer o make room for more scores
            LeaderBoard.Items.Clear();

            //iterate thorugh the leaderBoard Array so each line can be added to the Leaderboard
            foreach (string playerScore in leaderBoard)
            {
                //create a new item to add to the Leaderboard
                item = new ListViewItem();

                // add player name to list view
                item.Text = playerScore.Substring(0, playerScore.IndexOf(';'));

                // add players score to listview as a sub-item
                item.SubItems.Add(playerScore.Substring((playerScore.IndexOf(';') + 1), playerScore.LastIndexOf(';') - (playerScore.IndexOf(';') + 1)));

                //add difficulty played on to listview as a sub-item
                item.SubItems.Add(playerScore.Substring((playerScore.LastIndexOf(';') + 1), playerScore.Length - (playerScore.LastIndexOf(';') + 1)));

                //add the item to the leaderboard
                LeaderBoard.Items.Add(item);
            }
        }

        //**************************************************************************************************************************
        //Method:     private void SaveLeaderBoard()
        //Purpose:    saves the leaderboard stats to a .txt file, uses separate files for each difficulty
        //Parameters: string[] leaderBoardArray - an array containing all leaderboard items in string format to save to the file
        //**************************************************************************************************************************
        private void SaveLeaderBoard(string[] leaderBoard)
        {
            string fileName = "";

            // get file name
            fileName = _leaderBoardFileName[0];

            // write leaderboard array to file
           try
            {
                File.WriteAllLines(fileName, leaderBoard);
            }
            catch(Exception error) 
            {
                MessageBox.Show(error.Message, "nope ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //*********************************************************************************************
        //Method:     private void LoadLeaders()
        //Purpose:    loads a .txt file, stores leaderboard info from the file into a string array
        //            if a leaderboard file cannot be found a new one is created in its place
        //Parameters: string LbFileName - the file to load the leaderboard stats from
        //*********************************************************************************************
        private void LoadLeaders(string lbFileName)
        {
            string[] leaderBoard = null; //this array will contain an element for each line in the text file

            try
            {
                //get the file and store all lines into the string array
                leaderBoard = File.ReadAllLines(lbFileName);

                //fill the leaderboard with the info from the array
                FillBoard(leaderBoard);
            }

            //if the file cannot be found
            catch (FileNotFoundException error)
            {
                // if file exists
                if(!File.Exists(lbFileName))
                {
                    // if not make one
                    var fileStream = new FileStream(lbFileName, FileMode.Create);
                    fileStream.Close();
                }
                // err for no file found
                MessageBox.Show(error.Message + "New file created", "no file", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // recall method
                LoadLeaders(lbFileName);
            }
            //cath any other excetion errs
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ohhh no ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //occurs when the DeleteButton is pressed, 
        //removes the selected items from the leaderBoard, then saves the leaderboard
        private void delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in LeaderBoard.SelectedItems)
            {
                item.Remove();

                SaveLeaderBoard(GetLbArray());
            }
        }
    }
}
