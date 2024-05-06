namespace clinic_system
{
    partial class doctor_registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(doctor_registration));
            label3 = new Label();
            label1 = new Label();
            namelbl = new Label();
            button1 = new Button();
            doctor_number = new TextBox();
            doctor_name = new TextBox();
            num = new Label();
            label2 = new Label();
            doctor_spec = new TextBox();
            label4 = new Label();
            button2 = new Button();
            label5 = new Label();
            checkedListBox1 = new CheckedListBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(421, 44);
            label3.Name = "label3";
            label3.Size = new Size(295, 41);
            label3.TabIndex = 6;
            label3.Text = "Doctor Registration";
            label3.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 211);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 7;
            // 
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.BackColor = Color.Transparent;
            namelbl.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            namelbl.ForeColor = SystemColors.ButtonHighlight;
            namelbl.Location = new Point(309, 206);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(0, 25);
            namelbl.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(388, 519);
            button1.Name = "button1";
            button1.Size = new Size(402, 33);
            button1.TabIndex = 13;
            button1.Text = "save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // doctor_number
            // 
            doctor_number.Location = new Point(388, 236);
            doctor_number.Name = "doctor_number";
            doctor_number.Size = new Size(402, 27);
            doctor_number.TabIndex = 12;
            // 
            // doctor_name
            // 
            doctor_name.Location = new Point(388, 164);
            doctor_name.Name = "doctor_name";
            doctor_name.Size = new Size(402, 27);
            doctor_name.TabIndex = 11;
            // 
            // num
            // 
            num.AutoSize = true;
            num.BackColor = Color.Transparent;
            num.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            num.ForeColor = SystemColors.ButtonHighlight;
            num.Location = new Point(301, 235);
            num.Name = "num";
            num.Size = new Size(81, 25);
            num.TabIndex = 10;
            num.Text = "Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(320, 166);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 9;
            label2.Text = "Name";
            // 
            // doctor_spec
            // 
            doctor_spec.Location = new Point(388, 300);
            doctor_spec.Name = "doctor_spec";
            doctor_spec.Size = new Size(402, 27);
            doctor_spec.TabIndex = 14;
            doctor_spec.TextChanged += doctor_spec_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(259, 300);
            label4.Name = "label4";
            label4.Size = new Size(130, 25);
            label4.TabIndex = 15;
            label4.Text = "Specialization";
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.System;
            button2.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(28, 21);
            button2.Name = "button2";
            button2.Size = new Size(75, 50);
            button2.TabIndex = 16;
            button2.Text = "<-";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(259, 397);
            label5.Name = "label5";
            label5.Size = new Size(200, 31);
            label5.TabIndex = 23;
            label5.Text = "Doctor Workdays";
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = SystemColors.GradientActiveCaption;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday" });
            checkedListBox1.Location = new Point(477, 349);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(137, 136);
            checkedListBox1.TabIndex = 24;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // doctor_registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1165, 607);
            Controls.Add(checkedListBox1);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(doctor_spec);
            Controls.Add(button1);
            Controls.Add(doctor_number);
            Controls.Add(doctor_name);
            Controls.Add(num);
            Controls.Add(label2);
            Controls.Add(namelbl);
            Controls.Add(label1);
            Controls.Add(label3);
            Name = "doctor_registration";
            Text = "doctor_registration";
            Load += doctor_registration_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label1;
        private Label namelbl;
        private Button button1;
        private TextBox doctor_number;
        private TextBox doctor_name;
        private Label num;
        private Label label2;
        private TextBox doctor_spec;
        private Label label4;
        private Button button2;
        private Label label5;
        private CheckedListBox checkedListBox1;
    }
}