namespace DataProcessingClient
{
    partial class DataForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trbMaxRecords = new System.Windows.Forms.TrackBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbHostUrl = new System.Windows.Forms.TextBox();
            this.lblAPIUrl = new System.Windows.Forms.Label();
            this.lblDataformat = new System.Windows.Forms.Label();
            this.rbXML = new System.Windows.Forms.RadioButton();
            this.rbJson = new System.Windows.Forms.RadioButton();
            this.chartAD1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblStats = new System.Windows.Forms.Label();
            this.tbStats = new System.Windows.Forms.TextBox();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbMaxRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAD1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.tbStats);
            this.gbSettings.Controls.Add(this.lblStats);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.trbMaxRecords);
            this.gbSettings.Controls.Add(this.btnSave);
            this.gbSettings.Controls.Add(this.tbHostUrl);
            this.gbSettings.Controls.Add(this.lblAPIUrl);
            this.gbSettings.Controls.Add(this.lblDataformat);
            this.gbSettings.Controls.Add(this.rbXML);
            this.gbSettings.Controls.Add(this.rbJson);
            this.gbSettings.Location = new System.Drawing.Point(12, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(496, 300);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Max records (x100)";
            // 
            // trbMaxRecords
            // 
            this.trbMaxRecords.Location = new System.Drawing.Point(445, 16);
            this.trbMaxRecords.Minimum = 1;
            this.trbMaxRecords.Name = "trbMaxRecords";
            this.trbMaxRecords.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trbMaxRecords.Size = new System.Drawing.Size(45, 278);
            this.trbMaxRecords.TabIndex = 6;
            this.trbMaxRecords.Value = 1;
            this.trbMaxRecords.Scroll += new System.EventHandler(this.trbMaxRecords_Scroll);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(19, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(313, 37);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbHostUrl
            // 
            this.tbHostUrl.Location = new System.Drawing.Point(19, 90);
            this.tbHostUrl.Name = "tbHostUrl";
            this.tbHostUrl.Size = new System.Drawing.Size(313, 20);
            this.tbHostUrl.TabIndex = 4;
            this.tbHostUrl.Text = "http://localhost:54164/";
            // 
            // lblAPIUrl
            // 
            this.lblAPIUrl.AutoSize = true;
            this.lblAPIUrl.Location = new System.Drawing.Point(6, 73);
            this.lblAPIUrl.Name = "lblAPIUrl";
            this.lblAPIUrl.Size = new System.Drawing.Size(72, 13);
            this.lblAPIUrl.TabIndex = 3;
            this.lblAPIUrl.Text = "REST API Url";
            // 
            // lblDataformat
            // 
            this.lblDataformat.AutoSize = true;
            this.lblDataformat.Location = new System.Drawing.Point(6, 16);
            this.lblDataformat.Name = "lblDataformat";
            this.lblDataformat.Size = new System.Drawing.Size(62, 13);
            this.lblDataformat.TabIndex = 2;
            this.lblDataformat.Text = "Data format";
            // 
            // rbXML
            // 
            this.rbXML.AutoSize = true;
            this.rbXML.Location = new System.Drawing.Point(19, 53);
            this.rbXML.Name = "rbXML";
            this.rbXML.Size = new System.Drawing.Size(47, 17);
            this.rbXML.TabIndex = 1;
            this.rbXML.Text = "XML";
            this.rbXML.UseVisualStyleBackColor = true;
            this.rbXML.CheckedChanged += new System.EventHandler(this.rbXML_CheckedChanged);
            // 
            // rbJson
            // 
            this.rbJson.AutoSize = true;
            this.rbJson.Checked = true;
            this.rbJson.Location = new System.Drawing.Point(19, 30);
            this.rbJson.Name = "rbJson";
            this.rbJson.Size = new System.Drawing.Size(53, 17);
            this.rbJson.TabIndex = 0;
            this.rbJson.TabStop = true;
            this.rbJson.Text = "JSON";
            this.rbJson.UseVisualStyleBackColor = true;
            // 
            // chartAD1
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAD1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartAD1.Legends.Add(legend1);
            this.chartAD1.Location = new System.Drawing.Point(518, 12);
            this.chartAD1.Name = "chartAD1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartAD1.Series.Add(series1);
            this.chartAD1.Size = new System.Drawing.Size(496, 300);
            this.chartAD1.TabIndex = 1;
            this.chartAD1.Text = "Alcohol en Drugs Gebruik onder scholieren";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(12, 318);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(496, 300);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart1";
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(518, 318);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(496, 300);
            this.chart3.TabIndex = 1;
            this.chart3.Text = "chart1";
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(7, 117);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(49, 13);
            this.lblStats.TabIndex = 10;
            this.lblStats.Text = "Statistics";
            // 
            // tbStats
            // 
            this.tbStats.Location = new System.Drawing.Point(19, 134);
            this.tbStats.Multiline = true;
            this.tbStats.Name = "tbStats";
            this.tbStats.ReadOnly = true;
            this.tbStats.Size = new System.Drawing.Size(313, 110);
            this.tbStats.TabIndex = 11;
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 624);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chartAD1);
            this.Controls.Add(this.gbSettings);
            this.Name = "DataForm";
            this.Text = "Data Processing - Client";
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbMaxRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAD1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.RadioButton rbXML;
        private System.Windows.Forms.RadioButton rbJson;
        private System.Windows.Forms.Label lblAPIUrl;
        private System.Windows.Forms.Label lblDataformat;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbHostUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trbMaxRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAD1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.TextBox tbStats;
        private System.Windows.Forms.Label lblStats;
    }
}

