//Submission code 1202_CMPE2800_L03
//Chris Forest

using chris_lab03_pixelPenitration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chris_lab03_pixelPenitration
{
    public abstract class ShapeBase
    {
        // if set to this have shpae that collided be removed
        public bool IsMarkedForDeath { get; set; }//bool for if a shape collision will happen

        public bool IsMarkedForCompare { get; set; }//used in dist to check if needed to be compared for collision
        public PointF location { get; set; }//get center location
        public static float _fRadius { get; set; }// is size for shapes
        public Color BaseColor { get; set; }//default color for shapes
                
        protected float _fRotation;//rotate shape based on _fRotationIncrement
        private float _fRotationIncrement;// the rotation at which goes up or dowon by 
        private float _xfSpeed, _yfSpeed;//speed varaibles
        protected static Random _random = new Random();//use to have rdm ranges

        public ShapeBase(PointF center)
        {
            location = center;
            _fRotation = 0;
            _fRotationIncrement = _random.Next(-3, 3);
            _xfSpeed = (float)(-2.5 + (2.5 - (-2.5)) * _random.NextDouble());
            _yfSpeed = (float)(-2.5 + (2.5 - (-2.5)) * _random.NextDouble());
            BaseColor = Color.DarkBlue;
        }

        /// check dist b/w shapes if close flag bool compare
        /// then later on draw circle area(compare region)
        /// </summary>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <returns></returns>
        public bool Dist(PointF pt1,PointF pt2)
        {
            //find the x' and y' differences btwn the 2 points 
            double x = pt1.X - pt2.X;
            double y = pt1.Y - pt2.Y;
            //getting the distance between the 2 points
            double r = Math.Sqrt(Math.Pow(x, 2)+ Math.Pow(y, 2));

            //check for if near/in collision range?
            if (r < _fRadius *2)//may need to play around wiht this
            {
                return true;
            }
            else
            {
                return false;
            }               
        }

        /// <summary>
        /// make the graphics path for the shape classes
        /// </summary>
        /// <returns></returns>
        public abstract GraphicsPath GetPath();

        /// <summary>
        /// make the path for each shape that will be drawn and displayed
        /// </summary>
        /// <param name="numPoints">vertexs per shape</param>
        /// <param name="variance"></param>
        /// <returns></returns>
        protected static GraphicsPath MakePolygonPath( int numPoints, double variance)
        {
            GraphicsPath path = new GraphicsPath();//make a GraphicsPath to create shapes
            List<PointF> ListOfPoints = new List<PointF>();//create a list to add nwe points to
            double changeAngle = (Math.PI * 2) / numPoints; // adjust angle as per how many point are used
            PointF currentPos = new PointF();//make new points as per an angle increment 

            //set min distance for shape radius
            float minDist = (float)(_fRadius * (1 - variance));            

            //make a circle for each number of vertexs given
            for (double currentAngle = 0; currentAngle < (2*Math.PI); currentAngle += changeAngle)
            {
                //get a new random radius  for points given to draw the rocks
                double newRadius = _random.NextDouble() * (_fRadius - minDist) + minDist;

                //create a random length based on the minium radius
                currentPos.X = (float)(Math.Cos(currentAngle) * newRadius);
                currentPos.Y = (float)(Math.Sin(currentAngle) * newRadius);

                //add adjusted point to list
                ListOfPoints.Add(currentPos);
            }

            //add list of new points to be drawn 
            path.AddPolygon(ListOfPoints.ToArray());

            return path;
        }       

        /// <summary>
        /// renders the shapes being drawn as well as 
        /// if shapes are close enough to collide 
        /// display an Ellipse around the shape to showcompare area
        /// </summary>
        /// <param name="g"></param>
        public void Render(Graphics g)//clr not needed
        {
            //get the graphics path for the both shape classes
            GraphicsPath gp = GetPath();

            //fill in the shapes   
            g.FillPath(new SolidBrush(BaseColor), gp);

            //helps validate path
            //if IsMarkedForCompare is true draw an circle around at location
            if (IsMarkedForCompare==true)
            {
                //adds a circle around shape
                gp.AddEllipse(location.X-_fRadius,location.Y-_fRadius,_fRadius*2,2*_fRadius);                
                g.DrawPath(new Pen(Color.Green), gp);
            }
            else
            {
                g.FillPath(new SolidBrush(Color.Transparent), gp);
            }
        }

        /// <summary>
        ///  move shape according to speed vals and rotate at random
        /// </summary>
        /// <param name="boundaries"></param>
        public void Tick(Size boundaries)
        {
            PointF isOut = new PointF();
            isOut.X = (float)(location.X + _xfSpeed);
            isOut.Y = (float)(location.Y + _yfSpeed);

            //boudary checking for ListOfPoints
            if (isOut.X>=boundaries.Width)
            {
                isOut.X = boundaries.Width;
                _xfSpeed *= -1;
            }
            if (isOut.X <0)
            {
                isOut.X = 0;
                _xfSpeed *= -1;
            }
            if (isOut.Y >= boundaries.Height)
            {
                isOut.Y = boundaries.Height;
                _yfSpeed *= -1;
            }
            if (isOut.Y <0)
            {
                isOut.Y = 0;
                _yfSpeed *= -1;
            }

            //move shape   
            //and update if shape is out of bounds have it removed
            location = isOut;                     

            //get rotation for shape
            _fRotation += _fRotationIncrement;
        }
    }
}

/// <summary>
/// draw a rock with random amount of vertexs at a set varence
/// </summary>
class Rock : ShapeBase
{
    GraphicsPath _modelGraphicsPath = MakePolygonPath(_random.Next(4,12), _random.NextDouble());//= to make poly path
    //varience can be rdm btween 0 and 1 or a set value
    
    public Rock(PointF center) : base(center)
    {
        //find the center point
        location = center;
    }

    /// <summary>
    /// override getpath to draw and move the rocks
    /// </summary>
    /// <returns></returns>
    public override GraphicsPath GetPath()
    {
        GraphicsPath clone = (GraphicsPath)_modelGraphicsPath.Clone();

        //matrix
        Matrix RockMovement = new Matrix();       
        RockMovement.Translate(location.X, location.Y);
        RockMovement.Rotate(_fRotation);
        clone.Transform(RockMovement);

        return clone;
    }    
}

/// <summary>
/// draw a triangle with set amount of vertexs at no varience
/// </summary>
class Triangle : ShapeBase
{
    private static GraphicsPath _modelStaticPath = new GraphicsPath();

    // static one to remake path
    static Triangle()
    {
        //static stuff
        //calls rebuild model->model calls make polypath
        _modelStaticPath = MakePolygonPath(3, 0);
    }

    //instance one to get mouse pos-make triangle
    public Triangle(PointF centerF) : base(centerF)
    {
        //geting a center point for current shape
        location = centerF;
    }

    /// remake path when size is adjusted
    /// call make poly again with a new shape size
    /// </summary>
    public static void RebuildModel()
    {
        _modelStaticPath = MakePolygonPath(3, 0);      
    }

    /// <summary>
    /// ovvreide getpath to draw and move the rocks
    /// </summary>
    /// <returns></returns>
    public override GraphicsPath GetPath()
    {
        //make a clone of og GraphicsPath and assign it to a new GraphicsPath
        GraphicsPath clone =(GraphicsPath)_modelStaticPath.Clone();

        //check order of opersation
        Matrix TriangleMovement = new Matrix();        
        TriangleMovement.Translate(location.X, location.Y);
        TriangleMovement.Rotate(_fRotation);
        clone.Transform(TriangleMovement);

        return clone;
    }    
}

