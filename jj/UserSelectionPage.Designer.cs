namespace TechfixClientApp
{
    partial class UserSelectionPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.supplierBtn = new System.Windows.Forms.Button();
            this.techFixBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.supplierBtn);
            this.panel1.Controls.Add(this.techFixBtn);
            this.panel1.Location = new System.Drawing.Point(-2, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 852);
            this.panel1.TabIndex = 0;
            // 
            // supplierBtn
            // 
            this.supplierBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.supplierBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.supplierBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierBtn.ForeColor = System.Drawing.Color.White;
            this.supplierBtn.Location = new System.Drawing.Point(240, 477);
            this.supplierBtn.Name = "supplierBtn";
            this.supplierBtn.Size = new System.Drawing.Size(331, 68);
            this.supplierBtn.TabIndex = 29;
            this.supplierBtn.Text = "Supplier";
            this.supplierBtn.UseVisualStyleBackColor = false;
            this.supplierBtn.Click += new System.EventHandler(this.supplierBtn_Click);
            // 
            // techFixBtn
            // 
            this.techFixBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.techFixBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.techFixBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.techFixBtn.ForeColor = System.Drawing.Color.White;
            this.techFixBtn.Location = new System.Drawing.Point(240, 350);
            this.techFixBtn.Name = "techFixBtn";
            this.techFixBtn.Size = new System.Drawing.Size(331, 68);
            this.techFixBtn.TabIndex = 28;
            this.techFixBtn.Text = "TechFix";
            this.techFixBtn.UseVisualStyleBackColor = false;
            this.techFixBtn.Click += new System.EventHandler(this.techFixBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::TechfixClientApp.Properties.Resources.Techfix_logo;
            this.pictureBox1.Location = new System.Drawing.Point(254, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(322, 804);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Design and Developed by Azeez";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "Select User";
            // 
            // UserSelectionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 838);
            this.Controls.Add(this.panel1);
            this.Name = "UserSelectionPage";
            this.Text = "UserSelectionPage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button supplierBtn;
        private System.Windows.Forms.Button techFixBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
    }
}