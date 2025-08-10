namespace App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            view_Btn = new Button();
            DGV_View = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_View).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(view_Btn);
            groupBox1.Controls.Add(DGV_View);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(331, 269);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "View";
            // 
            // view_Btn
            // 
            view_Btn.Location = new Point(108, 229);
            view_Btn.Margin = new Padding(3, 4, 3, 4);
            view_Btn.Name = "view_Btn";
            view_Btn.Size = new Size(86, 31);
            view_Btn.TabIndex = 1;
            view_Btn.Text = "View";
            view_Btn.UseVisualStyleBackColor = true;
            view_Btn.Click += view_Btn_Click;
            // 
            // DGV_View
            // 
            DGV_View.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_View.Location = new Point(7, 29);
            DGV_View.Margin = new Padding(3, 4, 3, 4);
            DGV_View.Name = "DGV_View";
            DGV_View.RowHeadersWidth = 51;
            DGV_View.Size = new Size(311, 192);
            DGV_View.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGV_View).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button view_Btn;
        private DataGridView DGV_View;
    }
}
