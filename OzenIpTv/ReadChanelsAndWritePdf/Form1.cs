using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReadChanelsAndWritePdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\umity\source\repos\umtylmz\Works\OzenIpTv\ReadChanelsAndWritePdf\TextFile1.txt", FileMode.Open);

            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            List<string> channelName = new List<string>();
            List<string> categoryName = new List<string>();


            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string firstWord = "";
                string secondWord = "";
                int secondWordStartPoint = 0;

                for (int i = 8; ; i++)
                {
                    if (line[i] == '<')
                    {
                        secondWordStartPoint = i + 9;
                        break;
                    }

                    firstWord += line[i];
                }

                for (int i = secondWordStartPoint; ; i++)
                {
                    if (line[i] == '<') break;

                    secondWord += line[i];
                }

                channelName.Add(firstWord);
                categoryName.Add(secondWord);
            }

            //for (int i = 0; i < channelName.Count; i++)
            //{
            //    listBox1.Items.Add(channelName[i] + " " + categoryName[i]);
            //}

            Excel.Application ExcelUygulama = new Excel.Application();
            object Missing = System.Reflection.Missing.Value;
            Excel.Workbook ExcelProje = ExcelUygulama.Workbooks.Add(Missing);
            Excel.Worksheet ExcelSayfa = (Excel.Worksheet)ExcelProje.Worksheets.get_Item(1);
            Excel.Range ExcelRange = ExcelSayfa.UsedRange;
            ExcelSayfa = (Excel.Worksheet)ExcelUygulama.ActiveSheet;
            ExcelUygulama.Visible = false;
            ExcelUygulama.AlertBeforeOverwriting = false;

            int rowCount = 1;

            for (int i = 1; i <= channelName.Count; i++)
            {
                if (categoryName[i - 1] == "VOD: BITEN DIZILER")
                {
                    //int rowCount = i;

                    int column1Count = 1;
                    int column2Count = 2;

                    Excel.Range kolon1 = (Excel.Range)ExcelSayfa.Cells[rowCount, column1Count];
                    kolon1.Value2 = channelName[i - 1];

                    Excel.Range kolon2 = (Excel.Range)ExcelSayfa.Cells[rowCount, column2Count];
                    kolon2.Value2 = categoryName[i - 1];

                    rowCount++;
                }
            }

            ExcelProje.SaveAs(Application.StartupPath + @"\" + "deneme" + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, Missing, Missing, false, Missing, Excel.XlSaveAsAccessMode.xlNoChange);
            ExcelProje.Close(true, Missing, Missing);
            ExcelUygulama.Quit();
        }
    }
}
