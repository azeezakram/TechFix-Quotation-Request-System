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
    public partial class SupplierLoginPage : Form
    {
        TechFixWebServicesSoapClient techFixservice;
        string[] userData;
        public SupplierLoginPage()
        {
            InitializeComponent();
            techFixservice = new TechFixWebServicesSoapClient();
            this.FormClosing += SupplierLoginPage_FormClosing;
        }

        private void SupplierLoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void switchToTechfixBtn_Click(object sender, EventArgs e)
        {
            TechFixLoginPage techfixLoginPage = Application.OpenForms["TechFixLoginPage"] as TechFixLoginPage;
            if (techfixLoginPage == null)
            {
                this.Hide();  
                techfixLoginPage = new TechFixLoginPage();
                techfixLoginPage.FormClosed += (s, args) => this.Show();  
                techfixLoginPage.Show();
            }
            else
            {
                techfixLoginPage.BringToFront();  
            }
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTb.Text) || string.IsNullOrWhiteSpace(passwordTb.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = usernameTb.Text.Trim();
            string password = passwordTb.Text.Trim();

            bool isUsernameExists = !techFixservice.isUsernameNotExists(username);

            if (isUsernameExists)
            {
                try
                {
                    
                    userData = techFixservice.GetSupplierUsernameAndPassword(username).ToArray();

                    if (userData == null || userData.Length < 2)
                    {
                        MessageBox.Show("User data is missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (userData[1] != password)
                    {
                        MessageBox.Show("Your password is incorrect. Please try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SupplierHomePage supplierHomePage = Application.OpenForms["SupplierHomePage"] as SupplierHomePage;
                    if (supplierHomePage == null)
                    {
                        int supplierId = int.Parse(userData[2]);
                        //MessageBox.Show($"Supplier ID {supplierId}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        supplierHomePage = new SupplierHomePage(supplierId);
                        //supplierHomePage.FormClosed += (s, args) => this.Show();
                        supplierHomePage.ShowDialog();
                    }
                    else
                    {
                        supplierHomePage.BringToFront();
                    }
                    usernameTb.Clear();
                    passwordTb.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while fetching user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            { 
                MessageBox.Show("Username does not exist. Please input a valid username.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
