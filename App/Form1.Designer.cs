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
            branch_Cb = new ComboBox();
            new_Btn = new Button();
            label1 = new Label();
            save_Btn = new Button();
            delete_Btn = new Button();
            DGV_Add = new DataGridView();
            customerId_Tb = new TextBox();
            view_Btn = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Add).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(branch_Cb);
            groupBox1.Controls.Add(new_Btn);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(save_Btn);
            groupBox1.Controls.Add(delete_Btn);
            groupBox1.Controls.Add(DGV_Add);
            groupBox1.Controls.Add(customerId_Tb);
            groupBox1.Controls.Add(view_Btn);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(714, 304);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Customers";
            // 
            // branch_Cb
            // 
            branch_Cb.FormattingEnabled = true;
            branch_Cb.Location = new Point(67, 28);
            branch_Cb.Name = "branch_Cb";
            branch_Cb.Size = new Size(183, 28);
            branch_Cb.TabIndex = 8;
            // 
            // new_Btn
            // 
            new_Btn.Location = new Point(7, 264);
            new_Btn.Name = "new_Btn";
            new_Btn.Size = new Size(94, 29);
            new_Btn.TabIndex = 7;
            new_Btn.Text = "New";
            new_Btn.UseVisualStyleBackColor = true;
            new_Btn.Click += new_Btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 31);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 6;
            label1.Text = "Branch";
            // 
            // save_Btn
            // 
            save_Btn.Location = new Point(107, 263);
            save_Btn.Name = "save_Btn";
            save_Btn.Size = new Size(94, 29);
            save_Btn.TabIndex = 5;
            save_Btn.Text = "Save";
            save_Btn.UseVisualStyleBackColor = true;
            save_Btn.Click += save_Btn_Click;
            // 
            // delete_Btn
            // 
            delete_Btn.Location = new Point(207, 263);
            delete_Btn.Name = "delete_Btn";
            delete_Btn.Size = new Size(94, 29);
            delete_Btn.TabIndex = 4;
            delete_Btn.Text = "Delete";
            delete_Btn.UseVisualStyleBackColor = true;
            delete_Btn.Click += delete_Btn_Click;
            // 
            // DGV_Add
            // 
            DGV_Add.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Add.Location = new Point(7, 65);
            DGV_Add.Margin = new Padding(3, 4, 3, 4);
            DGV_Add.Name = "DGV_Add";
            DGV_Add.RowHeadersWidth = 51;
            DGV_Add.Size = new Size(689, 192);
            DGV_Add.TabIndex = 1;
            // 
            // customerId_Tb
            // 
            customerId_Tb.Location = new Point(479, 20);
            customerId_Tb.Name = "customerId_Tb";
            customerId_Tb.Size = new Size(125, 27);
            customerId_Tb.TabIndex = 2;
            customerId_Tb.KeyDown += customerId_Tb_KeyDown;
            // 
            // view_Btn
            // 
            view_Btn.Location = new Point(610, 20);
            view_Btn.Margin = new Padding(3, 4, 3, 4);
            view_Btn.Name = "view_Btn";
            view_Btn.Size = new Size(86, 31);
            view_Btn.TabIndex = 1;
            view_Btn.Text = "View";
            view_Btn.UseVisualStyleBackColor = true;
            view_Btn.Click += view_Btn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(602, 264);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 9;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 600);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "EF Core Course";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Add).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button view_Btn;
        private DataGridView DGV_Add;
        private TextBox customerId_Tb;
        private Button delete_Btn;
        private Button save_Btn;
        private Label label1;
        private ComboBox branch_Cb;
        private Button new_Btn;
        private Button button1;
    }
}
