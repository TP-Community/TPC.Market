using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECMU.Plugin
{
    public partial class Market_Page1 : Form
    {
        string advancedsettingsfn = "Creaous.AdvancedSettings.dll";
        string webserverfn = "Creaous.WebServer.dll";
        string sprfn = "Creaous.SystemPluginRemover.dll";

        public Market_Page1()
        {
            InitializeComponent();

            // Configuration for the web client.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Detect apps that already exist.
            AppAlreadyExists(advancedsettingsfn, btnAdvancedSettingsGet);
            AppAlreadyExists(webserverfn, btnWebServerGet);
        }

        private void AppAlreadyExists(string fn, Button btn)
        {
            if (File.Exists("Plugins\\" + fn))
            {
                // Disable the button.
                btn.Enabled = false;
                // Change the button text.
                btn.Text = "Already downloaded";
            }
        }

        private void StandardAppDownload(string appname, string url, string filename, Button btn)
        {
            // If the file doesn't exist,
            if (!File.Exists("Plugins\\" + filename))
            {
                // Use a web client,
                using (var client = new WebClient())
                {
                    // Download the file.
                    client.DownloadFile(url, "Plugins\\" + filename);

                    // Show message box as dialog result,
                    DialogResult dialogResult = MessageBox.Show(appname + " was downloaded successfully! Please restart the application to apply all changes. Do you wish to restart now?", "ECMU Market", MessageBoxButtons.YesNo);
                    // If the dialog result was yes,
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Restart the application.
                        Application.Restart();
                    }
                    else
                    {
                        // Show message box saying it was cancelled.
                        MessageBox.Show("Application restart cancelled by user.", "ECMU Market");
                    }
                }
                // Detect if the application already exists.
                AppAlreadyExists(filename, btn);
            }
        }

        private void remove_click(object sender, EventArgs e)
        {
            // Trigger the standard app download.
            StandardAppDownload("Advanced Settings", "https://ezcar.doubleddevelopment.ml/ecmu-plugin/apps/advancedsettings/latest.dll", advancedsettingsfn, btnAdvancedSettingsGet);
        }

        private void btnAdvancedSettingsGet_Click(object sender, EventArgs e)
        {
            // Trigger the standard app download.
            StandardAppDownload("Advanced Settings", "https://ezcar.doubleddevelopment.ml/ecmu-plugin/apps/advancedsettings/latest.dll", advancedsettingsfn, btnAdvancedSettingsGet);
        }

        private void btnWebServerGet_Click(object sender, EventArgs e)
        {
            // Trigger the standard app download.
            StandardAppDownload("Web Server", "https://ezcar.doubleddevelopment.ml/ecmu-plugin/apps/webserver/latest.dll", webserverfn, btnWebServerGet);
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

        private void btnSPRGet_Click(object sender, EventArgs e)
        {
            StandardAppDownload("System Plugin Remover", "https://ezcar.doubleddevelopment.ml/ecmu-plugin/apps/systempluginremover/latest.dll",sprfn, btnSPRGet );
        }
    }
}
