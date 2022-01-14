//*********************************************************************
//Program:    lab4- typeing tutor
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
using System.Threading;
using System.IO;

namespace lab4
{
    // set how many letters show up for each difficulty
    public enum Difficulty { easy = 5, mediun = 10, hard = 15 }

    //declare the delegate datatype for ending the game through the thread
    delegate void DelVoidEnd();

    public partial class Form1 : Form
    {
        public struct letters// definse letter speen and possiotn to start at
        {
            public char words; // must type this letter in gdi for score
            public int speed;  // speed at which the letters fall at
            public int xPos;   //X position for letter
            public int yPos;   // y posisition for ettter that will update
        }

        Speed _animateSpeed;                        // open speed dilaog window 
        CDrawer _draw=new CDrawer();                // make gdi window
        int _speedAnimation = 100;                  // set speed for how fal the letters fall
        int _scoreTotal;                            // total for player
        Difficulty _setting;                        // to set difficulty
        bool _pause = false;                        // boolean to pause thread and game
        bool _gameover = true;                      // boolean to end game and abort the thread
        Thread threadAnimate;                       // will run animation method nd is main game loop
        public List<letters> _lettersList;          // make liost for letters 
        DelVoidEnd delVoidEnd;                      // delagte to end game in thread 
        string[] _leaderBoardFileName = { ".txt" }; // save file for scores

        public Form1()
        {
            InitializeComponent();
            // initalize various varibles for the game
            _lettersList = new List<letters>();
            SPLabel.Text = _speedAnimation.ToString();
            _setting = lab4.Difficulty.easy;
            _animateSpeed = null;
            delVoidEnd = new DelVoidEnd(EndGame);
            LoadLeaders(_leaderBoardFileName[0]);
        }

        //occurs when the button is pressed
        //launches the difficulty selection screen, sets the difficulty
        private void StartButton_Click(object sender, EventArgs e)
        {
            // create difficulty modal and set difficulty
            var gameDifficulty = new GameDifficulty();
            gameDifficulty.selection = _setting;

            // if ok was pressed
            if(DialogResult.OK==gameDifficulty.ShowDialog())
            {
                // get difficulty from user
                _setting = gameDifficulty.selection;

                // load leaders from save
                LoadLeaders(_leaderBoardFileName[0]);

                // clear list and gdi make a list and initalize score to 0
                _draw.Clear();
                _lettersList.Clear();
                GenList();
                _scoreTotal = 0;
                score.Text = _scoreTotal.ToString();

                // sets game to running, disable buttons and enable others
                _gameover = false;
                StartButton.Enabled = false;
                PauseButton.Enabled = true;
                EndBtn.Enabled = true;

                // make and start the thread
                threadAnimate = new Thread(new ThreadStart(Animation));
                threadAnimate.IsBackground = true;
                threadAnimate.Start();
            }
            
        }

        //occurs when the button is pressed
        // pauses thread and enable/disable buttons
        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (_pause == false)
            {
                // pause thread
                _pause = true;
                // button controls
                StartButton.Enabled = true;
                PauseButton.Enabled = true;
                EndBtn.Enabled = true;
            }
            else if (_pause == true)
                _pause = false;
        }

        //occurs when the button is pressed
        // aborts thread and enable/disable buttons and end game
        private void EndBtn_Click(object sender, EventArgs e)
        {
            if (threadAnimate != null)
            {
                // button controals and abort thread and end game
                StartButton.Enabled = true;
                PauseButton.Enabled = false;
                EndBtn.Enabled = false;
                threadAnimate.Abort();
                EndGame();
            }
        }

        //occurs when the animation check box is toggled,
        // creates dialog window and gets animation speed set in it
        private void SpeedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if the box was checked, show the dialog
            if (SpeedCheckBox.Checked)
            {
                //if the dialog hasnt been created yet, create one and assign the delegates the proper methods
                if (_animateSpeed == null)
                {
                    _animateSpeed = new Speed();
                    _animateSpeed._animate = new DelAnimation(SetSpeed);
                    _animateSpeed._close = new DelClose(UncheckBox);
                    _animateSpeed.speed = _speedAnimation;
                }
                // show dialog window
                _animateSpeed.Show();
            }
            // hide when unchecked/closed
            else
                _animateSpeed.Hide();
        }

        //occurs when a key is pressed, is paused  key press wil unpause
        //if not paused or a game over happened, pressed key will pe searched for inlist
        //if matching in list score will be increased by one
        //and that letter will be removed from the list and gdi window, and replaced by another one
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int count;  //loop through list
            char input; // user input to remove letters

            // check if game is still going
            if(!_gameover)
            {
                // if paused resume on key press
                if(_pause)
                {
                    _pause = false;
                    PauseButton.Text = "pause";// y dis????
                }
                // if not paused 
                else
                {
                    // take user input and convert ti to lowercase so no issues woth cpas lock
                    input = e.KeyChar;
                    input = char.ToLower(input);

                    //check for matching letter
                    for(count=0;count<_lettersList.Count;count++)
                    {
                        //if match found remove it and replace with new one
                        if (_lettersList[count].words == input)
                        {
                            // remove pressed letter and add new one in its place
                            _lettersList.RemoveAt(count);
                            _lettersList.Insert(count, GetLetters());

                            // add up core and display it
                            _scoreTotal++;
                            score.Text = _scoreTotal.ToString();
                        }
                    }
                }
            }
        }

        //**************************************************************************************
        //Method:   private void GenList()
        //Purpose: add letters to list as er set difficulty
        //**************************************************************************************
        private void GenList()
        {
            int count;
            //generate letters as per set difficulty
            for (count = 0; count < (int)_setting; count++)
                //generate rdm letters for a to z with rdm values
                _lettersList.Add(GetLetters());
        }

        //**************************************************************************************
        //Method:  private void UncheckBox()
        //Purpose: used for unchecking the SpeedCheckbox when closing the modeless dialog
        //**************************************************************************************
        private void UncheckBox()
        {
            SpeedCheckBox.Checked = false;
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
            SPLabel.Text = _speedAnimation.ToString();
        }

        //*************************************************************************************************
        //Method:  private void EndGame()
        //Purpose: occurs at the end of the game, resets buttons and calls scoreboard to open to enter score
        //*************************************************************************************************
        private void EndGame()
        {
            StartButton.Enabled = true;
            PauseButton.Enabled = false;
            EndBtn.Enabled = false;
            _draw.AddText("GAME OVER", 60, Color.White);

            ScoreBoard();
        }

        //*************************************************************************************************
        //Method:  private void ScoreBoard()
        //Purpose: occurs at the end of the game, opens the scoreModal dialog to aquire a player name,
        //         Adds the current players stats to the leaderboard, then sorts the leaderboard 
        //*************************************************************************************************
        private void ScoreBoard()
        {
            var item = new ListViewItem(); //cretae list item to add to leaderboard
            var score = new HighScore();   // creste score modal

            //show if  ok is pressed
            if (score.ShowDialog()==DialogResult.OK)
            {
                //add the player name, score and difficulty to the item, and add the item to the leaderBoard
                item.Text = score.PlayerName;
                item.SubItems.Add(_scoreTotal.ToString());
                item.SubItems.Add(_setting.ToString());
                listViewBoard.Items.Add(item);

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
            int[] scoreArray = new int[listViewBoard.Items.Count]; // store score
            int index = 0;                                       // for tterating
            int compare = 0;                                     // for itterating
            int score1;                                          // swap int array elements
            int score2;                                          // swap int array elements
            string one;                                          // swap string array elements
            string two;                                          // swap string array elements

            //iterate through the leaderboard and fill the score array
            foreach (ListViewItem item in listViewBoard.Items)
            {
                //add only the players score to the scoreArray
                int.TryParse(item.SubItems[1].Text, out scoreArray[index]);
                index++;
            }

            //iterate through the score array and compare all elements against each other
            for (index = 0; index < scoreArray.Length; index++)
                for (compare = 1 + index; compare < scoreArray.Length; compare++)
                {
                    //if the current index value is lower than the next,swap them
                    if (scoreArray[index] < scoreArray[compare])
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
            listViewBoard.Items.Clear();
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
            listViewBoard.Items.Clear();

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
                listViewBoard.Items.Add(item);
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
            catch (Exception error)
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
                if (!File.Exists(lbFileName))
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

        //**************************************************************************************************
        //Method:  private string[] GetLbArray()
        //Purpose: creates a string array that will be used for saving leaderboard info
        //Returns: string[] lBArray - the array of string containing all info from the leaderboard
        //**************************************************************************************************
        private string[] GetLbArray()
        {
            string[] lBArray = new string[listViewBoard.Items.Count]; //storse info in leaderboard 
            int index = 0;                                          // counts items in leaderboard

            //iterate through the leaderboard one item at a time 
            foreach (ListViewItem item in listViewBoard.Items)
            {
                // add player info to leaderboard array
                lBArray[index] = item.Text + ";" + item.SubItems[1].Text + ";" + item.SubItems[2].Text;
                index++;
            }
            return lBArray;
        }

        //**************************************************************************************************
        //Method:  private void Animation()
        //Purpose: animate gdi  with falling letters
        //**************************************************************************************************
        private void Animation()
        {
            int count;    //loop through list
            letters temp; // add letters as removed

            try
            {
                // while game is still running 
                while(!_gameover)
                {
                    //draw letter in gdi and update position for next letter
                    for(count=0;count<_lettersList.Count;count++)
                    {
                        //
                        _draw.AddText(_lettersList[count].words.ToString(), 20, _lettersList[count].xPos, _lettersList[count].yPos, 25, 25, Color.Green);

                        //update y posistion
                        temp = _lettersList[count];
                        temp.yPos += temp.speed;

                        // lock list to prevent modification to thread
                        lock (_lettersList)
                            _lettersList[count] = temp;

                        // if letters reach bottom of the screen,end the game
                        if(_lettersList[count].yPos>=600)
                        {
                            _gameover = true;
                            Invoke(delVoidEnd);
                        }
                    }

                    //puse thread if game is paused
                    while (_pause)
                        Thread.Sleep(1);

                    //pause the speed and clear window for next run
                    Thread.Sleep(_speedAnimation);
                    _draw.Clear();
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Ahhhhhhhhhhhhhh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //**************************************************************************************************
        //Method:  private letters GetLetters()
        //Purpose: gen rdm letters 
        //Returns: newletters- rdm letters with rdm values
        //**************************************************************************************************
        private letters GetLetters()
        {
            letters newletters;        // to be filled with rdm letters and returned to list
            char characterrs;          // rdm leter in alphabet
            int speed;                 // rdm speed from 2-10
            int xPos;                  // rdm x pos from 50-750
            int yPos;                  // rdm y pos from 10-100
            int count;                 // loop through letter list
            bool rdmletters;           //flag to find unique letters
            Random rdm = new Random(); // randomizer

            do
            {
                // set true to loop for unique characters
                rdmletters = true;

                //generate rdm letters for a to z
                characterrs = (char)rdm.Next((int)'a', (int)'z');

                //check list to see if a letter already has been generated
                for(count=0;count<_lettersList.Count;count++)
                {
                    //set false flag so anew letter can be generated
                    if (_lettersList[count].words == characterrs)
                        rdmletters = false;
                }

            } while (!rdmletters);
            // keep generating unique letters

            // generate rdm speed and letter start possition
            speed = rdm.Next(2, 11);
            xPos = rdm.Next(50, 751);
            yPos = rdm.Next(10, 101);

            // assign values and return them
            newletters = new letters() { words = characterrs, speed = speed, xPos = xPos, yPos = yPos };
            return newletters;
        }
    }
}
