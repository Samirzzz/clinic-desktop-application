﻿namespace clinic_system
{
    partial class viewPatients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewPatients));
            dataGridView1 = new DataGridView();
            savebtn = new Button();
            deletebtn = new Button();
            idlbl = new Label();
            namelbl = new Label();
            numlbl = new Label();
            idbox = new TextBox();
            namebox = new TextBox();
            numbox = new TextBox();
            backbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // savebtn
            // 
            savebtn.BackColor = Color.Chartreuse;
            savebtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            savebtn.Location = new Point(519, 360);
            savebtn.Name = "savebtn";
            savebtn.Size = new Size(201, 64);
            savebtn.TabIndex = 1;
            savebtn.Text = "save";
            savebtn.UseVisualStyleBackColor = false;
            savebtn.Click += savebtn_Click;
            // 
            // deletebtn
            // 
            deletebtn.BackColor = Color.Red;
            deletebtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deletebtn.Location = new Point(799, 363);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(201, 61);
            deletebtn.TabIndex = 2;
            deletebtn.Text = "delete";
            deletebtn.UseVisualStyleBackColor = false;
            deletebtn.Click += deletebtn_Click;
            // 
            // idlbl
            // 
            idlbl.AutoSize = true;
            idlbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idlbl.ForeColor = Color.DarkOrange;
            idlbl.Location = new Point(606, 100);
            idlbl.MinimumSize = new Size(50, 30);
            idlbl.Name = "idlbl";
            idlbl.Size = new Size(53, 31);
            idlbl.TabIndex = 3;
            idlbl.Text = "ID : ";
            idlbl.Click += label1_Click;
            // 
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namelbl.ForeColor = Color.DarkOrange;
            namelbl.Location = new Point(571, 161);
            namelbl.MinimumSize = new Size(50, 30);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(88, 31);
            namelbl.TabIndex = 4;
            namelbl.Text = "name : ";
            // 
            // numlbl
            // 
            numlbl.AutoSize = true;
            numlbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numlbl.ForeColor = Color.DarkOrange;
            numlbl.Location = new Point(588, 238);
            numlbl.MinimumSize = new Size(50, 30);
            numlbl.Name = "numlbl";
            numlbl.Size = new Size(71, 31);
            numlbl.TabIndex = 5;
            numlbl.Text = "num :";
            // 
            // idbox
            // 
            idbox.Location = new Point(665, 100);
            idbox.Multiline = true;
            idbox.Name = "idbox";
            idbox.Size = new Size(218, 41);
            idbox.TabIndex = 6;
            // 
            // namebox
            // 
            namebox.Location = new Point(665, 161);
            namebox.Multiline = true;
            namebox.Name = "namebox";
            namebox.Size = new Size(218, 41);
            namebox.TabIndex = 7;
            // 
            // numbox
            // 
            numbox.Location = new Point(665, 238);
            numbox.Multiline = true;
            numbox.Name = "numbox";
            numbox.Size = new Size(218, 41);
            numbox.TabIndex = 8;
            // 
            // backbtn
            // 
            backbtn.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backbtn.Location = new Point(1002, 12);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(64, 46);
            backbtn.TabIndex = 9;
            backbtn.Text = "<--";
            backbtn.UseVisualStyleBackColor = true;
            backbtn.Click += backbtn_Click;
            // 
            // viewPatients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1078, 527);
            Controls.Add(backbtn);
            Controls.Add(numbox);
            Controls.Add(namebox);
            Controls.Add(idbox);
            Controls.Add(numlbl);
            Controls.Add(namelbl);
            Controls.Add(idlbl);
            Controls.Add(deletebtn);
            Controls.Add(savebtn);
            Controls.Add(dataGridView1);
            Name = "viewPatients";
            Text = "Form2";
            Load += viewPatients_Load;
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
        private Button backbtn;
    }
}