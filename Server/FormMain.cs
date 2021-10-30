using Server.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Common.Extension;
using Newtonsoft.Json;
using System.Drawing;
using System.Linq;
using Common.DAO;
using System.Net;
using System.IO;
using Common.BO;
using System;
using Server.Repository.Implement;

namespace Server
{
    public partial class FormMain : Form
    {
        private TcpListener server;
        private TcpClient worker;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private readonly IUserRepository _ur;
        private readonly IOrderRepository _or;

        public FormMain()
        {
            InitializeComponent();
            _ur = new UserRepository();
            _or = new OrderRepository();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            await LoadTable();
            InitServer();
            await HandleConnect();
        }

        #region Socket

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
        #endregion

        #region Order
        private async Task ShowOrder(RequestModel requestModel)
        {
            int UserId = Convert.ToInt32(requestModel.Payload);
            User user = await _ur.FindUserById(UserId);
            string msg = $">> {user.DisplayName} đã đặt món !";
            lbMSG.Items.Add(msg);
        }

        private async Task LoadTable()
        {
            try
            {
                List<User> listUser = await _ur.LoadUserWithOrder();
                int x = 10;
                int y = 10;
                for (int i = 0; i < listUser.Count; i++)
                {
                    Button btn = new Button()
                    {
                        Name = "btnTable" + (i + 1),
                        Text = listUser[i].DisplayName,
                        Tag = listUser[i].Id,
                        Width = 100,
                        Height = 50,
                        Location = new Point(x, y),
                    };
                    if (x < pnlTable.Width - 220)
                    {
                        x += 110;
                    }
                    else
                    {
                        x = 10;
                        y += 60;
                    }
                    OrderHeader order = await _or.GetOrderOfUser(listUser[i].Id);
                    if (order == null)
                    {
                        btn.BackColor = ColorTranslator.FromHtml("snow");
                    }
                    else
                    {
                        btn.BackColor = ColorTranslator.FromHtml("red");
                    }
                    btn.MouseClick += new MouseEventHandler(btnTable_MouseClick);
                    pnlTable.Controls.Add(btn);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void btnTable_MouseClick(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(((Button)sender).Tag);
            OrderHeader order = await _or.GetOrderOfUser(UserId);
            if (order != null)
            {
                lblTotal.Text = order.OrderTotal.ToString() + " VNĐ";

                pnlOrder.Controls.Clear();
                List<OrderDetail> orderDetail = await _or.GetOrderDetail(order.Id);
                int y = 10;
                for (int i = 0; i < orderDetail.Count; i++)
                {
                    Label lbl = new Label()
                    {
                        Name = "btnFB" + i,
                        Text = $"  {orderDetail[i].Food.Name,-30}{orderDetail[i].Count,5}",
                        Width = pnlOrder.Width - 20,
                        Height = 20,
                        Location = new Point(5, y)
                    };
                    y += 27;
                    pnlOrder.Controls.Add(lbl);
                }
            }
        }
        #endregion
    }
}
