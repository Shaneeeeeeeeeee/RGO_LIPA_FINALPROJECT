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
    public partial class loginforAdmin : Form
    {
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public loginforAdmin()
        {
            InitializeComponent();
           viewPassBtn.Visible = false;


        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            // Instantiate the Login form
            login loginForm = new login();

            // Show the Login form
            loginForm.Show();

            // Optionally, you can hide the current form
            this.Hide();
        }


        private void loginbtn_Click(object sender, EventArgs e)
        {
            string email = emailTxtBox.Text.Trim();
            string password = passTxtBox.Text;

            // Query to check both encrypted and plain text passwords
            string query = @"
        SELECT staffid FROM rgo_staffs 
        WHERE Email = @Email 
        AND (Password = crypt(@Password, Password) OR Password = @Password)
    ";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int staffId = Convert.ToInt32(result);
                            SessionData.CurrentAdminID = staffId; // Store the StaffID in the static class

                            MessageBox.Show("Login successful!");

                            // Open the adminAnnouncement form
                            adminAnnouncement adminAnnouncementForm = new adminAnnouncement();
                            this.Hide();
                            adminAnnouncementForm.Show();
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



        private void otherstaffsLoginBtn_Click(object sender, EventArgs e)
        {
            string email = emailTxtBox.Text.Trim();
            string password = passTxtBox.Text;

            // Query to check both encrypted and plain text passwords
            string query = @"
        SELECT staffid FROM other_staffs 
        WHERE Email = @Email 
        AND (Password = crypt(@Password, Password) OR Password = @Password)
    ";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int staffId = Convert.ToInt32(result);
                            SessionData.CurrentAdminID = staffId; // Store the StaffID in the static class

                            MessageBox.Show("Login successful!");

                            // Open the otherStaffsView form
                            otherStaffsView otherStaffsViewForm = new otherStaffsView();
                            this.Hide();
                            otherStaffsViewForm.Show();
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

        private void passTxtBox_TextChanged(object sender, EventArgs e)
        {
            passTxtBox.UseSystemPasswordChar = true;
        }

   

        private void viewPassBtn_Click_1(object sender, EventArgs e)
        {
            // Toggle the UseSystemPasswordChar property
            passTxtBox.UseSystemPasswordChar = true;
            guna2ImageButton1.Visible = true;
            viewPassBtn.Visible = false;    
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            passTxtBox.UseSystemPasswordChar = false;
            viewPassBtn.Visible = true;
            guna2ImageButton1.Visible = false;

        }
    }
}
