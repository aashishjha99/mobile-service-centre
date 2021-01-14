using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            string brandname = txtbrandname.Text;
            string type = txttype.Text;
            string problems = textproblems.Text;
            Int64 imeino = Convert.ToInt64(txtimei.Text);
            try
            {
                query = "insert into customer(serviceid,employeeid,name,sex,imeino,brandname,modelname,brandtype,dos,mobileno,address,problems) values('" + serviceid+ "','" +employee+ "','" + name + "','" + gender + "',"+imeino+",'" + brandname + "','" + modelname + "','" + type+"','" +dos+ "'," + mobile + ",'" +address+ "','"+problems+"')";
                fn.setData(query, "registeration successful");

            }
            catch (Exception)
            {
                MessageBox.Show(" customer already exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            clearall();
            addcustomer_Enter(this, null);
        }

        private void clearall()
        {
            txtname.ResetText();
            txtgender.ResetText();
            txtdos.ResetText();
            txtcontact.ResetText();
            txtaddress.ResetText();
            txttype.SelectedIndex = -1;
            txtserviceid.ResetText();
            txtmodel.SelectedIndex = -1;
            txtbrandname.SelectedIndex = -1;
            txttype.ResetText();
            textproblems.ResetText();
            txtimei.ResetText();
        }

        private void addcustomer_Load(object sender, EventArgs e)
        {

        }
       public void setcombobox(string query,ComboBox combo)
       {
            SqlDataReader sdr = fn.getForComboBox(query);

            while(sdr.Read())
            {
                for(int i = 0;i<sdr.FieldCount;i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
        }

        private void addcustomer_Enter(object sender, EventArgs e)
        {
            txtbrandname.Items.Clear();
            query = "select Brandname from mobilebrand";
            setcombobox(query, txtbrandname);
        }

        private void txtbrandid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtmodel.Items.Clear();
                string brand = txtbrandname.Text;
                query = " SELECT mobilemodel.modelname FROM mobilebrand FULL OUTER JOIN mobilemodel  ON mobilebrand.IdBrand = mobilemodel.IdBrand WHERE mobilebrand.Brandname = '" + brand + "'";
                setcombobox(query, txtmodel);
            }
            catch
            {
                MessageBox.Show("model not availble", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtimei_TextChanged(object sender, EventArgs e)
        {
            Int64 imeino = Int64.Parse(txtimei.Text);
            query = "select *from mobilemodel where imeino = "+imeino+"";
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
               
                pictureBox1.ImageLocation = @"B:\mini project\WindowsFormsApp1\WindowsFormsApp1\libraby\no.png";

            }
            else
            {
                
                pictureBox1.ImageLocation = @"B:\mini project\WindowsFormsApp1\WindowsFormsApp1\libraby\yes.png";

            }

        }
    }
}
