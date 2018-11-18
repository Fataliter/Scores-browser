﻿using System;
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
        public static string[][] pillowsTime;
        public static float[][][] pillowsPercentage;
        public static float[] playerAngle;
        public static bool settingTimeBool = false;
        public static bool pillowsTimeBool = false;

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
                PillowsTimeData(whichMission, length, data);

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
                settingTime[i] = new string[5];
            }

            for (int i = 0; i < length; i++)
            {
                settingTime[i][0] = data[whichMission][i][3];
                settingTime[i][1] = data[whichMission][i][4];
                settingTime[i][2] = data[whichMission][i][12];
                settingTime[i][3] = data[whichMission][i][13];
                settingTime[i][4] = data[whichMission][i][14];
            }

            settingTimeBool = true;
        }

        void PillowsTimeData(int whichMission, int length, string[][][] data)
        {
            playerAngle = new float[length];

            pillowsTime = new string[length][];
            for (int i = 0; i < length; i++)
            {
                pillowsTime[i] = new string[5];
            }

            for (int i = 0; i < length; i++)
            {
                pillowsTime[i][0] = data[whichMission][i][9];
                pillowsTime[i][1] = data[whichMission][i][10];
                pillowsTime[i][2] = data[whichMission][i][11];
                pillowsTime[i][3] = data[whichMission][i][1];
                pillowsTime[i][4] = data[whichMission][i][14];
                playerAngle[i] = Convert.ToSingle(Math.Round(double.Parse((data[whichMission][i][3].Split(',')[0]).Replace('.', ',')), 1));
            }

            pillowsPercentage = new float[3][][];
            for (int i = 0; i < 3; i++)
            {
                pillowsPercentage[i] = new float[length][];
                for (int j = 0; j < length; j++)
                {
                    pillowsPercentage[i][j] = new float[11];
                }
            }

            pillowsTimeBool = true;
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

        private void PillowsTimePercent_Click(object sender, EventArgs e)
        {
            if (pillowsTimeBool == true)
            {
                int lengthFirst = pillowsTime.Length;

                for (int i = 0; i < lengthFirst; i++)
                {
                    string[] pillowLeft = pillowsTime[i][0].Split(',');
                    string[] pillowRight = pillowsTime[i][1].Split(',');
                    string[] pillowRear = pillowsTime[i][2].Split(',');
                    float[] pillowLeftFloat = ParseToFloat(pillowLeft);
                    float[] pillowRightFloat = ParseToFloat(pillowRight);
                    float[] pillowRearFloat = ParseToFloat(pillowRear);
                    float wholeTime = Convert.ToSingle(Math.Round(double.Parse(pillowsTime[i][3].Replace('.', ',')), 1));
                    float pillows = Convert.ToSingle(Math.Round(double.Parse(pillowsTime[i][4]), 1));

                    int lengthSecond = pillowLeft.Length - 1;
                    float[] timeLeft = new float[11];
                    float[] timeRight = new float[11];
                    float[] timeRear = new float[11];

                    bool fakeInfo = false;
                    float timeToStart = 0f;
                    for (int j = 0; j < lengthSecond; j++)
                    {
                        if ((playerAngle[i] < 130 || playerAngle[i] > 150) && j == 0)
                        {
                            fakeInfo = true;
                        }
                        if (timeToStart > 14.7f && timeToStart < 14.9f)
                        {
                            timeToStart = 0f;
                            fakeInfo = false;
                        }
                        if (fakeInfo)
                        {
                            timeToStart += 0.2f;
                            continue;
                        }

                        if (pillowLeftFloat[j] >= 20 && pillowLeftFloat[j] < 28)
                            timeLeft[1] += 0.2f;
                        else if (pillowLeftFloat[j] >= 28 && pillowLeftFloat[j] < 36)
                            timeLeft[2] += 0.2f;
                        else if (pillowLeftFloat[j] >= 36 && pillowLeftFloat[j] < 44)
                            timeLeft[3] += 0.2f;
                        else if (pillowLeftFloat[j] >= 44 && pillowLeftFloat[j] < 52)
                            timeLeft[4] += 0.2f;
                        else if (pillowLeftFloat[j] >= 52 && pillowLeftFloat[j] < 60)
                            timeLeft[5] += 0.2f;
                        else if (pillowLeftFloat[j] >= 60 && pillowLeftFloat[j] < 68)
                            timeLeft[6] += 0.2f;
                        else if (pillowLeftFloat[j] >= 68 && pillowLeftFloat[j] < 76)
                            timeLeft[7] += 0.2f;
                        else if (pillowLeftFloat[j] >= 76 && pillowLeftFloat[j] < 84)
                            timeLeft[8] += 0.2f;
                        else if (pillowLeftFloat[j] >= 84 && pillowLeftFloat[j] < 92)
                            timeLeft[9] += 0.2f;
                        else if (pillowLeftFloat[j] >= 92 && pillowLeftFloat[j] <= 100)
                            timeLeft[10] += 0.2f;
                        else
                            timeLeft[0] += 0.2f;

                        if (pillowRightFloat[j] >= 20 && pillowRightFloat[j] < 28)
                            timeRight[1] += 0.2f;
                        else if (pillowRightFloat[j] >= 28 && pillowRightFloat[j] < 36)
                            timeRight[2] += 0.2f;
                        else if (pillowRightFloat[j] >= 36 && pillowRightFloat[j] < 44)
                            timeRight[3] += 0.2f;
                        else if (pillowRightFloat[j] >= 44 && pillowRightFloat[j] < 52)
                            timeRight[4] += 0.2f;
                        else if (pillowRightFloat[j] >= 52 && pillowRightFloat[j] < 60)
                            timeRight[5] += 0.2f;
                        else if (pillowRightFloat[j] >= 60 && pillowRightFloat[j] < 68)
                            timeRight[6] += 0.2f;
                        else if (pillowRightFloat[j] >= 68 && pillowRightFloat[j] < 76)
                            timeRight[7] += 0.2f;
                        else if (pillowRightFloat[j] >= 76 && pillowRightFloat[j] < 84)
                            timeRight[8] += 0.2f;
                        else if (pillowRightFloat[j] >= 84 && pillowRightFloat[j] < 92)
                            timeRight[9] += 0.2f;
                        else if (pillowRightFloat[j] >= 92 && pillowRightFloat[j] <= 100)
                            timeRight[10] += 0.2f;
                        else
                            timeRight[0] += 0.2f;

                        if (pillowRearFloat[j] >= 20 && pillowRearFloat[j] < 28)
                            timeRear[1] += 0.2f;
                        else if (pillowRearFloat[j] >= 28 && pillowRearFloat[j] < 36)
                            timeRear[2] += 0.2f;
                        else if (pillowRearFloat[j] >= 36 && pillowRearFloat[j] < 44)
                            timeRear[3] += 0.2f;
                        else if (pillowRearFloat[j] >= 44 && pillowRearFloat[j] < 52)
                            timeRear[4] += 0.2f;
                        else if (pillowRearFloat[j] >= 52 && pillowRearFloat[j] < 60)
                            timeRear[5] += 0.2f;
                        else if (pillowRearFloat[j] >= 60 && pillowRearFloat[j] < 68)
                            timeRear[6] += 0.2f;
                        else if (pillowRearFloat[j] >= 68 && pillowRearFloat[j] < 76)
                            timeRear[7] += 0.2f;
                        else if (pillowRearFloat[j] >= 76 && pillowRearFloat[j] < 84)
                            timeRear[8] += 0.2f;
                        else if (pillowRearFloat[j] >= 84 && pillowRearFloat[j] < 92)
                            timeRear[9] += 0.2f;
                        else if (pillowRearFloat[j] >= 92 && pillowRearFloat[j] <= 100)
                            timeRear[10] += 0.2f;
                        else
                            timeRear[0] += 0.2f;
                    }

                    for (int j = 0; j < 11; j++)
                    {
                        timeLeft[j] = (timeLeft[j] / wholeTime) * 100;
                        pillowsPercentage[0][i][j] = timeLeft[j];

                        timeRight[j] = (timeRight[j] / wholeTime) * 100;
                        pillowsPercentage[1][i][j] = timeRight[j];

                        timeRear[j] = (timeRear[j] / wholeTime) * 100;
                        pillowsPercentage[2][i][j] = timeRear[j];
                    }
                }

                Form3 form3 = new Form3();
                form3.Text = "Pillows press percentage";
                form3.Show();
            }
            else
            {
                MessageBox.Show("Nie wybrałeś misji.");
            }
        }

        private void SettingTime_Click(object sender, EventArgs e)
        {
            if (settingTimeBool == true)
            {
                int lengthFirst = settingTime.Length;

                List<float> averageCloseOneMission = new List<float>();
                List<float> averageFarOneMission = new List<float>();

                List<float> timeClose = new List<float>();
                List<float> timeFar = new List<float>();

                List<float> pillowsEach = new List<float>();

                List<float> averageAfterCloseOneMission = new List<float>();
                List<float> averageAfterFarOneMission = new List<float>();

                List<float> afterTimeClose = new List<float>();
                List<float> afterTimeFar = new List<float>();
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
                    float pillows = Convert.ToSingle(Math.Round(double.Parse(settingTime[i][4]), 1));

                    int lengthSecond = target.Length - 1;
                    int targetNumber = 0;
                    float prevTarget = targetFloat[0];
                    float timeCounter = 0;
                    float timeAfterSetting = 0;
                    float timetoStart = 0;
                    bool fakeInfo = false;
                    bool canEnter = true;

                    List<float> closeOneMission = new List<float>();
                    List<float> farOneMission = new List<float>();

                    List<float> afterCloseOneMission = new List<float>();
                    List<float> afterFarOneMission = new List<float>();

                    for (int j = 1; j < lengthSecond; j++)
                    {
                        if ((playerAngleFloat[j] < 130 || playerAngleFloat[j] > 150) && j == 1)
                        {
                            fakeInfo = true;
                        }
                        if (timetoStart > 14.7f && timetoStart < 14.9f)
                        {
                            timetoStart = 0;
                            fakeInfo = false;
                            prevTarget = targetFloat[j + 1];
                        }
                        if (fakeInfo)
                        {
                            timetoStart += 0.2f;
                            continue;
                        }

                        if (targetFloat[j] < -5f || targetFloat[j] > 5f)
                        {
                            if (prevTarget != targetFloat[j] || j == lengthSecond - 1)
                            {
                                canEnter = true;
                                pillowsEach.Add(pillows);
                                if (targetNumber < 4)
                                {
                                    timeClose.Add(timeCounter);
                                    closeOneMission.Add(timeCounter);
                                    afterTimeClose.Add(timeAfterSetting);
                                    afterCloseOneMission.Add(timeAfterSetting);
                                }
                                else
                                {
                                    timeFar.Add(timeCounter);
                                    farOneMission.Add(timeCounter);
                                    afterTimeFar.Add(timeAfterSetting);
                                    afterFarOneMission.Add(timeAfterSetting);
                                }
                                targetNumber++;
                                timeCounter = 0f;
                                timeAfterSetting = 0f;
                            }
                            if (targetFloat[j] > -50f && targetFloat[j] < -30f)
                            {
                                if (playerAngleFloat[j] > targetLeftFloat[j] && canEnter)
                                {
                                    timeCounter += 0.2f;
                                }
                                else
                                {
                                    canEnter = false;
                                    if (playerAngleFloat[j] > targetLeftFloat[j] || playerAngleFloat[j] < targetRightFloat[j])
                                    {
                                        timeAfterSetting += 0.2f;
                                    }
                                }
                            }
                            else if (targetFloat[j] < 50 && targetFloat[j] > 30)
                            {
                                if (playerAngleFloat[j] < targetRightFloat[j] && canEnter)
                                {
                                    timeCounter += 0.2f;
                                }
                                else
                                {
                                    canEnter = false;
                                    if (playerAngleFloat[j] > targetLeftFloat[j] || playerAngleFloat[j] < targetRightFloat[j])
                                    {
                                        timeAfterSetting += 0.2f;
                                    }
                                }
                            }
                            prevTarget = targetFloat[j];
                        }
                    }
                    float average = 0;
                    closeOneMission.ForEach(item => average += item);
                    average /= closeOneMission.Count;
                    averageCloseOneMission.Add(average);

                    average = 0;
                    afterCloseOneMission.ForEach(item => average += item);
                    average /= afterCloseOneMission.Count;
                    averageAfterCloseOneMission.Add(average);

                    average = 0;
                    farOneMission.ForEach(item => average += item);
                    average /= farOneMission.Count;
                    averageFarOneMission.Add(average);

                    average = 0;
                    afterFarOneMission.ForEach(item => average += item);
                    average /= afterFarOneMission.Count;
                    averageAfterFarOneMission.Add(average);
                }
                float averageClose = 0;
                timeClose.ForEach(item => averageClose += item);
                averageClose /= timeClose.Count;

                float averageFar = 0;
                timeFar.ForEach(item => averageFar += item);
                averageFar /= timeFar.Count;

                float afterAverageClose = 0;
                afterTimeClose.ForEach(item => afterAverageClose += item);
                afterAverageClose /= afterTimeClose.Count;

                float afterAverageFar = 0;
                afterTimeFar.ForEach(item => afterAverageFar += item);
                afterAverageFar /= afterTimeFar.Count;

                string timesClose = "";
                for (int i = 1; i <= averageCloseOneMission.Count; i++)
                {
                    timesClose += i + ". " + "p: " + pillowsEach[i - 1] + " ; " + averageCloseOneMission[i - 1] + " s     ";
                }

                string timesFar = "";
                for (int i = 1; i <= averageFarOneMission.Count; i++)
                {
                    timesFar += i + ". " + "p: " + pillowsEach[i - 1] + " ; " + averageFarOneMission[i - 1] + " s     ";
                }

                string afterTimesClose = "";
                for (int i = 1; i <= averageAfterCloseOneMission.Count; i++)
                {
                    afterTimesClose += i + ". " + "p: " + pillowsEach[i - 1] + " ; " + averageAfterCloseOneMission[i - 1] + " s     ";
                }

                string afterTimesFar = "";
                for (int i = 1; i <= averageAfterFarOneMission.Count; i++)
                {
                    afterTimesFar += i + ". " + "p: " + pillowsEach[i - 1] + " ; " + averageAfterFarOneMission[i - 1] + " s     ";
                }

                MessageBox.Show("average close: " + averageClose + "    average far: " + averageFar + "\n" + timesClose + "\n" + timesFar + "\n\n"
                    + "average after close: " + afterAverageClose + "    average after far: " + afterAverageFar + "\n" + afterTimesClose + "\n"
                    + afterTimesFar);
            }
            else
            {
                MessageBox.Show("Nie wybrałeś misji.");
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
