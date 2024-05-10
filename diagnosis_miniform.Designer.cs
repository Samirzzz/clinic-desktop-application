namespace clinic_system
{
    partial class diagnosis_miniform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(diagnosis_miniform));
            Diagnosis = new Label();
            textBox1 = new TextBox();
            save = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // Diagnosis
            // 
            Diagnosis.AutoSize = true;
            Diagnosis.Font = new Font("Segoe UI Historic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Diagnosis.Location = new Point(231, 25);
            Diagnosis.Name = "Diagnosis";
            Diagnosis.Size = new Size(146, 38);
            Diagnosis.TabIndex = 0;
            Diagnosis.Text = "Diagnosis";
            Diagnosis.Click += Diagnosis_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 113);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(405, 127);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // save
            // 
            save.Location = new Point(270, 265);
            save.Name = "save";
            save.Size = new Size(94, 29);
            save.TabIndex = 2;
            save.Text = "save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Location = new Point(21, 16);
            button5.Name = "button5";
            button5.Size = new Size(46, 47);
            button5.TabIndex = 7;
            button5.Text = "\r\n";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // diagnosis_miniform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 365);
            Controls.Add(button5);
            Controls.Add(save);
            Controls.Add(textBox1);
            Controls.Add(Diagnosis);
            Name = "diagnosis_miniform";
            Text = "diagnosis_miniform";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Diagnosis;
        private TextBox textBox1;
        private Button save;
        private Button button5;
    }
}