using System;
using System.Windows.Forms;
using System.IO;

namespace PrzegladarkaWynikow
{
    public partial class Form1 : Form
    {
        string userName = Environment.UserName;
        public static string[][][] dataToSplitOne, dataToSplitTwo;
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
        
        string[][][] ReadDataNew()
        {
            int[] counter = new int[5];
            string[][][] results = new string[5][][];
            for (int i = 0; i < 5; i++)
            {
                results[i] = new string[10][];
                for (int j = 0; j < 10; j++)
                {
                    results[i][j] = new string[12];
                    for (int k = 0; k < 12; k++)
                        results[i][j][k] = "";
                }
            }
            StreamReader file = new System.IO.StreamReader(@"C:\Users\" + userName + @"\AppData\LocalLow\DefaultCompany\Archery\Wyniki\" + fileName);
            string wholeFile = file.ReadToEnd();
            string[] singleMission = wholeFile.Split('#');
            Array.Resize(ref singleMission, singleMission.Length - 1);
            foreach (string sMission in singleMission)
            {
                string[] singleMissionSplitted = sMission.Split('@');
                for (int i = 0; i < singleMissionSplitted.Length; i++)
                {
                    if (singleMissionSplitted[0] == "training")
                    {
                        results[0][counter[0]][i] = singleMissionSplitted[i];
                        if (i == 11)
                            counter[0]++;
                    }
                    else if (singleMissionSplitted[0] == "village")
                    {
                        results[1][counter[1]][i] = singleMissionSplitted[i];
                        if (i == 11)
                            counter[1]++;
                    }
                    else if (singleMissionSplitted[0] == "mission2")
                    {
                        results[2][counter[2]][i] = singleMissionSplitted[i];
                        if (i == 11)
                            counter[2]++;
                    }
                    else if (singleMissionSplitted[0] == "mission3")
                    {
                        results[3][counter[3]][i] = singleMissionSplitted[i];
                        if (i == 11)
                            counter[3]++;
                    }
                    else if (singleMissionSplitted[0] == "mission4")
                    {
                        results[4][counter[4]][i] = singleMissionSplitted[i];
                        if (i == 11)
                            counter[4]++;
                    }
                }
            }
            return results;
        }

        private void showDiagram_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                if (formCounter<2)
                {
                    fileName = listBox1.SelectedItem.ToString();
                    if (!(fileName == f1_text || fileName == f2_text))
                    {
                        if (!f1)
                        {
                            Form2 form1 = new Form2();
                            form1.Text = fileName;
                            form1.Show();
                            f1_text = fileName;
                            dataToSplitOne = ReadDataNew();
                            f1 = true;
                        }
                        else if (!f2)
                        {
                            Form2 form2 = new Form2();
                            form2.Text = fileName;
                            form2.Show();
                            f2_text = fileName;
                            dataToSplitTwo = ReadDataNew();
                            f2 = true;
                        }
                        formCounter++;
                    }
                    else
                    {
                        MessageBox.Show("Plik o takiej nazwie jest już otwarty");
                    }
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
