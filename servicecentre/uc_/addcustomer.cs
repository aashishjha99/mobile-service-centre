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
    public partial class addcustomer : UserControl
    {
        function fn = new function();
        string query;
        public addcustomer()
        {
            InitializeComponent();
        }
        public string ID
        {
            set { txtemployeeid.Text = value; }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string gender = txtgender.Text;
            string dos = txtdos.Text;
            Int64 mobile = Int64.Parse(txtcontact.Text);
            string address = txtaddress.Text;
            string employee = txtemployeeid.Text;
            string serviceid = txtserviceid.Text;
            string modelname = txtmodel.Text;
            string brandid = txtbrandid.Text;
            string type = txttype.Text;
            try
            {
               query = "insert into customer(name,gender,brandid,brandname,brandtype,dos,mobileno,address,employeeid,serviceid) values('" + name + "','" + gender + "','" + brandid + "','" + modelname + "','" + type + "','" + dos + "'," + mobile + ",'" + address + "','" + employee + "','" + serviceid + "')";
               fn.setData(query, "registeration successful");

            }
            catch (Exception)
            {
              MessageBox.Show(" customer already exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txtname.ResetText();
            txtgender.ResetText();
            txtdos.ResetText();
            txtcontact.ResetText();
            txtaddress.ResetText();
            txttype.SelectedIndex = -1;
            txtserviceid.ResetText();
            txtmodel.ResetText();
            txtbrandid.SelectedIndex = -1;
            txttype.ResetText();
        }

       
    }
}
