﻿
namespace clinic_system
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            AddPatient = new Button();
            AddDoctor = new Button();
            WelcomeText = new TextBox();
            rudpatientbtn = new Button();
            doctorRUD = new Button();
            button1 = new Button();
            button2 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // AddPatient
            // 
            AddPatient.BackColor = Color.Turquoise;
            AddPatient.FlatAppearance.BorderColor = Color.Black;
            AddPatient.FlatAppearance.MouseDownBackColor = Color.Black;
            AddPatient.FlatStyle = FlatStyle.Flat;
            AddPatient.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddPatient.Location = new Point(778, 173);
            AddPatient.Name = "AddPatient";
            AddPatient.Size = new Size(257, 58);
            AddPatient.TabIndex = 1;
            AddPatient.Text = "Add Patient";
            AddPatient.UseVisualStyleBackColor = false;
            AddPatient.Click += button1_Click;
            // 
            // AddDoctor
            // 
            AddDoctor.BackColor = Color.Turquoise;
            AddDoctor.FlatAppearance.BorderColor = Color.Black;
            AddDoctor.FlatAppearance.MouseDownBackColor = Color.Black;
            AddDoctor.FlatStyle = FlatStyle.Flat;
            AddDoctor.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddDoctor.Location = new Point(778, 346);
            AddDoctor.Name = "AddDoctor";
            AddDoctor.Size = new Size(257, 58);
            AddDoctor.TabIndex = 2;
            AddDoctor.Text = "Add Doctor";
            AddDoctor.UseVisualStyleBackColor = false;
            AddDoctor.Click += AddDoctor_Click;
            // 
            // WelcomeText
            // 
            WelcomeText.BackColor = Color.White;
            WelcomeText.Font = new Font("Arial Black", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            WelcomeText.ForeColor = SystemColors.ActiveCaptionText;
            WelcomeText.Location = new Point(789, 22);
            WelcomeText.Name = "WelcomeText";
            WelcomeText.Size = new Size(218, 64);
            WelcomeText.TabIndex = 5;
            WelcomeText.Text = "Welcome";
            WelcomeText.TextChanged += WelcomeText_TextChanged;
            // 
            // rudpatientbtn
            // 
            rudpatientbtn.BackColor = Color.Turquoise;
            rudpatientbtn.FlatAppearance.BorderColor = Color.Black;
            rudpatientbtn.FlatAppearance.MouseDownBackColor = Color.Black;
            rudpatientbtn.FlatStyle = FlatStyle.Flat;
            rudpatientbtn.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rudpatientbtn.Location = new Point(778, 252);
            rudpatientbtn.Name = "rudpatientbtn";
            rudpatientbtn.Size = new Size(257, 58);
            rudpatientbtn.TabIndex = 6;
            rudpatientbtn.Text = "Manage patients";
            rudpatientbtn.UseVisualStyleBackColor = false;
            rudpatientbtn.Click += rudpatientbtn_Click;
            // 
            // doctorRUD
            // 
            doctorRUD.BackColor = Color.Turquoise;
            doctorRUD.FlatAppearance.BorderColor = Color.Black;
            doctorRUD.FlatAppearance.MouseDownBackColor = Color.Black;
            doctorRUD.FlatStyle = FlatStyle.Flat;
            doctorRUD.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            doctorRUD.Location = new Point(778, 433);
            doctorRUD.Name = "doctorRUD";
            doctorRUD.Size = new Size(257, 58);
            doctorRUD.TabIndex = 7;
            doctorRUD.Text = "Manage doctors\r\n\r\n";
            doctorRUD.UseVisualStyleBackColor = false;
            doctorRUD.Click += doctorRUD_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Turquoise;
            button1.Font = new Font("Arial Rounded MT Bold", 13.8F);
            button1.Location = new Point(778, 524);
            button1.Name = "button1";
            button1.Size = new Size(257, 58);
            button1.TabIndex = 8;
            button1.Text = "Book Appointment";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.Turquoise;
            button2.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(778, 608);
            button2.Name = "button2";
            button2.Size = new Size(257, 58);
            button2.TabIndex = 9;
            button2.Text = "Manage appointments";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Location = new Point(23, 22);
            button5.Name = "button5";
            button5.Size = new Size(46, 47);
            button5.TabIndex = 10;
            button5.Text = "\r\n";
            button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1083, 734);
            Controls.Add(button5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(doctorRUD);
            Controls.Add(rudpatientbtn);
            Controls.Add(WelcomeText);
            Controls.Add(AddDoctor);
            Controls.Add(AddPatient);
            Cursor = Cursors.IBeam;
            Name = "Form1";
            Text = "Homepage";
            ResumeLayout(false);
            PerformLayout();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

#endregion
        private Button AddPatient;
        private Button AddDoctor;
        private TextBox WelcomeText;
        private Button rudpatientbtn;
        private Button doctorRUD;
        private Button button1;
        private Button button2;
        private Button button5;
    }
}