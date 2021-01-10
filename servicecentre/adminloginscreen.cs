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
    public partial class adminloginscreen : Form
    {
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public adminloginscreen()
        {
            InitializeComponent();
        }
        function fc = new function();
        string query;
        DataSet ds;

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            query = "select * from servicecentrelogin ";
            ds = fc.GetData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(" Employee Not Registered ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtusername.Text == "admin" && txtpassword.Text == "admin")
                {

                    adminbody obj = new adminbody();
                    this.Hide();
                    obj.Show();
                }
            }
            else
            {
                query = " SELECT  username , password FROM servicecentrelogin WHERE username = '" + txtusername.Text + "' and password = '" + txtpassword.Text + "' and role = 'admin'";
                ds = fc.GetData(query);

                 if (ds.Tables[0].Rows.Count != 0)
                {
                     label2.Hide();
                      adminbody obj = new adminbody(txtusername.Text);
                       this.Hide();
                       obj.Show();
                 }
                  

                
                else
                {
                    //dont login
                    label2.Show();
                }

            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            servicecentreloginscreen obj = new servicecentreloginscreen();
            obj.Show();
        }

        private void adminloginscreen_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
    }
}
