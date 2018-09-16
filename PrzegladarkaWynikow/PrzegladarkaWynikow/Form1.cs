using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PrzegladarkaWynikow
{
    public partial class Form1 : Form
    {
        string userName = Environment.UserName;
        public static string[] dataToSplitOne, dataToSplitTwo;
        public static string fileName = "";
        public static int formCounter = 0;
        public static bool f1 = false, f2 = false;
        public static string f1_text = "", f2_text = "";

        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            string[] files = Directory.GetFiles(@"C:\Users\" + userName + @"\AppData\LocalLow\DefaultCompany\Archery\Wyniki");
            foreach (string file in files)
            {
                listBox1.Items.Add(Path.GetFileName(file));
            }
        }

        string[] ReadData()
        {
            int counter = 5;
            string line;
            string[] data = new string[25];
            StreamReader file = new System.IO.StreamReader(@"C:\Users\" + userName + @"\AppData\LocalLow\DefaultCompany\Archery\Wyniki\" + fileName);
            while ((line = file.ReadLine()) != null)
            {
                if (counter % 5 == 0)
                {
                    if (line == "training")
                    {
                        data[0] = line;
                        counter = 1;
                        continue;
                    }
                    else if (line == "mission1")
                    {
                        data[5] = line;
                        counter = 6;
                        continue;
                    }
                    else if (line == "mission2")
                    {
                        data[10] = line;
                        counter = 11;
                        continue;
                    }
                    else if (line == "mission3")
                    {
                        data[15] = line;
                        counter = 16;
                        continue;
                    }
                    else if (line == "mission4")
                    {
                        data[20] = line;
                        counter = 21;
                        continue;
                    }
                }
                if ((counter-1) % 5 == 0)
                {
                    data[counter] = data[counter] + line + ",";
                    counter++;
                    continue;
                }
                    data[counter] += line;
                    counter++;
            }
            file.Close();
            return data;
        }

        private void showDiagram_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                if (formCounter<2)
                {
                    fileName = listBox1.SelectedItem.ToString();
                    if (!f1)
                    {
                        Form2 form1 = new Form2();
                        form1.Text = fileName;
                        form1.Show();
                        f1_text = fileName;
                        dataToSplitOne = ReadData();
                        f1 = true;
                    }
                    else if (!f2)
                    {
                        Form2 form2 = new Form2();
                        form2.Text = fileName;
                        form2.Show();
                        f2_text = fileName;
                        dataToSplitTwo = ReadData();
                        f2 = true;
                    }
                    formCounter++;
                }
                else
                {
                    MessageBox.Show("Możesz mieć otwarte maksymalnie 2 okna z wynikami jednocześnie");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
