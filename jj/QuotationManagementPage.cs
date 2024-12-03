using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TechfixClientApp.techFixClientService;

namespace TechfixClientApp
{
    public partial class QuotationManagementPage : Form
    {
        private bool backButtonClicked = false;
        private int supplierId;
        private TechFixWebServicesSoapClient techFixService;

        public QuotationManagementPage(int supplierId)
        {
            InitializeComponent();
            this.supplierId = supplierId;
            techFixService = new TechFixWebServicesSoapClient();
            LoadDefaults();
            this.FormClosing += QuotationManagementPage_FormClosing;

            InitializeListViewSettings();
        }

        private void QuotationManagementPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!backButtonClicked)
            {
                Application.Exit();
            }
            else
            {
                backButtonClicked = false;
            }
        }

        private void InitializeListViewSettings()
        {
            quotationsListView.ReadOnly = true;
            quotationsListView.AllowUserToAddRows = false;
            quotationDetailsListView.ReadOnly = true;
            quotationDetailsListView.AllowUserToAddRows = false;

            quotationsListView.SelectionChanged += QuotationsListView_SelectionChanged;
            quotationDetailsListView.SelectionChanged += QuotationDetailsListView_SelectionChanged;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            backButtonClicked = true;
            this.Close();
        }

        private void LoadDefaults()
        {
            quotationsListView.Columns.Clear();
            quotationsListView.Rows.Clear();

            quotationsListView.Columns.Add("quotationId", "Quotation ID");

            var supplierIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "supplierId",
                HeaderText = "Supplier ID",
                Visible = false
            };
            quotationsListView.Columns.Add(supplierIdColumn);

            quotationsListView.Columns.Add("requestDate", "Request Date");
            quotationsListView.Columns.Add("approveDate", "Approve Date");

            var quotations = techFixService.GetAllQuotations()?.Where(q => q.supplierId == supplierId).ToList();

            //if (quotations == null || quotations.Count == 0)
            //{
            //    MessageBox.Show("No quotations found for this supplier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            //}

            foreach (var quotation in quotations)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = quotation.quotationId });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = quotation.supplierId });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = quotation.requestDate.ToString("yyyy-MM-dd") });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = quotation.approveDate?.ToString("yyyy-MM-dd") ?? "Need to approve" });
                quotationsListView.Rows.Add(row);
            }

            requestDiscountCounter.Enabled = false;
        }

        private void QuotationsListView_SelectionChanged(object sender, EventArgs e)
        {
            requestDiscountCounter.Enabled = false;

            if (quotationsListView.SelectedRows.Count > 0)
            {
                LoadQuotationDetails();
                CalculateGrandTotal();
            }
        }

        private void LoadQuotationDetails()
        {
            try
            {
                quotationDetailsListView.Columns.Clear();
                quotationDetailsListView.Rows.Clear();

                quotationDetailsListView.Columns.Add(new DataGridViewTextBoxColumn { Name = "quotationDetailId", HeaderText = "Quotation Detail ID", Visible = false });
                quotationDetailsListView.Columns.Add(new DataGridViewTextBoxColumn { Name = "productId", HeaderText = "Product ID", Visible = false });
                quotationDetailsListView.Columns.Add("name", "Product Name");
                quotationDetailsListView.Columns.Add("unitPrice", "Unit Price");
                quotationDetailsListView.Columns.Add("quantity", "Quantity");
                quotationDetailsListView.Columns.Add("supplierDiscount", "Supplier Discount (%)");
                quotationDetailsListView.Columns.Add("requestDiscount", "Request Discount (%)");

                var selectedRow = quotationsListView.SelectedRows[0];
                int quotationId = Convert.ToInt32(selectedRow.Cells["quotationId"].Value);
                var quotationDetails = techFixService.GetAllQuotationDetails()?.Where(qd => qd.quotationId == quotationId).ToList();

                if (quotationDetails == null || quotationDetails.Count == 0)
                {
                    MessageBox.Show("No details available for this quotation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var quotationDetail in quotationDetails)
                {
                    var detailRow = new DataGridViewRow();
                    detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.quotationDetailId });
                    detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.productId });
                    detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.name ?? "N/A" });
                    detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.unitPrice != 0 ? quotationDetail.unitPrice.ToString("F2") : "0" });
                    detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.quantity != 0 ? quotationDetail.quantity.ToString() : "N/A" });
                    detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.supplierDiscount != 0 ? quotationDetail.supplierDiscount.ToString("F2") : "0" });
                    detailRow.Cells.Add(new DataGridViewTextBoxCell { Value = quotationDetail.requestDiscount?.ToString("F2") ?? "0" });

                    quotationDetailsListView.Rows.Add(detailRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading quotation details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuotationDetailsListView_SelectionChanged(object sender, EventArgs e)
        {
            if (quotationDetailsListView.SelectedRows.Count > 0)
            {
                var selectedQuotationItem = quotationDetailsListView.SelectedRows[0];

                requestDiscountCounter.Enabled = Convert.ToDouble(selectedQuotationItem.Cells["supplierDiscount"].Value) == 0;

                if (requestDiscountCounter.Enabled)
                {
                    requestDiscountCounter.Value = Convert.ToDecimal(selectedQuotationItem.Cells["requestDiscount"].Value);
                }
            }
        }

        private void CalculateGrandTotal()
        {
            double grandTotal = 0;

            foreach (DataGridViewRow row in quotationDetailsListView.Rows)
            {
                if (double.TryParse(row.Cells["unitPrice"].Value?.ToString(), out double unitPrice) &&
                    int.TryParse(row.Cells["quantity"].Value?.ToString(), out int quantity))
                {
                    double supplierDiscount = double.TryParse(row.Cells["supplierDiscount"].Value?.ToString(), out double sDiscount) ? sDiscount : 0;
                    double requestDiscount = double.TryParse(row.Cells["requestDiscount"].Value?.ToString(), out double rDiscount) ? rDiscount : 0;

                    double discountMultiplier = (100 - supplierDiscount - requestDiscount) / 100;
                    double priceAfterDiscount = unitPrice * discountMultiplier;
                    grandTotal += priceAfterDiscount * quantity;
                }
            }

            grandTotalLB.Text = $"LKR. {grandTotal:F2}";
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (quotationDetailsListView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!requestDiscountCounter.Enabled) {
                MessageBox.Show("Nothing to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedQuotationItem = quotationDetailsListView.SelectedRows[0];
            int quotationDetailId = Convert.ToInt32(selectedQuotationItem.Cells["quotationDetailId"].Value);
            decimal requestDiscount = requestDiscountCounter.Value;

            var confirmResult = MessageBox.Show("Are you sure you want to update this quotation request item?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int result = techFixService.UpdateRequestDiscount(quotationDetailId, requestDiscount);
                    if (result == 0)
                    {
                        MessageBox.Show("Update failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    LoadQuotationDetails();
                    MessageBox.Show("Quotation request item has been successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating discount: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            if (quotationsListView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to approve", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedQuotation = quotationsListView.SelectedRows[0];

            if ((string)selectedQuotation.Cells["approveDate"].Value != "Need to approve")
            {
                MessageBox.Show("This quotation request is already approved", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            int quotationId = Convert.ToInt32(selectedQuotation.Cells["quotationId"].Value);

            var confirmResult = MessageBox.Show("Are you sure you want to approve this quotation?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int result = techFixService.SetQuotationApproved(quotationId);
                    if (result == 0)
                    {
                        MessageBox.Show("Approval failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    LoadDefaults();
                    MessageBox.Show("Quotation has been successfully approved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error approving quotation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
