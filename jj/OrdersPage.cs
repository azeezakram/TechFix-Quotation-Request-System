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
    public partial class OrdersPage : Form
    {
        private bool backButtonClicked = false;
        TechFixWebServicesSoapClient techFixService;
        public OrdersPage()
        {
            InitializeComponent();
            this.Text = "Orders - TechFix Solutions";
            techFixService = new TechFixWebServicesSoapClient();
            LoadDefaults();
            this.FormClosing += Orders_FormClosing;
            orderListView.SelectionChanged += OrderListView_SelectionChanged;
            orderListView.ReadOnly = true;
            orderItemListView.ReadOnly = true;
            orderItemListView.AllowUserToAddRows = false;
            orderListView.AllowUserToAddRows = false;
        }

        private void Orders_FormClosing(object sender, FormClosingEventArgs e)
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

        
        DataTable orderTable = new DataTable();

        void LoadDefaults()
        {

            orderListView.Columns.Clear();
            orderListView.Rows.Clear();


            orderListView.Columns.Add("orderId", "Order ID");
            orderListView.Columns.Add("supplierName", "Supplier Name");
            orderListView.Columns.Add("orderDate", "Order Date");
            orderListView.Columns.Add("totalAmount", "Total Amount");



            List<Order> orders = techFixService.GetAllOrders().ToList();

            foreach (var order in orders)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell { Value = order.orderId });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = order.supplierName });
                //row.Cells.Add(new DataGridViewTextBoxCell { Value = order.supplierId });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = order.orderDate.ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = order.totalAmount });

                

                orderListView.Rows.Add(row);
            }
        }


        private void OrderListView_SelectionChanged(object sender, EventArgs e)
        {
            if (orderListView.SelectedRows.Count > 0)
            {
                try
                {
                    orderItemListView.Columns.Clear();
                    orderItemListView.Rows.Clear();


                    DataGridViewTextBoxColumn productIdColumn = new DataGridViewTextBoxColumn();
                    productIdColumn.Name = "productId";
                    productIdColumn.HeaderText = "Product ID";
                    productIdColumn.Visible = false;
                    orderItemListView.Columns.Add(productIdColumn);

                    orderItemListView.Columns.Add("name", "Product Name");
                    orderItemListView.Columns.Add("unitPrice", "Unit Price (Rs.)");
                    orderItemListView.Columns.Add("quantity", "Quantity");                   
                    orderItemListView.Columns.Add("subTotal", "Sub Total (Rs.)");

                    DataGridViewRow selectedRow = orderListView.SelectedRows[0];
                    int orderId = Convert.ToInt32(selectedRow.Cells["orderId"].Value);

                    List<OrderItem> orderItems = techFixService.GetAllOrderItems().ToList();

                    if (orderItems == null || orderItems.Count == 0)
                    {
                        MessageBox.Show("No items available for this order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (OrderItem orderItem in orderItems)
                    {
                        if (orderItem.orderId == orderId)
                        {
                            DataGridViewRow itemRow = new DataGridViewRow();
                            itemRow.Cells.Add(new DataGridViewTextBoxCell { Value = orderItem.productId });
                            itemRow.Cells.Add(new DataGridViewTextBoxCell { Value = orderItem.productName ?? "N/A" });
                            itemRow.Cells.Add(new DataGridViewTextBoxCell { Value = orderItem.unitPrice != 0 ? orderItem.unitPrice.ToString("F2") : "N/A" });
                            itemRow.Cells.Add(new DataGridViewTextBoxCell { Value = orderItem.quantity != 0 ? orderItem.quantity.ToString() : "N/A" });
                            itemRow.Cells.Add(new DataGridViewTextBoxCell { Value = orderItem.subTotal != 0 ? orderItem.subTotal.ToString("F2") : "N/A" });

                            orderItemListView.Rows.Add(itemRow);
                        }
                        //CalculateGrandTotal();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
