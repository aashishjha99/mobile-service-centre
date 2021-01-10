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
    public partial class dash : UserControl
    {
        public dash()
        {
            InitializeComponent();
        }
        public string ID
        {
            set { label1.Text = value; }
        }

        private void dash_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour < 12)
            {

                wishes.Text = "GOOD MORNING";

            }
            else if (DateTime.Now.Hour < 17)
            {

                wishes.Text = "GOOD AFTERNOON";
            }
            else
            {

                wishes.Text = "GOOD EVENING";
            }
        }
    }
}
