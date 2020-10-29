using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ECMU.Plugin
{
    public partial class Market_Help : Form
    {
        public Market_Help()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>()
            .FirstOrDefault(c => c is Market_Page0);
            if (formToShow != null)
            {
                Hide();
                formToShow.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // https://ezcar.doubleddevelopment.ml/ecmu-plugin/ECMU.Market.ecmu_dll
            using (var client = new WebClient())
            {
                // Download the file.
                client.DownloadFile("https://ezcar.doubleddevelopment.ml/ecmu-plugin/ECMU.Market.ecmu_dll", "Plugins\\ECMU.Market.ecmu_dll.new");
            }

            MessageBox.Show("To fully restore please go to the Plugins folder and remove 'ECMU.Market.ecmu_dll' then remove the '.new' part from 'ECMU.Market.ecmu_dll.new'");
        }
    }
}
