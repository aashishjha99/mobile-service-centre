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
    public partial class adminbody : Form
    {
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public adminbody()
        {
            InitializeComponent();
        }

        public adminbody(string username)
        {
            InitializeComponent();
            user_id = username;
            profile_1.ID = ID;
            label1.Text = username;

        }
        public string ID
        {
            get { return user_id.ToString(); }
        }
        public string user_id = "";
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            employee1.Visible = true;
            employee1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            admin_dash1.Visible = true;
            admin_dash1.BringToFront();
        }

        private void adminbody_Load(object sender, EventArgs e)
        {
            guna2Button1_Click(this, null);
        }

        private void close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void adminbody_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            record1.Visible = true;
            record1.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            profile_1.Visible = true;
            profile_1.BringToFront();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminloginscreen obj = new adminloginscreen();
            obj.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            mobile1.Visible = true;
            mobile1.BringToFront();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            modelnameregisteration1.Visible = true;
            modelnameregisteration1.BringToFront();
        }
    }
}
