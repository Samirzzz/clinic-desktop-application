﻿namespace clinic_system
{
    partial class viewDoctors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewDoctors));
            dataGridView1 = new DataGridView();
            savebtn = new Button();
            deletebtn = new Button();
            idlbl = new Label();
            namelbl = new Label();
            numlbl = new Label();
            idbox = new TextBox();
            namebox = new TextBox();
            numbox = new TextBox();
            speclbl = new Label();
            specbox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(285, 9);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(554, 565);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // savebtn
            // 
            savebtn.BackColor = Color.Chartreuse;
            savebtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            savebtn.Location = new Point(873, 198);
            savebtn.Name = "savebtn";
            savebtn.Size = new Size(201, 64);
            savebtn.TabIndex = 1;
            savebtn.Text = "Save";
            savebtn.UseVisualStyleBackColor = false;
            savebtn.Click += savebtn_Click;
            // 
            // deletebtn
            // 
            deletebtn.BackColor = Color.Red;
            deletebtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deletebtn.Location = new Point(873, 349);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(201, 61);
            deletebtn.TabIndex = 2;
            deletebtn.Text = "Delete";
            deletebtn.UseVisualStyleBackColor = false;
            deletebtn.Click += deletebtn_Click;
            // 
            // idlbl
            // 
            idlbl.AutoSize = true;
            idlbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idlbl.ForeColor = Color.DarkOrange;
            idlbl.Location = new Point(-1, 68);
            idlbl.MinimumSize = new Size(50, 30);
            idlbl.Name = "idlbl";
            idlbl.Size = new Size(53, 31);
            idlbl.TabIndex = 3;
            idlbl.Text = "ID : ";
            // 
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namelbl.ForeColor = Color.DarkOrange;
            namelbl.Location = new Point(-1, 174);
            namelbl.MinimumSize = new Size(50, 30);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(92, 31);
            namelbl.TabIndex = 4;
            namelbl.Text = "Name : ";
            namelbl.Click += namelbl_Click;
            // 
            // numlbl
            // 
            numlbl.AutoSize = true;
            numlbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numlbl.ForeColor = Color.DarkOrange;
            numlbl.Location = new Point(-1, 286);
            numlbl.MinimumSize = new Size(50, 30);
            numlbl.Name = "numlbl";
            numlbl.Size = new Size(75, 31);
            numlbl.TabIndex = 5;
            numlbl.Text = "Num :";
            // 
            // idbox
            // 
            idbox.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idbox.Location = new Point(-1, 102);
            idbox.Multiline = true;
            idbox.Name = "idbox";
            idbox.Size = new Size(218, 41);
            idbox.TabIndex = 6;
            // 
            // namebox
            // 
            namebox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namebox.Location = new Point(-1, 208);
            namebox.Multiline = true;
            namebox.Name = "namebox";
            namebox.Size = new Size(218, 41);
            namebox.TabIndex = 7;
            // 
            // numbox
            // 
            numbox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numbox.Location = new Point(-1, 320);
            numbox.Multiline = true;
            numbox.Name = "numbox";
            numbox.Size = new Size(218, 41);
            numbox.TabIndex = 8;
            // 
            // speclbl
            // 
            speclbl.AutoSize = true;
            speclbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            speclbl.ForeColor = Color.DarkOrange;
            speclbl.Location = new Point(-1, 399);
            speclbl.MinimumSize = new Size(50, 30);
            speclbl.Name = "speclbl";
            speclbl.Size = new Size(166, 31);
            speclbl.TabIndex = 9;
            speclbl.Text = "Specialization :";
            speclbl.Click += speclbl_Click;
            // 
            // specbox
            // 
            specbox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            specbox.Location = new Point(-1, 433);
            specbox.Multiline = true;
            specbox.Name = "specbox";
            specbox.Size = new Size(218, 41);
            specbox.TabIndex = 10;
            // 
            // viewDoctors
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1099, 594);
            Controls.Add(specbox);
            Controls.Add(speclbl);
            Controls.Add(numbox);
            Controls.Add(namebox);
            Controls.Add(idbox);
            Controls.Add(numlbl);
            Controls.Add(namelbl);
            Controls.Add(idlbl);
            Controls.Add(deletebtn);
            Controls.Add(savebtn);
            Controls.Add(dataGridView1);
            Name = "viewDoctors";
            Text = "View Doctors";
            Load += viewDoctors_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private DataGridView dataGridView1;
        private Button savebtn;
        private Button deletebtn;
        private Label idlbl;
        private Label namelbl;
        private Label numlbl;
        private TextBox idbox;
        private TextBox namebox;
        private TextBox numbox;
        private Label speclbl;
        private TextBox specbox;
    }
}
