namespace clinic_system
{
    partial class add_medication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_medication));
            button5 = new Button();
            save = new Button();
            textBox1 = new TextBox();
            Diagnosis = new Label();
            SuspendLayout();
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Location = new Point(25, 27);
            button5.Name = "button5";
            button5.Size = new Size(46, 47);
            button5.TabIndex = 11;
            button5.Text = "\r\n";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // save
            // 
            save.Location = new Point(337, 306);
            save.Name = "save";
            save.Size = new Size(94, 29);
            save.TabIndex = 10;
            save.Text = "save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(186, 142);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(405, 127);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Diagnosis
            // 
            Diagnosis.AutoSize = true;
            Diagnosis.Font = new Font("Segoe UI Historic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Diagnosis.Location = new Point(306, 74);
            Diagnosis.Name = "Diagnosis";
            Diagnosis.Size = new Size(165, 38);
            Diagnosis.TabIndex = 8;
            Diagnosis.Text = "Medication";
            // 
            // add_medication
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(save);
            Controls.Add(textBox1);
            Controls.Add(Diagnosis);
            Name = "add_medication";
            Text = "add_investigation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button5;
        private Button save;
        private TextBox textBox1;
        private Label Diagnosis;
    }
}