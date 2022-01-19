using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Chrid_Hi_Low_Game
{
    public partial class Form1 : Form
    {
        Socket _socket = null;
        BinaryFormatter _bf = new BinaryFormatter();
        public Form1()
        {
            InitializeComponent();
            Text = "High/LowNumber Gusser";
        }
    }
}
