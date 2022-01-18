using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ica_18EqualsStarter
{
    public interface IRender
    {
        void Render(CDrawer dr);
    }

    public abstract class Shape : IRender
    {
        public Point Pos { get; private set; }
        public Shape(Point InitPos) => Pos = InitPos;
        public void Render(CDrawer dr)
        {// NVI Render model used
         // Pre-work here...
            vRender(dr);
            // Post-work here..
        }
        protected abstract void vRender(CDrawer dr);
        public override bool Equals(object obj)
        {
            // not the same types (or null), can't be equal...
            if (obj == null || !GetType().Equals(obj.GetType()))
                return false;
            // could check position here, but that would mean items
            // were only the same if the position was the same
            // not looking for that behaviour, so ignore position
            // no member checking, so unless error, at this point
            // we are the same!
            return true;
        }
        public abstract override int GetHashCode();
    }

    //class to build square shape
    class Square : Shape
    {
        double Length;

        //set deafult size
        public Square(Point p, double l) : base(p)
        {
            Length = l;
        }

        //check for same sized shapes
        public override bool Equals(object obj)
        {
            base.Equals(obj);
            if (!(obj is Square arg))
                return false;
            return Length.Equals(arg.Length);
        }
        public override int GetHashCode()
        {
            return 1;
        }

        // Render for use in Square, modify as required for Circle class Render
        protected override void vRender(CDrawer dr)
        {
            dr.AddCenteredRectangle(Pos, (int)Length, (int)Length, Color.LightCyan, 2, Color.Red);
            Rectangle tout = new Rectangle(
            (int)(Pos.X - Length),
            (int)(Pos.Y - Length),
            (int)(Length * 2),
            (int)(Length * 2));
            dr.AddText($"{Length}", Math.Max((int)(Length * 0.4), 8), tout, Color.Black);
        }
    }
    //class to build Circle shape
    class Circle : Shape
    {
        double diameter;

        //set default diameter
        public Circle(Point p, double l) : base(p)
        {
            diameter = l;
        }

        //check for same sized shapes
        public override bool Equals(object obj)
        {
            base.Equals(obj);
            if (!(obj is Circle arg))
                return false;
            return diameter.Equals(arg.diameter);
        }
        public override int GetHashCode()
        {
            return 1;
        }

        // Render for use in Circle class Render
        protected override void vRender(CDrawer dr)
        {
            dr.AddCenteredEllipse(Pos, (int)diameter, (int)diameter, Color.LightCyan, 2, Color.Blue);
            Rectangle tout = new Rectangle(
            (int)(Pos.X - diameter),
            (int)(Pos.Y - diameter),
            (int)(diameter * 2),
            (int)(diameter * 2));
            dr.AddText($"{diameter}", Math.Max((int)(diameter * 0.4), 8), tout, Color.Black);
        }
    }
}
