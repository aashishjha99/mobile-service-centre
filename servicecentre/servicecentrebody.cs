using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class servicecentrebody : Form
    {
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public servicecentrebody()
        {
            InitializeComponent();
        }
        public servicecentrebody(string user)
        {
            InitializeComponent();
            label1.Text = user;
            user_id = user;
            profile1.ID = ID;
            dash1.ID = ID;
            addcustomer1.ID = ID;
            biling1.ID = ID;
        }
        public string ID
        {
            get { return user_id.ToString(); }
        }
        public string user_id = "";


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            dash1.Visible = true;
            dash1.BringToFront();
        }

        private void customer_Click(object sender, EventArgs e)
        {
            addcustomer1.Visible = true;
            addcustomer1.BringToFront();
        }

        private void billing_Click(object sender, EventArgs e)
        {
            biling1.Visible = true;
            biling1.BringToFront();
        }

        private void Totalservices_Click(object sender, EventArgs e)
        {
            totalservices1.Visible = true;
            totalservices1.BringToFront();
        }

        private void profile_Click(object sender, EventArgs e)
        {
            profile1.Visible = true;
            profile1.BringToFront();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            servicecentreloginscreen obj = new servicecentreloginscreen();
            obj.Show();
        }

        private void servicecentrebody_Load(object sender, EventArgs e)
        {
            dashboard.PerformClick();
        }

        private void close_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void setting_Click(object sender, EventArgs e)
        {
            settings_1.Visible = true;
            settings_1.BringToFront();
        }

        private void biling1_Load(object sender, EventArgs e)
        {

        }

        private void settings_1_Load(object sender, EventArgs e)
        {
                    }
    }
}
