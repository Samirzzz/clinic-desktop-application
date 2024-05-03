namespace clinic_system
{
    partial class diagnosis
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
            patient_name = new Label();
            doc_name = new Label();
            diag = new Label();
            SuspendLayout();
            // 
            // patient_name
            // 
            patient_name.AutoSize = true;
            patient_name.BackColor = Color.Transparent;
            patient_name.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            patient_name.ForeColor = SystemColors.ActiveCaptionText;
            patient_name.Location = new Point(46, 55);
            patient_name.Name = "patient_name";
            patient_name.Size = new Size(113, 31);
            patient_name.TabIndex = 0;
            patient_name.Text = "Welcome";
            patient_name.Click += patient_name_Click;
            // 
            // doc_name
            // 
            doc_name.AutoSize = true;
            doc_name.Location = new Point(73, 117);
            doc_name.Name = "doc_name";
            doc_name.Size = new Size(50, 20);
            doc_name.TabIndex = 1;
            doc_name.Text = "label1";
            // 
            // diag
            // 
            diag.AutoSize = true;
            diag.Location = new Point(216, 75);
            diag.Name = "diag";
            diag.Size = new Size(50, 20);
            diag.TabIndex = 2;
            diag.Text = "label1";
            // 
            // diagnosis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1077, 470);
            Controls.Add(diag);
            Controls.Add(doc_name);
            Controls.Add(patient_name);
            Name = "diagnosis";
            Text = "diagnosis";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label patient_name;
        private Label doc_name;
        private Label diag;
    }
}