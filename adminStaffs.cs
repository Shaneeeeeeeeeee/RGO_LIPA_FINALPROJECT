using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGO_LIPA_FINALPROJECT
{
    public partial class adminStaffs : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public adminStaffs()
        {
            InitializeComponent();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Open the login form
            login loginForm = new login();
            loginForm.Show();
        }

        private void adminStaffs_Load(object sender, EventArgs e)
        {
            // Load data into tables on form load
            LoadRgoStaffsData();
            LoadOtherStaffsData();
        }

        private void addrgoStaffBtn_Click(object sender, EventArgs e)
        {
            // Gather input from textboxes
            string name = nameTextBox.Text;
            string staffid = staffidTextBox.Text;
            string position = positionTextBox.Text;
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;

            // Confirm details with the user
            DialogResult result = MessageBox.Show("Are you 100% sure about the details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Insert into RGO_STAFFS
                InsertStaff("RGO_STAFFS", staffid, name, position, email, password);
                // Refresh DataGridView
                LoadRgoStaffsData();
            }
        }

        private void addotherStaffBtn_Click(object sender, EventArgs e)
        {
            // Gather input from textboxes
            string name = nameTextBox.Text;
            string staffid = staffidTextBox.Text;
            string position = positionTextBox.Text;
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;

            // Confirm details with the user
            DialogResult result = MessageBox.Show("Are you 100% sure about the details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Insert into OTHER_STAFFS
                InsertStaff("OTHER_STAFFS", staffid, name, position, email, password);
                // Refresh DataGridView
                LoadOtherStaffsData();
            }
        }

        private void InsertStaff(string tableName, string staffid, string name, string position, string email, string password)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"INSERT INTO {tableName} (STAFFID, NAME, POSITION, EMAIL, PASSWORD) " +
                                   "VALUES (@staffid, @name, @position, @email, crypt(@password, gen_salt('bf')))";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("staffid", int.Parse(staffid));
                        cmd.Parameters.AddWithValue("name", name);
                        cmd.Parameters.AddWithValue("position", position);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("password", password);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Staff details added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadRgoStaffsData()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT STAFFID, NAME, POSITION, EMAIL, PASSWORD FROM RGO_STAFFS";
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        rgoStaffsDataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadOtherStaffsData()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT STAFFID, NAME, POSITION, EMAIL, PASSWORD FROM OTHER_STAFFS";
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        otherStaffsDataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rgoStaffsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click events if needed
        }

        private void otherStaffsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click events if needed
        }

        private void announcementBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            adminAnnouncement adminAnnouncementForm = new adminAnnouncement();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminAnnouncementForm.ShowDialog();
        }

        private void studentBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            adminStudents adminStudentsForm = new adminStudents();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminStudentsForm.ShowDialog();
        }

        private void accBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            adminAccounts adminAccountsForm = new adminAccounts();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminAccountsForm.ShowDialog();
        }

        private void productBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            adminProducts adminProductsForm = new adminProducts();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminProductsForm.ShowDialog();
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            adminOrders adminOrdersForm = new adminOrders();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminOrdersForm.ShowDialog();
        }


        private void paymentBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            adminPayments adminPaymentsForm = new adminPayments();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminPaymentsForm.ShowDialog();
        }

        private void faqBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            adminFAQ adminFAQForm = new adminFAQ();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminFAQForm.ShowDialog();
        }

        private void feedbackBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            adminFeedback adminFeedbackForm = new adminFeedback();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminFeedbackForm.ShowDialog();
        }

        private void deletergoStaffBtn_Click(object sender, EventArgs e)
        {
            if (rgoStaffsDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row data
                DataGridViewRow row = rgoStaffsDataGridView.SelectedRows[0];
                string staffid = row.Cells[0].Value.ToString(); // Assuming staffid is the first column

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete the selected staff member?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Delete the staff member's details
                    DeleteStaff("RGO_STAFFS", staffid);
                    // Refresh DataGridView
                    LoadRgoStaffsData();
                }
            }
            else
            {
                MessageBox.Show("No staff member selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private bool CheckStaffConnections(string staffid)
        {
            bool hasConnections = false;

            // Check if the staff has connections in other tables
            // Implement your logic here to check for connections in other tables
            // For example:
            // Check if the staffid exists in other related tables
            // If it does, set hasConnections to true

            return hasConnections;
        }

        private void DeleteStaff(string tableName, string staffid)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM {tableName} WHERE STAFFID=@staffid";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("staffid", int.Parse(staffid));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Staff details deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No staff member selected or invalid staff ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void deleteotherStaffBtn_Click(object sender, EventArgs e)
        {
            if (otherStaffsDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow row = otherStaffsDataGridView.SelectedRows[0];

                if (row != null)
                {
                    // Assuming the staffid is in the first column (index 0)
                    string staffid = row.Cells[0].Value?.ToString();

                    if (!string.IsNullOrEmpty(staffid))
                    {
                        // Confirm deletion with the user
                        DialogResult result = MessageBox.Show("Are you sure you want to permanently delete the selected staff member?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            // Delete the staff member's details
                            DeleteOtherStaff("OTHER_STAFFS", staffid);
                            // Refresh DataGridView
                            LoadOtherStaffsData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected row does not contain staff ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No staff member selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No staff member selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void DeleteOtherStaff(string tableName, string staffid)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"DELETE FROM {tableName} WHERE STAFFID=@staffid";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("staffid", int.Parse(staffid));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Staff details deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No staff member selected or invalid staff ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void viewMyAccountBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminMyAccount adminMyAccountForm = new adminMyAccount();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminMyAccountForm.ShowDialog();
        }
    }
}
