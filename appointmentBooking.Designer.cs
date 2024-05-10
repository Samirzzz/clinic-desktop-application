namespace clinic_system
{
    partial class appointmentBooking
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            datee = new DateTimePicker();
            button1 = new Button();
            backbtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 22.2F);
            label1.Location = new Point(9, 31);
            label1.Name = "label1";
            label1.Size = new Size(267, 42);
            label1.TabIndex = 0;
            label1.Text = "Patient Number: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 22.2F);
            label2.Location = new Point(8, 96);
            label2.Name = "label2";
            label2.Size = new Size(137, 42);
            label2.TabIndex = 0;
            label2.Text = "Doctor: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 22.2F);
            label3.Location = new Point(8, 173);
            label3.Name = "label3";
            label3.Size = new Size(105, 42);
            label3.TabIndex = 0;
            label3.Text = "Date: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(284, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 27);
            textBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(161, 105);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // datee
            // 
            datee.Location = new Point(129, 184);
            datee.Name = "datee";
            datee.Size = new Size(250, 27);
            datee.TabIndex = 3;
            datee.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(269, 282);
            button1.Name = "button1";
            button1.Size = new Size(256, 29);
            button1.TabIndex = 4;
            button1.Text = "BOOK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // backbtn
            // 
            backbtn.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backbtn.Location = new Point(710, 24);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(64, 46);
            backbtn.TabIndex = 18;
            backbtn.Text = "<--";
            backbtn.UseVisualStyleBackColor = true;
            backbtn.Click += backbtn_Click;
            // 
            // appointmentBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(backbtn);
            Controls.Add(button1);
            Controls.Add(datee);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "appointmentBooking";
            Text = "appointmentBooking";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private DateTimePicker datee;
        private Button button1;
        private Button backbtn;
    }
}