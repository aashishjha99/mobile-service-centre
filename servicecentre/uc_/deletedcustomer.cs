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
    public partial class deletedcustomer : UserControl
    {
        function fn = new function();
        string query;
        
        public deletedcustomer()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            query = "select *from customerserviced where serviceid = '"+txtserviceid.Text.ToString()+"' ";
            setdatgridview(query);
        }
        private void setdatgridview(string query)
        {
            DataSet ds = fn.GetData(query);
            GridView1.DataSource = ds.Tables[0];
        }
        internal void viewdtad()
        {
            query = "select *from customerserviced";
            setdatgridview(query);
        }

        private void GridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            viewdtad();
        }
    }
}
