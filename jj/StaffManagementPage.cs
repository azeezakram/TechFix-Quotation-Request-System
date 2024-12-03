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
    public partial class StaffManagementPage : Form
    {
        private bool backButtonClicked = false;
        TechFixWebServicesSoapClient techFixService;
        public StaffManagementPage()
        {
            InitializeComponent();
            this.Text = "Staff Management - TechFix Solutions";
            techFixService = new TechFixWebServicesSoapClient();
            LoadDefaults();
            this.FormClosing += StaffMangementPage_FormClosing;
            staffListView.SelectionChanged += StaffListView_SelectionChanged;
            staffListView.ReadOnly = true;
            staffListView.AllowUserToAddRows = false;
            

        }

        private void StaffMangementPage_FormClosing(object sender, FormClosingEventArgs e)
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
            staffListView.Rows.Clear();
            staffListView.Columns.Clear();
            List<TechFixStaff> staffs = techFixService.GetAllStaffs().ToList();

            staffListView.Columns.Add("staffId", "Staff ID");
            staffListView.Columns.Add("staffName", "Staff Name");
            staffListView.Columns.Add("username", "Username");
            staffListView.Columns.Add("password", "Password");
            
            

            foreach (TechFixStaff staff in staffs)
            {
                DataGridViewRow row = new DataGridViewRow();

                //MessageBox.Show($"Supplier ID {supplierId}\n {product.supplierId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                
                row.Cells.Add(new DataGridViewTextBoxCell { Value = staff.staffId });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = staff.staffName });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = staff.username });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = staff.password });
                

                staffListView.Rows.Add(row);

            }

        }

        private void StaffListView_SelectionChanged(object sender, EventArgs e)
        {


            if (staffListView.SelectedRows.Count > 0)
            {
                //MessageBox.Show($"Supplier ID {supplierId}\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    DataGridViewRow selectedRow = staffListView.SelectedRows[0];

                    nameTb.Text = Convert.ToString(selectedRow.Cells["staffName"].Value);
                    usernameTb.Text = Convert.ToString(selectedRow.Cells["userName"].Value);
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


        private void addStaffBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string staffName = nameTb.Text.Trim();
                string username = usernameTb.Text.Trim().Replace(" ", "");
                string password = passwordTb.Text.Trim();



                if (string.IsNullOrEmpty(staffName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Fill all the fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (username.Length < 5)
                {
                    MessageBox.Show("Username must be at least 5 characters long.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password.Length < 5) {
                    MessageBox.Show("Password must be at least 8 characters long.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                foreach (DataGridViewRow row in staffListView.Rows)
                {
                    if (row.Cells["username"].Value != null && (string)row.Cells["username"].Value == username)
                    {
                        MessageBox.Show("This username is already in use. Try a new one.", "Duplicate username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                TechFixStaff staff = new TechFixStaff
                {
                    staffName = staffName,
                    username = username,
                    password = password
                };


                int result = techFixService.AddNewStaff(staff);

                if (result > 0)
                {
                    MessageBox.Show("Staff is not added. Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadDefaults();

                MessageBox.Show("Staff successfully added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                if (staffListView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = staffListView.SelectedRows[0];

                    if (selectedRow.Cells["staffId"].Value == null)
                    {
                        MessageBox.Show("Please select a staff to update.", "Staff Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string staffName = nameTb.Text.Trim();
                    string username = usernameTb.Text.Trim().Replace(" ", "");
                    string password = passwordTb.Text.Trim();
                    string currentUsername = (string)selectedRow.Cells["username"].Value;

                    if (string.IsNullOrEmpty(staffName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
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
                        foreach (DataGridViewRow row in staffListView.Rows)
                        {
                            if (row.Cells["username"].Value != null && (string)row.Cells["username"].Value == username)
                            {
                                MessageBox.Show("This username is already in use. Try a new one.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    TechFixStaff staff = new TechFixStaff
                    {
                        staffId = (int)selectedRow.Cells["staffId"].Value,
                        staffName = staffName,
                        username = username,
                        password = password
                    };

                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to update?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int result = techFixService.UpdateStaff(staff);
                        if (result > 0)
                        {
                            MessageBox.Show("Update failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        LoadDefaults();
                        MessageBox.Show($"'{staff.staffName}' has been updated.", "Staff Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a staff to update.", "No Staff Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (staffListView.SelectedRows.Count > 0)
                {


                    DataGridViewRow selectedRow = staffListView.SelectedRows[0];


                    int staffId = (int)selectedRow.Cells["staffId"].Value;
                    

                    DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove the '{selectedRow.Cells["staffName"].Value}' ?",
                                          "Confirm Clear",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
                    int result = 0;
                    if (dialogResult == DialogResult.Yes)
                    {
                        result = techFixService.DeleteStaff(staffId);
                        
                        MessageBox.Show($"'{selectedRow.Cells["staffName"].Value}' has been removed.", "Staff removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDefaults();
                    }
                    else
                    {
                        return;
                    }

                    if (result > 0)
                    {
                        MessageBox.Show("Staff isn't remove. Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
