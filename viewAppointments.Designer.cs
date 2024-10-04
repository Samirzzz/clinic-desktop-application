namespace clinic_system
{
    partial class viewAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewAppointments));
            backbtn = new Button();
            PnumBox = new TextBox();
            dnumBox = new TextBox();
            numlbl = new Label();
            namelbl = new Label();
            deletebtn = new Button();
            savebtn = new Button();
            dataGridView1 = new DataGridView();
            Datebox = new TextBox();
            label1 = new Label();
            appointbox = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // backbtn
            // 
            backbtn.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backbtn.Location = new Point(954, 22);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(64, 46);
            backbtn.TabIndex = 17;
            backbtn.Text = "<--";
            backbtn.UseVisualStyleBackColor = true;
            backbtn.Click += backbtn_Click;
            // 
            // PnumBox
            // 
            PnumBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PnumBox.Location = new Point(730, 209);
            PnumBox.Multiline = true;
            PnumBox.Name = "PnumBox";
            PnumBox.Size = new Size(218, 41);
            PnumBox.TabIndex = 16;
            // 
            // dnumBox
            // 
            dnumBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dnumBox.Location = new Point(730, 145);
            dnumBox.Multiline = true;
            dnumBox.Name = "dnumBox";
            dnumBox.Size = new Size(218, 41);
            dnumBox.TabIndex = 15;
            // 
            // numlbl
            // 
            numlbl.AutoSize = true;
            numlbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numlbl.ForeColor = Color.DarkOrange;
            numlbl.Location = new Point(545, 211);
            numlbl.MinimumSize = new Size(50, 30);
            numlbl.Name = "numlbl";
            numlbl.Size = new Size(180, 31);
            numlbl.TabIndex = 14;
            numlbl.Text = "Patient Number:";
            // 
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namelbl.ForeColor = Color.DarkOrange;
            namelbl.Location = new Point(543, 152);
            namelbl.MinimumSize = new Size(50, 30);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(178, 31);
            namelbl.TabIndex = 13;
            namelbl.Text = "Doctor Number:";
            // 
            // deletebtn
            // 
            deletebtn.BackColor = Color.Red;
            deletebtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deletebtn.Location = new Point(825, 328);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(201, 61);
            deletebtn.TabIndex = 12;
            deletebtn.Text = "delete";
            deletebtn.UseVisualStyleBackColor = false;
            deletebtn.Click += deletebtn_Click;
            // 
            // savebtn
            // 
            savebtn.BackColor = Color.Chartreuse;
            savebtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            savebtn.Location = new Point(545, 325);
            savebtn.Name = "savebtn";
            savebtn.Size = new Size(201, 64);
            savebtn.TabIndex = 11;
            savebtn.Text = "save";
            savebtn.UseVisualStyleBackColor = false;
            savebtn.Click += savebtn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(474, 485);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Datebox
            // 
            Datebox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Datebox.Location = new Point(730, 278);
            Datebox.Multiline = true;
            Datebox.Name = "Datebox";
            Datebox.Size = new Size(218, 41);
            Datebox.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(580, 281);
            label1.MinimumSize = new Size(50, 30);
            label1.Name = "label1";
            label1.Size = new Size(79, 31);
            label1.TabIndex = 18;
            label1.Text = "Date:  ";
            // 
            // appointbox
            // 
            appointbox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            appointbox.Location = new Point(730, 84);
            appointbox.Multiline = true;
            appointbox.Name = "appointbox";
            appointbox.Size = new Size(218, 41);
            appointbox.TabIndex = 21;
            appointbox.TextChanged += appointbox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkOrange;
            label2.Location = new Point(543, 91);
            label2.MinimumSize = new Size(50, 30);
            label2.Name = "label2";
            label2.Size = new Size(183, 31);
            label2.TabIndex = 20;
            label2.Text = "Appointment ID:";
            // 
            // viewAppointments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1030, 517);
            Controls.Add(appointbox);
            Controls.Add(label2);
            Controls.Add(Datebox);
            Controls.Add(label1);
            Controls.Add(backbtn);
            Controls.Add(PnumBox);
            Controls.Add(dnumBox);
            Controls.Add(numlbl);
            Controls.Add(namelbl);
            Controls.Add(deletebtn);
            Controls.Add(savebtn);
            Controls.Add(dataGridView1);
            Name = "viewAppointments";
            Text = "viewAppointments";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backbtn;
        private TextBox PnumBox;
        private TextBox dnumBox;
        private Label numlbl;
        private Label namelbl;
        private Button deletebtn;
        private Button savebtn;
        private DataGridView dataGridView1;
        private TextBox Datebox;
        private Label label1;
        private TextBox appointbox;
        private Label label2;
    }
}