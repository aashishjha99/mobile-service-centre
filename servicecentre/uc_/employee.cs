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
    public partial class employee : UserControl

    {
        function fc = new function();
        string query;
        public employee()
        {
            InitializeComponent();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            query = "select *from servicecentrelogin where username = '" + txtusername.Text+ "'";
            DataSet ds = fc.GetData(query);
            if(ds.Tables[0].Rows.Count ==0)
            {
                pictureBox1.ImageLocation = @"B:\mini project\WindowsFormsApp1\WindowsFormsApp1\libraby\yes.png";
                label11.Visible = true;



            }
            else
            {
                pictureBox1.ImageLocation = @"B:\mini project\WindowsFormsApp1\WindowsFormsApp1\libraby\no.png";
                txtusername.ResetText();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string role = txtrole.Text.ToString();
            string name = txtname.Text.ToString();
            string sex = txtsex.Text.ToString();
            string dob = txtdob.Text.ToString();
            string address = txtaddress.Text.ToString();
            string username = txtusername.Text.ToString();
            string password = txtpassword.Text.ToString();
            Int64 mobile = Int64.Parse(txtcontact.Text);
            string mail = txtmail.Text.ToString();

            try
            {
                query = "insert into servicecentrelogin(role,username,password,sex,dob,mobileno,address,mailid,name) values ('" + role + "','" + username + "','" + password + "','" + sex + "','" + dob + "'," + mobile + ",'" + address + "','" + mail + "','" + name + "')";
                fc.setData(query, "registered");
                clearall();

            }
            catch
            {
                MessageBox.Show("unable to register", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            clearall();
        }
        void clearall()
        {
            txtrole.SelectedIndex = -1;
            txtname.ResetText();
            txtdob.ResetText();
            txtusername.ResetText();
            txtpassword.ResetText();
            txtaddress.ResetText();
            txtcontact.ResetText();
            txtmail.ResetText();
            txtsex.SelectedIndex = -1;

        }

        private void employee_Load(object sender, EventArgs e)
        {
            label11.Visible = false;
        }
    }
    }

