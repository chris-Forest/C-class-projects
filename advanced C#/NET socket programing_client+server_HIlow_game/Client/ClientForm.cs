//Submission code : 1202_CMPE2800_HILO_CLIENT
//Chris Forest
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using static System.Diagnostics.Trace;
using System;
using WinFrameLib;

/// <summary>
/// win won game disconsct from server
/// </summary>
namespace Client
{
    public partial class ClientForm : Form
    {
        Socket _socket = null;
        BinaryFormatter _bf = new BinaryFormatter();
        Thread re;
        bool connection = false;
        public ClientForm()
        {
            InitializeComponent();
            Text = "High/Low Number Guesser";
            //AdressBox.Text = "bits.net.nait.ca";
            AdressBox.Text = "127.0.0.1";
            PortTextBox.Text = "1667";
            ConnectionButton.Click += ConnectionButton_Click;
            TrackBarGuess.Scroll += TrackBarGuess_Scroll;
            GuessButton.Click += GuessButton_Click;
            GuessButton.Enabled = false;
            TrackBarGuess.Enabled = false;
        }

        //save the trackbar val and send guess to server
        private void GuessButton_Click(object sender, EventArgs e)
        {            
            try
            {
                ListBoxStatus.Items.Insert(0, $"Guess: {TrackBarGuess.Value}");
                GuessFrame gf = new GuessFrame();
                gf.Value = TrackBarGuess.Value;

                MemoryStream ms = new MemoryStream();
                _bf.Serialize(ms, gf);
                _socket.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                Thread.Sleep(200);// pause between sends
            }
            catch (Exception err)
            {
                ListBoxStatus.Items.Insert(0, $"guess: error {err.Message}");
            }          
        }     

        //connect to server and disconect from server
        //on every new connection reset guess inputs
        private void ConnectionButton_Click(object sender, EventArgs e)
        {            
            if (connection == false)
            {
                MakeConnection();
                GuessButton.Enabled = true;
                TrackBarGuess.Enabled = true;
                //on every new connection reset inputs
                TrackBarGuess.Minimum = 0;
                TrackBarGuess.Maximum = 1000;
                TrackBarGuess.Value = 500;
                GuessValLabel.Text = TrackBarGuess.Value.ToString();
                L_min.Text = TrackBarGuess.Minimum.ToString();
                L_High.Text = TrackBarGuess.Maximum.ToString();
            }
            else
            {
                //close connection
                disconect();
            }
        }
        void disconect()
        {
            //Disable both sending and receiving on this Socket.
            _socket?.Shutdown(SocketShutdown.Both);
            // Closes the Socket connection and releases all associated resources.
            _socket?.Close();
            re.Abort();//not needed           
            ConnectionButton.Text = "Connect";
            connection = false;//we disconected
            GuessButton.Enabled = false;
            TrackBarGuess.Enabled = false;            
        }
        
        private void MakeConnection()
        {
            //ConnectionButton.Text = "Connecting";
            try
            {                
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //_socket.BeginConnect(host,port callback,state)
                _socket.BeginConnect(AdressBox.Text,Convert.ToInt32(PortTextBox.Text), cbConnect, null);
                ConnectionButton.Text = "Connecting";//here?
                //msg to listbox on good connection
                ListBoxStatus.Items.Insert(0,"Connection: Success");
            }
            catch (Exception err)
            {
                //msg to listbox on error with connection
                ListBoxStatus.Items.Insert(0,$"MakeConnection: error {err.Message}");
            }
            ConnectionButton.Text = "Disconnect";
            //can Disconnect when already connected on btn press
            connection = true;
        }
        void cbConnect(IAsyncResult ar)// Async callback, runs in Begin() threadpool thread
        {
            try
            {
                //end connection
                _socket.EndConnect(ar);
                _socket.NoDelay = true;// no delay on send ever..
                //send guess here?
                Invoke(new Action(() => { StartReceiveThread(_socket); }));
            }
            catch (Exception err)
            {
                //msg err?
                //Invoke(new Action(() => { ListBoxStatus.Items.Insert(0, $"cbConnect: error {err.Message}"); }));
                ListBoxStatus.Items.Insert(0,$"cbConnect: error {err.Message}");
            }
        }
        //reset all game elements to default in here
        //call this method to cbConnect(a callBack method)
        void StartReceiveThread(Socket socket)
        {
            //threading?
            re = new Thread(RecieveThread);
            re.IsBackground = true;
            re.Start(socket);
        }
        //send thread?
        void RecieveThread(object obj)
        {
            byte[] buff = new byte[2000];

            //if (!(obj is Socket sock)) return;
            Socket sock = (Socket)obj;
            // not specifically required (could access as a member)
            // ensure that receive calls won't timeout!
            sock.ReceiveTimeout = 0;

            while(true)//go until connection terminates
            {
                int iNumBytes = 0;
                try
                {
                    // block on receive - will throw on hard disco
                    iNumBytes = sock.Receive(buff);                    
                }
                catch (SocketException err)
                {
                    // invoke handle loss of connection here then end thread!
                    Invoke(new Action(() => { ListBoxStatus.Items.Insert(0, $"RecieveThread:Hard Disco {err.Message}"); }));
                    Invoke(new Action(() => { disconect(); }));
                    return;
                }
                if (iNumBytes == 0)//if won game
                {
                    // invoke handle loss of connection here then end thread!
                    Invoke(new Action(() => { ListBoxStatus.Items.Insert(0, $"RecieveThread: soft disco "); })); 
                    Invoke(new Action(() => { disconect(); }));//soft disco
                    return;
                }
                object objfr = _bf.Deserialize(new MemoryStream(buff));
              
                if(objfr is HiFrame high)
                {                    
                    Invoke(new Action(() => { updateForm(TrackBarGuess.Value,"high", $"to high {high.hint}"); }));
                }               
                else if (objfr is LowFrame low)//else
                {                    
                    Invoke(new Action(() => { updateForm(TrackBarGuess.Value, "low", $"to low {low.hint}"); }));
                }
                else if (objfr is WinFrame winer)//else
                {
                    Invoke(new Action(() => { ListBoxStatus.Items.Insert(0, $"{winer.Congrats}"); }));
                }
                else
                {
                    Invoke(new Action(() => { ListBoxStatus.Items.Insert(0, $"RecieveThread : unknown"); }));
                    Invoke(new Action(() => { disconect(); }));
                    return;
                }
            }
        }
        void updateForm(int guess,string text,string hint)
        {
            ListBoxStatus.Items.Insert(0,$"guess: {hint}");
            if(text=="high")
            {
                //if lower adjust TB to new max
                TrackBarGuess.Maximum = guess - 1;
                L_High.Text = TrackBarGuess.Maximum.ToString();
            }
            if (text == "low")
            {
                //if lower adjust TB to new min 
                TrackBarGuess.Minimum = guess + 1;
                L_min.Text = TrackBarGuess.Minimum.ToString();
            }
            TrackBarGuess.Value = (TrackBarGuess.Minimum + TrackBarGuess.Maximum) / 2;
            GuessValLabel.Text = TrackBarGuess.Value.ToString();
        }
        private void TrackBarGuess_Scroll(object sender, EventArgs e)
        {
            GuessValLabel.Text = TrackBarGuess.Value.ToString();
        }
    }
}
