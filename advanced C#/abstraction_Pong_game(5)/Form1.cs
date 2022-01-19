using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abstraction;

namespace ChrisF_Pong
{
    public partial class Form1 : Form
    {
        Random BallVel = new Random();

        InputAbstraction P1;
        InputAbstraction P2;        

        private BufferedGraphicsContext _bgc = new BufferedGraphicsContext();
        private BufferedGraphics _bg = null;

        GraphicsPath ball = new GraphicsPath();
        GraphicsPath LeftPaddle = new GraphicsPath();
        GraphicsPath RightPaddle = new GraphicsPath();

        SolidBrush ballColor = new SolidBrush(Color.White);
        SolidBrush leftPadColor = new SolidBrush(Color.White);
        SolidBrush rightPadColor = new SolidBrush(Color.White);

        bool playingGame = false;


        //Initial xVel and yVel equals to 5
        int xVel , yVel;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            Text = "PONG! - Chris F.";

            //play with this as needed
            xVel = BallVel.Next(-15, 15);
            yVel = BallVel.Next(-15, 15);

            //if velocity is zero get a nwe number that isn't zreo
            //keep going until velocity is not zero
            while (xVel == 0)
                xVel = BallVel.Next(-15, 15);
            while (yVel == 0)
                yVel = BallVel.Next(-15, 15);
        }       

        private void startBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            label2.Enabled = false;
            label3.Enabled = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            startBtn.Visible = false;
            playingGame = true;
            makegame();
        }
       
        private void pauseGame()
        {
            if (P2.Pause == false && P2.Pause == false)
            {
                playingGame = true;
            }
            else if (P2.Pause == true || P2.Pause == true)
            {
                playingGame = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (playingGame)
            {
                render();
                pauseGame();
            }
            else
                pauseGame();
        }

        private void makegame()
        {
            _bg = _bgc.Allocate(CreateGraphics(), ClientRectangle);
            //play with theese
            Point leftP = new Point(10, 200);// starting point is missing up top/btm stopage
            Point rightP = new Point(760, 200);
            Point ballPos = new Point(380, 230);

            Size paddlesSize = new Size(10, 70);
            Size ballSize = new Size(10, 10);

            LeftPaddle.AddRectangle(new Rectangle(leftP, paddlesSize));
            RightPaddle.AddRectangle(new Rectangle(rightP, paddlesSize));
            ball.AddRectangle(new Rectangle(ballPos, ballSize));
        }

        private void render()
        {
            //Clears the back buffer
            _bg.Graphics.Clear(Color.Black);

            _bg.Graphics.FillPath(ballColor, ball);
            _bg.Graphics.FillPath(leftPadColor, LeftPaddle);
            _bg.Graphics.FillPath(rightPadColor, RightPaddle);

            BallMoves(ball);
            //player one paddle key input movement
            if (P1.Up == true)
            {
                UPMovePaddle(LeftPaddle);

                if (LeftPaddle.GetBounds().Y < 0)
                    downMovePaddle(LeftPaddle);
            }

            if (P1.Down == true)
            {
                downMovePaddle(LeftPaddle);
                if (LeftPaddle.GetBounds().Bottom > Height - 20)
                    UPMovePaddle(LeftPaddle);
            }
            //this can restart game when over// or restart in the middle of playing
            if (P1.start)
            {
                //timer1.Start();
                //BallMoves(ball);
                label1.Text = "start game from a key player one";
            }

            //******************************************Player 2******************************************************
            //draw shapes and move them based on abs class bools
            if (P2.Up == true)
            {
                UPMovePaddle(RightPaddle);
                if (RightPaddle.GetBounds().Y < 0)
                    downMovePaddle(RightPaddle);
            }

            if (P2.Down == true)
            {
                //move paddle down
                downMovePaddle(RightPaddle);
                if (RightPaddle.GetBounds().Bottom > Height - 20)
                    UPMovePaddle(RightPaddle);
            }
            //this can restart game when over// or restart in the middle of playing
            if (P2.start == true)
            {
                //timer1.Start();
                //BallMoves(ball);
                label1.Text = "start game form p2 left key";
            }

            _bg.Render();
        }      
           
        #region RBtns
        private void _rbWASD_CheckedChanged(object sender, EventArgs e)
        {
            if(_rbWASD.Checked==true)
            {
                _rbMouse1.Enabled = false;
                P1 = new InputAbstraction(0);
                KeyDown += P1.press_KeyDown;
                KeyUp += P1.release_KeyUp;
            }
        }

        private void _rbMouse1_CheckedChanged(object sender, EventArgs e)
        {
            if(_rbMouse1.Checked==true)
            {
                _rbWASD.Enabled = false;
                P1 = new InputAbstraction(2);
                MouseMove+= P1.Player_MouseMove;
            }
        }

        private void ArrowKeys_CheckedChanged(object sender, EventArgs e)
        {
            if(ArrowKeys.Checked==true)
            {
                _rbMouse2.Enabled = false;
                P2 = new InputAbstraction(1);
                KeyDown += P2.press_KeyDown;
                KeyUp += P2.release_KeyUp;
            }
        }

        private void _rbMouse2_CheckedChanged(object sender, EventArgs e)
        {
            if(_rbMouse2.Checked==true)
            {
                ArrowKeys.Enabled = false;
                P2 = new InputAbstraction(2);
                MouseMove += P2.Player_MouseMove;
            }
        }
        #endregion

        #region movments
        private void UPMovePaddle(GraphicsPath pad)
        {
            Matrix movement = new Matrix();

            movement.Translate(0, -20);

            pad.Transform(movement);
        }

        private void downMovePaddle(GraphicsPath pad)
        {
            Matrix movement = new Matrix();

            movement.Translate(0, 20);

            pad.Transform(movement);
        }
        private void BallMoves(GraphicsPath gp)
        {
            Matrix ballMove = new Matrix();

            if (gp.GetBounds().Y < 0)
            {
                yVel = -yVel;
            }

            if (gp.GetBounds().X < 0)
            {
                xVel = -xVel;
                //end game
                timer1.Stop();
            }

            if (gp.GetBounds().X > ClientRectangle.Width - ball.GetBounds().Width)
            {
                xVel = -xVel;
                //end game
                timer1.Stop();
            }

            if (gp.GetBounds().Y > ClientRectangle.Height - ball.GetBounds().Height)
            {
                yVel = -yVel;
            }

            if (ball.GetBounds().IntersectsWith(RightPaddle.GetBounds()))
            {
                xVel = -xVel;
                yVel = -yVel;
            }

            if (ball.GetBounds().IntersectsWith(LeftPaddle.GetBounds()))
            {
                xVel = -xVel;
                yVel = -yVel;
            }

            ballMove.Translate(xVel, yVel);

            gp.Transform(ballMove);
        }
        #endregion
    }
}
