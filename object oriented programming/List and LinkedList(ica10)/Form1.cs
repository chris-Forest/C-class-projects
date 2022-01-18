//Submission Code : 1201_2300_A10
//chris forest
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

namespace chris_ica10
{
    public partial class Form1 : Form
    {
        List<Point> ptr = new List<Point>();
        LinkedList<Point> linkedPoint = new LinkedList<Point>();
        CDrawer drawer = null;

        public Form1()
        {
            InitializeComponent();
            ListButton.Click += MakeList_Click;
            ShufflleButton.Click += ShufflleButton_Click;
            POPbutton.Click += Populate_Click;
            FilterANDorderBtn.Click += FilterANDorder_Click;
            drawer = new CDrawer();
            drawer.ContinuousUpdate = false;
        }

        //[Make List]
        //extract the divisor as an integer.Using that divisor and the ScaledWidth and ScaledHeight of the CDrawer
        //use nested for() loops to generate all possible Points within the CDrawer window (based on the divisor increments)
        private void MakeList_Click(object sender, EventArgs e)
        {
            int divisor = (int)divisorUpDown.Value;

            //nested loops to generate all points in cdrawer
            for (int y = 0; y < drawer.ScaledHeight; y+=divisor)//y vals
            {
                for (int x = 0; x < drawer.ScaledWidth; x+=divisor)//x vals
                {
                    ptr.Add(new Point(x, y));
                }
            }

            //once list has been populated , clear the drawer
            drawer.Clear();

            //itterate through list points while drawing fuchsia lines between all adjcent points
            for (int i = 1; i < ptr.Count; i++)
                if (i != 1)
                    drawer.AddLine(ptr[i - 1].X, ptr[i - 1].Y, ptr[i].X, ptr[i].Y, Color.Fuchsia);

            //render drawn lines
            drawer.Render();

            //display number of points in list
            ListButton.Text = $"List contains: {ptr.Count} points";
        }

        //using an extension method shuffle list points
        //while not modifing exsisting list in green lines
        private void ShufflleButton_Click(object sender, EventArgs e)
        {
            //invoke extension method
            ptr = ptr.Shuffle();

            drawer.Clear();

            //display  shuffleed list
            for (int i = 1; i < ptr.Count; i++)
                if (i != 1)
                    drawer.AddLine(ptr[i - 1].X, ptr[i - 1].Y, ptr[i].X, ptr[i].Y, Color.Green);
            drawer.Render();
        }

        //Your[populate] button will clear the LinkedList.Then using foreach() iterate through your List of points
        //attempting to insert the Point in its appropriate location using these steps :
        //  - determine if the LinkedList is empty, if so, add the Point as the first node, skip/continue to next foreach()
        //    Point
        //  - otherwise make a new LinkedListNode initialized to the start of the list to use in traversing your list
        //    looking for either the correct location or the end of the list.You will loop and stop when either :
        //      o (X* Height + Y ) values of the current Point compared to the same of the current LinkedListNode
        //        indicates the correct position – What does the comparision expression ensure ?
        //      o or the end of the list is reached
        //  - Now, the loop has completed - you are either at the end of the list, or you stopped at the correct node for
        //    insert.Now Add the point appropriately.Note that the linked list collection allows you to add before and
        //    after a given Node or the beginning or end of the linked list
        private void Populate_Click(object sender, EventArgs e)
        {
            //clear link list
            linkedPoint.Clear();

            //for each through list of points and insert at appropriate location
            foreach (Point point in ptr)
            {
                LinkedListNode<Point> node = linkedPoint.First;

                while ((node != null) && (node.Value.X * drawer.ScaledHeight + node.Value.Y) < (point.X * drawer.ScaledHeight + point.Y))
                    node = node.Next;

                //if empty add add first list node 
                if (node != null)
                    linkedPoint.AddBefore(node, point);
                else
                    linkedPoint.AddLast(point);                             
            }
            drawer.Clear();

            //loop thropugh list node drawing yellow lines
            for (LinkedListNode<Point> node = linkedPoint.First; node!=linkedPoint.Last; node=node.Next)
                if (node.Next != null)//should be if(node.next!=null) was if (node != linkedPoint.First)
                    drawer.AddLine(node.Value.X, node.Value.Y, node.Next.Value.X, node.Next.Value.Y, Color.Yellow);

            drawer.Render();

            POPbutton.Text = $"Linked list contains: {linkedPoint.Count} Points";
        }

        //using a Where() and OrderBy() create
        //an enumerated collection used to construct a new LinkedList to replace the existing linkedlist.
        private void FilterANDorder_Click(object sender, EventArgs e)
        {
            int divisor = (int)divisorUpDown.Value;

            //using lambdas, where shall extract points where the X/Divisor and Y/Divisor sum is odd.
            //OrderBy:order the points by the increasing distance from the origin
            LinkedList<Point> orderdLinkList = new LinkedList<Point>(
                linkedPoint.Where(x => ((x.X / divisor) + (x.Y / divisor)) % 2 != 0).OrderBy(item => Math.Sqrt((item.X * item.X) + (item.Y * item.Y))));

            drawer.Clear();

            //display your linkedlist
            //again,as blue lines
            for (LinkedListNode<Point> node = orderdLinkList.First; node != orderdLinkList.Last; node = node.Next)
                if (node != orderdLinkList.First)
                    drawer.AddLine(node.Previous.Value.X, node.Previous.Value.Y, node.Value.X, node.Value.Y, Color.Blue);

            drawer.Render();

            FilterANDorderBtn.Text = $"Filtered LinkList Contains: {orderdLinkList.Count}";
        }
    }
}
