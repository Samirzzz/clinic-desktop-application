﻿namespace clinic_system
{
    partial class treatment
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
            save = new Button();
            Diagnosis = new Label();
            comboBox1 = new ComboBox();
            panel1 = new Panel();
            customtreatment = new TextBox();
            customsave = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // save
            // 
            save.Location = new Point(40, 440);
            save.Name = "save";
            save.Size = new Size(94, 29);
            save.TabIndex = 5;
            save.Text = "save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // Diagnosis
            // 
            Diagnosis.AutoSize = true;
            Diagnosis.Font = new Font("Segoe UI Historic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Diagnosis.Location = new Point(40, 30);
            Diagnosis.Name = "Diagnosis";
            Diagnosis.Size = new Size(153, 38);
            Diagnosis.TabIndex = 3;
            Diagnosis.Text = "Treatment";
            Diagnosis.Click += Diagnosis_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(865, 95);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Location = new Point(40, 95);
            panel1.Name = "panel1";
            panel1.Size = new Size(771, 323);
            panel1.TabIndex = 7;
            // 
            // customtreatment
            // 
            customtreatment.Location = new Point(846, 255);
            customtreatment.Multiline = true;
            customtreatment.Name = "customtreatment";
            customtreatment.Size = new Size(222, 129);
            customtreatment.TabIndex = 8;
            // 
            // customsave
            // 
            customsave.Location = new Point(850, 407);
            customsave.Name = "customsave";
            customsave.Size = new Size(94, 29);
            customsave.TabIndex = 9;
            customsave.Text = "save";
            customsave.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(850, 226);
            label1.Name = "label1";
            label1.Size = new Size(166, 17);
            label1.TabIndex = 10;
            label1.Text = "Enter treatment manually";
            label1.Click += label1_Click;
            // 
            // treatment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 496);
            Controls.Add(label1);
            Controls.Add(customsave);
            Controls.Add(customtreatment);
            Controls.Add(panel1);
            Controls.Add(comboBox1);
            Controls.Add(save);
            Controls.Add(Diagnosis);
            Name = "treatment";
            Text = "treatment";
            Load += treatment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button save;
        private Label Diagnosis;
        private ComboBox comboBox1;
        private Panel panel1;
        private TextBox customtreatment;
        private Button customsave;
        private Label label1;
    }
}