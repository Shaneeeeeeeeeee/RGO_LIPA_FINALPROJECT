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
    public partial class studentLogin : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public studentLogin()
        {
            InitializeComponent();

            viewPassBtn.Visible = false;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            // Show the login form
            login loginForm = new login();
            loginForm.Show();
            // Close the current form
            this.Hide();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string email = emailTxtBox.Text.Trim();
            string password = passTxtBox.Text;

            // Query to check if the email and password match in the database and retrieve the SRCODE
            // It checks both encrypted and plain text passwords
            string query = @"
        SELECT SRCODE FROM student 
        WHERE Email = @Email 
        AND (Password = crypt(@Password, Password) OR Password = @Password)
    ";

            // Using statement ensures the connection is properly closed even if an exception occurs
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null) // Check if a SRCODE is returned
                        {
                            int studentSRCODE = Convert.ToInt32(result);

                            // Save the student's SRCODE in the session data
                            SessionData.CurrentStudentSRCODE = studentSRCODE;

                            MessageBox.Show("Login successful!");

                            // Create an instance of studentHome form
                            studentHome studentHomeForm = new studentHome();

                            this.Hide();

                            // Show the studentHome form
                            studentHomeForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            passTxtBox.UseSystemPasswordChar = false;
            viewPassBtn.Visible = true;
            guna2ImageButton1.Visible = false;

        }

        private void viewPassBtn_Click(object sender, EventArgs e)
        {
            // Toggle the UseSystemPasswordChar property
            passTxtBox.UseSystemPasswordChar = true;
            guna2ImageButton1.Visible = true;
            viewPassBtn.Visible = false;
        }

        private void passTxtBox_TextChanged(object sender, EventArgs e)
        {
            passTxtBox.UseSystemPasswordChar = true;
        }
    }
}
