namespace clinic_system
{
    partial class loginDoctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginDoctor));
            label1 = new Label();
            txtnumber = new TextBox();
            label2 = new Label();
            txtpassword = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 74);
            label1.Name = "label1";
            label1.Size = new Size(247, 41);
            label1.TabIndex = 0;
            label1.Text = "Doctor Number:\r\n";
            label1.Click += label1_Click;
            // 
            // txtnumber
            // 
            txtnumber.Location = new Point(284, 88);
            txtnumber.Name = "txtnumber";
            txtnumber.Size = new Size(289, 27);
            txtnumber.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 160);
            label2.Name = "label2";
            label2.Size = new Size(192, 41);
            label2.TabIndex = 0;
            label2.Text = "PASSWORD:";
            label2.Click += label1_Click;
            // 
            // txtpassword
            // 
            txtpassword.Location = new Point(284, 174);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(289, 27);
            txtpassword.TabIndex = 1;
            txtpassword.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.Location = new Point(284, 287);
            button1.Name = "button1";
            button1.Size = new Size(289, 29);
            button1.TabIndex = 2;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(284, 346);
            button2.Name = "button2";
            button2.Size = new Size(289, 29);
            button2.TabIndex = 3;
            button2.Text = "CLEAR";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.System;
            button3.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(713, 33);
            button3.Name = "button3";
            button3.Size = new Size(75, 50);
            button3.TabIndex = 22;
            button3.Text = "<-";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // loginDoctor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(814, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtpassword);
            Controls.Add(label2);
            Controls.Add(txtnumber);
            Controls.Add(label1);
            Name = "loginDoctor";
            Text = "loginDoctor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtnumber;
        private Label label2;
        private TextBox txtpassword;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}