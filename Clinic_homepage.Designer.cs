
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
            pictureBox1 = new PictureBox();
            AddPatient = new Button();
            AddDoctor = new Button();
            searchPatient = new Button();
            SearchDoctor = new Button();
            WelcomeText = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-8, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(757, 809);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // AddPatient
            // 
            AddPatient.FlatAppearance.BorderColor = Color.Black;
            AddPatient.FlatAppearance.MouseDownBackColor = Color.Black;
            AddPatient.FlatStyle = FlatStyle.Flat;
            AddPatient.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddPatient.Location = new Point(800, 133);
            AddPatient.Name = "AddPatient";
            AddPatient.Size = new Size(207, 53);
            AddPatient.TabIndex = 1;
            AddPatient.Text = "Add Patient";
            AddPatient.UseVisualStyleBackColor = true;
            AddPatient.Click += button1_Click;
            // 
            // AddDoctor
            // 
            AddDoctor.FlatAppearance.BorderColor = Color.Black;
            AddDoctor.FlatAppearance.MouseDownBackColor = Color.Black;
            AddDoctor.FlatStyle = FlatStyle.Flat;
            AddDoctor.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddDoctor.Location = new Point(800, 223);
            AddDoctor.Name = "AddDoctor";
            AddDoctor.Size = new Size(207, 53);
            AddDoctor.TabIndex = 2;
            AddDoctor.Text = "Add Doctor";
            AddDoctor.UseVisualStyleBackColor = true;
            AddDoctor.Click += AddDoctor_Click;
            // 
            // searchPatient
            // 
            searchPatient.FlatAppearance.BorderColor = Color.Black;
            searchPatient.FlatAppearance.MouseDownBackColor = Color.Black;
            searchPatient.FlatStyle = FlatStyle.Flat;
            searchPatient.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchPatient.Location = new Point(779, 318);
            searchPatient.Name = "searchPatient";
            searchPatient.Size = new Size(257, 50);
            searchPatient.TabIndex = 3;
            searchPatient.Text = "search for patient";
            searchPatient.UseVisualStyleBackColor = true;
            searchPatient.Click += searchPatient_Click;
            // 
            // SearchDoctor
            // 
            SearchDoctor.FlatAppearance.BorderColor = Color.Black;
            SearchDoctor.FlatAppearance.MouseDownBackColor = Color.Black;
            SearchDoctor.FlatStyle = FlatStyle.Flat;
            SearchDoctor.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchDoctor.Location = new Point(779, 416);
            SearchDoctor.Name = "SearchDoctor";
            SearchDoctor.Size = new Size(257, 53);
            SearchDoctor.TabIndex = 4;
            SearchDoctor.Text = "Search For Doctor";
            SearchDoctor.UseVisualStyleBackColor = true;
            SearchDoctor.Click += SearchDoctor_Click;
            // 
            // WelcomeText
            // 
            WelcomeText.Font = new Font("Arial Black", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            WelcomeText.Location = new Point(789, 22);
            WelcomeText.Name = "WelcomeText";
            WelcomeText.Size = new Size(218, 64);
            WelcomeText.TabIndex = 5;
            WelcomeText.Text = "Welcome";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1069, 680);
            Controls.Add(WelcomeText);
            Controls.Add(SearchDoctor);
            Controls.Add(searchPatient);
            Controls.Add(AddDoctor);
            Controls.Add(AddPatient);
            Controls.Add(pictureBox1);
            Cursor = Cursors.IBeam;
            Name = "Form1";
            Text = "Homepage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button AddPatient;
        private Button AddDoctor;
        private Button searchPatient;
        private Button SearchDoctor;
        private TextBox WelcomeText;
    }
}