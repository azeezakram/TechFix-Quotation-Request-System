using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechfixClientApp
{
    public partial class SupplierHomePage : Form
    {
        int supplierId;
        bool logOutClicked =false;
        public SupplierHomePage(int supplierId)
        {
            InitializeComponent();
            this.supplierId = supplierId;
            this.FormClosing += SupplierHomePage_FormClosing;
        }

        private void SupplierHomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logOutClicked)
            {

                logOutClicked = false;
                return;
            }
            Application.Exit();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            logOutClicked = true;
            this.Close();

            UserSelectionPage userSelectionPage = Application.OpenForms["UserSelectionPage"] as UserSelectionPage;
            if (userSelectionPage == null)
            {
                userSelectionPage = new UserSelectionPage();
                userSelectionPage.Show();
            }
            else
            {
                TechFixLoginPage techFixLoginPage = Application.OpenForms["TechFixLoginPage"] as TechFixLoginPage;
                if (techFixLoginPage != null)
                {
                    techFixLoginPage.Hide();
                }
                userSelectionPage.Show();

            }
        }

        private void inventoryManagementBtn_Click(object sender, EventArgs e)
        {
            InventoryManagementPage inventoryManagementPage = Application.OpenForms["InventoryManagementPage"] as InventoryManagementPage;
            if (inventoryManagementPage == null)
            {
                this.Hide();
                //MessageBox.Show($"Supplier ID {supplierId}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                inventoryManagementPage = new InventoryManagementPage(this.supplierId);
                inventoryManagementPage.FormClosed += (s, args) => this.Show();
                inventoryManagementPage.ShowDialog();
            }
            else
            {
                inventoryManagementPage.BringToFront();
            }
        }

        private void quotationManagementBtn_Click(object sender, EventArgs e)
        {
            QuotationManagementPage quotationManagementPage = Application.OpenForms["QuotationManagementPage"] as QuotationManagementPage;
            if (quotationManagementPage == null)
            {
                this.Hide();
                quotationManagementPage = new QuotationManagementPage(supplierId);
                quotationManagementPage.FormClosed += (s, args) => this.Show();
                quotationManagementPage.ShowDialog();
            }
            else
            {
                quotationManagementPage.BringToFront();
            }
        }

        private void orderManagementBtn_Click(object sender, EventArgs e)
        {
            OrderManagementPage orderManagementPage = Application.OpenForms["OrderManagementPage"] as OrderManagementPage;
            if (orderManagementPage == null)
            {
                this.Hide();
                orderManagementPage = new OrderManagementPage(supplierId);
                orderManagementPage.FormClosed += (s, args) => this.Show();
                orderManagementPage.ShowDialog();
            }
            else
            {
                orderManagementPage.BringToFront();
            }
        }

        
    }
}
