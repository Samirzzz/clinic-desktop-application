namespace clinic_system
{
    partial class doctor_search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(doctor_search));
            label1 = new Label();
            doctor_num = new TextBox();
            enterbut = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(458, 92);
            label1.Name = "label1";
            label1.Size = new Size(215, 41);
            label1.TabIndex = 15;
            label1.Text = "Doctor Search";
            // 
            // doctor_num
            // 
            doctor_num.Location = new Point(366, 167);
            doctor_num.Name = "doctor_num";
            doctor_num.PlaceholderText = "enter doctor's number";
            doctor_num.Size = new Size(402, 27);
            doctor_num.TabIndex = 14;
            doctor_num.TextChanged += doctor_num_TextChanged;
            // 
            // enterbut
            // 
            enterbut.Location = new Point(518, 224);
            enterbut.Name = "enterbut";
            enterbut.Size = new Size(94, 29);
            enterbut.TabIndex = 16;
            enterbut.Text = "enter";
            enterbut.UseVisualStyleBackColor = true;
            enterbut.Click += enterbut_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.System;
            button2.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(63, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 50);
            button2.TabIndex = 20;
            button2.Text = "<-";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // doctor_search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1122, 490);
            Controls.Add(button2);
            Controls.Add(enterbut);
            Controls.Add(label1);
            Controls.Add(doctor_num);
            Name = "doctor_search";
            Text = "doctors_search";
            Load += doctor_search_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox doctor_num;
        private Button enterbut;
        private Button button2;
    }
}