//Submission code : 1202_CMPE2800_HILO_SERVER
//Chris Forest

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Diagnostics.Trace;

namespace server
{
    public partial class ServerForm : Form
    {
        Socket _listener = null;

        //every time a client connects make new instance of ClientConnect class and add it to list
        List<ClientConnect> Listcc = new List<ClientConnect>();//don't know how to use this at all     
                
        public ServerForm()
        {
            InitializeComponent();
            Text = "server";
            Shown += ServerForm_Shown;
            rdoSoft.Checked = true;
        }

        /// <summary>
        /// start a thread for server proccessing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServerForm_Shown(object sender, EventArgs e)
        {
            StartListen();
        }

        /// <summary>
        /// start listening for connections
        /// and begin accepting connection attepmts
        /// </summary>
        void StartListen()
        {            
            try
            {
                _listener?.Close();

                // Makes the socket, no action yet
                _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Wire it up to the network.. mostly likely point of failure.. security
                _listener.Bind(new IPEndPoint(IPAddress.Any, 1667));

                _listener.Listen(1);
                
                Invoke(new Action(() => { listBox1.Items.Insert(0, "Server StartListening"); }));

                //begin accepting connection attempts
                _listener.BeginAccept(cbAccept, null);
            }
            catch (Exception err)
            {
                _listener = null;
                Invoke(new Action(() => { listBox1.Items.Insert(0, $"StartListening:Error {err.Message}"); }));
            }
        }
        
        /// <summary>
        /// callback method for accepting a connection
        /// establish a new client,start a connection
        /// start recieving data
        /// display who is connected,how many people are connected
        /// add connecting clients to a collection
        /// </summary>
        /// <param name="ar"></param>
        void cbAccept(IAsyncResult ar)
        {
            try
            {
                ClientConnect cc = new ClientConnect();

                //accpet incoming connection requests
                cc._Client = _listener.EndAccept(ar);

                Invoke(new Action(() => { listBox1.Items.Insert(0, $"{ cc._Client.RemoteEndPoint} :Connected"); }));

                Invoke(new Action(() => { StartRxThread(cc); }));

                //add client socket to collection
                Listcc.Add(cc);

                Invoke(new Action(() => { label1.Text = $"Clients: {Listcc.Count}"; }));
                _listener.BeginAccept(cbAccept, null);
            }
            catch (Exception exc)
            {
                Invoke(new Action(() => { listBox1.Items.Insert(0, $"cbAccept:exception raised : {exc.Message}"); }));
            }
        }

        /// <summary>
        /// start the recieve thread
        /// </summary>
        /// <param name="cc"></param>
        void StartRxThread(ClientConnect cc)
        {
            Thread re = new Thread(rx);
            re.IsBackground = true;
            re.Start(cc);
        }

        /// <summary>
        /// thread method
        /// detects a hrad and soft disco
        /// calls the proccess method from connect class
        /// get and send response from client guess
        /// </summary>
        /// <param name="obj"></param>
        void rx(object obj)
        {
            byte[] buff = new byte[2000];

            //if object is not the class return
            if (!(obj is ClientConnect sock)) return;

            //keeprunning game until a win or disco is detected
            while (true)
            {
                string resp = "";
                int NumBytes = 0;
                try
                {
                    NumBytes = sock._Client.Receive(buff);
                }
                catch (Exception exc)//hard disco detection
                {
                    Invoke(new Action(() => { listBox1.Items.Insert(0, $"Rx: Hard disco {exc.Message}"); }));
                    sock._Client.Close();
                    Listcc.Remove(sock);
                    Invoke(new Action(() => { label1.Text = $"Clients: {Listcc.Count}"; }));
                    return;
                }
                //soft disco detection
                //updates connected clients label 
                if (NumBytes == 0)
                {
                    Invoke(new Action(() => { listBox1.Items.Insert(0, $"Rx: soft disco "); }));
                    sock._Client.Disconnect(false);
                    Listcc.Remove(sock);
                    Invoke(new Action(() => { label1.Text = $"Clients: {Listcc.Count}"; }));
                    return;
                }
                resp = sock.proccess(buff);

                if (sock.won)
                {            
                    sock._Client.Disconnect(false);//soft disco
                    Listcc.Remove(sock);
                    Invoke(new Action(() => { label1.Text = $"Clients: {Listcc.Count}"; }));
                }

                Invoke(new Action(() => { listBox1.Items.Insert(0, $"{resp}"); }));
            }
        }
                
        /// <summary>
        /// based on rdo btn choice
        /// hard of soft disco a client on btn click
        /// remove client from class collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiscoBtn_Click(object sender, EventArgs e)
        {
            for (int i = Listcc.Count - 1; i >= 0; i--)
            {
                //hard dc by server
                if (rdoHard.Checked)
                {
                    Listcc[i]._Client.Close();                              
                    Listcc.Remove(Listcc[i]);
                    Invoke(new Action(() => { label1.Text = $"Clients: {Listcc.Count}"; }));
                }
                //soft disco by server
                if (rdoSoft.Checked)
                {
                    Listcc[i]._Client.Disconnect(false);                 
                    Listcc.Remove(Listcc[i]);
                    Invoke(new Action(() => { label1.Text = $"Clients: {Listcc.Count}"; }));
                }
            }
        }
    }

    /// <summary>
    /// evey time a new client is connected re-establish(new instance) of client
    /// new client connected, new random number picked
    /// </summary>
    public class ClientConnect
    {
        public Socket _Client = null;
        BinaryFormatter _bf = new BinaryFormatter(); // formatter (how to serialize)
        private static Random rng = new Random();

        public int Attempts = 0;//trck number of attepts made by clients
        public int SecretNumber = rng.Next(0, 1001);//get random number from range assigning it to varible

        //bool for win game
        public bool won { get; private set; }

        /// <summary>
        /// procces clients guess
        /// and assgin a string response to be displayed in client form
        /// </summary>
        /// <param name="buff"></param>
        /// <returns></returns>
        public string proccess(byte[] buff)
        {
            string resp = "";
            object frame = null;
            Random rng = new Random();

            object obj = _bf.Deserialize(new MemoryStream(buff));

            Attempts++;

            //if object Deserialize is the guess frame
            //start proccessing clients guess            
            if (obj is WinFrameLib.GuessFrame gf)
            {
                //comparsons of guess to hidden number                    
                if (gf.Value < SecretNumber)//if guess too low
                {
                    WinFrameLib.LowFrame lf = new WinFrameLib.LowFrame();
                    var ToLow = (WinFrameLib.LowFrame.EHint[])Enum.GetValues(typeof(WinFrameLib.LowFrame.EHint));
                    lf.hint = ToLow[rng.Next(ToLow.Length)];
                    frame = lf;

                    resp = $"IP:{_Client.LocalEndPoint} :Number {SecretNumber} :Guess {gf.Value}";
                }
                //if guess too high
                else if (gf.Value > SecretNumber)
                {
                    //call high frame with rdm enum hint response
                    WinFrameLib.HiFrame hf = new WinFrameLib.HiFrame();
                    var ToHigh = (WinFrameLib.HiFrame.EHint[])Enum.GetValues(typeof(WinFrameLib.HiFrame.EHint));
                    hf.hint = ToHigh[rng.Next(ToHigh.Length)];
                    frame = hf;

                    resp = $"IP:{_Client.LocalEndPoint} :Number {SecretNumber} :Guess {gf.Value}";
                }
                //win condition
                else if (gf.Value == SecretNumber)
                {
                    won = true;
                    WinFrameLib.WinFrame wf = new WinFrameLib.WinFrame();
                    string winMsg = $"won in {Attempts} Attempts";
                    wf.Congrats = winMsg;
                    frame = wf;

                    resp = $"{_Client.RemoteEndPoint}: won in {Attempts} Attempts";
                }              

                try
                {
                    MemoryStream ms = new MemoryStream();
                    _bf.Serialize(ms, frame);
                    //send back response to client
                    _Client.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                }
                catch (Exception exc)
                {
                    resp = $"send err: {exc.Message}";
                }
            }
            else//if bad frame detected
            {
                resp = "unknown frame recieved";
                _Client.Disconnect(false);                
            }
            return resp;
        }
    }
}
