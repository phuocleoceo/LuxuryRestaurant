using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Common.Extension;
using Newtonsoft.Json;
using Server.Data;
using Common.DAO;
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
        private LuxuryContext _db;

        public FormMain()
        {
            InitializeComponent();
            _db = new LuxuryContext();
        }

        private void InitServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 1008);
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
                RequestModel requestModel = JsonConvert.DeserializeObject<RequestModel>(request);

                if (requestModel.Header == Constant.Place_Order) await ShowOrder(requestModel);
                string response = await new Routing().RouteAppRequest(requestModel);

                await writer.WriteLineAsync(response);
                worker.Close();
            }
        }

        private async Task ShowOrder(RequestModel requestModel)
        {
            int UserId = Convert.ToInt32(requestModel.Payload);
            User user = await _db.Users.FindAsync(UserId);
            string msg = $">> {user.DisplayName} đã đặt món !";
            lbMSG.Items.Add(msg);
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            InitServer();
            await HandleConnect();
        }
    }
}
