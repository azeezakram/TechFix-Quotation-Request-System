namespace TechfixClientApp
{
    partial class TechFixHomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TechFixHomePage));
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ordersBtn = new System.Windows.Forms.Button();
            this.quotationsBtn = new System.Windows.Forms.Button();
            this.quotationRequestBtn = new System.Windows.Forms.Button();
            this.supplierManagementBtn = new System.Windows.Forms.Button();
            this.staffManagementBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.supplierManagementBtn);
            this.panel1.Controls.Add(this.staffManagementBtn);
            this.panel1.Controls.Add(this.logoutBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ordersBtn);
            this.panel1.Controls.Add(this.quotationsBtn);
            this.panel1.Controls.Add(this.quotationRequestBtn);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 868);
            this.panel1.TabIndex = 0;
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.Transparent;
            this.logoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.logoutBtn.Location = new System.Drawing.Point(32, 766);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(110, 45);
            this.logoutBtn.TabIndex = 27;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 36);
            this.label2.TabIndex = 26;
            this.label2.Text = "TechFix Dashboard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(340, 841);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Design and Developed by Azeez";
            // 
            // ordersBtn
            // 
            this.ordersBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ordersBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ordersBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordersBtn.ForeColor = System.Drawing.Color.White;
            this.ordersBtn.Location = new System.Drawing.Point(258, 422);
            this.ordersBtn.Name = "ordersBtn";
            this.ordersBtn.Size = new System.Drawing.Size(331, 68);
            this.ordersBtn.TabIndex = 4;
            this.ordersBtn.Text = "Orders";
            this.ordersBtn.UseVisualStyleBackColor = false;
            this.ordersBtn.Click += new System.EventHandler(this.ordersBtn_Click);
            // 
            // quotationsBtn
            // 
            this.quotationsBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.quotationsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quotationsBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quotationsBtn.ForeColor = System.Drawing.Color.White;
            this.quotationsBtn.Location = new System.Drawing.Point(258, 320);
            this.quotationsBtn.Name = "quotationsBtn";
            this.quotationsBtn.Size = new System.Drawing.Size(331, 68);
            this.quotationsBtn.TabIndex = 3;
            this.quotationsBtn.Text = "Quotations";
            this.quotationsBtn.UseVisualStyleBackColor = false;
            this.quotationsBtn.Click += new System.EventHandler(this.quotationsBtn_Click);
            // 
            // quotationRequestBtn
            // 
            this.quotationRequestBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.quotationRequestBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quotationRequestBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quotationRequestBtn.ForeColor = System.Drawing.Color.White;
            this.quotationRequestBtn.Location = new System.Drawing.Point(258, 221);
            this.quotationRequestBtn.Name = "quotationRequestBtn";
            this.quotationRequestBtn.Size = new System.Drawing.Size(331, 68);
            this.quotationRequestBtn.TabIndex = 2;
            this.quotationRequestBtn.Text = "Quotation Request";
            this.quotationRequestBtn.UseVisualStyleBackColor = false;
            this.quotationRequestBtn.Click += new System.EventHandler(this.quotationRequestBtn_Click);
            // 
            // supplierManagementBtn
            // 
            this.supplierManagementBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.supplierManagementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.supplierManagementBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierManagementBtn.ForeColor = System.Drawing.Color.White;
            this.supplierManagementBtn.Location = new System.Drawing.Point(255, 623);
            this.supplierManagementBtn.Name = "supplierManagementBtn";
            this.supplierManagementBtn.Size = new System.Drawing.Size(331, 68);
            this.supplierManagementBtn.TabIndex = 29;
            this.supplierManagementBtn.Text = "Supplier Management";
            this.supplierManagementBtn.UseVisualStyleBackColor = false;
            this.supplierManagementBtn.Click += new System.EventHandler(this.supplierManagementBtn_Click);
            // 
            // staffManagementBtn
            // 
            this.staffManagementBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.staffManagementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.staffManagementBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffManagementBtn.ForeColor = System.Drawing.Color.White;
            this.staffManagementBtn.Location = new System.Drawing.Point(255, 521);
            this.staffManagementBtn.Name = "staffManagementBtn";
            this.staffManagementBtn.Size = new System.Drawing.Size(331, 68);
            this.staffManagementBtn.TabIndex = 28;
            this.staffManagementBtn.Text = "Staff Management";
            this.staffManagementBtn.UseVisualStyleBackColor = false;
            this.staffManagementBtn.Click += new System.EventHandler(this.staffManagementBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(604, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // TechFixHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 862);
            this.Controls.Add(this.panel1);
            this.Name = "TechFixHomePage";
            this.Text = "Home Page - TechFix Solutions";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button quotationRequestBtn;
        private System.Windows.Forms.Button ordersBtn;
        private System.Windows.Forms.Button quotationsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button supplierManagementBtn;
        private System.Windows.Forms.Button staffManagementBtn;
    }
}