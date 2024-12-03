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
    public partial class TechFixHomePage : Form
    {
        bool logOutClicked = false;
        public TechFixHomePage()
        {
            InitializeComponent();
            this.FormClosing += TechFixHomePage_FormClosing;
        }

        

        private void TechFixHomePage_FormClosing(object sender, FormClosingEventArgs e)
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
                if(techFixLoginPage != null)
                {
                    techFixLoginPage.Hide();
                }
                userSelectionPage.Show();

            }
        }


        private void quotationsBtn_Click(object sender, EventArgs e)
        {
            QuotationsPage quotationsPage = Application.OpenForms["QuotationsPage"] as QuotationsPage;
            if (quotationsPage == null)
            {
                this.Hide();
                quotationsPage = new QuotationsPage();
                quotationsPage.FormClosed += (s, args) => this.Show();
                quotationsPage.ShowDialog();
            }
            else
            {
                quotationsPage.BringToFront();
            }
        }

        private void quotationRequestBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            if (form1 == null)
            {
                this.Hide();
                form1 = new Form1();
                form1.FormClosed += (s, args) => this.Show();
                form1.ShowDialog();
            }
            else
            {
                form1.BringToFront();
            }
        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {
            OrdersPage ordersPage = Application.OpenForms["OrdersPage"] as OrdersPage;
            if (ordersPage == null)
            {
                this.Hide();
                ordersPage = new OrdersPage();
                ordersPage.FormClosed += (s, args) => this.Show();
                ordersPage.ShowDialog();
            }
            else
            {
                ordersPage.BringToFront();
            }
        }

        private void staffManagementBtn_Click(object sender, EventArgs e)
        {
            StaffManagementPage staffManagementPage = Application.OpenForms["StaffManagementPage"] as StaffManagementPage;
            if (staffManagementPage == null)
            {
                this.Hide();
                staffManagementPage = new StaffManagementPage();
                staffManagementPage.FormClosed += (s, args) => this.Show();
                staffManagementPage.ShowDialog();
            }
            else
            {
                staffManagementPage.BringToFront();
            }
        }

        private void supplierManagementBtn_Click(object sender, EventArgs e)
        {
            SupplierManagementPage supplierManagementPage = Application.OpenForms["SupplierManagementPage"] as SupplierManagementPage;
            if (supplierManagementPage == null)
            {
                this.Hide();
                supplierManagementPage = new SupplierManagementPage();
                supplierManagementPage.FormClosed += (s, args) => this.Show();
                supplierManagementPage.ShowDialog();
            }
            else
            {
                supplierManagementPage.BringToFront();
            }
        }
    }
}
