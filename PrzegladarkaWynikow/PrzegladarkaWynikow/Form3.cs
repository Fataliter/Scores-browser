using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PrzegladarkaWynikow
{
    public partial class Form3 : Form
    {
        Button[] buttons = new Button[35];
        Chart chartOne = new Chart();
        Chart chartTwo = new Chart();
        Chart chartThree = new Chart();

        public Form3()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;

            int length = Form2.pillowsPercentage[0].Length;
            for (int i = 0; i < length + 1; i++)
            {
                Button newButton = new Button();
                newButton.Location = new Point(10 + i * 35, 15);
                newButton.Size = new Size(30, 23);
                newButton.Text = (i + 1).ToString();
                buttons[i] = newButton;
                buttons[i].Click += new EventHandler(Draw_Click);
                this.Controls.Add(newButton);
            }

            chartOne.Location = new Point(0, 45);
            int height = Convert.ToInt32(0.3 * this.Size.Height);
            chartOne.Size = new Size(this.Size.Width, height);
            chartOne.Visible = true;
            this.Controls.Add(chartOne);
            ChartArea areaOne = new ChartArea();
            chartOne.ChartAreas.Add(areaOne);
            areaOne.Name = "areaOne";
            Title titleOne = new Title();
            titleOne.Name = "Title";
            chartOne.Titles.Add(titleOne);

            chartTwo.Location = new Point(0, 45 + height);
            chartTwo.Size = new Size(this.Size.Width, height);
            chartTwo.Visible = true;
            this.Controls.Add(chartTwo);
            ChartArea areaTwo = new ChartArea();
            chartTwo.ChartAreas.Add(areaTwo);
            areaTwo.Name = "areaTwo";
            Title titleTwo = new Title();
            titleTwo.Name = "Title";
            chartTwo.Titles.Add(titleTwo);

            chartThree.Location = new Point(0, 45 + height + height);
            chartThree.Size = new Size(this.Size.Width, height);
            chartThree.Visible = true;
            this.Controls.Add(chartThree);
            ChartArea areaThree = new ChartArea();
            chartThree.ChartAreas.Add(areaThree);
            areaThree.Name = "areaThree";
            Title titleThree = new Title();
            titleThree.Name = "Title";
            chartThree.Titles.Add(titleThree);
        }

        void Draw_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            DrawGraph(Form2.whichMission, int.Parse(button.Text) - 1, Form2.pillowsPercentage);
        }

        void DrawGraph(int whichMission, int whichSession, float[][][] pillowsPercentage)
        {
            chartOne.Series.Clear();
            chartTwo.Series.Clear();
            chartThree.Series.Clear();

            chartOne.Series.Add("Left");
            chartOne.Series["Left"].BorderWidth = 2;
            chartOne.Series["Left"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartOne.Series["Left"].IsValueShownAsLabel = true;
            chartOne.Series["Left"].Name = "Lewa";
            var areaOne = chartOne.ChartAreas["areaOne"];
            areaOne.AxisX.Title = "przedziały nacisku na poduszki";
            areaOne.AxisY.Title = "czas nacisku [%]";

            chartTwo.Series.Add("Right");
            chartTwo.Series["Right"].BorderWidth = 2;
            chartTwo.Series["Right"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartTwo.Series["Right"].IsValueShownAsLabel = true;
            chartTwo.Series["Right"].Name = "Prawa";
            var areaTwo = chartTwo.ChartAreas["areaTwo"];
            areaTwo.AxisX.Title = "przedziały nacisku na poduszki";
            areaTwo.AxisY.Title = "czas nacisku [%]";

            chartThree.Series.Add("Rear");
            chartThree.Series["Rear"].BorderWidth = 2;
            chartThree.Series["Rear"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartThree.Series["Rear"].IsValueShownAsLabel = true;
            chartThree.Series["Rear"].Name = "Tylna";
            var areaThree = chartThree.ChartAreas["areaThree"];
            areaThree.AxisX.Title = "przedziały nacisku na poduszki";
            areaThree.AxisY.Title = "czas nacisku [%]";

            if (whichSession == Form2.pillowsPercentage[0].Length)
            {
                int lengthPercentage = Form2.pillowsPercentage[0].Length;
                float[] pillowsPercentageLeft = new float[11];
                float[] pillowsPercentageRight = new float[11];
                float[] pillowsPercentageRear = new float[11];

                var csv = new StringBuilder();
                csv.AppendLine(this.Text);
                //csv.AppendLine("pLeft;pRight;pRear");

                string pLeft = "";
                string pRight = "";
                string pRear = "";

                for (int i = 0; i < 11; i++)
                {
                    float averageLeft = 0;
                    float averageRight = 0;
                    float averageRear = 0;
                    for (int j = 0; j < lengthPercentage; j++)
                    {
                        averageLeft += pillowsPercentage[0][j][i];
                        averageRight += pillowsPercentage[1][j][i];
                        averageRear += pillowsPercentage[2][j][i];
                    }
                    pillowsPercentageLeft[i] = averageLeft / lengthPercentage;
                    pillowsPercentageRight[i] = averageRight / lengthPercentage;
                    pillowsPercentageRear[i] = averageRear / lengthPercentage;

                    if (i < 10)
                    {
                        pLeft += pillowsPercentageLeft[i] + ";";
                        pRight += pillowsPercentageRight[i] + ";";
                        pRear += pillowsPercentageRear[i] + ";";
                    }
                    else
                    {
                        pLeft += pillowsPercentageLeft[i];
                        pRight += pillowsPercentageRight[i];
                        pRear += pillowsPercentageRear[i];
                    }
                }
                csv.AppendLine(pLeft+";"+pRight+";"+pRear);

                File.AppendAllText(@"D:\Studia\csvki\procent_poduszek.csv", csv.ToString());

                chartOne.Titles["Title"].Text = "Lewa Poduszka";
                chartTwo.Titles["Title"].Text = "Prawa Poduszka";
                chartThree.Titles["Title"].Text = "Tylna Poduszka";

                for (int i = 1; i <= 11; i++)
                {
                    chartOne.Series["Lewa"].Points.AddXY(i, Math.Round(Convert.ToDouble(pillowsPercentageLeft[i - 1]), 2));
                    chartTwo.Series["Prawa"].Points.AddXY(i, Math.Round(Convert.ToDouble(pillowsPercentageRight[i - 1]), 2));
                    chartThree.Series["Tylna"].Points.AddXY(i, Math.Round(Convert.ToDouble(pillowsPercentageRear[i - 1]), 2));
                }
                return;
            }

            chartOne.Titles["Title"].Text = "Lewa Poduszka - próg: " + Form2.pillowsTime[whichSession][4];
            chartTwo.Titles["Title"].Text = "Prawa Poduszka - próg: " + Form2.pillowsTime[whichSession][4];
            chartThree.Titles["Title"].Text = "Tylna Poduszka - próg: " + Form2.pillowsTime[whichSession][4];

            for (int i = 1; i <= 11; i++)
            {
                chartOne.Series["Lewa"].Points.AddXY(i, Math.Round(Convert.ToDouble(pillowsPercentage[0][whichSession][i - 1]), 2));
                chartTwo.Series["Prawa"].Points.AddXY(i, Math.Round(Convert.ToDouble(pillowsPercentage[1][whichSession][i - 1]), 2));
                chartThree.Series["Tylna"].Points.AddXY(i, Math.Round(Convert.ToDouble(pillowsPercentage[2][whichSession][i - 1]), 2));
            }
        }
    }
}
