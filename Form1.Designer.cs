namespace clinic_system
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            namelbl = new Label();
            num = new Label();
            patient_name = new TextBox();
            patient_number = new TextBox();
            button1 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.BackColor = Color.Transparent;
            namelbl.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            namelbl.Location = new Point(321, 157);
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
            num.Location = new Point(302, 226);
            num.Name = "num";
            num.Size = new Size(81, 25);
            num.TabIndex = 1;
            num.Text = "Number";
            // 
            // patient_name
            // 
            patient_name.Location = new Point(389, 155);
            patient_name.Name = "patient_name";
            patient_name.Size = new Size(402, 27);
            patient_name.TabIndex = 2;
            patient_name.TextChanged += textBox1_TextChanged;
            // 
            // patient_number
            // 
            patient_number.Location = new Point(389, 227);
            patient_number.Name = "patient_number";
            patient_number.Size = new Size(402, 27);
            patient_number.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(513, 297);
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
            label3.Location = new Point(436, 38);
            label3.Name = "label3";
            label3.Size = new Size(299, 41);
            label3.TabIndex = 5;
            label3.Text = "Patient Registration";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1121, 450);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(patient_number);
            Controls.Add(patient_name);
            Controls.Add(num);
            Controls.Add(namelbl);
            Name = "Form1";
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
    }
}
