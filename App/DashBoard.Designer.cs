namespace App
{
    partial class DashBoard
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
            DGV1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            totalSalesLbl = new Label();
            label4 = new Label();
            totalOrderLbl = new Label();
            panel1 = new Panel();
            label8 = new Label();
            label5 = new Label();
            label3 = new Label();
            DGV3 = new DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            DGV2 = new DataGridView();
            groupBox1 = new GroupBox();
            Refresh_Btn = new Button();
            label7 = new Label();
            DTPTo = new DateTimePicker();
            label6 = new Label();
            DTPFrom = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)DGV1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // DGV1
            // 
            DGV1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV1.Location = new Point(12, 14);
            DGV1.Name = "DGV1";
            DGV1.Size = new Size(930, 175);
            DGV1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(318, 32);
            label1.TabIndex = 1;
            label1.Text = "Sales Summary Dashboard";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(888, 116);
            label2.Name = "label2";
            label2.Size = new Size(95, 21);
            label2.TabIndex = 2;
            label2.Text = "Total Sales:";
            // 
            // totalSalesLbl
            // 
            totalSalesLbl.AutoSize = true;
            totalSalesLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            totalSalesLbl.Location = new Point(977, 116);
            totalSalesLbl.Name = "totalSalesLbl";
            totalSalesLbl.Size = new Size(112, 21);
            totalSalesLbl.TabIndex = 3;
            totalSalesLbl.Text = "00,000,000.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(888, 90);
            label4.Name = "label4";
            label4.Size = new Size(106, 21);
            label4.TabIndex = 2;
            label4.Text = "Total Orders:";
            // 
            // totalOrderLbl
            // 
            totalOrderLbl.AutoSize = true;
            totalOrderLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            totalOrderLbl.Location = new Point(989, 90);
            totalOrderLbl.Name = "totalOrderLbl";
            totalOrderLbl.Size = new Size(46, 21);
            totalOrderLbl.TabIndex = 3;
            totalOrderLbl.Text = "0000";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(DGV3);
            panel1.Controls.Add(chart1);
            panel1.Controls.Add(DGV2);
            panel1.Controls.Add(DGV1);
            panel1.Location = new Point(12, 151);
            panel1.Name = "panel1";
            panel1.Size = new Size(1472, 636);
            panel1.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 192);
            label8.Name = "label8";
            label8.Size = new Size(466, 15);
            label8.TabIndex = 5;
            label8.Text = "*Table shows each salesman’s total orders, total order amount, and highest order value.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 398);
            label5.Name = "label5";
            label5.Size = new Size(549, 15);
            label5.TabIndex = 4;
            label5.Text = "*Table shows each customer’s total orders and total amount, along with the highest single order value .";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 604);
            label3.Name = "label3";
            label3.Size = new Size(531, 15);
            label3.TabIndex = 3;
            label3.Text = "*Table shows the count of customers per salesman, split into tiers: <1K, 1K–9K, 10K–99K, and 100K+.";
            // 
            // DGV3
            // 
            DGV3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV3.Location = new Point(12, 426);
            DGV3.Name = "DGV3";
            DGV3.Size = new Size(930, 175);
            DGV3.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(948, 14);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(511, 175);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            // 
            // DGV2
            // 
            DGV2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV2.Location = new Point(12, 220);
            DGV2.Name = "DGV2";
            DGV2.Size = new Size(930, 175);
            DGV2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Refresh_Btn);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(DTPTo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(DTPFrom);
            groupBox1.Location = new Point(12, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(341, 89);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Date";
            // 
            // Refresh_Btn
            // 
            Refresh_Btn.Location = new Point(260, 40);
            Refresh_Btn.Name = "Refresh_Btn";
            Refresh_Btn.Size = new Size(75, 23);
            Refresh_Btn.TabIndex = 7;
            Refresh_Btn.Text = "Refresh";
            Refresh_Btn.UseVisualStyleBackColor = true;
            Refresh_Btn.Click += Refresh_Btn_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 60);
            label7.Name = "label7";
            label7.Size = new Size(26, 15);
            label7.TabIndex = 6;
            label7.Text = "To :";
            // 
            // DTPTo
            // 
            DTPTo.Location = new Point(53, 56);
            DTPTo.Name = "DTPTo";
            DTPTo.Size = new Size(200, 23);
            DTPTo.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 28);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 6;
            label6.Text = "From :";
            // 
            // DTPFrom
            // 
            DTPFrom.Location = new Point(53, 24);
            DTPFrom.Name = "DTPFrom";
            DTPFrom.Size = new Size(200, 23);
            DTPFrom.TabIndex = 6;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1496, 802);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(totalOrderLbl);
            Controls.Add(label4);
            Controls.Add(totalSalesLbl);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DashBoard";
            Text = "DashBoard";
            Load += DashBoard_Load;
            ((System.ComponentModel.ISupportInitialize)DGV1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV3).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV1;
        private Label label1;
        private Label label2;
        private Label totalSalesLbl;
        private Label label4;
        private Label totalOrderLbl;
        private Panel panel1;
        private DataGridView DGV2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private GroupBox groupBox1;
        private Button Refresh_Btn;
        private Label label7;
        private DateTimePicker DTPTo;
        private Label label6;
        private DateTimePicker DTPFrom;
        private DataGridView DGV3;
        private Label label8;
        private Label label5;
        private Label label3;
    }
}