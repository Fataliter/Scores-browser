using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PrzegladarkaWynikow
{
    public partial class Form2 : Form
    {
        public static int whichMission;
        Button[] buttons = new Button[10];
        public static string[][] settingTime;

        public Form2()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;
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

                SettingTimeData(whichMission, length, data);

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

        void SettingTimeData(int whichMission, int length, string[][][] data)
        {
            settingTime = new string[length][];
            for (int i = 0; i < length; i++)
            {
                settingTime[i] = new string[4];
            }

            for (int i = 0; i < length; i++)
            {
                settingTime[i][0] = data[whichMission][i][3];
                settingTime[i][1] = data[whichMission][i][4];
                settingTime[i][2] = data[whichMission][i][12];
                settingTime[i][3] = data[whichMission][i][13];
            }
        }

        void DrawGraph(int whichMission, int whichSession, string[][][] data)
        {
            dataGraph.Series.Clear();
            bigDataGraph.Series.Clear();
            float[] timeToHitFloat = new float[data[whichMission][whichSession][2].Length];
            for (int i = 0; i < 15; i++)
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
                        for (int j = 0; j < dataLineSplitted.Length - 1; j++)
                        {
                            timeToHitFloat[j] = float.Parse(dataLineSplitted[j].Replace(".", ","));
                        }
                        break;
                    case 3:
                        dataGraph.Location = new Point(0,70);
                        int height = Convert.ToInt32(0.45 * this.Size.Height);
                        dataGraph.Size = new Size(this.Size.Width,height);
                        var chartArea = dataGraph.ChartAreas["ChartArea1"];
                        chartArea.AxisX.Minimum = 0;
                        chartArea.AxisX.Maximum = Math.Ceiling(dataLineSplitted.Length / 5f);
                        chartArea.CursorX.AutoScroll = true;
                        chartArea.AxisX.Title = "czas [s]";
                        chartArea.AxisY.Title = "kąt [°]";
                        chartArea.AxisX.ScaleView.Zoomable = true;
                        chartArea.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                        chartArea.AxisX.ScaleView.Zoom(0, 40);
                        chartArea.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
                        chartArea.AxisX.ScaleView.SmallScrollSize = Math.Ceiling(dataLineSplitted.Length / 5f);
                        chartArea.AxisX.Interval = 5;
                        Draw("angle", dataLineSplitted);
                        dataGraph.Series["angle"].Name = "Kąt obrotu postaci";
                        break;
                    case 4:
                        Draw("targetLocation", dataLineSplitted);
                        dataGraph.Series["targetLocation"].Color = Color.Green;
                        dataGraph.Series["targetLocation"].Name = "Położenie celu";
                        break;
                    case 5:
                        dataGraph.Series.Add("hitAngle");
                        dataGraph.Series["hitAngle"].BorderWidth = 2;
                        dataGraph.Series["hitAngle"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                        for (int j = 0; j < dataLineSplitted.Length - 1; j++)
                        {
                            float dataToDrawFloat = float.Parse(dataLineSplitted[j].Replace(".", ","));
                            dataGraph.Series["hitAngle"].Points.AddXY(timeToHitFloat[j], dataToDrawFloat);
                        }
                        dataGraph.Series["hitAngle"].Name = "Trafienie";
                        break;
                    case 6:
                        /*Draw("points", dataLineSplitted);
                        dataGraph.Series["points"].Name = "Punkty";*/
                        break;
                    case 7:
                        int prevGraphHeight = Convert.ToInt32(0.45 * this.Size.Height) + 70;
                        bigDataGraph.Location = new Point(0, prevGraphHeight);
                        int heightSecondGraph = Convert.ToInt32(0.39 * this.Size.Height);
                        bigDataGraph.Size = new Size(this.Size.Width, heightSecondGraph);
                        var bigChartArea = bigDataGraph.ChartAreas["ChartArea1"];
                        bigChartArea.AxisX.Minimum = 0;
                        bigChartArea.AxisX.Maximum = Math.Ceiling(dataLineSplitted.Length / 5f);
                        bigChartArea.AxisX.Title = "czas [s]";
                        bigChartArea.AxisY.Title = "nacisk [%]";
                        bigChartArea.CursorX.AutoScroll = true;
                        bigChartArea.AxisX.ScaleView.Zoomable = true;
                        bigChartArea.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                        bigChartArea.AxisX.ScaleView.Zoom(0, 40);
                        bigChartArea.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
                        bigChartArea.AxisX.ScaleView.SmallScrollSize = Math.Ceiling(dataLineSplitted.Length / 5f);
                        bigChartArea.AxisX.Interval = 5;
                        DrawSecond("pressOnLeftLeg", dataLineSplitted);
                        bigDataGraph.Series["pressOnLeftLeg"].Name = "Nacisk - lewa noga";
                        break;
                    case 8:
                        DrawSecond("pressOnRightLeg", dataLineSplitted);
                        bigDataGraph.Series["pressOnRightLeg"].Name = "Nacisk - prawa noga";
                        break;
                    case 9:
                        DrawSecond("pressOnLeftPillow", dataLineSplitted);
                        bigDataGraph.Series["pressOnLeftPillow"].Name = "Nacisk - lewa poduszka";
                        break;
                    case 10:
                        DrawSecond("pressOnRightPillow", dataLineSplitted);
                        bigDataGraph.Series["pressOnRightPillow"].Name = "Nacisk - prawa poduszka";
                        break;
                    case 11:
                        DrawSecond("pressOnRearPillow", dataLineSplitted);
                        bigDataGraph.Series["pressOnRearPillow"].Name = "Nacisk - tylna poduszka";
                        break;
                    case 12:
                        dataGraph.Series.Add("targetAngleLeft");
                        dataGraph.Series["targetAngleLeft"].BorderWidth = 1;
                        dataGraph.Series["targetAngleLeft"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        dataGraph.Series["targetAngleLeft"].Color = Color.Red;
                        for (int j = 0; j < dataLineSplitted.Length - 1; j++)
                        {
                            float dataToDrawFloat = float.Parse(dataLineSplitted[j].Replace(".", ","));
                            dataGraph.Series["targetAngleLeft"].Points.AddXY(j * 0.2f, dataToDrawFloat);
                        }
                        dataGraph.Series["targetAngleLeft"].Name = "Lewa strona";
                        break;
                    case 13:
                        dataGraph.Series.Add("targetAngleRight");
                        dataGraph.Series["targetAngleRight"].BorderWidth = 1;
                        dataGraph.Series["targetAngleRight"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        dataGraph.Series["targetAngleRight"].Color = Color.Red;
                        for (int j = 0; j < dataLineSplitted.Length - 1; j++)
                        {
                            float dataToDrawFloat = float.Parse(dataLineSplitted[j].Replace(".", ","));
                            dataGraph.Series["targetAngleRight"].Points.AddXY(j * 0.2f, dataToDrawFloat);
                        }
                        dataGraph.Series["targetAngleRight"].Name = "Prawa strona";
                        break;
                }
            }
        }

        private void Draw(string series, string[] dataSplitted)
        {
            dataGraph.Series.Add(series);
            dataGraph.Series[series].BorderWidth = 2;
            dataGraph.Series[series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < dataSplitted.Length - 1; i++)
            {
                float dataToDrawFloat = float.Parse(dataSplitted[i].Replace(".", ","));
                dataGraph.Series[series].Points.AddXY(i * 0.2f, dataToDrawFloat);
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

        private void SettingTime_Click(object sender, EventArgs e)
        {
            int lengthFirst = settingTime.Length;
            for (int i = 0; i < lengthFirst; i++)
            {
                string[] playerAngle = settingTime[i][0].Split(',');
                string[] target = settingTime[i][1].Split(',');
                string[] targetLeft = settingTime[i][2].Split(',');
                string[] targetRight = settingTime[i][3].Split(',');
                float[] playerAngleFloat = ParseToFloat(playerAngle);
                float[] targetFloat = ParseToFloat(target);
                float[] targetLeftFloat = ParseToFloat(targetLeft);
                float[] targetRightFloat = ParseToFloat(targetRight);

                int lengthSecond = playerAngle.Length - 1;
                float prevTarget = targetFloat[0];
                float timeCounter = 0;

                for (int j = 1; j < lengthSecond; j++)
                {
                    if (targetFloat[j] < -5f || targetFloat[j] > 5f)
                    {
                        if (prevTarget != targetFloat[j])
                        {
                            Debug.WriteLine(timeCounter);
                            timeCounter = 0f;
                        }
                        if (targetFloat[j] > -50f && targetFloat[j] < -30f)
                        {
                            if (playerAngleFloat[j] > targetLeftFloat[j])
                            {
                                timeCounter += 0.2f;
                            }
                        }
                        else if (targetFloat[j] < 50 && targetFloat[j] > 30)
                        {
                            if (playerAngleFloat[j] < targetRightFloat[j])
                            {
                                timeCounter += 0.2f;
                            }
                        }
                        prevTarget = targetFloat[j];
                    }
                }
            }
        }

        float[] ParseToFloat(string[] data)
        {
            int length = data.Length - 1;
            float[] dataFloat = new float[length];
            for (int i = 0; i < length; i++)
            {
                dataFloat[i] = Convert.ToSingle(Math.Round(double.Parse(data[i].Replace('.', ',')), 1));
            }
            return dataFloat;
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

        private void dataGraph_AxisViewChanged(object sender, System.Windows.Forms.DataVisualization.Charting.ViewEventArgs e)
        {
            var chartArea = dataGraph.ChartAreas["ChartArea1"];
            var bigChartArea = bigDataGraph.ChartAreas["ChartArea1"];

            var ax1 = chartArea.AxisX;
            var ax2 = bigChartArea.AxisX;
            if (e.Axis == ax1)
            {
                ax2.ScaleView.Position = ax1.ScaleView.Position;
            }
        }

        private void bigDataGraph_AxisViewChanged(object sender, System.Windows.Forms.DataVisualization.Charting.ViewEventArgs e)
        {
            var chartArea = dataGraph.ChartAreas["ChartArea1"];
            var bigChartArea = bigDataGraph.ChartAreas["ChartArea1"];

            var ax1 = chartArea.AxisX;
            var ax2 = bigChartArea.AxisX;
            if (e.Axis == ax2)
            {
                ax1.ScaleView.Position = ax2.ScaleView.Position;
            }
        }
    }
}
