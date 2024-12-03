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
    public partial class TechFixLoginPage : Form
    {
        TechFixWebServicesSoapClient techFixservice;
        string[] userData;

        public TechFixLoginPage()
        {
            InitializeComponent();
            this.FormClosing += TechFixLoginPage_FormClosing;
            techFixservice = new TechFixWebServicesSoapClient();
        }

        private void TechFixLoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        private void switchToSupplierBtn_Click(object sender, EventArgs e)
        {
            SupplierLoginPage supplierLoginPage = Application.OpenForms["SupplierLoginPage"] as SupplierLoginPage;
            if (supplierLoginPage == null)
            {
                this.Hide();  
                supplierLoginPage = new SupplierLoginPage();
                supplierLoginPage.FormClosed += (s, args) => this.Show();  
                supplierLoginPage.Show();  
            }
            else
            {
                supplierLoginPage.BringToFront();  
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

            bool isUsernameExists = !techFixservice.isStaffUsernameNotExists(username);

            if (isUsernameExists)
            {
                try
                {

                    userData = techFixservice.GetStaffUsernameAndPassword(username).ToArray();

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

                    TechFixHomePage techFixHomePage = Application.OpenForms["TechFixHomePage"] as TechFixHomePage;
                    if (techFixHomePage == null)
                    {
                        this.Hide();
                        techFixHomePage = new TechFixHomePage();
                        //techFixHomePage.FormClosed += (s, args) => this.Show();
                        techFixHomePage.ShowDialog();
                    }
                    else
                    {
                        techFixHomePage.BringToFront();
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
