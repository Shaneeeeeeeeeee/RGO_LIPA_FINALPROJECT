using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;


namespace RGO_LIPA_FINALPROJECT
{
    public partial class studentChangePassword : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";


        public studentChangePassword()
        {
            InitializeComponent();


            // Display SRCODE of the current student when the form loads
            DisplayCurrentStudentSRCODE();

            // Display student information when the form loads
            DisplayStudentInformation(SessionData.CurrentStudentSRCODE);

            // Start the timer to update the time and date
            timer1.Start();
        }


        private void DisplayCurrentStudentSRCODE()
        {
            // Retrieve SRCODE of the current student
            int currentStudentSRCODE = SessionData.CurrentStudentSRCODE;

            // Display SRCODE in the srcodeLabel
            srcodeLabel.Text = $"SRCODE: {currentStudentSRCODE}";
        }

        // Method to retrieve image data from pg_largeobject table
        private byte[] RetrieveImageData(int profileImageOid)
        {
            string query = "SELECT data FROM pg_largeobject WHERE loid = @LOID ORDER BY pageno";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LOID", profileImageOid);

                    try
                    {
                        connection.Open();
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            List<byte[]> chunks = new List<byte[]>();
                            while (reader.Read())
                            {
                                byte[] chunk = (byte[])reader["data"];
                                chunks.Add(chunk);
                            }
                            // Concatenate all chunks into a single byte array
                            return chunks.SelectMany(x => x).ToArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions, e.g., log the error
                        Console.WriteLine("Error retrieving image data: " + ex.Message);
                        return null;
                    }
                }
            }
        }

        // Method to display student information
        private void DisplayStudentInformation(int srcode)
        {
            string query = "SELECT NAME, EMAIL, DEPARTMENT, PROFILE_IMAGE FROM STUDENT WHERE SRCODE = @SRCODE";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SRCODE", srcode);

                    try
                    {
                        connection.Open();
                        NpgsqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            nameLabel.Text = reader["NAME"].ToString();
                            emailLabel.Text = "EMAIL: " + reader["EMAIL"].ToString();
                            departmentLabel.Text = "DEPARTMENT: " + reader["DEPARTMENT"].ToString();

                            // Check if profile image OID exists
                            if (!reader.IsDBNull(reader.GetOrdinal("PROFILE_IMAGE")))
                            {
                                int profileImageOid = Convert.ToInt32(reader["PROFILE_IMAGE"]);
                                byte[] imageData = RetrieveImageData(profileImageOid);
                                if (imageData != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        profilePictureBox.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    profilePictureBox.Image = null; // No profile image available
                                }
                            }
                            else
                            {
                                profilePictureBox.Image = null; // No profile image available
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions, e.g., log the error
                        Console.WriteLine("Error retrieving student information: " + ex.Message);
                    }
                }
            }
        }


        private void guna2Button3_Click(object sender, EventArgs e) //HOME BUTTON
        {
            // Create an instance of the student form
            studentHome studentHomeForm = new studentHome();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentHomeForm.ShowDialog();
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the student form
            studentOrders studentOrdersForm = new studentOrders();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentOrdersForm.ShowDialog();
        }

        private void announcementBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the student form
            studentAnnouncement studentAnnouncementForm = new studentAnnouncement();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentAnnouncementForm.ShowDialog();
        }

        private void faqBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the student form
            studentFAQ studentFAQForm = new studentFAQ();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentFAQForm.ShowDialog();
        }

        private void feedbackBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the student form
            studentFeedback studentFeedbackForm = new studentFeedback();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentFeedbackForm.ShowDialog();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form (studentOrders form)
            this.Close();

            // Open the login form
            login loginForm = new login();
            loginForm.Show();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string currentPassword = currentPasswordTxtBox.Text.Trim();
            string newPassword = newPasswordTxtBox.Text.Trim();
            string reEnteredNewPassword = reEnterNewTextBox.Text.Trim();

            // Check if the new password and re-entered password match
            if (newPassword != reEnteredNewPassword)
            {
                MessageBox.Show("New password and re-entered password do not match.");
                return;
            }

            // Retrieve SRCODE of the current student
            int currentSRCODE = SessionData.CurrentStudentSRCODE;

            // Retrieve the stored password from the database
            string storedPassword = RetrieveStoredPassword(currentSRCODE);

            // Verify if the entered current password matches the stored password
            if (!VerifyPassword(currentPassword, storedPassword))
            {
                MessageBox.Show("Incorrect current password.");
                return;
            }

            // Ask for confirmation before updating the password
            DialogResult result = MessageBox.Show("Are you sure you want to change your password? This action cannot be undone.", "Confirm Password Change", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return; // User canceled the operation
            }

            // Update the password in the database
            UpdatePassword(currentSRCODE, newPassword);

            MessageBox.Show("Password updated successfully.");
        }


        // Method to retrieve the stored password from the database
        private string RetrieveStoredPassword(int srcode)
        {
            string storedPassword = null;
            string query = "SELECT PASSWORD FROM STUDENT WHERE SRCODE = @SRCODE";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SRCODE", srcode);

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

        // Method to verify if the entered password matches the stored password
        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            // You can use a secure hashing algorithm like BCrypt for password hashing and verification
            // Here's an example using BCrypt.Net library for hashing and verification
            // You need to install the BCrypt.Net library via NuGet Package Manager

            // Check if the stored password is hashed using BCrypt
            if (BCrypt.Net.BCrypt.Verify(enteredPassword, storedPassword))
            {
                // The entered password matches the stored hashed password
                return true;
            }
            else
            {
                // The entered password does not match the stored hashed password
                return false;
            }
        }

        // Method to update the password in the database
        private void UpdatePassword(int srcode, string newPassword)
        {
            // Hash the new password before storing it in the database
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // Update the password for the student with SRCODE using the new hashed password
            string query = "UPDATE STUDENT SET PASSWORD = @NEWPASSWORD WHERE SRCODE = @SRCODE";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NEWPASSWORD", hashedPassword);
                    command.Parameters.AddWithValue("@SRCODE", srcode);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Password updated successfully
                        }
                        else
                        {
                            MessageBox.Show("Failed to update password.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating password: " + ex.Message);
                    }
                }
            }
        }



    }
}
