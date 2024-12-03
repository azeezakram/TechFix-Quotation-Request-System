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
using TechfixClientApp.techFixClientService;

namespace TechfixClientApp
{
    public partial class QuotationsPage : Form
    {
        private bool backButtonClicked = false;
        TechFixWebServicesSoapClient techFixService;
        public QuotationsPage()
        {
            InitializeComponent();
            this.Text = "Quotations - TechFix Solutions";
            techFixService = new TechFixWebServicesSoapClient();
            LoadDefaults();
            this.FormClosing += Quotation_FormClosing;
            quotationsListView.SelectionChanged += QuotationsListVew_SelectionChanged;
            quotationsListView.ReadOnly = true;
            quotationDetailsListView.ReadOnly = true;
            quotationDetailsListView.AllowUserToAddRows = false;
            quotationsListView.AllowUserToAddRows = false;

        }

        private void Quotation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backButtonClicked)
            {

                backButtonClicked = false;
                return;
            }
            Application.Exit();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            backButtonClicked = true;

            this.Close();
        }

        
        DataTable quotationTable = new DataTable();

        void LoadDefaults()
        {
            
            quotationsListView.Columns.Clear();
            quotationsListView.Rows.Clear();

            
            quotationsListView.Columns.Add("quotationId", "Quotation ID");
            quotationsListView.Columns.Add("supplierName", "Supplier Name");
            DataGridViewTextBoxColumn supplierIdColumn = new DataGridViewTextBoxColumn();
            supplierIdColumn.Name = "supplierId";
            supplierIdColumn.HeaderText = "Supplier ID";
            supplierIdColumn.Visible = false;
            quotationsListView.Columns.Add(supplierIdColumn);

            quotationsListView.Columns.Add("requestDate", "Request Date");
            quotationsListView.Columns.Add("approveDate", "Approve Date");

            

            List<Quotation> quotations = techFixService.GetAllQuotations().ToList();

            foreach (var quotation in quotations)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell { Value = quotation.quotationId });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = quotation.supplierName });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = quotation.supplierId });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = quotation.requestDate.ToString("yyyy-MM-dd") });

                if (quotation.approveDate != null)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = quotation.approveDate.Value.ToString("yyyy-MM-dd") });
                }
                else
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = "Pending" });
                }

                quotationsListView.Rows.Add(row);
            }
        }


        private void QuotationsListVew_SelectionChanged(object sender, EventArgs e)
        {
            if (quotationsListView.SelectedRows.Count > 0)
            {
                try
                {      
                    quotationDetailsListView.Columns.Clear();
                    quotationDetailsListView.Rows.Clear();

                    DataGridViewTextBoxColumn productIdColumn = new DataGridViewTextBoxColumn();
                    productIdColumn.Name = "productId";
                    productIdColumn.HeaderText = "Product ID";
                    productIdColumn.Visible = false;
                    quotationDetailsListView.Columns.Add(productIdColumn);

                    quotationDetailsListView.Columns.Add("name", "Product Name");
                    quotationDetailsListView.Columns.Add("unitPrice", "Unit Price");
                    quotationDetailsListView.Columns.Add("quantity", "Quantity");
                    quotationDetailsListView.Columns.Add("supplierDiscount", "Supplier Discount (%)");
                    quotationDetailsListView.Columns.Add("requestDiscount", "Request Discount (%)");

                    
                    DataGridViewRow selectedRow = quotationsListView.SelectedRows[0];
                    int quotationId = Convert.ToInt32(selectedRow.Cells["quotationId"].Value);

                    List<QuotationDetail> quotationDetails = techFixService.GetAllQuotationDetails()?.ToList();

                    if (quotationDetails == null || quotationDetails.Count == 0)
                    {
                        MessageBox.Show("No details available for this quotation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (QuotationDetail quotationDetail in quotationDetails)
                    {
                        if (quotationDetail.quotationId == quotationId)
                        {
                            DataGridViewRow detailRow = new DataGridViewRow();
                            detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.productId});
                            detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.name ?? "N/A" });
                            detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.unitPrice != 0 ? quotationDetail.unitPrice.ToString("F2") : "N/A" });
                            detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.quantity != 0 ? quotationDetail.quantity.ToString() : "N/A" });
                            detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.supplierDiscount != 0 ? quotationDetail.supplierDiscount.ToString("F2") : "N/A" });
                            detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.requestDiscount.HasValue ? quotationDetail.requestDiscount.Value.ToString() : "N/A" });

                            quotationDetailsListView.Rows.Add(detailRow);
                        }
                        CalculateGrandTotal();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void checkoutBT_Click(object sender, EventArgs e)
        {
            
            try
            {
                DataGridViewRow selectedRow = quotationsListView.SelectedRows[0];
                
                if (quotationsListView.SelectedRows.Count > 0 && selectedRow.Cells["approveDate"].Value.ToString() == "Pending")
                {                   
                    MessageBox.Show("Quotation approval is pending. Wait until supplier aprrove.", "Quotation pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;                   
                }

                int? orderSupplierId = Convert.ToInt32(selectedRow.Cells["supplierId"].Value);

                if (orderSupplierId == null)
                {
                    MessageBox.Show("All items in a quotation request must be from the same supplier. Remove all items to change the supplier.", "Supplier Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    Order newOrder = new Order
                    {
                        supplierId = orderSupplierId.Value
                    };

                    List<OrderItem> orderItems = new List<OrderItem>();

                    foreach (DataGridViewRow row in quotationDetailsListView.Rows)
                    {
                        if (row.Cells["productId"].Value != null)
                        {
                            int productId = Convert.ToInt32(row.Cells["productId"].Value);
                            decimal unitPrice = Convert.ToDecimal(row.Cells["unitPrice"].Value);
                            int quantity = Convert.ToInt32(row.Cells["quantity"].Value);

                            decimal? supplierDiscount = row.Cells["supplierDiscount"].Value.ToString() != "N/A"
                                ? (decimal?)Convert.ToDecimal(row.Cells["supplierDiscount"].Value)
                                : 0;

                            decimal? requestDiscount = row.Cells["requestDiscount"].Value.ToString() != "N/A"
                                ? (decimal?)Convert.ToDecimal(row.Cells["requestDiscount"].Value)
                                : 0;

                            /*MessageBox.Show($"Supllier discount {supplierDiscount} \n Request discount {requestDiscount}", "Supplier Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);*/

                            decimal priceAfterDiscount = unitPrice - (((decimal)supplierDiscount / 100) * unitPrice + ((decimal)requestDiscount / 100) * unitPrice);

                            //MessageBox.Show($"priceAfterDiscount {priceAfterDiscount}", "Supplier Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            orderItems.Add(new OrderItem
                            {
                                productId = productId,
                                unitPrice = priceAfterDiscount,
                                quantity = quantity,
                            });

                            //MessageBox.Show($"Proudct 1 {orderItems[0].productId}\n {orderItems[0].unitPrice} \n {orderItems[0].quantity}", "Supplier Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    int newOrderId = techFixService.CreateNewOrder(newOrder, orderItems.ToArray());

                    MessageBox.Show($"Quotation request checkout successfully! Order ID: {newOrderId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("An error occurred while sending the order place:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void removeItemBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedQuotationRow = quotationsListView.SelectedRows[0];
                DataGridViewRow selectedQuotationDetailRow = quotationDetailsListView.SelectedRows[0];

                if (quotationsListView.SelectedRows.Count > 0 && selectedQuotationRow.Cells["approveDate"].Value.ToString() == "Pending")
                {
                    MessageBox.Show("You can't edit approval pending quotations. Wait until supplier aprrove.", "Can't edit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (quotationDetailsListView.SelectedRows.Count > 0)
                    {

                        foreach (DataGridViewRow row in quotationDetailsListView.SelectedRows)
                        {

                            if (!row.IsNewRow)
                            {
                                quotationDetailsListView.Rows.Remove(row);
                            }
                        }

                        CalculateGrandTotal();

                    }
                    else
                    {
                        MessageBox.Show("Please select a row to remove.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Please select a valid data row to remove.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }


        private void CalculateGrandTotal()
        {
            double grandTotal = 0;

            foreach (DataGridViewRow row in quotationDetailsListView.Rows)
            {
                if (row.Cells["unitPrice"].Value != null && row.Cells["quantity"].Value != null)
                {
             
                    double unitPrice = Convert.ToDouble(row.Cells["unitPrice"].Value);
                    int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                    double supplierDiscount = row.Cells["supplierDiscount"].Value != null && row.Cells["supplierDiscount"].Value.ToString() != "N/A"
                        ? Convert.ToDouble(row.Cells["supplierDiscount"].Value)
                        : 0;

                    double requestDiscount = row.Cells["requestDiscount"].Value != null && row.Cells["requestDiscount"].Value.ToString() != "N/A"
                        ? Convert.ToDouble(row.Cells["requestDiscount"].Value)
                        : 0;

                    double discountMultiplier = (100 - supplierDiscount - requestDiscount) / 100;
                    double priceAfterDiscount = unitPrice * discountMultiplier;

                   
                    grandTotal += priceAfterDiscount * quantity;
                }
            }

            
            grandTotalLB.Text = $"LKR. {grandTotal:F2}";
        }

    }
}
