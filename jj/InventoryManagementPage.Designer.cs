namespace TechfixClientApp
{
    partial class InventoryManagementPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryManagementPage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label9 = new System.Windows.Forms.Label();
            this.clearTheInventoryBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.backIcon = new System.Windows.Forms.PictureBox();
            this.discountCounter = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.removeItemBtn = new System.Windows.Forms.Button();
            this.addItemBtn = new System.Windows.Forms.Button();
            this.inventoryListView = new System.Windows.Forms.DataGridView();
            this.stockController = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.unitPriceTb = new System.Windows.Forms.TextBox();
            this.productNameTb = new System.Windows.Forms.TextBox();
            this.addStockController = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockController)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addStockController)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(659, 839);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Design and Developed by Azeez";
            // 
            // clearTheInventoryBtn
            // 
            this.clearTheInventoryBtn.BackColor = System.Drawing.Color.Crimson;
            this.clearTheInventoryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearTheInventoryBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearTheInventoryBtn.ForeColor = System.Drawing.Color.White;
            this.clearTheInventoryBtn.Location = new System.Drawing.Point(555, 256);
            this.clearTheInventoryBtn.Name = "clearTheInventoryBtn";
            this.clearTheInventoryBtn.Size = new System.Drawing.Size(266, 45);
            this.clearTheInventoryBtn.TabIndex = 39;
            this.clearTheInventoryBtn.Text = "Clear the inventory";
            this.clearTheInventoryBtn.UseVisualStyleBackColor = false;
            this.clearTheInventoryBtn.Click += new System.EventHandler(this.clearTheInventoryBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(57, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 38;
            this.label7.Text = "Back to Home";
            // 
            // backIcon
            // 
            this.backIcon.BackColor = System.Drawing.Color.White;
            this.backIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backIcon.Image = ((System.Drawing.Image)(resources.GetObject("backIcon.Image")));
            this.backIcon.Location = new System.Drawing.Point(17, 21);
            this.backIcon.Name = "backIcon";
            this.backIcon.Size = new System.Drawing.Size(30, 35);
            this.backIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backIcon.TabIndex = 37;
            this.backIcon.TabStop = false;
            this.backIcon.Click += new System.EventHandler(this.backBtn_click);
            // 
            // discountCounter
            // 
            this.discountCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.discountCounter.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountCounter.Location = new System.Drawing.Point(21, 348);
            this.discountCounter.Name = "discountCounter";
            this.discountCounter.Size = new System.Drawing.Size(294, 25);
            this.discountCounter.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 17);
            this.label6.TabIndex = 35;
            this.label6.Text = "Discount (%) (optional)";
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.Color.White;
            this.updateBtn.Location = new System.Drawing.Point(555, 300);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(266, 45);
            this.updateBtn.TabIndex = 34;
            this.updateBtn.Text = "Update seleted item";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(610, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // removeItemBtn
            // 
            this.removeItemBtn.BackColor = System.Drawing.Color.Crimson;
            this.removeItemBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeItemBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeItemBtn.ForeColor = System.Drawing.Color.White;
            this.removeItemBtn.Location = new System.Drawing.Point(555, 212);
            this.removeItemBtn.Name = "removeItemBtn";
            this.removeItemBtn.Size = new System.Drawing.Size(266, 45);
            this.removeItemBtn.TabIndex = 33;
            this.removeItemBtn.Text = "Remove item";
            this.removeItemBtn.UseVisualStyleBackColor = false;
            this.removeItemBtn.Click += new System.EventHandler(this.removeItemBtn_Click);
            // 
            // addItemBtn
            // 
            this.addItemBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.addItemBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addItemBtn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.addItemBtn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemBtn.ForeColor = System.Drawing.Color.White;
            this.addItemBtn.Location = new System.Drawing.Point(555, 167);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Size = new System.Drawing.Size(266, 45);
            this.addItemBtn.TabIndex = 31;
            this.addItemBtn.Text = "Add item";
            this.addItemBtn.UseVisualStyleBackColor = false;
            this.addItemBtn.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // inventoryListView
            // 
            this.inventoryListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventoryListView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inventoryListView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.inventoryListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inventoryListView.DefaultCellStyle = dataGridViewCellStyle2;
            this.inventoryListView.GridColor = System.Drawing.Color.DarkGray;
            this.inventoryListView.Location = new System.Drawing.Point(21, 405);
            this.inventoryListView.Name = "inventoryListView";
            this.inventoryListView.Size = new System.Drawing.Size(800, 370);
            this.inventoryListView.TabIndex = 30;
            // 
            // stockController
            // 
            this.stockController.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stockController.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockController.Location = new System.Drawing.Point(21, 289);
            this.stockController.Name = "stockController";
            this.stockController.Size = new System.Drawing.Size(294, 25);
            this.stockController.TabIndex = 29;
            this.stockController.Value = new decimal(new int[] {
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
            this.label4.Location = new System.Drawing.Point(18, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Unit Price (Rs.)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 36);
            this.label1.TabIndex = 23;
            this.label1.Text = "Inventory Management";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Product Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.addStockController);
            this.panel1.Controls.Add(this.unitPriceTb);
            this.panel1.Controls.Add(this.productNameTb);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.clearTheInventoryBtn);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.backIcon);
            this.panel1.Controls.Add(this.discountCounter);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.updateBtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.removeItemBtn);
            this.panel1.Controls.Add(this.addItemBtn);
            this.panel1.Controls.Add(this.inventoryListView);
            this.panel1.Controls.Add(this.stockController);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-3, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 873);
            this.panel1.TabIndex = 1;
            // 
            // unitPriceTb
            // 
            this.unitPriceTb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitPriceTb.Location = new System.Drawing.Point(21, 232);
            this.unitPriceTb.Name = "unitPriceTb";
            this.unitPriceTb.Size = new System.Drawing.Size(294, 25);
            this.unitPriceTb.TabIndex = 42;
            // 
            // productNameTb
            // 
            this.productNameTb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productNameTb.Location = new System.Drawing.Point(21, 174);
            this.productNameTb.Name = "productNameTb";
            this.productNameTb.Size = new System.Drawing.Size(294, 25);
            this.productNameTb.TabIndex = 41;
            // 
            // addStockController
            // 
            this.addStockController.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addStockController.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStockController.Location = new System.Drawing.Point(321, 289);
            this.addStockController.Name = "addStockController";
            this.addStockController.Size = new System.Drawing.Size(91, 25);
            this.addStockController.TabIndex = 43;
            this.addStockController.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(318, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 44;
            this.label5.Text = "Add Stock";
            // 
            // InventoryManagementPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 862);
            this.Controls.Add(this.panel1);
            this.Name = "InventoryManagementPage";
            this.Text = "InventoryManagementPage";
            ((System.ComponentModel.ISupportInitialize)(this.backIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockController)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addStockController)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button clearTheInventoryBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox backIcon;
        private System.Windows.Forms.NumericUpDown discountCounter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button removeItemBtn;
        private System.Windows.Forms.Button addItemBtn;
        private System.Windows.Forms.DataGridView inventoryListView;
        private System.Windows.Forms.NumericUpDown stockController;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox unitPriceTb;
        private System.Windows.Forms.TextBox productNameTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown addStockController;
    }
}