namespace clinic_system
{
    partial class patient_search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(patient_search));
            label1 = new Label();
            patient_num = new TextBox();
            enterbut = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(458, 139);
            label1.Name = "label1";
            label1.Size = new Size(219, 41);
            label1.TabIndex = 16;
            label1.Text = "Patient Search";
            // 
            // patient_num
            // 
            patient_num.Location = new Point(364, 220);
            patient_num.Name = "patient_num";
            patient_num.PlaceholderText = "enter patient's number";
            patient_num.Size = new Size(402, 27);
            patient_num.TabIndex = 17;
            // 
            // enterbut
            // 
            enterbut.Location = new Point(506, 284);
            enterbut.Name = "enterbut";
            enterbut.Size = new Size(94, 29);
            enterbut.TabIndex = 18;
            enterbut.Text = "enter";
            enterbut.UseVisualStyleBackColor = true;
            enterbut.Click += enterbut_Click;
            // 
            // patient_search
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1130, 467);
            Controls.Add(enterbut);
            Controls.Add(patient_num);
            Controls.Add(label1);
            Name = "patient_search";
            Text = "patient_search";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox patient_num;
        private Button enterbut;
    }
}