using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1.uc_
{
    public partial class profile_ : UserControl
    {
        function fn = new function();
        string query;
       
        public profile_()
        {
            InitializeComponent();
        }
        public string ID
        {
            set { userNameLabel.Text = value; }
        }

        private void profile__Enter(object sender, EventArgs e)
        {
            query = "select *from servicecentrelogin where username = '" + userNameLabel.Text + "'";
            DataSet ds = fn.GetData(query);
            name.Text = ds.Tables[0].Rows[0][8].ToString();
            mobileno.Text = ds.Tables[0].Rows[0][5].ToString();
            address.Text = ds.Tables[0].Rows[0][6].ToString();
            password.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Int64 mobileno_ = Int64.Parse(mobileno.Text);
            string address_ = address.Text;
            string password_ = password.Text;
            string user_id = userNameLabel.Text;

            query = "update  servicecentrelogin  set mobileno = " + mobileno_ + ",address = '" + address_ + "',password = '" + password_ + "' where username ='" + user_id + "' ";
            fn.setData(query, "profile updation successful");
            clearall();
        }
        internal void clearall()
        {
            name.ResetText();
            mobileno.ResetText();
            address.ResetText();
            password.ResetText();

        }
    }
}
