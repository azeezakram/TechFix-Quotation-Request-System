using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TechfixClientApp.techFixClientService;

namespace TechfixClientApp
{
    public partial class InventoryManagementPage : Form
    {
        private bool backButtonClicked = false;
        int supplierId;
        TechFixWebServicesSoapClient techFixservice;

        public InventoryManagementPage(int supplierId)
        {
            InitializeComponent();
            this.supplierId = supplierId;
            techFixservice = new TechFixWebServicesSoapClient();
            LoadDefaults(); 
            this.FormClosing += InventoryManagement_FormClosing;
            inventoryListView.ReadOnly = true;
            inventoryListView.AllowUserToAddRows = false;
            inventoryListView.SelectionChanged += InventoryListView_SelectionChanged;
        }

        private void InventoryManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backButtonClicked)
            {

                backButtonClicked = false;
                return;
            }
            Application.Exit();
        }

        private void backBtn_click(object sender, EventArgs e)
        {
            backButtonClicked = true;

            this.Close();

        }

        DataTable itemDataTable = new DataTable();
        

        void LoadDefaults()
        {
            inventoryListView.Rows.Clear();
            inventoryListView.Columns.Clear();
            List<Product> products = techFixservice.GetAllProducts().ToList();

            inventoryListView.Columns.Add("productId", "Product ID");
            inventoryListView.Columns.Add("name", "Product Name");
            inventoryListView.Columns.Add("unitPrice", "Unit Price");
            inventoryListView.Columns.Add("stock", "Stock");
            inventoryListView.Columns.Add("discount", "Discount (%)");
            inventoryListView.Columns.Add("updatedAt", "Updated At");
            inventoryListView.Columns.Add("createdAt", "Created At");

            foreach (var product in products)
            {
                DataGridViewRow row = new DataGridViewRow();

                //MessageBox.Show($"Supplier ID {supplierId}\n {product.supplierId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (product.supplierId == supplierId)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = product.productId });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = product.name });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = product.unitPrice });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = product.stock });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = product.discount });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = product.updatedAt.ToString() });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = product.createdAt.ToString() });

                    inventoryListView.Rows.Add(row);
                }
 
            }

            stockController.Minimum = 1;
            stockController.Maximum = 100000;
            addStockController.Minimum = 0;
            addStockController.Value = 0;
            stockController.Maximum = 100000;
            discountCounter.Minimum = 0;
            discountCounter.Maximum = 100;

            

        }

        private void InventoryListView_SelectionChanged(object sender, EventArgs e)
        {
            

            if (inventoryListView.SelectedRows.Count > 0)
            {
                //MessageBox.Show($"Supplier ID {supplierId}\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    DataGridViewRow selectedRow = inventoryListView.SelectedRows[0];

                    int productId = Convert.ToInt32(selectedRow.Cells["productId"].Value);
                    string productName = Convert.ToString(selectedRow.Cells["name"].Value);
                    string unitPirce = Convert.ToString(selectedRow.Cells["unitPrice"].Value);
                    int stock = Convert.ToInt32(selectedRow.Cells["stock"].Value);
                    decimal discount = Convert.ToDecimal(selectedRow.Cells["discount"].Value);
                    

                    productNameTb.Text = productName;
                    unitPriceTb.Text = unitPirce;
                    stockController.Value = stock;
                    discountCounter.Value = discount;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Select valid record row!", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show($"Error\n {ex}", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                stockController.Value = 1;
                addStockController.Value = 0;
                discountCounter.Value = 0;
            }
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = productNameTb.Text.Trim();
                string unitPriceText = unitPriceTb.Text.Trim();
                string stockText = stockController.Value.ToString().Trim();
                string addStockText = addStockController.Value.ToString().Trim();
                string discountText = discountCounter.Value.ToString().Trim();

                
                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Product name cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               
                if (string.IsNullOrEmpty(unitPriceText) || !double.TryParse(unitPriceText, out double unitPrice) || unitPrice <= 0)
                {
                    MessageBox.Show("Please enter a valid unit price greater than 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (string.IsNullOrEmpty(stockText) || !int.TryParse(stockText, out int stock) || stock < 0)
                {
                    MessageBox.Show("Please enter a valid stock quantity greater than or equal to 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(addStockText) || !int.TryParse(addStockText, out int addStock) || addStock < 0)
                {
                    MessageBox.Show("Please enter a valid stock quantity greater than or equal to 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (string.IsNullOrEmpty(discountText) || !double.TryParse(discountText, out double discount) || discount < 0 || discount > 100)
                {
                    MessageBox.Show("Please enter a valid discount percentage between 0 and 100.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataGridViewRow row in inventoryListView.Rows)
                {
                    if (row.Cells["name"].Value != null && (string)row.Cells["name"].Value == productName)
                    {
                        MessageBox.Show("This product has already been added to the inventory.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                Product product = new Product
                {
                    supplierId = supplierId,
                    name = productName,
                    unitPrice = unitPrice,
                    stock = stock + addStock,
                    discount = discount
                };

                
                int result = techFixservice.AddNewProduct(product);

                LoadDefaults();
                
                MessageBox.Show("Product successfully added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result > 0) {
                    MessageBox.Show("Product is not added. Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                    
                productNameTb.Clear();
                unitPriceTb.Clear();
                stockController.Value = stockController.Minimum;
                addStockController.Value = addStockController.Minimum;
                discountCounter.Value = discountCounter.Minimum;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void updateBtn_Click(object sender, EventArgs e)
        {
            
            if (inventoryListView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = inventoryListView.SelectedRows[0];

                if (selectedRow.Cells["productId"].Value == null)
                {
                    MessageBox.Show("Please select an request item to update.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string productName = productNameTb.Text.Trim();
                string unitPriceText = unitPriceTb.Text.Trim();
                string stockText = stockController.Value.ToString().Trim();
                string addStockText = addStockController.Value.ToString().Trim();
                string discountText = discountCounter.Value.ToString().Trim();

                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Product name cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (string.IsNullOrEmpty(unitPriceText) || !double.TryParse(unitPriceText, out double unitPrice) || unitPrice <= 0)
                {
                    MessageBox.Show("Please enter a valid unit price greater than 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (string.IsNullOrEmpty(stockText) || !int.TryParse(stockText, out int stock) || stock < 0)
                {
                    MessageBox.Show("Please enter a valid stock quantity greater than or equal to 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(addStockText) || !int.TryParse(addStockText, out int addStock) || addStock < 0)
                {
                    MessageBox.Show("Please enter a valid stock quantity greater than or equal to 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (string.IsNullOrEmpty(discountText) || !double.TryParse(discountText, out double discount) || discount < 0 || discount > 100)
                {
                    MessageBox.Show("Please enter a valid discount percentage between 0 and 100.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                Product product = new Product
                {
                    productId = (int)selectedRow.Cells["productId"].Value,
                    name = productName,
                    unitPrice = unitPrice,
                    stock = stock + addStock,
                    discount = discount
                };

                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to update the '{product.name}' ?",
                                          "Confirm Update",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
                int result = 0;
                if (dialogResult == DialogResult.Yes)
                {
                    result = techFixservice.UpdateProduct(product);
                    LoadDefaults();
                    MessageBox.Show($"'{product.name}' has been updated.", "Inventory product updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    return;
                }

                //MessageBox.Show($"Product {selectedRow.Cells["productId"].Value}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //int result = techFixservice.UpdateProduct(product);

                if (result > 0) {
                    MessageBox.Show("Product is not added. Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //LoadDefaults();

                //MessageBox.Show("Product updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select an product to update.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void removeItemBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (inventoryListView.SelectedRows.Count > 0)
                {


                    DataGridViewRow selectedRow = inventoryListView.SelectedRows[0];

                    Product product = new Product
                    {
                        productId = (int)selectedRow.Cells["productId"].Value
                    };

                    DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove the '{selectedRow.Cells["name"].Value}' from the inventory?",
                                          "Confirm Clear",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
                    int result = 0;
                    if (dialogResult == DialogResult.Yes)
                    {
                        result = techFixservice.DeleteProduct(product);
                        MessageBox.Show($"'{selectedRow.Cells["name"].Value}' has been removed from the inventory.", "Inventory product cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaults();
                    }
                    else
                    {
                        return;
                    }

                    if (result > 0) {
                        MessageBox.Show("Product isn't remove. Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Please select a row to remove.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearTheInventoryBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to the inventory?",
                                          "Confirm Clear",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
                int result = 0;
                if (dialogResult == DialogResult.Yes)
                {
                    result = techFixservice.ClearTheInventory(supplierId);
                    MessageBox.Show("Inventory has been cleared from the inventory.", "Inventory cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDefaults();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
