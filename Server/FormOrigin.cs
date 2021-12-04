using System;
using System.Net;
using System.Windows.Forms;

namespace Server
{
    public partial class FormOrigin : Form
    {
        public FormOrigin()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse(txtIPAddress.Text);
            int port = Convert.ToInt32(txtPort.Text);
            FormMain fm = new FormMain(ip, port);
            this.Hide();
            fm.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
