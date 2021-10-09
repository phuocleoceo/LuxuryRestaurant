using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FormMain : Form
    {
        private TcpListener server;
        private TcpClient worker;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public FormMain()
        {
            InitializeComponent();
        }

        private void InitServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 1308);
            server.Start(10);
            lblHeader.Text=$"<< Server started at {server.LocalEndpoint} >>";
        }

        private async Task InitStream()
        {
            worker = await server.AcceptTcpClientAsync();
            stream = worker.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
        }

        private async Task Handle()
        {
            while (true)
            {
                await InitStream();
                string request = reader.ReadLine();
                lbMSG.Items.Add($">> Request from {worker.Client.RemoteEndPoint} : {request}");
                worker.Close();
            }
        }

        private async Task FormMain_Load(object sender, EventArgs e)
        {
            InitServer();
            await Handle();
        }
    }
}
