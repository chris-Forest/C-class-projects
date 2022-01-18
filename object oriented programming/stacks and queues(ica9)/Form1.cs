//Submission Code : 1201_2300_A09
//Chris Forest
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using GDIDrawer;
using static System.Diagnostics.Trace;

namespace chris_ica9
{
    public partial class Form1 : Form
    {
        List<Queue<sheeple>> Qsheep = new List<Queue<sheeple>>();
        Stack<sheeple> StackSheep = new Stack<sheeple>();
        CDrawer CDrawer = null;
        private int scale = 20;
        private int count=0;
        private bool _running = false;
        private Random rnd = new Random();
        const int MAXSHEEP = 12;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(10, 10);

            timer1.Tick += Timer1_Tick;
            timer1.Start();
            timer1.Interval = 20;
            CDrawer = new CDrawer(800, 20);//defalut drawer, will be closed and new one is made on button press
            CDrawer.Position = new Point(this.Width,this.Height-124);
        }

        /// <summary>
        /// thread queue method to proccess queue data
        /// </summary>
        /// <param name="inQu"></param>
        private void QProcess(Queue<sheeple> inQu)
        {
            int sleeply = rnd.Next(20, 41) * 10;

            //sanity check to see if incoming data is valid
            if (!(inQu is Queue<sheeple> peep))
                throw new ArgumentException("Not a valid Queue of Sheeple");

            //Loop until the _running flag indicates an exit condition
            while (_running == true)
            {
                //sleep for a random amount of time
                Thread.Sleep(sleeply);

                //lock thread
                lock (peep)
                {
                    //Determine if your queue has anything to process, if not continue looping
                    if (peep.Count > 0)
                    {
                        //Have a Peek at process() of Sheeple in queue – its count of items will decrease
                        inQu.Peek().process();

                        //peek in queue to see if sheeple is done
                        if (peep.Peek().done == true)
                        {
                            // if so, remove and add to total(count) of items
                            count += peep.Peek().TotalItems;
                            peep.Dequeue();
                        }
                    }
                }              
            }

            lock (peep)
            {
                peep.Clear();
            }

            //output sample to see if done
            WriteLine($"thread {Thread.CurrentThread.ManagedThreadId}is done");
        }

        /// <summary>
        /// on click with set number of lines wanting to test
        /// simulate a queue system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simulateBtn_Click(object sender, EventArgs e)
        {
            //clear running flag
            _running = false;

            //use any() with a lambda to perform sleep(10) in a loop
            //until all queues are empty(signal that threads r terminated)
            while (Qsheep.Any(Qs => Qs.Count > 0) || StackSheep.Count > 0)
                Thread.Sleep(10);

            //Clear your list and stats.
            Qsheep.Clear();
            count = 0;

            //close exsisting drawer and allocate new one
            if (CDrawer != null)
                CDrawer.Close();

            CDrawer = new CDrawer(800, (int)howManyUpDown1.Value * scale,false);
            CDrawer.Position = new Point(this.Width, this.Height - 124);
            //CDrawer.Scale = scale;

            for (count = 0; count < MAXSHEEP; count++)
            {
                StackSheep.Push(new sheeple());
            }

            for (count = 0; count < howManyUpDown1.Value; count++)
            {
                Qsheep.Add(new Queue<sheeple>());
            }

            _running = true;//enable run bool

            //create and start a Thread, passing the thread its processing Queue from our list
            //(it doesn't need to see any other Queues)
            foreach (Queue<sheeple> item in Qsheep)
            {
                Thread newTH = new Thread(() => QProcess(item));
                newTH.IsBackground = true;
                newTH.Start();
            }
        }

        //Your Timer should be running all the time ( 20ms )
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //check first if a CDrawer exists, if not, return, nothing to do
            if (CDrawer == null)
                return;

            int crntX = 0, crntY = 0, empty = 0;

            //base version- populate a single waiting Sheeple once for each timer callback into
            //the first queue found to have less than 6 Sheeple.

            //1.Check if any Sheeple are waiting in the Stack, if so, find the first queue with less than 6
            //Sheeple, and add that Sheeple, if no queue has space, do not add a Sheeple.Note that you
            //may not remove the Sheeple from the waiting Stack if there is not a spot for it.This pass
            //should only ever result in a single Sheeple transition from waiting to queue'd.
            //if (_inPassengers.Count > 0)
            //if (StackSheep.Count>0)
            //{
            //    // add to queue here 
            //    foreach (Queue<sheeple> queue in Qsheep)
            //    {
            //        lock (queue)
            //        {
            //            if (queue.Count < 6)
            //                queue.Enqueue(StackSheep.Pop());
            //        }
            //    }
            //}

            //brave version-we want move our waiting Sheeple to the queues only if there is actual room in our
            //display to fully show the Sheeple, and then add it to the actual shortest queue length(we don't
            //know how slow the processing is ).

            //1.Using a combination of lambdas with Any(), Sum() our existing queues and the next
            //potential Sheeple determine if there is room to completely show the waiting Sheeple(use
            //total items here).If there is, find, using OrderBy() and First() determine the shortest actual
            //queue( using current items ) to add the new Sheeple to and add them to the queue.To
            //slightly simplify, and ease the application of our desired extension+lambdas, we will ignore
            //locking when examining the queue sizes, as they are reads and won't modify the collection.
            //You must still lock for any modifications made.
            if (StackSheep.Count > 0)
            {
                if (Qsheep.Any(sheepx => sheepx.Sum(sheepy => sheepy.currentItems) * scale
                + StackSheep.Peek().TotalItems * scale < CDrawer.ScaledWidth))
                {
                    lock (Qsheep)
                        Qsheep.OrderBy(xxx => xxx.Sum(yyy => yyy.currentItems)).First().Enqueue(StackSheep.Pop());
                }
            }

            //2.Display our Queues. Using nested foreach ()’s, invoke ShowSheeple with their respective
            //queue line one unit tall, shifting over for each Sheeple ( like Prediblocks, but no end / wrap
            //check )
            CDrawer.Clear();
            foreach (Queue<sheeple> queue in Qsheep)
            {
                //crntY = Qsheep.IndexOf(queue);
                crntX = 0;
                foreach (sheeple item in queue)
                {
                    //Invoke(new Action(() => item.showSheep(CDrawer, crntX, crntY)));
                    item.ShowSheeple(CDrawer, crntX, crntY, scale);
                    crntX += item.TotalItems;
                }
                crntY++;

                if (queue.Count == 0)
                {
                    empty++;
                }
            }
            CDrawer.Render();

            //3.Update the running total processed value as shown in title bar, and update the “Next
            //Sheeple” label to show the size and color of the next Sheeple waiting in the Stack.
            this.Text = count.ToString();
            if (StackSheep.Count > 0)
            {
                labelStack.Text = StackSheep.Peek().TotalItems.ToString();
                labelStack.BackColor = StackSheep.Peek().sheepColor;
            }
            else
            {
                labelStack.Text = "0";
                labelStack.BackColor = Control.DefaultBackColor;
            }
        }
    }
}

