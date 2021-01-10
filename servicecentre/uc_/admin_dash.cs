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
    public partial class admin_dash : UserControl
    {
       
        function fn = new function();
        string query;
        DataSet ds;
        public admin_dash()
        {
            InitializeComponent();
        }

        private void bunifuUserControl1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void admin_dash_Load(object sender, EventArgs e)
        {
             query = " SELECT COUNT(role) from servicecentrelogin where role = 'admin' ";
            ds = fn.GetData(query);
            setlabel(ds, admin);

            query = "select count(role) from servicecentrelogin where role = 'employee' ";
            ds = fn.GetData(query);
            setlabel(ds,employee);



        }

        void setlabel(DataSet ds,Label lb1)
        {
            if(ds.Tables[0].Rows.Count!=0)
            {
                lb1.Text = ds.Tables[0].Rows[0][0].ToString();

            }
            else
            {
                lb1.Text = "0";
            }
        }

       

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            admin_dash_Load(this, null);
        }
    }
}
