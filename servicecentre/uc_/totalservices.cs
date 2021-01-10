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
    public partial class totalservices : UserControl
    {
        function fn = new function();
        string query;
        string bid;
        public totalservices()
        {
            InitializeComponent();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT  customer.name,customer.brandid,customer.brandname,customer.customerid,repairdetails.serviceid,repairdetails.description FROM customer  LEFT JOIN repairdetails ON customer.serviceid = repairdetails.serviceid where customer.serviceid = '" + txtsearch.Text + "'";
            setdatgridview(query);
        }

        private void txtdatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtdatagrid.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
            {
                bid = txtdatagrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // query = "delete from repairdetails were serviceid='" + serviceid + "'";
                query = " BEGIN TRANSACTION DELETE FROM repairdetails WHERE serviceid = '" + bid + "'  DELETE FROM customer  WHERE serviceid = '" + bid + "' COMMIT TRANSACTION ";
                fn.GetData(query);
               
            }
            catch
            {
                MessageBox.Show("deleted", "delete confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        internal void viewdtad()
        {
            query = "select id,employeeid,serviceid,dateofdelievery,brandid,type,cost,brandname from repairdetails";
            setdatgridview(query);
        }
        private void setdatgridview(string query)
        {
            DataSet ds = fn.GetData(query);
            txtdatagrid.DataSource = ds.Tables[0];
        }

        private void totalservices_Enter(object sender, EventArgs e)
        {
            viewdtad();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            viewdtad();
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT  customer.name,customer.brandid,customer.brandname,customer.customerid,repairdetails.serviceid,repairdetails.description FROM customer  LEFT JOIN repairdetails ON customer.serviceid = repairdetails.serviceid where customer.serviceid = '" + txtname.Text + "'";
            setdatgridview(query);
        }
    }
}
