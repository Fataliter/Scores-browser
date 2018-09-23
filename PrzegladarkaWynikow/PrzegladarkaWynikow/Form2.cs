using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PrzegladarkaWynikow
{
    public partial class Form2 : Form
    {
        public static int whichMission;
        Button[] buttons = new Button[10];

        public Form2()
        {
            InitializeComponent();
        }

        private void Check(string[][][] data)
        {
            int length = 0;
            for (int i = 0; i < 10; i++)
                if (data[whichMission][i][0].Length > 0)
                    length++;

            if (length == 0)
            {
                MessageBox.Show("Nie ma danych dla tego poziomu");
            }
            else
            {
                for (int i = 9; i > 0; i--)
                {
                    if (buttons[i] != null)
                    {
                        this.Controls.Remove(buttons[i]);
                    }
                }
                for (int i = 0; i < length; i++)
                {
                    Button newButton = new Button();
                    newButton.Location = new Point(10 + i * 60, 45);
                    newButton.Size = new Size(40, 23);
                    newButton.Text = (i + 1).ToString();
                    buttons[i] = newButton;
                    buttons[i].Click += new EventHandler(Draw_Click);
                    this.Controls.Add(newButton);
                }

                DrawGraph(whichMission, 0, data);
            }
        }

        public void CheckData(string[][][] data, string missionName)
        {
            if (missionName == "Training")
            {
                whichMission = 0;
                Check(data);
            }
            else if (missionName == "Mission1")
            {
                whichMission = 1;
                Check(data);
            }
            else if (missionName == "Mission2")
            {
                whichMission = 2;
                Check(data);
            }
            else if (missionName == "Mission3")
            {
                whichMission = 3;
                Check(data);
            }
            else if (missionName == "Mission4")
            {
                whichMission = 4;
                Check(data);
            }
        }

        void DrawGraph(int whichMission, int whichSession, string[][][] data)
        {
            dataGraph.Series.Clear();
            bigDataGraph.Series.Clear();
            for (int i = 0; i < 12; i++)
            {
                string[] dataLineSplitted = data[whichMission][whichSession][i].Split(new char[] { ',' });
                switch (i)
                {
                    case 0:
                        dataGraph.Titles["Title"].Text = "Czas gry " + dataLineSplitted[0];
                        break;
                    case 1:
                        float timePlayed = float.Parse(dataLineSplitted[0].Replace(".", ","));
                        timePlayed /= 60f;
                        dataGraph.Titles["Title"].Text += " w minutach: " + timePlayed;
                        break;
                    case 2:
                        var chartArea = dataGraph.ChartAreas["ChartArea1"];
                        chartArea.AxisX.Minimum = 0;
                        chartArea.AxisX.Maximum = dataLineSplitted.Length;
                        chartArea.CursorX.AutoScroll = true;
                        chartArea.AxisX.ScaleView.Zoomable = true;
                        chartArea.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                        chartArea.AxisX.ScaleView.Zoom(0, 6);
                        chartArea.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
                        chartArea.AxisX.ScaleView.SmallScrollSize = dataLineSplitted.Length;
                        Draw("timeToHit", dataLineSplitted);
                        dataGraph.Series["timeToHit"].Name = "Czas do trafienia";
                        break;
                    case 3:
                        Draw("angle", dataLineSplitted);
                        dataGraph.Series["angle"].Name = "Kąt obrotu";
                        break;
                    case 4:
                        Draw("points", dataLineSplitted);
                        dataGraph.Series["points"].Name = "Punkty";
                        break;
                    case 5:
                        Draw("timeOnLeftPillow", dataLineSplitted);
                        dataGraph.Series["timeOnLeftPillow"].Name = "Czas na lewej poduszce";
                        break;
                    case 6:
                        Draw("timeOnRightPillow", dataLineSplitted);
                        dataGraph.Series["timeOnRightPillow"].Name = "Czas na prawej poduszce";
                        break;
                    case 7:
                        Draw("timeOnRearPillow", dataLineSplitted);
                        dataGraph.Series["timeOnRearPillow"].Name = "Czas na tylnej poduszce";
                        break;
                    case 8:
                        var bigChartArea = bigDataGraph.ChartAreas["ChartArea1"];
                        bigChartArea.AxisX.Minimum = 0;
                        bigChartArea.AxisX.Maximum = Math.Ceiling(dataLineSplitted.Length / 5f);
                        bigChartArea.CursorX.AutoScroll = true;
                        bigChartArea.AxisX.ScaleView.Zoomable = true;
                        bigChartArea.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                        bigChartArea.AxisX.ScaleView.Zoom(0, 240);
                        bigChartArea.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
                        bigChartArea.AxisX.ScaleView.SmallScrollSize = Math.Ceiling(dataLineSplitted.Length / 5f);
                        DrawSecond("pressOnLeftLeg", dataLineSplitted);
                        bigDataGraph.Series["pressOnLeftLeg"].Name = "Nacisk - lewa noga";
                        break;
                    case 9:
                        DrawSecond("pressOnRightLeg", dataLineSplitted);
                        bigDataGraph.Series["pressOnRightLeg"].Name = "Nacisk - prawa noga";
                        break;
                    case 10:
                        DrawSecond("pressOnLeftPillow", dataLineSplitted);
                        bigDataGraph.Series["pressOnLeftPillow"].Name = "Nacisk - lewa poduszka";
                        break;
                    case 11:
                        DrawSecond("pressOnRightPillow", dataLineSplitted);
                        bigDataGraph.Series["pressOnRightPillow"].Name = "Nacisk - prawa poduszka";
                        break;
                }
            }
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

        void DrawSecond(string series, string[] dataSplitted)
        {
            bigDataGraph.Series.Add(series);
            bigDataGraph.Series[series].BorderWidth = 2;
            bigDataGraph.Series[series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int  i = 0; i < dataSplitted.Length - 1; i++)
            {
                float dataToDrawFloat = float.Parse(dataSplitted[i].Replace(".", ","));
                bigDataGraph.Series[series].Points.AddXY(i * 0.2f, dataToDrawFloat);
            }
        }

        void Draw_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (this.Text == Form1.f1_text)
                DrawGraph(whichMission, int.Parse(button.Text) - 1, Form1.dataToSplitOne);
            else
                DrawGraph(whichMission, int.Parse(button.Text) - 1, Form1.dataToSplitTwo);
        }

        private void Training_Click(object sender, EventArgs e)
        {
            Button buttonTraining = sender as Button;
            WhichClicked(buttonTraining.Name);
        }

        private void Mission1_Click(object sender, EventArgs e)
        {
            Button buttonMission1 = sender as Button;
            WhichClicked(buttonMission1.Name);
        }

        private void Mission2_Click(object sender, EventArgs e)
        {
            Button buttonMission2 = sender as Button;
            WhichClicked(buttonMission2.Name);
        }

        private void Mission3_Click(object sender, EventArgs e)
        {
            Button buttonMission3 = sender as Button;
            WhichClicked(buttonMission3.Name);
        }

        private void Mission4_Click(object sender, EventArgs e)
        {
            Button buttonMission4 = sender as Button;
            WhichClicked(buttonMission4.Name);
        }

        private void WhichClicked(string button_name)
        {
            if (this.Text == Form1.f1_text)
                CheckData(Form1.dataToSplitOne, button_name);
            else
                CheckData(Form1.dataToSplitTwo, button_name);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.formCounter--;
            if (this.Text == Form1.f1_text)
            {
                Form1.f1 = false;
                Form1.f1_text = "";
            }
            else
            {
                Form1.f2 = false;
                Form1.f2_text = "";
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
