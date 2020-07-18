namespace XwNetTest
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericChannels = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.radioClient = new System.Windows.Forms.RadioButton();
            this.radioServer = new System.Windows.Forms.RadioButton();
            this.comboServerIP = new System.Windows.Forms.ComboBox();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.textClientIP = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelChannels = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelAvgRecv = new System.Windows.Forms.Label();
            this.labelAvgSent = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelCountRecv = new System.Windows.Forms.Label();
            this.labelCountSent = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chartTraffic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Pump = new System.Windows.Forms.Timer(this.components);
            this.Measure = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericChannels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTraffic)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericChannels);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioClient);
            this.groupBox2.Controls.Add(this.radioServer);
            this.groupBox2.Controls.Add(this.comboServerIP);
            this.groupBox2.Controls.Add(this.numericPort);
            this.groupBox2.Controls.Add(this.textClientIP);
            this.groupBox2.Controls.Add(this.buttonStart);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 87);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // numericChannels
            // 
            this.numericChannels.Location = new System.Drawing.Point(335, 50);
            this.numericChannels.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericChannels.Name = "numericChannels";
            this.numericChannels.Size = new System.Drawing.Size(89, 20);
            this.numericChannels.TabIndex = 10;
            this.numericChannels.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Channels";
            // 
            // radioClient
            // 
            this.radioClient.AutoSize = true;
            this.radioClient.Location = new System.Drawing.Point(14, 51);
            this.radioClient.Name = "radioClient";
            this.radioClient.Size = new System.Drawing.Size(51, 17);
            this.radioClient.TabIndex = 9;
            this.radioClient.TabStop = true;
            this.radioClient.Text = "Client";
            this.radioClient.UseVisualStyleBackColor = true;
            // 
            // radioServer
            // 
            this.radioServer.AutoSize = true;
            this.radioServer.Checked = true;
            this.radioServer.Location = new System.Drawing.Point(14, 21);
            this.radioServer.Name = "radioServer";
            this.radioServer.Size = new System.Drawing.Size(56, 17);
            this.radioServer.TabIndex = 8;
            this.radioServer.TabStop = true;
            this.radioServer.Text = "Server";
            this.radioServer.UseVisualStyleBackColor = true;
            // 
            // comboServerIP
            // 
            this.comboServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServerIP.FormattingEnabled = true;
            this.comboServerIP.Location = new System.Drawing.Point(76, 20);
            this.comboServerIP.Name = "comboServerIP";
            this.comboServerIP.Size = new System.Drawing.Size(190, 21);
            this.comboServerIP.TabIndex = 4;
            // 
            // numericPort
            // 
            this.numericPort.Location = new System.Drawing.Point(335, 20);
            this.numericPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(89, 20);
            this.numericPort.TabIndex = 5;
            this.numericPort.Value = new decimal(new int[] {
            27100,
            0,
            0,
            0});
            // 
            // textClientIP
            // 
            this.textClientIP.Location = new System.Drawing.Point(76, 50);
            this.textClientIP.Name = "textClientIP";
            this.textClientIP.Size = new System.Drawing.Size(190, 20);
            this.textClientIP.TabIndex = 7;
            this.textClientIP.TextChanged += new System.EventHandler(this.textClientIP_TextChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(444, 19);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(101, 52);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "TCP Port";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelChannels);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.labelAvgRecv);
            this.groupBox3.Controls.Add(this.labelAvgSent);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.labelCountRecv);
            this.groupBox3.Controls.Add(this.labelCountSent);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.chartTraffic);
            this.groupBox3.Location = new System.Drawing.Point(12, 113);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(558, 338);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Location = new System.Drawing.Point(68, 64);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(13, 13);
            this.labelChannels.TabIndex = 14;
            this.labelChannels.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Channels:";
            // 
            // labelAvgRecv
            // 
            this.labelAvgRecv.AutoSize = true;
            this.labelAvgRecv.Location = new System.Drawing.Point(352, 39);
            this.labelAvgRecv.Name = "labelAvgRecv";
            this.labelAvgRecv.Size = new System.Drawing.Size(13, 13);
            this.labelAvgRecv.TabIndex = 12;
            this.labelAvgRecv.Text = "0";
            // 
            // labelAvgSent
            // 
            this.labelAvgSent.AutoSize = true;
            this.labelAvgSent.Location = new System.Drawing.Point(68, 39);
            this.labelAvgSent.Name = "labelAvgSent";
            this.labelAvgSent.Size = new System.Drawing.Size(13, 13);
            this.labelAvgSent.TabIndex = 11;
            this.labelAvgSent.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(306, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Avg:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Avg:";
            // 
            // labelCountRecv
            // 
            this.labelCountRecv.AutoSize = true;
            this.labelCountRecv.Location = new System.Drawing.Point(352, 16);
            this.labelCountRecv.Name = "labelCountRecv";
            this.labelCountRecv.Size = new System.Drawing.Size(13, 13);
            this.labelCountRecv.TabIndex = 8;
            this.labelCountRecv.Text = "0";
            // 
            // labelCountSent
            // 
            this.labelCountSent.AutoSize = true;
            this.labelCountSent.Location = new System.Drawing.Point(68, 16);
            this.labelCountSent.Name = "labelCountSent";
            this.labelCountSent.Size = new System.Drawing.Size(13, 13);
            this.labelCountSent.TabIndex = 7;
            this.labelCountSent.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Received:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Sent:";
            // 
            // chartTraffic
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTraffic.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTraffic.Legends.Add(legend2);
            this.chartTraffic.Location = new System.Drawing.Point(7, 93);
            this.chartTraffic.Name = "chartTraffic";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartTraffic.Series.Add(series2);
            this.chartTraffic.Size = new System.Drawing.Size(543, 239);
            this.chartTraffic.TabIndex = 0;
            this.chartTraffic.Text = "chart1";
            // 
            // Pump
            // 
            this.Pump.Interval = 200;
            this.Pump.Tick += new System.EventHandler(this.Pump_Tick);
            // 
            // Measure
            // 
            this.Measure.Interval = 250;
            this.Measure.Tick += new System.EventHandler(this.Measure_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 463);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XwNetTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericChannels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTraffic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericPort;
        private System.Windows.Forms.TextBox textClientIP;
        private System.Windows.Forms.Timer Pump;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTraffic;
        private System.Windows.Forms.Timer Measure;
        private System.Windows.Forms.Label labelCountRecv;
        private System.Windows.Forms.Label labelCountSent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelAvgRecv;
        private System.Windows.Forms.Label labelAvgSent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericChannels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioClient;
        private System.Windows.Forms.RadioButton radioServer;
        private System.Windows.Forms.ComboBox comboServerIP;
        private System.Windows.Forms.Label labelChannels;
        private System.Windows.Forms.Label label3;
    }
}

