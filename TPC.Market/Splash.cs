using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ECMU.Market
{
    public partial class Splash : Form
    {
        System.Windows.Forms.Timer tmr;
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }

        private void Splash_Shown(object sender, EventArgs e)
        {
            tmr = new System.Windows.Forms.Timer();
            //set time interval 3 sec
            tmr.Interval = 3000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();
            //display mainform
            Plugin.Market_Page0 mf = new Plugin.Market_Page0();
            mf.Show();
            //hide this form
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {      
            label1.ForeColor = Color.Green;
            label2.ForeColor = Color.Green;
            label3.ForeColor = Color.Green;
        }
    }
}
