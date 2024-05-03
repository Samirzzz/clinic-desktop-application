namespace clinic_system
{
    partial class patient_registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(patient_registration));
            namelbl = new Label();
            num = new Label();
            patient_name = new TextBox();
            patient_number = new TextBox();
            button1 = new Button();
            label3 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.BackColor = Color.Transparent;
            namelbl.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            namelbl.ForeColor = SystemColors.ButtonHighlight;
            namelbl.Location = new Point(327, 185);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(62, 25);
            namelbl.TabIndex = 0;
            namelbl.Text = "Name";
            namelbl.Click += label1_Click;
            // 
            // num
            // 
            num.AutoSize = true;
            num.BackColor = Color.Transparent;
            num.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            num.ForeColor = SystemColors.ButtonHighlight;
            num.Location = new Point(308, 254);
            num.Name = "num";
            num.Size = new Size(81, 25);
            num.TabIndex = 1;
            num.Text = "Number";
            // 
            // patient_name
            // 
            patient_name.Location = new Point(395, 183);
            patient_name.Name = "patient_name";
            patient_name.Size = new Size(402, 27);
            patient_name.TabIndex = 2;
            patient_name.TextChanged += textBox1_TextChanged;
            // 
            // patient_number
            // 
            patient_number.Location = new Point(395, 255);
            patient_number.Name = "patient_number";
            patient_number.Size = new Size(402, 27);
            patient_number.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(511, 366);
            button1.Name = "button1";
            button1.Size = new Size(140, 33);
            button1.TabIndex = 4;
            button1.Text = "save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(436, 38);
            label3.Name = "label3";
            label3.Size = new Size(299, 41);
            label3.TabIndex = 5;
            label3.Text = "Patient Registration";
            label3.Click += label3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.System;
            button2.Font = new Font("Dungeon", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(79, 49);
            button2.Name = "button2";
            button2.Size = new Size(75, 50);
            button2.TabIndex = 20;
            button2.Text = "<-";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // patient_registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1121, 594);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(patient_number);
            Controls.Add(patient_name);
            Controls.Add(num);
            Controls.Add(namelbl);
            Name = "patient_registration";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label namelbl;
        private Label num;
        private TextBox patient_name;
        private TextBox patient_number;
        private Button button1;
        private Label label3;
        private Button button2;
    }
}
