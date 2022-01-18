//Submission Code : 1201_2300_L02
//chris Forest
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace Chris_lab2
{
    class missile
    {
        private Point missleStart;                                   //origin or source of the missile
        private double angle;                                        //firing angle
        private double length;                                       //missile path length
        private double Ydestination;                                 //height, altitude
        private int radius = 5;                                      // inital radius for friendly missiles
        private int alpha = 255;                                     // to mimic an explsion fade away
        private int speed = 0;                                       //the speed at which the missile goes at
        public bool whoIsIt {  get; private set; }                   // true= friendly missile false=enemy missile        
        private static CDrawer _drawer;                              //static drawer
        public static CDrawer drawer { set { _drawer = value; } }    
        private static int _boomRadius;                              //-represents explosion radius
        public static int boomRadius{ set { _boomRadius = value; } }

        private static Random _rdm;                                 //static randomizer
        public static bool Loading                                  //bool for rendering and clearing gdi window
        {
            set
            {
                if (value)
                    _drawer.Clear();
                else
                    _drawer.Render();
            }
        }

        /// <summary>
        /// initialize ranomizer,set explosion radius and init cDrawer
        /// </summary>
        static missile()
        {
            _rdm = new Random();
            boomRadius = 50;
            drawer = null;
        }

        /// <summary>
        /// incoming enemy missiles
        /// </summary>
        public missile()
        {
            double min = 3 * Math.PI / 4;// set min angle
            double max = 5 * Math.PI / 4;// set max angle

            //set start point for missiles at a random point at top of gdi window
            missleStart.X = _rdm.Next(_drawer.ScaledWidth);
            missleStart.Y = 0 + 5 * 2;

            angle = min + (max - min) * _rdm.NextDouble();// set angle between  3pi/4-5pi/4
            length = 5;
            speed = 5;
            //set the enemy missile path toward the bottom of the gdi window
            Ydestination =_drawer.ScaledHeight;            
            whoIsIt = false;//set as enemy missile
        }

        /// <summary>
        /// friendly missile
        /// </summary>
        /// <param name="toClick"></param>
        public missile(Point toClick )
        {
            //start point for friendly missiles(at center point on the bottom edge of gdi window)
            missleStart.X = _drawer.ScaledWidth/2;
            missleStart.Y = _drawer.ScaledHeight;  
            
            // set y destination to where user would click at in gdi window
            Ydestination = toClick.Y;
            //angle based on where users clicks
            angle = Math.Atan(-1.0*(toClick.X - missleStart.X)/ (toClick.Y - missleStart.Y));

            radius = 10;
            speed = 20;
            whoIsIt = true;//set as friendly missile
        }

        /// <summary>
        /// calculate the missile location based on its angle
        /// and current length traveled
        /// </summary>
        /// <returns></returns>
        public Point Where()
        {
            //find and set missile location and return it 
            Point iswhere = new Point();
            iswhere.X = (int)(Math.Sin(angle) * length) + missleStart.X;
            iswhere.Y = (int)(-1*Math.Cos(angle) * length) + missleStart.Y;
            return iswhere;
        }


        /// <summary>
        /// check if missile is friendly or an enemy 
        /// then render it
        /// </summary>
        public void DrawMissiles()
        {
            //foe missile
            if (whoIsIt == false)
            {                
                _drawer.AddCenteredEllipse(Where(), radius * 2, radius * 2, Color.Red);
                _drawer.AddLine(missleStart.X, missleStart.Y, Where().X, Where().Y, Color.Red);
            }

            //friendly missile
            else
            {            
                _drawer.AddCenteredEllipse(Where(), radius * 2, radius * 2, Color.FromArgb(alpha,Color.Green));
                _drawer.AddLine(missleStart.X, missleStart.Y, Where().X, Where().Y, Color.Green);
            }
        }

        /// <summary>
        /// get all missiles to move
        /// </summary>
        public void move()
        {
            // if foe missile
            if (whoIsIt==false)
            {
                // add current speed to length
                length += speed;                
            }

            //If friendly missile
            else if (whoIsIt==true)
            {
               //determine our missile's state/location.
               if(Where().Y>Ydestination)
               {
                   length += speed;
               }

               //when friendly missile hits enemy missle cause an explosion and fade away explosion
               else if (Where().Y<=Ydestination)
               {
                    speed = 0;
                    radius += 5;

                    //fade away explosion when it happens
                    if(radius>=_boomRadius)
                    {
                        alpha -= 10;
                    }
               }
            }            
        }

        /// <summary>
        /// explosion method to determine if explosion is done or not  
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static bool Explosion(missile arg)
        {
            //if explosion radius' alpha value is less then or equal to 10
            //the explosion is done happening
            if (arg.alpha <= 10)
                return true;
            //otherwise explosion is still happening
            else
                return false;
        }

        /// <summary>
        /// override method for minimum distance for missile colision
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //if not a missile return false
            if (!(obj is missile arg))
                return false;

            //distance check for missile colision, return that distance
            float dis = (float)Math.Sqrt(Math.Pow(arg.Where().X-Where().X, 2) + Math.Pow(arg.Where().Y - Where().Y, 2));
            float mindis = this.radius + arg.radius;
            return (dis <= mindis && arg.whoIsIt != whoIsIt);
        }

        /// <summary>
        /// for happy code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 1;
        }

        /// <summary>
        /// left and right walls boundary check
        /// if a missile goes past gdi boundaries
        /// then remove them in main form code
        /// </summary>
        /// <param name="foe"></param>
        /// <returns></returns>
        public static bool boundaryCheckLeftRIght(missile foe)
        {
            //null check
            if (foe == null)return false;

            // if past gdi walls return its location and have it removed in main 
            return (foe.Where().X < (0 + foe.radius * 2)) || (foe.Where().X > (_drawer.ScaledWidth + foe.radius * 2));
        }

        /// <summary>
        /// top and bottom boundary check
        /// if a missile goes past gdi boundaries(left and right walls)
        /// then remove them in main form code
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static bool BoundaryCheckUpDown(missile arg)
        {
            //null check
            if (arg == null) return false;

            // if past gdi walls return its location and have it removed in main 
            return (arg.Where().Y < 0) || (arg.Where().Y > _drawer.ScaledHeight);
        }     
    }
}
