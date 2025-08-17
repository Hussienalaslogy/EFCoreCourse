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
            DGV_Add = new DataGridView();
            add_Btn = new Button();
            customerId_Tb = new TextBox();
            view_Btn = new Button();
            edit_Btn = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Add).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(edit_Btn);
            groupBox1.Controls.Add(DGV_Add);
            groupBox1.Controls.Add(add_Btn);
            groupBox1.Controls.Add(customerId_Tb);
            groupBox1.Controls.Add(view_Btn);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(888, 269);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "View";
            // 
            // DGV_Add
            // 
            DGV_Add.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Add.Location = new Point(7, 28);
            DGV_Add.Margin = new Padding(3, 4, 3, 4);
            DGV_Add.Name = "DGV_Add";
            DGV_Add.RowHeadersWidth = 51;
            DGV_Add.Size = new Size(875, 192);
            DGV_Add.TabIndex = 1;
            // 
            // add_Btn
            // 
            add_Btn.Location = new Point(230, 231);
            add_Btn.Margin = new Padding(3, 4, 3, 4);
            add_Btn.Name = "add_Btn";
            add_Btn.Size = new Size(86, 31);
            add_Btn.TabIndex = 1;
            add_Btn.Text = "Add";
            add_Btn.UseVisualStyleBackColor = true;
            add_Btn.Click += add_Btn_Click_1;
            // 
            // customerId_Tb
            // 
            customerId_Tb.Location = new Point(7, 231);
            customerId_Tb.Name = "customerId_Tb";
            customerId_Tb.Size = new Size(125, 27);
            customerId_Tb.TabIndex = 2;
            // 
            // view_Btn
            // 
            view_Btn.Location = new Point(138, 231);
            view_Btn.Margin = new Padding(3, 4, 3, 4);
            view_Btn.Name = "view_Btn";
            view_Btn.Size = new Size(86, 31);
            view_Btn.TabIndex = 1;
            view_Btn.Text = "View";
            view_Btn.UseVisualStyleBackColor = true;
            view_Btn.Click += view_Btn_Click;
            // 
            // edit_Btn
            // 
            edit_Btn.Location = new Point(322, 233);
            edit_Btn.Name = "edit_Btn";
            edit_Btn.Size = new Size(94, 29);
            edit_Btn.TabIndex = 3;
            edit_Btn.Text = "Edit";
            edit_Btn.UseVisualStyleBackColor = true;
            edit_Btn.Click += edit_Btn_Click;
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
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Add).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button view_Btn;
        private Button add_Btn;
        private DataGridView DGV_Add;
        private TextBox customerId_Tb;
        private Button edit_Btn;
    }
}
