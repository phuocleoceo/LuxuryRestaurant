using Common.DTO;
using Common.Entities;
using Common.Extension;
using Newtonsoft.Json;
using Server.Repository.Implement;
using Server.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private readonly IUserRepository _ur;
        private readonly IOrderRepository _or;
        private readonly IPAddress IPAddress;
        private readonly int port;
        private StringBuilder printContent;

        public FormMain(IPAddress IPAddress, int port)
        {
            InitializeComponent();
            this.IPAddress = IPAddress;
            this.port = port;
            _ur = new UserRepository();
            _or = new OrderRepository();
            printContent = new StringBuilder();
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
            server = new TcpListener(IPAddress, port);
            server.Start(10);
            lblHeader.Text = $"<< Server started at {server.LocalEndpoint} >>";
        }

        private async Task InitStream()
        {
            client = await server.AcceptTcpClientAsync();
            stream = client.GetStream();
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
                if (requestModel.Header == Constant.Message_Request) await ShowRequest(requestModel);

                await writer.WriteLineAsync(response);
                client.Close();
            }
        }
        #endregion

        #region Order
        private async Task ShowOrder(RequestModel requestModel)
        {
            await LoadTable();
            int UserId = Convert.ToInt32(requestModel.Body);
            string DisplayName = await _ur.GetDisplayName(UserId);
            string msg = $"> {DisplayName} đã đặt món !";
            lbMSG.Items.Add(msg);
        }

        private async Task LoadTable()
        {
            try
            {
                pnlTable.Controls.Clear();
                List<User> listUser = await _ur.LoadCustomer();
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
                        Location = new Point(x, y)
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
                    List<OrderHeader> order = await _or.GetOrderOfUser(listUser[i].Id);
                    if (order.Count == 0)
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
            string DisplayName = ((Button)sender).Text;
            lblTableName.Text = DisplayName;

            int UserId = Convert.ToInt32(((Button)sender).Tag);
            pnlOrder.Tag = UserId;

            // Khởi tạo lại printContent
            printContent.Clear();
            printContent.AppendLine("\t\t\t\tLuxury Restaurant P&N\n");
            printContent.AppendLine("\t\t\t\tHoa don thanh toan\n");


            List<OrderHeader> order = await _or.GetOrderOfUser(UserId);
            if (order.Count > 0)
            {
                printContent.AppendLine("\t\t\tNgay dat mon : " + order.Last().OrderDate);
                printContent.AppendLine("\t\t\tNgay thanh toan : " + DateTime.Now);
                printContent.AppendLine($"\n{"Mon an",-40}\t{"Don gia",20}\t{"So luong",20}\t{"Thanh Tien",20}");

                pnlOrder.Controls.Clear();
                double total = order.Sum(c => c.OrderTotal);
                lblTotal.Text = total.ToString() + " VNĐ";

                // Ghep tat ca List<OrderDetail> lai thanh 1
                List<OrderDetail> orderDetail = await _or.GetOrderDetail(order);

                // Hien thi danh sach mon an
                int y = 10;
                for (int i = 0; i < orderDetail.Count; i++)
                {
                    string FoodName = orderDetail[i].Food.Name;
                    double FoodPrice = orderDetail[i].Food.Price;
                    int OrderCount = orderDetail[i].Count;
                    Label lbl = new Label()
                    {
                        Name = "btnFB" + i,
                        Text = $"  {FoodName,-30}{OrderCount,5}",
                        Width = pnlOrder.Width - 20,
                        Height = 20,
                        Location = new Point(5, y)
                    };
                    y += 27;
                    pnlOrder.Controls.Add(lbl);
                    printContent.AppendLine($"{FoodName,-40}\t{FoodPrice,20}\t{OrderCount,20}\t{FoodPrice * OrderCount,20}");
                }
                printContent.AppendLine("\n\n\t\t\t\t>> Tong tien : " + total + " VNĐ");
                btnPurchase.Enabled = true;
                btnPrint.Enabled = true;
            }
            else
            {
                pnlOrder.Controls.Clear();
                lblTotal.Text = "";
                btnPurchase.Enabled = false;
                btnPrint.Enabled = false;
            }
        }
        #endregion

        #region Request
        private async Task ShowRequest(RequestModel requestModel)
        {
            UserRequest ur = JsonConvert.DeserializeObject<UserRequest>(requestModel.Body);
            string DisplayName = await _ur.GetDisplayName(ur.UserId);
            string msg = $"> {DisplayName} : {ur.Message}";
            lbMSG.Items.Add(msg);
        }
        #endregion

        #region ButtonPurchase
        private async void btnPurchase_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Xác nhận thanh toán : " + lblTableName.Text + "\n\nTổng tiền : "
                + lblTotal.Text + " VNĐ", "Xác nhận !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ms == DialogResult.Yes)
            {
                int UserId = Convert.ToInt32(pnlOrder.Tag);
                if (await _or.PurchaseForUser(UserId))
                {
                    lblTotal.Text = "";
                    pnlOrder.Controls.Clear();
                    MessageBox.Show("Thanh toán thành công !  " + lblTotal.Text,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTable();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region ButtonPrint
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                printDialogLR.Document = printDocumentLR;
                if (printDialogLR.ShowDialog() == DialogResult.OK)
                {
                    printDocumentLR.Print();
                }
            }
            catch
            {
                MessageBox.Show("Không in được !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocumentLR_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string content = printContent.ToString();
            e.Graphics.DrawString(content, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, 100, 100);
        }
        #endregion
    }
}
