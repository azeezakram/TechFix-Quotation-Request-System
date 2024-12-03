namespace TechfixClientApp
{
    partial class SupplierHomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierHomePage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.orderManagementBtn = new System.Windows.Forms.Button();
            this.quotationManagementBtn = new System.Windows.Forms.Button();
            this.inventoryManagementBtn = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.logoutBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.orderManagementBtn);
            this.panel1.Controls.Add(this.quotationManagementBtn);
            this.panel1.Controls.Add(this.inventoryManagementBtn);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 877);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 36);
            this.label2.TabIndex = 28;
            this.label2.Text = "Supplier Dashboard";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(604, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.Transparent;
            this.logoutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.logoutBtn.Location = new System.Drawing.Point(22, 775);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(110, 45);
            this.logoutBtn.TabIndex = 6;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
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
            // orderManagementBtn
            // 
            this.orderManagementBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.orderManagementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.orderManagementBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderManagementBtn.ForeColor = System.Drawing.Color.White;
            this.orderManagementBtn.Location = new System.Drawing.Point(258, 462);
            this.orderManagementBtn.Name = "orderManagementBtn";
            this.orderManagementBtn.Size = new System.Drawing.Size(331, 68);
            this.orderManagementBtn.TabIndex = 4;
            this.orderManagementBtn.Text = "Order Management";
            this.orderManagementBtn.UseVisualStyleBackColor = false;
            this.orderManagementBtn.Click += new System.EventHandler(this.orderManagementBtn_Click);
            // 
            // quotationManagementBtn
            // 
            this.quotationManagementBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.quotationManagementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quotationManagementBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quotationManagementBtn.ForeColor = System.Drawing.Color.White;
            this.quotationManagementBtn.Location = new System.Drawing.Point(258, 360);
            this.quotationManagementBtn.Name = "quotationManagementBtn";
            this.quotationManagementBtn.Size = new System.Drawing.Size(331, 68);
            this.quotationManagementBtn.TabIndex = 3;
            this.quotationManagementBtn.Text = "Quotation Management";
            this.quotationManagementBtn.UseVisualStyleBackColor = false;
            this.quotationManagementBtn.Click += new System.EventHandler(this.quotationManagementBtn_Click);
            // 
            // inventoryManagementBtn
            // 
            this.inventoryManagementBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.inventoryManagementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inventoryManagementBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryManagementBtn.ForeColor = System.Drawing.Color.White;
            this.inventoryManagementBtn.Location = new System.Drawing.Point(258, 261);
            this.inventoryManagementBtn.Name = "inventoryManagementBtn";
            this.inventoryManagementBtn.Size = new System.Drawing.Size(331, 68);
            this.inventoryManagementBtn.TabIndex = 2;
            this.inventoryManagementBtn.Text = "Inventory Management";
            this.inventoryManagementBtn.UseVisualStyleBackColor = false;
            this.inventoryManagementBtn.Click += new System.EventHandler(this.inventoryManagementBtn_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // SupplierHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 862);
            this.Controls.Add(this.panel1);
            this.Name = "SupplierHomePage";
            this.Text = "SupplierHomePage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button orderManagementBtn;
        private System.Windows.Forms.Button quotationManagementBtn;
        private System.Windows.Forms.Button inventoryManagementBtn;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}