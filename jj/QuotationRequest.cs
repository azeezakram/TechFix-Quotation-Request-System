using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechfixClientApp.techFixClientService;


namespace TechfixClientApp
{
    public partial class Form1 : Form
    {
        private bool backButtonClicked = false;

        public Form1()
        {
            InitializeComponent();
            
            quotationItemsListView.SelectionChanged += QuotationItemsListView_SelectionChanged;
            this.FormClosing += QuotationRequest_FormClosing;
            quotationItemsListView.ReadOnly = true;
            quotationItemsListView.AllowUserToAddRows = false;
        }

        private void QuotationRequest_FormClosing(object sender, FormClosingEventArgs e)
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
        TechFixWebServicesSoapClient techFixservice = new TechFixWebServicesSoapClient();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDefaults();
            this.Text = "Quotation Request - TechFix Solutions";
            supplierCB.SelectedIndexChanged += supplierCB_SelectedIndexChanged;
           
        }

        void LoadDefaults()
        {
            List<Product> productList = techFixservice.GetAllProducts().ToList();
            List<Supplier> supplierList = techFixservice.GetSuppliers().ToList();
            productCB.DataSource = productList;
            supplierCB.DataSource = supplierList;
            productCB.DisplayMember = "name";
            productCB.ValueMember = "productId";
            supplierCB.DisplayMember = "supplierName";
            supplierCB.ValueMember = "supplierId";
            

            itemDataTable.Columns.Add("productId", typeof(int));
            itemDataTable.Columns.Add("name", typeof(string));
            itemDataTable.Columns.Add("stock", typeof(int));

            quotationItemsListView.Columns.Add("productId", "Product ID");
            quotationItemsListView.Columns.Add("name", "Product Name");
            quotationItemsListView.Columns.Add("unitPrice", "Unit Price");
            quotationItemsListView.Columns.Add("stock", "Stock");
            quotationItemsListView.Columns.Add("discount", "Supplier Discount (%)");


            quantityController.Minimum = 1;
            requestDiscountCounter.Minimum = 0;
            requestDiscountCounter.Maximum = 100;

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            
            quantityColumn.Name = "quantity";
            quantityColumn.HeaderText = "Quantity";
            quotationItemsListView.Columns.Add(quantityColumn);

            DataGridViewTextBoxColumn discountRequestColumn = new DataGridViewTextBoxColumn();
            discountRequestColumn.Name = "requestDiscount";
            discountRequestColumn.HeaderText = "Request Discount (%)";
            quotationItemsListView.Columns.Add(discountRequestColumn);

            productCB.DataSource = null;
            productCB.Enabled = false;
            supplierCB.Text = "--Supplier--";
            quantityController.Enabled = false;
            requestDiscountCounter.Enabled = false;
        }


        private void supplierCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supplierCB.SelectedValue != null)
            {
                int selectedSupplierId = (int)supplierCB.SelectedValue;

                List<Product> filteredProductList = techFixservice.GetAllProducts()
                    .Where(p => p.supplierId == selectedSupplierId) 
                    .ToList();

                productCB.DataSource = filteredProductList;
                productCB.DisplayMember = "name";
                productCB.Enabled = true;
                productCB.ValueMember = "productId";
                quantityController.Enabled = true;
                
            }
        }

        private int? selectedSupplierId = null;

        private void addItemTotheListBT_click(object sender, EventArgs e)
        {
            if (productCB.SelectedItem != null)
            {
                Product selectedProduct = (Product)productCB.SelectedItem;

                if (selectedSupplierId == null)
                {
                    selectedSupplierId = selectedProduct.supplierId;
                    supplierCB.SelectedValue = selectedSupplierId; 
                    supplierCB.Enabled = false; 
                }
                else if (selectedSupplierId != selectedProduct.supplierId)
                {
                   
                    MessageBox.Show("All items in a quotation request must be from the same supplier. Remove all items to change the supplier.", "Supplier Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataGridViewRow row in quotationItemsListView.Rows)
                {
                    if (row.Cells["productId"].Value != null && (int)row.Cells["productId"].Value == selectedProduct.productId)
                    {
                        MessageBox.Show("This product has already been added to the request.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int productId = selectedProduct.productId;
                string productName = selectedProduct.name;
                double unitPrice = selectedProduct.unitPrice;
                int stock = selectedProduct.stock;
                double discount = selectedProduct.discount;
                int quantity = (int)quantityController.Value;
                double requestDiscount = (double)requestDiscountCounter.Value;

                if (quantity > stock)
                {
                    MessageBox.Show("Quantity cannot exceed available stock.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = productId });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = productName });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = unitPrice });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = stock });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = discount });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = quantity });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = requestDiscount });

                quotationItemsListView.Rows.Add(newRow);

                CalculateGrandTotal();

                quantityController.Value = 1;
                requestDiscountCounter.Value = 0;
            }
            else
            {
                MessageBox.Show("Please select a product first.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void QuotationItemsListView_SelectionChanged(object sender, EventArgs e)
        {
            requestDiscountCounter.Enabled = false;

            if (quotationItemsListView.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = quotationItemsListView.SelectedRows[0];

                    int productId = Convert.ToInt32(selectedRow.Cells["productId"].Value);
                    int quantity = Convert.ToInt32(selectedRow.Cells["quantity"].Value);
                    double supplierDiscount = Convert.ToDouble(selectedRow.Cells["discount"].Value);
                    double requestDiscount = Convert.ToDouble(selectedRow.Cells["requestDiscount"].Value);

                    

                    Product selectedProduct = techFixservice.GetAllProducts().FirstOrDefault(p => p.productId == productId);
                    int supplierId = selectedProduct != null ? selectedProduct.supplierId : 0;

                    

                    if (supplierDiscount < 1)
                    {   
                        requestDiscountCounter.Enabled = true;
                        requestDiscountCounter.Value = (decimal)requestDiscount;   
                    }

                    productCB.SelectedValue = productId;
                    supplierCB.SelectedValue = supplierId;
                    quantityController.Value = quantity;
                    
                    

                }
                catch (Exception ex) {
                    MessageBox.Show("Select valid record row!", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            } else
            {
                quantityController.Value = 1;
                requestDiscountCounter.Value = 0;
            }
        }

        private void quotationItemsListView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the column being changed is either Quantity or DiscountRequest
            if (e.ColumnIndex == quotationItemsListView.Columns["quantity"].Index || e.ColumnIndex == quotationItemsListView.Columns["DiscountRequest"].Index)
            {
                // Handle Quantity change
                if (e.ColumnIndex == quotationItemsListView.Columns["Quantity"].Index)
                {
                    int quantity = 0;

                    // Try parsing the quantity value and validate it
                    if (int.TryParse(quotationItemsListView.Rows[e.RowIndex].Cells["quantity"].Value?.ToString(), out quantity))
                    {
                        if (quantity < 1)
                        {
                            MessageBox.Show("Quantity cannot be less than 1.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            quotationItemsListView.Rows[e.RowIndex].Cells["quantity"].Value = 1; // Reset to 1 if invalid
                        }
                        else
                        {
                            // Optionally: Update the total price based on quantity and unit price
                            double unitPrice = Convert.ToDouble(quotationItemsListView.Rows[e.RowIndex].Cells["unitPrice"].Value);
                            double totalPrice = unitPrice * quantity;
                            quotationItemsListView.Rows[e.RowIndex].Cells["TotalPrice"].Value = totalPrice; // Assuming a "TotalPrice" column exists
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid quantity entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        quotationItemsListView.Rows[e.RowIndex].Cells["quantity"].Value = 1; // Reset to default value
                    }
                }

                // Handle DiscountRequest change
                if (e.ColumnIndex == quotationItemsListView.Columns["discountRequest"].Index)
                {
                    string discountRequest = quotationItemsListView.Rows[e.RowIndex].Cells["discountRequest"].Value?.ToString();

                    // Optionally validate discount request (e.g., if it must be a number or a valid percentage)
                    if (!string.IsNullOrEmpty(discountRequest))
                    {
                        double discount;
                        if (double.TryParse(discountRequest, out discount))
                        {
                            if (discount < 0 || discount > 100)
                            {
                                MessageBox.Show("Discount must be between 0 and 100 percentage(%).", "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                quotationItemsListView.Rows[e.RowIndex].Cells["discountRequest"].Value = ""; // Clear invalid input
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid discount percentage.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            quotationItemsListView.Rows[e.RowIndex].Cells["discountRequest"].Value = ""; // Clear invalid input
                        }
                    }
                    else
                    {
                        // If no discount request entered, you can set it to 0 or leave it empty based on your preference
                        quotationItemsListView.Rows[e.RowIndex].Cells["discountRequest"].Value = 0;
                    }
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (quotationItemsListView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = quotationItemsListView.SelectedRows[0];

                
                if (selectedRow.Cells["productId"].Value == null) {
                    MessageBox.Show("Please select an request item to update.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                selectedRow.Cells["productId"].Value = (int)productCB.SelectedValue;
                selectedRow.Cells["name"].Value = productCB.Text;
                

                if ((int)quantityController.Value > (int)selectedRow.Cells["stock"].Value)
                {
                    MessageBox.Show("Quantity cannot exceed available stock.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return;
                }

                selectedRow.Cells["quantity"].Value = (int)quantityController.Value;
                selectedRow.Cells["requestDiscount"].Value = requestDiscountCounter.Value;

                CalculateGrandTotal();

                MessageBox.Show("Request item updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantityController.Value = 1;
                requestDiscountCounter.Value = 0;
            }
            else
            {
                MessageBox.Show("Please select an request item to update.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void CalculateGrandTotal()
        {
            double grandTotal = 0;

            foreach (DataGridViewRow row in quotationItemsListView.Rows)
            {
                if (row.Cells["unitPrice"].Value != null && row.Cells["quantity"].Value != null)
                {
                    
                    double unitPrice = Convert.ToDouble(row.Cells["unitPrice"].Value);
                    int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                    double discount = row.Cells["discount"].Value != null
                        ? Convert.ToDouble(row.Cells["discount"].Value)
                        : 0;

                    
                    double totalForProduct = (unitPrice - (unitPrice * discount/100)) * quantity;
                    grandTotal += totalForProduct;
                }
            }

            grandTotalLB.Text = $"LKR.{grandTotal:F2}";
        }

     
        private void sendQuotationBtn_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (supplierCB.SelectedValue == null)
                {
                    MessageBox.Show("Please select a supplier.");
                    return;
                }

                int currentSupplierId = Convert.ToInt32(supplierCB.SelectedValue);

                
                if (selectedSupplierId == null)
                {
                    
                    selectedSupplierId = currentSupplierId;
                }
                else if (selectedSupplierId != currentSupplierId)
                {
                    
                    MessageBox.Show("All items in a quotation request must be from the same supplier. Remove all items to change the supplier.", "Supplier Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Quotation newQuotation = new Quotation
                {
                    supplierId = selectedSupplierId.Value 
                };

                List<QuotationDetail> quotationDetails = new List<QuotationDetail>();

                foreach (DataGridViewRow row in quotationItemsListView.Rows)
                {
                    if (row.Cells["productId"].Value != null) 
                    {
                        
                        int productId = Convert.ToInt32(row.Cells["productId"].Value);
                        double unitPrice = Convert.ToDouble(row.Cells["unitPrice"].Value);
                        int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                        double supplierDiscount = Convert.ToDouble(row.Cells["discount"].Value);

                        double? requestDiscount = row.Cells["requestDiscount"].Value != null
                            ? (double?)Convert.ToDouble(row.Cells["requestDiscount"].Value)
                            : null;

                        quotationDetails.Add(new QuotationDetail
                        {
                            productId = productId,
                            unitPrice = (decimal)unitPrice,
                            quantity = quantity,
                            supplierDiscount = (decimal)supplierDiscount,
                            requestDiscount = (decimal?)requestDiscount
                        });
                    }
                }

                int newQuotationId = techFixservice.CreateNewQuotationRequest(newQuotation, quotationDetails.ToArray());

                MessageBox.Show($"Quotation request sent successfully! Quotation ID: {newQuotationId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                supplierCB.Enabled = false;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("An error occurred while sending the quotation request:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearTheListBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to clear all items from the list?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                
                quotationItemsListView.Rows.Clear();

                itemDataTable.Rows.Clear();

                selectedSupplierId = null;
                supplierCB.Enabled = true;
                supplierCB.SelectedIndex = -1;
                productCB.DataSource = null;
                productCB.Enabled = false;
                supplierCB.Text = "--Supplier--";
                quantityController.Enabled = false;
                requestDiscountCounter.Enabled = false;

                MessageBox.Show("The list has been cleared successfully.", "List Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void removeItemBtn_Click(object sender, EventArgs e)
        {
            
            if (quotationItemsListView.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow row in quotationItemsListView.SelectedRows)
                {
                   
                    if (!row.IsNewRow)
                    {
                        quotationItemsListView.Rows.Remove(row);
                    }
                }

                CalculateGrandTotal();

                if (quotationItemsListView.Rows.Count < 2) {
                    selectedSupplierId = null;
                    supplierCB.Enabled = true;
                    supplierCB.SelectedIndex = -1;
                    productCB.DataSource = null;
                    productCB.Enabled = false;
                    supplierCB.Text = "--Supplier--";
                    quantityController.Enabled = false;
                    requestDiscountCounter.Enabled = false;
                }
                
            }
            else
            {
                MessageBox.Show("Please select a row to remove.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

        
    }
}
