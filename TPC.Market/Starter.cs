using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ECMU.Interface;
using ECMU.Market;

namespace ECMU.Plugin
{
    public class Starter : PluginImplementer 
    {
        public string PluginName()
        {
            // This is for the plugin name.
            return "ECMU Market";
        }

        public string PluginVersion()
        {
            // This is for the plugin version.
            return "1.0.0.0";
        }

        public string PluginAuthor()
        {
            // This is the plugin author, normally your name or alias.
            return "The ECMU Foundation";
        }

        public string PluginDescription()
        {
            // This is for your plugin description.
            return "This is a market plugin for ECMU.";
        }

        public Icon PluginIcon()
        {
            // Don't mess with this.
            return Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
        }

        public void ButtonAdder(System.Windows.Forms.Button btn)
        {
            // You need this no matter what. It uses the function below.
            btn.Click += button_Click;
        }

        public void button_Click(object sender, EventArgs e)
        {
            // Add a main form variable to show the form.
            Splash main = new Splash();
            // Show the form using the variable.
            main.Show();
        }
    }
}
