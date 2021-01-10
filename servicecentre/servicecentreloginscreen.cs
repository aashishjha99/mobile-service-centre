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
    public partial class servicecentreloginscreen : Form
    {

        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        string query;
        DataSet ds;
        function fc = new function();

        public servicecentreloginscreen()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            query = "select * from servicecentrelogin ";
            ds = fc.GetData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(" Employee Not Registered ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtusername.Text == "root" && txtpassword.Text == "root")
                {
                   
                    servicecentrebody obj = new servicecentrebody();
                    this.Hide();
                   obj.Show();
                }
            }
            else
            {
                query = " SELECT  username , password FROM servicecentrelogin WHERE username = '" + txtusername.Text + "' and password = '" + txtpassword.Text + "' and role= 'employee' ";
                ds = fc.GetData(query);

                if (ds.Tables[0].Rows.Count != 0)
                

                    {

                        label1.Hide();
                        servicecentrebody obj = new servicecentrebody(txtusername.Text);
                        this.Hide();
                        obj.Show();
                    }
                else
                {
                    //dont login
                    label1.Show();
                }

            }
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

        private void servicecentreloginscreen_Load(object sender, EventArgs e)
        {
            label1.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminloginscreen obj = new adminloginscreen();
            obj.Show();
        }

        
    }
    }

