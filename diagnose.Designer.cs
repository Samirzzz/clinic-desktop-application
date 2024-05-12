namespace clinic_system
{
    partial class diagnose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(diagnose));
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            display = new DataGridView();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)display).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(78, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(472, 88);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 215);
            button1.Name = "button1";
            button1.Size = new Size(142, 35);
            button1.TabIndex = 1;
            button1.Text = "Diagnosis";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(13, 279);
            button2.Name = "button2";
            button2.Size = new Size(142, 33);
            button2.TabIndex = 2;
            button2.Text = "Investigation";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(12, 345);
            button3.Name = "button3";
            button3.Size = new Size(142, 32);
            button3.TabIndex = 3;
            button3.Text = "Medication";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // display
            // 
            display.AllowUserToAddRows = false;
            display.AllowUserToDeleteRows = false;
            display.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            display.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            display.Location = new Point(611, 151);
            display.Name = "display";
            display.ReadOnly = true;
            display.RowHeadersWidth = 51;
            display.ShowCellErrors = false;
            display.ShowCellToolTips = false;
            display.ShowRowErrors = false;
            display.Size = new Size(521, 510);
            display.TabIndex = 5;
            display.CellContentClick += dataGridView2_CellContentClick;
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Location = new Point(13, 4);
            button5.Name = "button5";
            button5.Size = new Size(46, 47);
            button5.TabIndex = 6;
            button5.Text = "\r\n";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(12, 409);
            button6.Name = "button6";
            button6.Size = new Size(142, 30);
            button6.TabIndex = 7;
            button6.Text = "Report";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(514, 151);
            button7.Name = "button7";
            button7.Size = new Size(91, 35);
            button7.TabIndex = 8;
            button7.Text = "Diagnosis";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(514, 192);
            button8.Name = "button8";
            button8.Size = new Size(91, 33);
            button8.TabIndex = 9;
            button8.Text = "Investigation";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.Location = new Point(514, 231);
            button9.Name = "button9";
            button9.Size = new Size(91, 32);
            button9.TabIndex = 10;
            button9.Text = "Medication";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button4
            // 
            button4.Location = new Point(13, 151);
            button4.Name = "button4";
            button4.Size = new Size(142, 35);
            button4.TabIndex = 11;
            button4.Text = "Cheif Complaint";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // diagnose
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1132, 661);
            Controls.Add(button4);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(display);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "diagnose";
            Text = "diagnose";
            Load += diagnose_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)display).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView display;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button4;
    }
}