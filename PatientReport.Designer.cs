namespace clinic_system
{
    partial class PatientReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientReport));
            label2 = new Label();
            Name_textbox = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            Report_label = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            textBox3 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBox5 = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            textBox6 = new TextBox();
            comboBox1 = new ComboBox();
            label12 = new Label();
            button5 = new Button();
            header = new Panel();
            controlbox = new Panel();
            close = new Button();
            label13 = new Label();
            comboBox2 = new ComboBox();
            textBox4 = new TextBox();
            comboBox3 = new ComboBox();
            label14 = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            print = new Button();
            comboBox4 = new ComboBox();
            textBox7 = new TextBox();
            header.SuspendLayout();
            controlbox.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(72, 105);
            label2.Name = "label2";
            label2.Size = new Size(146, 23);
            label2.TabIndex = 3;
            label2.Text = "Patient Name:";
            label2.Click += label2_Click;
            // 
            // Name_textbox
            // 
            Name_textbox.Location = new Point(246, 105);
            Name_textbox.Name = "Name_textbox";
            Name_textbox.Size = new Size(360, 27);
            Name_textbox.TabIndex = 4;
            Name_textbox.TextChanged += Name_textbox_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(246, 149);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(360, 27);
            textBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(72, 150);
            label1.Name = "label1";
            label1.Size = new Size(168, 23);
            label1.TabIndex = 5;
            label1.Text = "Patient Number:";
            label1.Click += label1_Click_1;
            // 
            // Report_label
            // 
            Report_label.AutoSize = true;
            Report_label.Font = new Font("Calibri", 25.8000011F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            Report_label.Location = new Point(275, 30);
            Report_label.Name = "Report_label";
            Report_label.Size = new Size(143, 54);
            Report_label.TabIndex = 7;
            Report_label.Text = "Report";
            Report_label.Click += Report_label_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(111, 180);
            label3.Name = "label3";
            label3.Size = new Size(495, 20);
            label3.TabIndex = 8;
            label3.Text = "_________________________________________________________________________________";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label4.Location = new Point(72, 215);
            label4.Name = "label4";
            label4.Size = new Size(171, 23);
            label4.TabIndex = 9;
            label4.Text = "Cheif Complaint:";
            label4.Click += label4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(122, 254);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(484, 184);
            textBox2.TabIndex = 10;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 438);
            label5.Name = "label5";
            label5.Size = new Size(675, 20);
            label5.TabIndex = 11;
            label5.Text = "_______________________________________________________________________________________________________________";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label6.Location = new Point(44, 458);
            label6.Name = "label6";
            label6.Size = new Size(141, 23);
            label6.TabIndex = 12;
            label6.Text = "Investigation:";
            label6.Click += label6_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(180, 505);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(484, 27);
            textBox3.TabIndex = 13;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 628);
            label7.Name = "label7";
            label7.Size = new Size(675, 20);
            label7.TabIndex = 15;
            label7.Text = "_______________________________________________________________________________________________________________";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label8.Location = new Point(55, 659);
            label8.Name = "label8";
            label8.Size = new Size(119, 23);
            label8.TabIndex = 16;
            label8.Text = "Diagnoses:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(180, 696);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.ScrollBars = ScrollBars.Vertical;
            textBox5.Size = new Size(484, 88);
            textBox5.TabIndex = 17;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 787);
            label9.Name = "label9";
            label9.Size = new Size(675, 20);
            label9.TabIndex = 18;
            label9.Text = "_______________________________________________________________________________________________________________";
            label9.Click += label9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label10.Location = new Point(40, 807);
            label10.Name = "label10";
            label10.Size = new Size(134, 23);
            label10.TabIndex = 19;
            label10.Text = "Medications:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label11.Location = new Point(40, 914);
            label11.Name = "label11";
            label11.Size = new Size(145, 23);
            label11.TabIndex = 20;
            label11.Text = "Doctor Name:";
            label11.Click += label11_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(180, 843);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(484, 56);
            textBox6.TabIndex = 21;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(72, 696);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(85, 28);
            comboBox1.TabIndex = 22;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label12.Location = new Point(29, 696);
            label12.Name = "label12";
            label12.Size = new Size(37, 23);
            label12.TabIndex = 23;
            label12.Text = "ID:";
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Location = new Point(0, 0);
            button5.Name = "button5";
            button5.Size = new Size(46, 47);
            button5.TabIndex = 24;
            button5.Text = "\r\n";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // header
            // 
            header.AutoScroll = true;
            header.BackColor = SystemColors.ActiveCaption;
            header.Controls.Add(controlbox);
            header.Controls.Add(button5);
            header.Location = new Point(0, -4);
            header.Name = "header";
            header.Size = new Size(761, 46);
            header.TabIndex = 25;
            header.Paint += header_Paint;
            // 
            // controlbox
            // 
            controlbox.BackColor = SystemColors.ActiveCaption;
            controlbox.Controls.Add(close);
            controlbox.Dock = DockStyle.Right;
            controlbox.Location = new Point(662, 0);
            controlbox.Name = "controlbox";
            controlbox.Size = new Size(78, 47);
            controlbox.TabIndex = 25;
            // 
            // close
            // 
            close.BackColor = SystemColors.ActiveBorder;
            close.BackgroundImage = (Image)resources.GetObject("close.BackgroundImage");
            close.BackgroundImageLayout = ImageLayout.Stretch;
            close.Location = new Point(22, 7);
            close.Name = "close";
            close.Size = new Size(38, 33);
            close.TabIndex = 0;
            close.UseVisualStyleBackColor = false;
            close.Click += close_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label13.Location = new Point(29, 505);
            label13.Name = "label13";
            label13.Size = new Size(37, 23);
            label13.TabIndex = 26;
            label13.Text = "ID:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(72, 505);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(85, 28);
            comboBox2.TabIndex = 27;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(191, 914);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(227, 27);
            textBox4.TabIndex = 29;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(72, 843);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(85, 28);
            comboBox3.TabIndex = 30;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label14.Location = new Point(29, 843);
            label14.Name = "label14";
            label14.Size = new Size(37, 23);
            label14.TabIndex = 31;
            label14.Text = "ID:";
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // print
            // 
            print.Location = new Point(582, 913);
            print.Name = "print";
            print.Size = new Size(94, 29);
            print.TabIndex = 32;
            print.Text = "print";
            print.UseVisualStyleBackColor = true;
            print.Click += print_Click;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(72, 550);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(85, 28);
            comboBox4.TabIndex = 33;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(180, 551);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(484, 27);
            textBox7.TabIndex = 34;
            // 
            // PatientReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(728, 960);
            Controls.Add(textBox7);
            Controls.Add(comboBox4);
            Controls.Add(print);
            Controls.Add(label14);
            Controls.Add(comboBox3);
            Controls.Add(textBox4);
            Controls.Add(comboBox2);
            Controls.Add(label13);
            Controls.Add(header);
            Controls.Add(label12);
            Controls.Add(comboBox1);
            Controls.Add(textBox6);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(textBox5);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Report_label);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(Name_textbox);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            MinimizeBox = false;
            Name = "PatientReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PatientReport";
            Load += PatientReport_Load;
            header.ResumeLayout(false);
            controlbox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox Name_textbox;
        private TextBox textBox1;
        private Label label1;
        private Label Report_label;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private Label label6;
        private TextBox textBox3;
        private Label label7;
        private Label label8;
        private TextBox textBox5;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox textBox6;
        private ComboBox comboBox1;
        private Label label12;
        private Button button5;
        private Panel header;
        private Panel controlbox;
        private Button close;
        private Label label13;
        private ComboBox comboBox2;
        private TextBox textBox4;
        private ComboBox comboBox3;
        private Label label14;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private Button print;
        private ComboBox comboBox4;
        private TextBox textBox7;
    }
}