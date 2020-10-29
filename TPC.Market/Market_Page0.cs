using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECMU.Plugin
{
    public partial class Market_Page0 : Form
    {
        public Market_Page0()
        {
            InitializeComponent();
        }

        private void btnApps_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>()
            .FirstOrDefault(c => c is Market_Page1);
            if (formToShow != null)
            {
                Hide();
                formToShow.Show();
            } else
            {
                Hide();
                Market_Page1 page1 = new Market_Page1();
                page1.Show();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>()
            .FirstOrDefault(c => c is Market_Help);
            if (formToShow != null)
            {
                Hide();
                formToShow.Show();
            }
            else
            {
                Hide();
                Market_Help help = new Market_Help();
                help.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Close this form.
            this.Close();
        }

        private void Market_Page0_Load(object sender, EventArgs e)
        {

        }
    }
}
