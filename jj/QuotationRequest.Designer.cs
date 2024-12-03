namespace TechfixClientApp
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.supplierCB = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.clearTheListBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.backIcon = new System.Windows.Forms.PictureBox();
            this.requestDiscountCounter = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.grandTotalLB = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.removeItemBtn = new System.Windows.Forms.Button();
            this.sendQuotationBtn = new System.Windows.Forms.Button();
            this.addItemTotheListBT = new System.Windows.Forms.Button();
            this.quotationItemsListView = new System.Windows.Forms.DataGridView();
            this.quantityController = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.productCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestDiscountCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotationItemsListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityController)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quotation Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Supplier";
            // 
            // supplierCB
            // 
            this.supplierCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.supplierCB.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierCB.FormattingEnabled = true;
            this.supplierCB.IntegralHeight = false;
            this.supplierCB.Location = new System.Drawing.Point(28, 178);
            this.supplierCB.Margin = new System.Windows.Forms.Padding(6);
            this.supplierCB.Name = "supplierCB";
            this.supplierCB.Size = new System.Drawing.Size(294, 25);
            this.supplierCB.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.clearTheListBtn);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.backIcon);
            this.panel1.Controls.Add(this.requestDiscountCounter);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.grandTotalLB);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.updateBtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.removeItemBtn);
            this.panel1.Controls.Add(this.sendQuotationBtn);
            this.panel1.Controls.Add(this.addItemTotheListBT);
            this.panel1.Controls.Add(this.quotationItemsListView);
            this.panel1.Controls.Add(this.quantityController);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.productCB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.supplierCB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-9, -9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 884);
            this.panel1.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(666, 845);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Design and Developed by Azeez";
            // 
            // clearTheListBtn
            // 
            this.clearTheListBtn.BackColor = System.Drawing.Color.Crimson;
            this.clearTheListBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearTheListBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearTheListBtn.ForeColor = System.Drawing.Color.White;
            this.clearTheListBtn.Location = new System.Drawing.Point(562, 244);
            this.clearTheListBtn.Name = "clearTheListBtn";
            this.clearTheListBtn.Size = new System.Drawing.Size(266, 45);
            this.clearTheListBtn.TabIndex = 20;
            this.clearTheListBtn.Text = "Clear the list";
            this.clearTheListBtn.UseVisualStyleBackColor = false;
            this.clearTheListBtn.Click += new System.EventHandler(this.clearTheListBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 836);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(374, 26);
            this.label8.TabIndex = 19;
            this.label8.Text = "*This grand total including with the supplier discount, not the request discount." +
    "\r\n\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(64, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Back to Home";
            // 
            // backIcon
            // 
            this.backIcon.BackColor = System.Drawing.Color.White;
            this.backIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backIcon.Image = global::TechfixClientApp.Properties.Resources.arrow_back_24dp_999999_FILL0_wght300_GRAD0_opsz24;
            this.backIcon.Location = new System.Drawing.Point(24, 27);
            this.backIcon.Name = "backIcon";
            this.backIcon.Size = new System.Drawing.Size(30, 35);
            this.backIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backIcon.TabIndex = 17;
            this.backIcon.TabStop = false;
            this.backIcon.Click += new System.EventHandler(this.backBtn_click);
            // 
            // requestDiscountCounter
            // 
            this.requestDiscountCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.requestDiscountCounter.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestDiscountCounter.Location = new System.Drawing.Point(28, 354);
            this.requestDiscountCounter.Name = "requestDiscountCounter";
            this.requestDiscountCounter.Size = new System.Drawing.Size(294, 25);
            this.requestDiscountCounter.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Request Discount (optional)";
            // 
            // grandTotalLB
            // 
            this.grandTotalLB.AutoSize = true;
            this.grandTotalLB.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grandTotalLB.Location = new System.Drawing.Point(166, 807);
            this.grandTotalLB.Name = "grandTotalLB";
            this.grandTotalLB.Size = new System.Drawing.Size(99, 24);
            this.grandTotalLB.TabIndex = 14;
            this.grandTotalLB.Text = "LKR.0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 803);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Grand total:";
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.White;
            this.updateBtn.Location = new System.Drawing.Point(562, 288);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(266, 45);
            this.updateBtn.TabIndex = 12;
            this.updateBtn.Text = "Update seleted item";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::TechfixClientApp.Properties.Resources.Techfix_logo;
            this.pictureBox1.Location = new System.Drawing.Point(617, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // removeItemBtn
            // 
            this.removeItemBtn.BackColor = System.Drawing.Color.Crimson;
            this.removeItemBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeItemBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeItemBtn.ForeColor = System.Drawing.Color.White;
            this.removeItemBtn.Location = new System.Drawing.Point(562, 200);
            this.removeItemBtn.Name = "removeItemBtn";
            this.removeItemBtn.Size = new System.Drawing.Size(266, 45);
            this.removeItemBtn.TabIndex = 11;
            this.removeItemBtn.Text = "Remove item";
            this.removeItemBtn.UseVisualStyleBackColor = false;
            this.removeItemBtn.Click += new System.EventHandler(this.removeItemBtn_Click);
            // 
            // sendQuotationBtn
            // 
            this.sendQuotationBtn.BackColor = System.Drawing.Color.Black;
            this.sendQuotationBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendQuotationBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendQuotationBtn.ForeColor = System.Drawing.Color.White;
            this.sendQuotationBtn.Location = new System.Drawing.Point(562, 332);
            this.sendQuotationBtn.MaximumSize = new System.Drawing.Size(266, 45);
            this.sendQuotationBtn.MinimumSize = new System.Drawing.Size(266, 45);
            this.sendQuotationBtn.Name = "sendQuotationBtn";
            this.sendQuotationBtn.Size = new System.Drawing.Size(266, 45);
            this.sendQuotationBtn.TabIndex = 10;
            this.sendQuotationBtn.Text = "Send quotation request";
            this.sendQuotationBtn.UseVisualStyleBackColor = false;
            this.sendQuotationBtn.Click += new System.EventHandler(this.sendQuotationBtn_Click);
            // 
            // addItemTotheListBT
            // 
            this.addItemTotheListBT.BackColor = System.Drawing.SystemColors.HotTrack;
            this.addItemTotheListBT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addItemTotheListBT.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.addItemTotheListBT.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemTotheListBT.ForeColor = System.Drawing.Color.White;
            this.addItemTotheListBT.Location = new System.Drawing.Point(562, 155);
            this.addItemTotheListBT.Name = "addItemTotheListBT";
            this.addItemTotheListBT.Size = new System.Drawing.Size(266, 45);
            this.addItemTotheListBT.TabIndex = 9;
            this.addItemTotheListBT.Text = "Add item";
            this.addItemTotheListBT.UseVisualStyleBackColor = false;
            this.addItemTotheListBT.Click += new System.EventHandler(this.addItemTotheListBT_click);
            // 
            // quotationItemsListView
            // 
            this.quotationItemsListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.quotationItemsListView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.quotationItemsListView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.quotationItemsListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.quotationItemsListView.DefaultCellStyle = dataGridViewCellStyle2;
            this.quotationItemsListView.GridColor = System.Drawing.Color.DarkGray;
            this.quotationItemsListView.Location = new System.Drawing.Point(28, 411);
            this.quotationItemsListView.Name = "quotationItemsListView";
            this.quotationItemsListView.Size = new System.Drawing.Size(800, 370);
            this.quotationItemsListView.TabIndex = 8;
            // 
            // quantityController
            // 
            this.quantityController.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quantityController.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityController.Location = new System.Drawing.Point(28, 295);
            this.quantityController.Name = "quantityController";
            this.quantityController.Size = new System.Drawing.Size(294, 25);
            this.quantityController.TabIndex = 7;
            this.quantityController.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Select Quantity";
            // 
            // productCB
            // 
            this.productCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productCB.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productCB.FormattingEnabled = true;
            this.productCB.IntegralHeight = false;
            this.productCB.Location = new System.Drawing.Point(28, 236);
            this.productCB.Margin = new System.Windows.Forms.Padding(6);
            this.productCB.Name = "productCB";
            this.productCB.Size = new System.Drawing.Size(294, 25);
            this.productCB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Select Product";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 862);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestDiscountCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotationItemsListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityController)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox supplierCB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox productCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown quantityController;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView quotationItemsListView;
        private System.Windows.Forms.Button addItemTotheListBT;
        private System.Windows.Forms.Button sendQuotationBtn;
        private System.Windows.Forms.Button removeItemBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label grandTotalLB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown requestDiscountCounter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox backIcon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button clearTheListBtn;
        private System.Windows.Forms.Label label9;
    }
}

