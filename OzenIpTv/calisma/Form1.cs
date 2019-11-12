using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calisma
{
    public partial class Form1 : Form
    {
        List<HtmlElement> chanelList = new List<HtmlElement>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var appName = Process.GetCurrentProcess().ProcessName + ".exe";
            //SetIE11KeyforWebBrowserControl(appName);

            wb.Navigate("https://alfaiptvserver.com/kanal_listesi");
        }

        public void gorev()
        {
            HtmlElementCollection spans = wb.Document.GetElementsByTagName("span");



        }

        //private void SetIE11KeyforWebBrowserControl(string appName)
        //{
        //    RegistryKey Regkey = null;
        //    try
        //    {
        //        // For 64 bit machine
        //        if (Environment.Is64BitOperatingSystem)
        //            Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
        //        else  //For 32 bit machine
        //            Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);

        //        // If the path is not correct or
        //        // if the user haven't priviledges to access the registry
        //        if (Regkey == null)
        //        {
        //            MessageBox.Show("Application Settings Failed - Address Not found");
        //            return;
        //        }

        //        string FindAppkey = Convert.ToString(Regkey.GetValue(appName));

        //        // Check if key is already present
        //        if (FindAppkey == "11001")
        //        {
        //            MessageBox.Show("Required Application Settings Present");
        //            Regkey.Close();
        //            return;
        //        }

        //        // If a key is not present add the key, Key value 8000 (decimal)
        //        if (string.IsNullOrEmpty(FindAppkey))
        //            Regkey.SetValue(appName, unchecked((int)0x2AF9), RegistryValueKind.DWord);

        //        // Check for the key after adding
        //        FindAppkey = Convert.ToString(Regkey.GetValue(appName));

        //        if (FindAppkey == "11001")
        //            MessageBox.Show("Application Settings Applied Successfully");
        //        else
        //            MessageBox.Show("Application Settings Failed, Ref: " + FindAppkey);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Application Settings Failed");
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        // Close the Registry
        //        if (Regkey != null)
        //            Regkey.Close();
        //    }
        //}

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection trs = wb.Document.GetElementsByTagName("tr");

            string fileName = "text.txt";
            FileStream stream = null;

            // Create a FileStream with mode CreateNew  
            stream = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);

            foreach (HtmlElement tr in trs)
            {
                
                // Create a StreamWriter from FileStream  

                    writer.WriteLine(tr.OuterHtml);

            }

            writer.Dispose();
        }

        void LoginKingdoms()
        {
            wb_DocumentCompleted(wb, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginKingdoms();
        }
    }
}

