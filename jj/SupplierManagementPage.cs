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
    public partial class SupplierManagementPage : Form
    {
        private bool backButtonClicked = false;
        TechFixWebServicesSoapClient techFixService;
        public SupplierManagementPage()
        {
            InitializeComponent();
            this.Text = "Supplier Management - TechFix Solutions";
            techFixService = new TechFixWebServicesSoapClient();
            LoadDefaults();
            this.FormClosing += SupplierMangementPage_FormClosing;
            supplierListView.SelectionChanged += SupplierListView_SelectionChanged;
            supplierListView.ReadOnly = true;
            supplierListView.AllowUserToAddRows = false;


        }

        private void SupplierMangementPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backButtonClicked)
            {

                backButtonClicked = false;
                return;
            }
            Application.Exit();
        }

        private void backIcon_Click(object sender, EventArgs e)
        {
            backButtonClicked = true;

            this.Close();
        }

        void LoadDefaults()
        {
            supplierListView.Rows.Clear();
            supplierListView.Columns.Clear();
            List<Supplier> suppliers = techFixService.GetSuppliers().ToList();

            supplierListView.Columns.Add("supplierId", "Supplier ID");
            supplierListView.Columns.Add("supplierName", "Supplier Name");
            supplierListView.Columns.Add("username", "Username");
            supplierListView.Columns.Add("password", "Password");



            foreach (Supplier staff in suppliers)
            {
                DataGridViewRow row = new DataGridViewRow();

                //MessageBox.Show($"Supplier ID {supplierId}\n {product.supplierId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                row.Cells.Add(new DataGridViewTextBoxCell { Value = staff.supplierId });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = staff.supplierName });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = staff.username });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = staff.password });


                supplierListView.Rows.Add(row);

            }

        }

        private void SupplierListView_SelectionChanged(object sender, EventArgs e)
        {


            if (supplierListView.SelectedRows.Count > 0)
            {
                //MessageBox.Show($"Supplier ID {supplierId}\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    DataGridViewRow selectedRow = supplierListView.SelectedRows[0];

                    nameTb.Text = Convert.ToString(selectedRow.Cells["supplierName"].Value);
                    usernameTb.Text = Convert.ToString(selectedRow.Cells["username"].Value);
                    passwordTb.Text = Convert.ToString(selectedRow.Cells["password"].Value);

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Select valid record row!", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show($"Error\n {ex}", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                nameTb.Clear();
                usernameTb.Clear();
                passwordTb.Clear();

            }
        }


        private void addSupplierBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string supplierName = nameTb.Text.Trim();
                string username = usernameTb.Text.Trim().Replace(" ", "");
                string password = passwordTb.Text.Trim();



                if (string.IsNullOrEmpty(supplierName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Fill all the fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (username.Length < 5)
                {
                    MessageBox.Show("Username must be at least 5 characters long.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password.Length < 5)
                {
                    MessageBox.Show("Password must be at least 8 characters long.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                foreach (DataGridViewRow row in supplierListView.Rows)
                {
                    if (row.Cells["username"].Value != null && (string)row.Cells["username"].Value == username)
                    {
                        MessageBox.Show("This username is already in use. Try a new one.", "Duplicate username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                

                Supplier supplier = new Supplier
                {
                    
                    supplierName = supplierName,
                    username = username,
                    password = password
                };


                int result = techFixService.AddNewSupplier(supplier);

                //if (result > 0)
                //{
                //    MessageBox.Show("Supplier is not added. Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                LoadDefaults();

                MessageBox.Show("Supplier successfully added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nameTb.Clear();
                usernameTb.Clear();
                passwordTb.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (supplierListView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = supplierListView.SelectedRows[0];

                    if (selectedRow.Cells["supplierId"].Value == null)
                    {
                        MessageBox.Show("Please select a staff to update.", "Supplier Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string supplierName = nameTb.Text.Trim();
                    string username = usernameTb.Text.Trim().Replace(" ", "");
                    string password = passwordTb.Text.Trim();
                    string currentUsername = (string)selectedRow.Cells["username"].Value;

                    if (string.IsNullOrEmpty(supplierName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Fill all the fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (username.Length < 5)
                    {
                        MessageBox.Show("Username must be at least 5 characters long.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (password.Length < 5)
                    {
                        MessageBox.Show("Password must be at least 8 characters long.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    if (username != currentUsername)
                    {
                        foreach (DataGridViewRow row in supplierListView.Rows)
                        {
                            if (row.Cells["username"].Value != null && (string)row.Cells["username"].Value == username)
                            {
                                MessageBox.Show("This username is already in use. Try a new one.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    Supplier supplier = new Supplier
                    {
                        supplierId = (int)selectedRow.Cells["supplierId"].Value,
                        supplierName = supplierName,
                        username = username,
                        password = password
                    };

                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to update?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int result = techFixService.UpdateSupplier(supplier);
                        if (result > 0)
                        {
                            MessageBox.Show("Update failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        LoadDefaults();
                        MessageBox.Show($"'{supplier.supplierName}' has been updated.", "Supplier Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a supplier to update.", "No Staff Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (supplierListView.SelectedRows.Count > 0)
                {


                    DataGridViewRow selectedRow = supplierListView.SelectedRows[0];


                    int supplierId = (int)selectedRow.Cells["supplierId"].Value;


                    DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove the '{selectedRow.Cells["supplierName"].Value}' ?",
                                          "Confirm Clear",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
                    int result = 0;
                    if (dialogResult == DialogResult.Yes)
                    {
                        result = techFixService.DeleteSupplier(supplierId);

                        MessageBox.Show($"'{selectedRow.Cells["supplierName"].Value}' has been removed.", "Supplier removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaults();
                    }
                    else
                    {
                        return;
                    }

                    if (result > 0)
                    {
                        MessageBox.Show("Supplier isn't remove. Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Please select a row to remove.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}

