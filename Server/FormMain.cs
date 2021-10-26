using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Common.BO;
using System;
using Common.Extension;
using Server.Repository.Implement;
using Common.DAO;
using Server.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Server.Repository.Interface;

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

                string response = await new Routing().RouteAppRequest(requestModel);
                if (requestModel.Header == Constant.Place_Order) await ShowOrder(requestModel);

                await writer.WriteLineAsync(response);
                worker.Close();
            }
        }

        private async Task ShowOrder(RequestModel requestModel)
        {
            int UserId = Convert.ToInt32(requestModel.Payload);
            LuxuryContext _db = new LuxuryContext();
            OrderHeader orderHeader = await _db.OrderHeaders.Include(c=>c.OrderDetails)
                                        .FirstOrDefaultAsync(c => c.UserId == UserId);
            User user = await _db.Users.FindAsync(UserId);
            StringBuilder sb = new StringBuilder();
            sb.Append($">> Order request from  {user.DisplayName} : ");
            foreach(OrderDetail od in orderHeader.OrderDetails)
            {
                sb.AppendLine($"{od.FoodId} : {od.Count}");
            }
            lbMSG.Items.Add(sb.ToString());
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            InitServer();
            await HandleConnect();
        }
    }
}
