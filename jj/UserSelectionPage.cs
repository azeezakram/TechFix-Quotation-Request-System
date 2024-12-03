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
    public partial class UserSelectionPage : Form
    {
        public UserSelectionPage()
        {
            InitializeComponent();
        }

        private void techFixBtn_Click(object sender, EventArgs e)
        {
            ShowLoginPage("TechFixLoginPage");
        }

        private void supplierBtn_Click(object sender, EventArgs e)
        {
            ShowLoginPage("SupplierLoginPage");
        }

        private void ShowLoginPage(string formName)
        {
            Form loginPage = null;

            if (formName == "TechFixLoginPage")
            {
                loginPage = new TechFixLoginPage();
            }
            else if (formName == "SupplierLoginPage")
            {
                loginPage = new SupplierLoginPage();
            }

            if (loginPage != null)
            {
                this.Hide();

                loginPage.FormClosed += (s, args) => this.Show(); 
                loginPage.Show(); 
            }
        }



    }
}
