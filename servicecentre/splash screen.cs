using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        int tim = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tim += 1;
            ProgressBar1.Value = tim;
            if (ProgressBar1.Value == 100)
            {
                ProgressBar1.Value = 0;
                timer1.Stop();
                servicecentreloginscreen obj = new servicecentreloginscreen();

                obj.Show();
            }
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}

