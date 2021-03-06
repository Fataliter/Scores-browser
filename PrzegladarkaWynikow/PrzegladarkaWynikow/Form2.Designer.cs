﻿namespace PrzegladarkaWynikow
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Training = new System.Windows.Forms.Button();
            this.Mission1 = new System.Windows.Forms.Button();
            this.Mission2 = new System.Windows.Forms.Button();
            this.Mission3 = new System.Windows.Forms.Button();
            this.Mission4 = new System.Windows.Forms.Button();
            this.bigDataGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SettingTime = new System.Windows.Forms.Button();
            this.PillowsTimePercent = new System.Windows.Forms.Button();
            this.IntegralCritButton = new System.Windows.Forms.Button();
            this.CountFifteen = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigDataGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGraph
            // 
            chartArea1.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea1.Name = "ChartArea1";
            this.dataGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.dataGraph.Legends.Add(legend1);
            this.dataGraph.Location = new System.Drawing.Point(6, 70);
            this.dataGraph.Name = "dataGraph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "timeToHit";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "angle";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "targetLocation";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "hitAngle";
            this.dataGraph.Series.Add(series1);
            this.dataGraph.Series.Add(series2);
            this.dataGraph.Series.Add(series3);
            this.dataGraph.Series.Add(series4);
            this.dataGraph.Size = new System.Drawing.Size(865, 321);
            this.dataGraph.TabIndex = 0;
            this.dataGraph.Text = "dataGraph";
            title1.Name = "Title";
            title1.Text = "Data";
            this.dataGraph.Titles.Add(title1);
            this.dataGraph.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.dataGraph_AxisViewChanged);
            // 
            // Training
            // 
            this.Training.Location = new System.Drawing.Point(13, 13);
            this.Training.Name = "Training";
            this.Training.Size = new System.Drawing.Size(75, 23);
            this.Training.TabIndex = 1;
            this.Training.Text = "Trening";
            this.Training.UseVisualStyleBackColor = true;
            this.Training.Click += new System.EventHandler(this.Training_Click);
            // 
            // Mission1
            // 
            this.Mission1.Location = new System.Drawing.Point(108, 13);
            this.Mission1.Name = "Mission1";
            this.Mission1.Size = new System.Drawing.Size(75, 23);
            this.Mission1.TabIndex = 2;
            this.Mission1.Text = "Misja 1";
            this.Mission1.UseVisualStyleBackColor = true;
            this.Mission1.Click += new System.EventHandler(this.Mission1_Click);
            // 
            // Mission2
            // 
            this.Mission2.Location = new System.Drawing.Point(202, 13);
            this.Mission2.Name = "Mission2";
            this.Mission2.Size = new System.Drawing.Size(75, 23);
            this.Mission2.TabIndex = 3;
            this.Mission2.Text = "Misja 2";
            this.Mission2.UseVisualStyleBackColor = true;
            this.Mission2.Click += new System.EventHandler(this.Mission2_Click);
            // 
            // Mission3
            // 
            this.Mission3.Location = new System.Drawing.Point(296, 13);
            this.Mission3.Name = "Mission3";
            this.Mission3.Size = new System.Drawing.Size(75, 23);
            this.Mission3.TabIndex = 4;
            this.Mission3.Text = "Misja 3";
            this.Mission3.UseVisualStyleBackColor = true;
            this.Mission3.Click += new System.EventHandler(this.Mission3_Click);
            // 
            // Mission4
            // 
            this.Mission4.Location = new System.Drawing.Point(395, 13);
            this.Mission4.Name = "Mission4";
            this.Mission4.Size = new System.Drawing.Size(75, 23);
            this.Mission4.TabIndex = 5;
            this.Mission4.Text = "Misja 4";
            this.Mission4.UseVisualStyleBackColor = true;
            this.Mission4.Click += new System.EventHandler(this.Mission4_Click);
            // 
            // bigDataGraph
            // 
            chartArea2.Name = "ChartArea1";
            this.bigDataGraph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.bigDataGraph.Legends.Add(legend2);
            this.bigDataGraph.Location = new System.Drawing.Point(6, 397);
            this.bigDataGraph.Name = "bigDataGraph";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "pressOnLeftLeg";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "pressOnRightLeg";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "pressOnLeftPillow";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "pressOnRightPillow";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Legend = "Legend1";
            series9.Name = "pressOnRearPillow";
            this.bigDataGraph.Series.Add(series5);
            this.bigDataGraph.Series.Add(series6);
            this.bigDataGraph.Series.Add(series7);
            this.bigDataGraph.Series.Add(series8);
            this.bigDataGraph.Series.Add(series9);
            this.bigDataGraph.Size = new System.Drawing.Size(865, 279);
            this.bigDataGraph.TabIndex = 6;
            this.bigDataGraph.Text = "bigDataGraph";
            this.bigDataGraph.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.bigDataGraph_AxisViewChanged);
            // 
            // SettingTime
            // 
            this.SettingTime.Location = new System.Drawing.Point(493, 13);
            this.SettingTime.Name = "SettingTime";
            this.SettingTime.Size = new System.Drawing.Size(75, 23);
            this.SettingTime.TabIndex = 7;
            this.SettingTime.Text = "Czas ust.";
            this.SettingTime.UseVisualStyleBackColor = true;
            this.SettingTime.Click += new System.EventHandler(this.SettingTime_Click);
            // 
            // PillowsTimePercent
            // 
            this.PillowsTimePercent.Location = new System.Drawing.Point(588, 13);
            this.PillowsTimePercent.Name = "PillowsTimePercent";
            this.PillowsTimePercent.Size = new System.Drawing.Size(75, 23);
            this.PillowsTimePercent.TabIndex = 8;
            this.PillowsTimePercent.Text = "Czas pod.";
            this.PillowsTimePercent.UseVisualStyleBackColor = true;
            this.PillowsTimePercent.Click += new System.EventHandler(this.PillowsTimePercent_Click);
            // 
            // IntegralCritButton
            // 
            this.IntegralCritButton.Location = new System.Drawing.Point(682, 13);
            this.IntegralCritButton.Name = "IntegralCritButton";
            this.IntegralCritButton.Size = new System.Drawing.Size(75, 23);
            this.IntegralCritButton.TabIndex = 9;
            this.IntegralCritButton.Text = "Kryt. całk.";
            this.IntegralCritButton.UseVisualStyleBackColor = true;
            this.IntegralCritButton.Click += new System.EventHandler(this.IntegralCritButton_Click);
            // 
            // CountFifteen
            // 
            this.CountFifteen.AutoSize = true;
            this.CountFifteen.Location = new System.Drawing.Point(790, 18);
            this.CountFifteen.Name = "CountFifteen";
            this.CountFifteen.Size = new System.Drawing.Size(65, 17);
            this.CountFifteen.TabIndex = 10;
            this.CountFifteen.Text = "Licz 15s";
            this.CountFifteen.UseVisualStyleBackColor = true;
            this.CountFifteen.CheckedChanged += new System.EventHandler(this.CountFifteen_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 677);
            this.Controls.Add(this.CountFifteen);
            this.Controls.Add(this.IntegralCritButton);
            this.Controls.Add(this.PillowsTimePercent);
            this.Controls.Add(this.SettingTime);
            this.Controls.Add(this.bigDataGraph);
            this.Controls.Add(this.Mission4);
            this.Controls.Add(this.Mission3);
            this.Controls.Add(this.Mission2);
            this.Controls.Add(this.Mission1);
            this.Controls.Add(this.Training);
            this.Controls.Add(this.dataGraph);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigDataGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Training;
        private System.Windows.Forms.Button Mission1;
        public System.Windows.Forms.DataVisualization.Charting.Chart dataGraph;
        private System.Windows.Forms.Button Mission2;
        private System.Windows.Forms.Button Mission3;
        private System.Windows.Forms.Button Mission4;
        private System.Windows.Forms.DataVisualization.Charting.Chart bigDataGraph;
        private System.Windows.Forms.Button SettingTime;
        private System.Windows.Forms.Button PillowsTimePercent;
        private System.Windows.Forms.Button IntegralCritButton;
        private System.Windows.Forms.CheckBox CountFifteen;
    }
}