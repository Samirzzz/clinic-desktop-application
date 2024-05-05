namespace clinic_system
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
            namelbl = new Label();
            numlbl = new Label();
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
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namelbl.ForeColor = Color.DarkOrange;
            namelbl.Location = new Point(610, 190);
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
            numlbl.Location = new Point(627, 254);
            numlbl.MinimumSize = new Size(50, 30);
            numlbl.Name = "numlbl";
            numlbl.Size = new Size(71, 31);
            numlbl.TabIndex = 5;
            numlbl.Text = "num :";
            // 
            // namebox
            // 
            namebox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namebox.Location = new Point(704, 180);
            namebox.Multiline = true;
            namebox.Name = "namebox";
            namebox.Size = new Size(218, 41);
            namebox.TabIndex = 7;
            // 
            // numbox
            // 
            numbox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numbox.Location = new Point(704, 244);
            numbox.Multiline = true;
            numbox.Name = "numbox";
            numbox.Size = new Size(218, 41);
            numbox.TabIndex = 8;
            numbox.TextChanged += numbox_TextChanged;
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
            Controls.Add(numlbl);
            Controls.Add(namelbl);
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
        private Label namelbl;
        private Label numlbl;
        private TextBox namebox;
        private TextBox numbox;
        private Button backbtn;
    }
}