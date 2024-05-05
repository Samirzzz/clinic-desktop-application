namespace clinic_system
{
    partial class searchPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchPatient));
            label1 = new Label();
            Name_label = new Label();
            Name_textbox = new TextBox();
            Number_textbox = new TextBox();
            numberlabel = new Label();
            searchbutton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(363, 93);
            label1.Name = "label1";
            label1.Size = new Size(462, 51);
            label1.TabIndex = 0;
            label1.Text = "Enter Patient Details";
            label1.Click += label1_Click;
            // 
            // Name_label
            // 
            Name_label.AutoSize = true;
            Name_label.BackColor = Color.Transparent;
            Name_label.Font = new Font("Arial Rounded MT Bold", 15.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name_label.ForeColor = Color.White;
            Name_label.Location = new Point(247, 197);
            Name_label.Name = "Name_label";
            Name_label.Size = new Size(91, 32);
            Name_label.TabIndex = 1;
            Name_label.Text = "Name";
            // 
            // Name_textbox
            // 
            Name_textbox.Location = new Point(398, 202);
            Name_textbox.Name = "Name_textbox";
            Name_textbox.Size = new Size(398, 27);
            Name_textbox.TabIndex = 2;
            Name_textbox.TextChanged += Name_textbox_TextChanged;
            // 
            // Number_textbox
            // 
            Number_textbox.Location = new Point(398, 283);
            Number_textbox.Name = "Number_textbox";
            Number_textbox.Size = new Size(398, 27);
            Number_textbox.TabIndex = 3;
            Number_textbox.TextChanged += textBox1_TextChanged;
            // 
            // numberlabel
            // 
            numberlabel.AutoSize = true;
            numberlabel.BackColor = Color.Transparent;
            numberlabel.Font = new Font("Arial Rounded MT Bold", 15.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numberlabel.ForeColor = Color.White;
            numberlabel.Location = new Point(247, 277);
            numberlabel.Name = "numberlabel";
            numberlabel.Size = new Size(120, 32);
            numberlabel.TabIndex = 4;
            numberlabel.Text = "Number";
            // 
            // searchbutton
            // 
            searchbutton.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchbutton.Location = new Point(506, 365);
            searchbutton.Name = "searchbutton";
            searchbutton.Size = new Size(154, 44);
            searchbutton.TabIndex = 5;
            searchbutton.Text = "Search";
            searchbutton.UseVisualStyleBackColor = true;
            searchbutton.Click += searchbutton_Click;
            // 
            // searchPatient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1110, 554);
            Controls.Add(searchbutton);
            Controls.Add(numberlabel);
            Controls.Add(Number_textbox);
            Controls.Add(Name_textbox);
            Controls.Add(Name_label);
            Controls.Add(label1);
            Name = "searchPatient";
            Text = "searchPatient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label Name_label;
        private TextBox Name_textbox;
        private TextBox Number_textbox;
        private Label numberlabel;
        private Button searchbutton;
    }
}