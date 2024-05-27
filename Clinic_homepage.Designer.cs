
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
            searchPatient = new Button();
            SearchDoctor = new Button();
            rudpatientbtn = new Button();
            doctorRUD = new Button();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // AddPatient
            // 
            AddPatient.BackColor = Color.Chartreuse;
            AddPatient.FlatAppearance.BorderColor = Color.Black;
            AddPatient.FlatAppearance.MouseDownBackColor = Color.Black;
            AddPatient.FlatStyle = FlatStyle.Flat;
            AddPatient.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddPatient.Location = new Point(117, 162);
            AddPatient.Name = "AddPatient";
            AddPatient.Size = new Size(257, 53);
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
            AddDoctor.Location = new Point(652, 150);
            AddDoctor.Name = "AddDoctor";
            AddDoctor.Size = new Size(257, 53);
            AddDoctor.TabIndex = 2;
            AddDoctor.Text = "Add Doctor";
            AddDoctor.UseVisualStyleBackColor = false;
            AddDoctor.Click += AddDoctor_Click;
            // 
            // searchPatient
            // 
            searchPatient.BackColor = Color.Chartreuse;
            searchPatient.FlatAppearance.BorderColor = Color.Black;
            searchPatient.FlatAppearance.MouseDownBackColor = Color.Black;
            searchPatient.FlatStyle = FlatStyle.Flat;
            searchPatient.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchPatient.Location = new Point(117, 261);
            searchPatient.Name = "searchPatient";
            searchPatient.Size = new Size(257, 50);
            searchPatient.TabIndex = 3;
            searchPatient.Text = "search for patient";
            searchPatient.UseVisualStyleBackColor = false;
            searchPatient.Click += searchPatient_Click;
            // 
            // SearchDoctor
            // 
            SearchDoctor.BackColor = Color.Turquoise;
            SearchDoctor.FlatAppearance.BorderColor = Color.Black;
            SearchDoctor.FlatAppearance.MouseDownBackColor = Color.Black;
            SearchDoctor.FlatStyle = FlatStyle.Flat;
            SearchDoctor.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchDoctor.Location = new Point(652, 260);
            SearchDoctor.Name = "SearchDoctor";
            SearchDoctor.Size = new Size(257, 53);
            SearchDoctor.TabIndex = 4;
            SearchDoctor.Text = "Search For Doctor";
            SearchDoctor.UseVisualStyleBackColor = false;
            SearchDoctor.Click += SearchDoctor_Click;
            // 
            // rudpatientbtn
            // 
            rudpatientbtn.BackColor = Color.Chartreuse;
            rudpatientbtn.FlatAppearance.BorderColor = Color.Black;
            rudpatientbtn.FlatAppearance.MouseDownBackColor = Color.Black;
            rudpatientbtn.FlatStyle = FlatStyle.Flat;
            rudpatientbtn.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rudpatientbtn.Location = new Point(117, 376);
            rudpatientbtn.Name = "rudpatientbtn";
            rudpatientbtn.Size = new Size(257, 70);
            rudpatientbtn.TabIndex = 6;
            rudpatientbtn.Text = "Manage Patients";
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
            doctorRUD.Location = new Point(652, 378);
            doctorRUD.Name = "doctorRUD";
            doctorRUD.Size = new Size(257, 67);
            doctorRUD.TabIndex = 7;
            doctorRUD.Text = "Manage Doctors";
            doctorRUD.UseVisualStyleBackColor = false;
            doctorRUD.Click += doctorRUD_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Turquoise;
            button1.Font = new Font("Arial Rounded MT Bold", 13.8F);
            button1.Location = new Point(652, 505);
            button1.Name = "button1";
            button1.Size = new Size(257, 56);
            button1.TabIndex = 8;
            button1.Text = "Book Appointment";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.Turquoise;
            button2.Font = new Font("Arial Rounded MT Bold", 13.8F);
            button2.Location = new Point(781, 702);
            button2.Name = "button2";
            button2.Size = new Size(257, 62);
            button2.TabIndex = 9;
            button2.Text = "view-edit-delete appointments";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(451, 47);
            label1.Name = "label1";
            label1.Size = new Size(208, 57);
            label1.TabIndex = 17;
            label1.Text = "Welcome";
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
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(doctorRUD);
            Controls.Add(rudpatientbtn);
            Controls.Add(SearchDoctor);
            Controls.Add(searchPatient);
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
        private Button searchPatient;
        private Button SearchDoctor;
        private Button rudpatientbtn;
        private Button doctorRUD;
        private Button button1;
        private Button button2;
        protected Label label1;
    }
}