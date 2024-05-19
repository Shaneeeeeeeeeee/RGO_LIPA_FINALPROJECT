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
    public partial class adminMyAccount : Form
    {
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public adminMyAccount()
        {
            InitializeComponent();

            DisplayAdminInformation();
        }

        private void DisplayAdminInformation()
        {
            string query = "SELECT NAME, POSITION, EMAIL FROM RGO_STAFFS WHERE STAFFID = @STAFFID";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@STAFFID", SessionData.CurrentAdminID);

                    try
                    {
                        connection.Open();
                        NpgsqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            nameLabel.Text = "Name: " + reader["NAME"].ToString();
                            positionLabel.Text = "Position: " + reader["POSITION"].ToString();
                            emailLabel.Text = "Email: " + reader["EMAIL"].ToString();
                            staffidLabel.Text = "Staff ID: " + SessionData.CurrentAdminID;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving admin information: " + ex.Message);
                    }
                }
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form (adminMyAccount)
            this.Close();

            // Open the login form
            login loginForm = new login();
            loginForm.Show();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string currentPassword = currentPasswordTxtBox.Text.Trim();
            string newPassword = newPasswordTxtBox.Text.Trim();
            string reEnteredNewPassword = reEnterNewTextBox.Text.Trim();

            // Check if the new password and re-entered password match
            if (newPassword != reEnteredNewPassword)
            {
                MessageBox.Show("New password and re-entered password do not match.");
                return;
            }

            // Confirm password update
            DialogResult result = MessageBox.Show("Are you sure you want to update the password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Retrieve the stored password from the database
            string storedPassword = RetrieveStoredPassword();

            // Verify if the entered current password matches the stored password
            if (!VerifyPassword(currentPassword, storedPassword))
            {
                MessageBox.Show("Incorrect current password.");
                return;
            }

            // Hash the new password
            string hashedPassword = HashPassword(newPassword);

            // Update the password in the database
            if (UpdatePassword(hashedPassword))
            {
                MessageBox.Show("Password updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update password.");
            }
        }

        private string RetrieveStoredPassword()
        {
            string storedPassword = null;
            string query = "SELECT PASSWORD FROM RGO_STAFFS WHERE STAFFID = @STAFFID";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@STAFFID", SessionData.CurrentAdminID);

                    try
                    {
                        connection.Open();
                        storedPassword = (string)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving stored password: " + ex.Message);
                    }
                }
            }

            return storedPassword;
        }


        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            // Implement password verification logic here
            // You can use a secure hashing algorithm like BCrypt for password hashing and verification
            // Example using BCrypt.Net library:
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPassword);
        }

        private string HashPassword(string password)
        {
            // Hash the password using a secure hashing algorithm like BCrypt
            // Example using BCrypt.Net library:
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool UpdatePassword(string hashedPassword)
        {
            string query = "UPDATE RGO_STAFFS SET PASSWORD = @PASSWORD WHERE STAFFID = @STAFFID";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PASSWORD", hashedPassword);
                    command.Parameters.AddWithValue("@STAFFID", SessionData.CurrentAdminID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating password: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        private void announcementBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminAnnouncement adminAnnouncementForm = new adminAnnouncement();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminAnnouncementForm.ShowDialog();
        }

        private void studentBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminStudents adminStudentsForm = new adminStudents();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminStudentsForm.ShowDialog();
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminStaffs adminStaffsForm = new adminStaffs();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminStaffsForm.ShowDialog();
        }

        private void accBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminAccounts adminAccountsForm = new adminAccounts();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminAccountsForm.ShowDialog();
        }

        private void productBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminProducts adminProductsForm = new adminProducts();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminProductsForm.ShowDialog();
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminOrders adminOrdersForm = new adminOrders();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminOrdersForm.ShowDialog();
        }

        private void paymentBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminPayments adminPaymentsForm = new adminPayments();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminPaymentsForm.ShowDialog();
        }

        private void faqBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminFAQ adminFAQForm = new adminFAQ();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminFAQForm.ShowDialog();
        }

        private void feedbackBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the admin form
            adminFeedback adminFeedbackForm = new adminFeedback();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminFeedbackForm.ShowDialog();
        }
    }
}
