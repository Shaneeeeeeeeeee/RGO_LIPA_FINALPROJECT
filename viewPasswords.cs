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
    public partial class viewPasswords : Form
    {
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public viewPasswords()
        {
            InitializeComponent();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Implement search functionality based on SRCODE or STAFFID
            string searchText = searchTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                // Perform search and display results
                // You can choose to implement this functionality based on your database schema
            }
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // SHOW HERE THE SELECTED DATA 
        }

        private void studentBtn_Click(object sender, EventArgs e)
        {
            // Retrieve student information and display passwords
            DisplayPasswords("STUDENT", "SRCODE");
        }

        private void rgostaffBtn_Click(object sender, EventArgs e)
        {
            // Retrieve RGO staff information and display passwords
            DisplayPasswords("RGO_STAFFS", "STAFFID");
        }

        private void otherstaffBtn_Click(object sender, EventArgs e)
        {
            // Retrieve other staff information and display passwords
            DisplayPasswords("OTHER_STAFFS", "STAFFID");
        }

        private void DisplayPasswords(string tableName, string idColumnName)
        {
            string searchText = searchTextBox.Text.Trim();
            if (int.TryParse(searchText, out int searchID))
            {
                string query = $"SELECT * FROM {tableName} WHERE {idColumnName} = @ID";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@ID", searchID);

                        try
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            DataGridView.DataSource = dataTable;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetStudentBtn_Click(object sender, EventArgs e)
        {
            ResetPassword("STUDENT", "SRCODE");
        }

        private void resetRgoBtn_Click(object sender, EventArgs e)
        {
            ResetPassword("RGO_STAFFS", "STAFFID");
        }

        private void resetOtherBtn_Click(object sender, EventArgs e)
        {
            ResetPassword("OTHER_STAFFS", "STAFFID");
        }

        private void ResetPassword(string tableName, string idColumnName)
        {
            string searchText = searchTextBox.Text.Trim();
            string newPassword = "default123"; // Default password

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter a valid SRCODE or STAFFID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ask the user for confirmation before resetting the password
            DialogResult result = MessageBox.Show("Are you sure you want to reset the password to 'default123'?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Determine the type of the ID column to handle it correctly
                bool isNumeric = int.TryParse(searchText, out int searchID);

                // Update the password in the database
                bool passwordUpdated = isNumeric
                    ? UpdatePassword(tableName, idColumnName, searchID, newPassword)
                    : UpdatePassword(tableName, idColumnName, searchText, newPassword);

                if (passwordUpdated)
                {
                    MessageBox.Show("Password reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to reset password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool UpdatePassword(string tableName, string idColumnName, int idValue, string newPassword)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = $"UPDATE {tableName} SET Password = @NewPassword WHERE {idColumnName} = @ID";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@ID", idValue);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private bool UpdatePassword(string tableName, string idColumnName, string idValue, string newPassword)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = $"UPDATE {tableName} SET Password = @NewPassword WHERE {idColumnName} = @ID";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@ID", idValue);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminAccounts adminAccountsForm = new adminAccounts();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminAccountsForm.ShowDialog();
        }
    }
}
