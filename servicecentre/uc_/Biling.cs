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
            string brand = txtbrandname.Text;
            string modelname = txtmodel.Text;
            string type = txttype.Text;
            Int64 cost = Int64.Parse(txtcost.Text);
            string date = DateTime.Now.ToString("M/d/yyyy");
            string serviceid = txtserviceid.Text;
            string insurance = txtinsurance.Text;
            Int64 imei = Int64.Parse(txtimeino.Text);
            try
            {

                query = " insert into repairdetails (employeeid,details,brandname,type,dateofdelievery,modelname,cost,INSURANCE,serviceid,imeino) values('"+employeeid+ "','"+description+"','" +brand+ "','" +type+ "','" +date+ "','"+modelname+"'," +cost+",'" +insurance+ "','" +serviceid+"',"+imei+")";
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
            txtbrandname.ResetText();
            txtmodel.ResetText();
            txttype.ResetText();
            txtcost.ResetText();
            txtimeino.ResetText();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            clearall();
        }

        private void txtserviceid_TextChanged(object sender, EventArgs e)
        {
            
        }
        void MyMethod()
        {
            if (txtserviceid.Text != "")
            {
                query = "select brandname,modelname,brandtype,imeino from customer where serviceid ='"+txtserviceid.Text+"'";
                 DataSet ds =fn.GetData(query);
                
                if(ds.Tables[0].Rows.Count !=0)
                {
                    txtbrandname.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtmodel.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtimeino.Text = ds.Tables[0].Rows[0][3].ToString();
                    txttype.Text = ds.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    MessageBox.Show("database error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MyMethod();
        }
    }
}
