using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Common.BO;
using System;

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
            lblHeader.Text = $"<< Server started at {server.LocalEndpoint} >>";
        }

        private async Task InitStream()
        {
            worker = await server.AcceptTcpClientAsync();
            stream = worker.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
        }

        private async Task HandleConnect()
        {
            while (true)
            {
                await InitStream();
                string request = await reader.ReadLineAsync();
                lbMSG.Items.Add($">> Request from {worker.Client.RemoteEndPoint} : {request}");
                
                RequestModel requestModel = JsonConvert.DeserializeObject<RequestModel>(request);
                // Nếu header là đặt món thì lấy thông tin đưa vào listbox tại đây
                string response = await Routing.RouteAppRequest(requestModel);

                await writer.WriteLineAsync(response);
                worker.Close();
            }
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            InitServer();
            await HandleConnect();
        }
    }
}
