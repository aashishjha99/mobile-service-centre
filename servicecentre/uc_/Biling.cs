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
    public partial class Biling : UserControl
    {
        function fn = new function();
        string query;
        public Biling()
        {
            InitializeComponent();
        }
        public string ID
        {
            set { txtemployee.Text = value; }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string employeeid = txtemployee.Text;
            string description = txtdiscript.Text;
            string brandid = txtbrandid.Text;
            string brandname = txtmodel.Text;
            string type = txttype.Text;
            Int64 cost = Int64.Parse(txtcost.Text);
            string date = DateTime.Now.ToString("M/d/yyyy");
            string serviceid = txtserviceid.Text;
            try
            {

                query = " insert into repairdetails (brandid,brandname,type,description,employeeid,serviceid,dateofdelievery,cost) values('" + brandid + "','"+brandname+"','" +type+ "','" +description+ "','" + employeeid+ "','" +serviceid+ "','" + date + "'," + cost + ")";
                fn.setData(query, "Repaired And Delievred");
                clearall();

            }

            catch (Exception)
            {
                MessageBox.Show("customer not registred", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        void clearall()
        {
            txtserviceid.ResetText();
            txtdiscript.ResetText();
            txtbrandid.ResetText();
            txtmodel.ResetText();
            txttype.ResetText();
            txtcost.ResetText();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            clearall();
        }

        private void txtserviceid_TextChanged(object sender, EventArgs e)
        {
            MyMethod();
        }
        void MyMethod()
        {
            if (txtserviceid == null) return;

            if (String.IsNullOrEmpty(txtserviceid.Text)) return;

            string service = Convert.ToString(txtserviceid.Text);
            query = "select *from customer where serviceid = '" + service + "' ";
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtbrandid.Text = ds.Tables[0].Rows[0][1].ToString();
                txtmodel.Text = ds.Tables[0].Rows[0][2].ToString();
                txttype.Text = ds.Tables[0].Rows[0][3].ToString();

            }
            else
            {
               // MessageBox.Show("database error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
