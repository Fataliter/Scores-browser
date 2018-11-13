namespace PrzegladarkaWynikow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Training = new System.Windows.Forms.Button();
            this.Mission1 = new System.Windows.Forms.Button();
            this.Mission2 = new System.Windows.Forms.Button();
            this.Mission3 = new System.Windows.Forms.Button();
            this.Mission4 = new System.Windows.Forms.Button();
            this.bigDataGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SettingTime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigDataGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGraph
            // 
            chartArea3.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea3.Name = "ChartArea1";
            this.dataGraph.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.dataGraph.Legends.Add(legend3);
            this.dataGraph.Location = new System.Drawing.Point(6, 70);
            this.dataGraph.Name = "dataGraph";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Color = System.Drawing.Color.Blue;
            series10.Legend = "Legend1";
            series10.Name = "timeToHit";
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.Name = "angle";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.Name = "targetLocation";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Legend = "Legend1";
            series13.Name = "hitAngle";
            this.dataGraph.Series.Add(series10);
            this.dataGraph.Series.Add(series11);
            this.dataGraph.Series.Add(series12);
            this.dataGraph.Series.Add(series13);
            this.dataGraph.Size = new System.Drawing.Size(865, 321);
            this.dataGraph.TabIndex = 0;
            this.dataGraph.Text = "dataGraph";
            title2.Name = "Title";
            title2.Text = "Data";
            this.dataGraph.Titles.Add(title2);
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
            chartArea4.Name = "ChartArea1";
            this.bigDataGraph.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.bigDataGraph.Legends.Add(legend4);
            this.bigDataGraph.Location = new System.Drawing.Point(6, 397);
            this.bigDataGraph.Name = "bigDataGraph";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Legend = "Legend1";
            series14.Name = "pressOnLeftLeg";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Legend = "Legend1";
            series15.Name = "pressOnRightLeg";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series16.Legend = "Legend1";
            series16.Name = "pressOnLeftPillow";
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series17.Legend = "Legend1";
            series17.Name = "pressOnRightPillow";
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series18.Legend = "Legend1";
            series18.Name = "pressOnRearPillow";
            this.bigDataGraph.Series.Add(series14);
            this.bigDataGraph.Series.Add(series15);
            this.bigDataGraph.Series.Add(series16);
            this.bigDataGraph.Series.Add(series17);
            this.bigDataGraph.Series.Add(series18);
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 677);
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
    }
}