using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrzegladarkaWynikow
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Draw(string series, string[] dataSplitted)
        {
            dataGraph.Series.Add(series);
            for (int i = 0; i < dataSplitted.Length - 1; i++)
            {
                float dataToDrawFloat = float.Parse(dataSplitted[i].Replace(".", ","));
                dataGraph.Series[series].Points.Add(dataToDrawFloat);
            }
        }

        private void Split(int begin, int end, string[] data)
        {
            for (int i = begin; i < end; i++)
            {
                string[] dataLineSplitted = data[i].Split(new char[] { ',' });
                DrawGraph(dataLineSplitted, i);
            }
        }

        public void SplitData(string[] data, string missionName)
        {
            if (missionName == "Training")
                Split(0, 5, data);
            else if (missionName == "Mission1")
                Split(5, 10, data);
            else if (missionName == "Mission2")
                Split(10, 15, data);
            else if (missionName == "Mission3")
                Split(15, 20, data);
            else if (missionName == "Mission4")
                Split(20, 25, data);
        }

        void DrawGraph(string[] dataSplitted, int counter)
        {
            if (counter % 5 == 0)
                dataGraph.Titles["Title"].Text = "Czas gry " + dataSplitted[0];
            else if ((counter - 1) % 5 == 0)
            {
                float timePlayed = 0;
                for (int i = 0; i < dataSplitted.Length - 1; i++)
                {
                    float dataToDrawFloat = float.Parse(dataSplitted[i].Replace(".", ","));
                    timePlayed += dataToDrawFloat;
                }
                timePlayed = timePlayed / 60f;
                dataGraph.Titles["Title"].Text += " w minutach: " + timePlayed;
            }
            else if ((counter - 2) % 5 == 0)
            {
                Draw("timeToHit", dataSplitted);
                dataGraph.Series["timeToHit"].Name = "Czas do trafienia";
            }
            else if ((counter - 3) % 5 == 0)
            {
                Draw("angle", dataSplitted);
                dataGraph.Series["angle"].Name = "Kąt obrotu";
            }
            else if ((counter - 4) % 5 == 0)
            {
                dataGraph.ChartAreas["ChartArea1"].AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
                dataGraph.ChartAreas["ChartArea1"].AxisY2.Minimum = -5;
                dataGraph.ChartAreas["ChartArea1"].AxisY2.Maximum = 5;
                Draw("points", dataSplitted);
                dataGraph.Series["points"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                dataGraph.Series["points"].Name = "Punkty";
            }
        }

        private void Training_Click(object sender, EventArgs e)
        {
            Button buttonTraining = sender as Button;
            dataGraph.Series.Clear();
            WhichClicked(buttonTraining.Name);
        }

        private void Mission1_Click(object sender, EventArgs e)
        {
            Button buttonMission1 = sender as Button;
            dataGraph.Series.Clear();
            WhichClicked(buttonMission1.Name);
        }

        private void WhichClicked(string button_name)
        {
            if (this.Text == Form1.f1_text)
                SplitData(Form1.dataToSplitOne, button_name);
            else
                SplitData(Form1.dataToSplitTwo, button_name);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.formCounter--;
            if (this.Text == Form1.f1_text)
                Form1.f1 = false;
            else
                Form1.f2 = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
