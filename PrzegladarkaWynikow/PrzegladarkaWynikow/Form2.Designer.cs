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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dataGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Training = new System.Windows.Forms.Button();
            this.Mission1 = new System.Windows.Forms.Button();
            this.Mission2 = new System.Windows.Forms.Button();
            this.Mission3 = new System.Windows.Forms.Button();
            this.Mission4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.dataGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.dataGraph.Legends.Add(legend1);
            this.dataGraph.Location = new System.Drawing.Point(13, 44);
            this.dataGraph.Name = "dataGraph";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Blue;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "timeToHit";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "angle";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "points";
            this.dataGraph.Series.Add(series1);
            this.dataGraph.Series.Add(series2);
            this.dataGraph.Series.Add(series3);
            this.dataGraph.Size = new System.Drawing.Size(775, 394);
            this.dataGraph.TabIndex = 0;
            this.dataGraph.Text = "dataGraph";
            title1.Name = "Title";
            title1.Text = "Data";
            this.dataGraph.Titles.Add(title1);
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
            // 
            // Mission3
            // 
            this.Mission3.Location = new System.Drawing.Point(296, 13);
            this.Mission3.Name = "Mission3";
            this.Mission3.Size = new System.Drawing.Size(75, 23);
            this.Mission3.TabIndex = 4;
            this.Mission3.Text = "Misja 3";
            this.Mission3.UseVisualStyleBackColor = true;
            // 
            // Mission4
            // 
            this.Mission4.Location = new System.Drawing.Point(395, 13);
            this.Mission4.Name = "Mission4";
            this.Mission4.Size = new System.Drawing.Size(75, 23);
            this.Mission4.TabIndex = 5;
            this.Mission4.Text = "Misja 4";
            this.Mission4.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Mission4);
            this.Controls.Add(this.Mission3);
            this.Controls.Add(this.Mission2);
            this.Controls.Add(this.Mission1);
            this.Controls.Add(this.Training);
            this.Controls.Add(this.dataGraph);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Training;
        private System.Windows.Forms.Button Mission1;
        public System.Windows.Forms.DataVisualization.Charting.Chart dataGraph;
        private System.Windows.Forms.Button Mission2;
        private System.Windows.Forms.Button Mission3;
        private System.Windows.Forms.Button Mission4;
    }
}