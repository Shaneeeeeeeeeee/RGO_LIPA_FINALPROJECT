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

namespace RGO_LIPA_FINALPROJECT
{
    public partial class studentFeedback : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public studentFeedback()
        {
            InitializeComponent();
            // Display SRCODE of the current student when the form loads
            DisplayCurrentStudentSRCODE();

            // Display student information when the form loads
            DisplayStudentInformation(SessionData.CurrentStudentSRCODE);

            // Start the timer to update the time and date
            timer1.Start();

           

            // Load all feedback data when form loads
            LoadFeedbackData();
        }


        private void DisplayCurrentStudentSRCODE()
        {
            // Retrieve SRCODE of the current student
            int currentStudentSRCODE = SessionData.CurrentStudentSRCODE;

            // Display SRCODE in the srcodeLabel
            srcodeLabel.Text = $"SRCODE: {currentStudentSRCODE}";
        }

        // Method to display student information
        private void DisplayStudentInformation(int srcode)
        {
            string query = "SELECT NAME FROM STUDENT WHERE SRCODE = @SRCODE";

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

        private void srcodeLabel_Click(object sender, EventArgs e)
        {
            //napindot lng
        }

        private void homeBtn_Click(object sender, EventArgs e)
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

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form (studentOrders form)
            this.Close();

            // Open the login form
            login loginForm = new login();
            loginForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update the label text with the current date and time
            labelDateTime.Text = DateTime.Now.ToString("MMMM dd, yyyy  hh:mm:ss tt");
        }

        private void LoadFeedbackData()
        {
            string query = "SELECT SRCODE, FEEDBACKS, DATEFB FROM FEEDBACKS";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                feedbackDataGridView.DataSource = dataTable;
            }
        }

        private void feedbackDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = feedbackDataGridView.Rows[e.RowIndex];
                feedbackTextBox.Text = row.Cells["FEEDBACKS"].Value.ToString();
            }
        }

        private void feedbackLabel_Click(object sender, EventArgs e)
        {
            // No action needed
        }

        private void addFeedbackBtn_Click(object sender, EventArgs e)
        {
            int srCode = SessionData.CurrentStudentSRCODE; // Use current student's SRCODE
            string feedback = feedbackTextBox.Text; // Assume you have a TextBox for feedback
            DateTime dateFb = DateTime.Now;

            // Check if feedback is empty before insertion
            if (!string.IsNullOrEmpty(feedback))
            {
                // Prompt the user to confirm posting feedback
                DialogResult result = MessageBox.Show("Are you sure you want to post this feedback?", "Confirm Feedback Posting", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Construct the query for insertion
                    string query = "INSERT INTO FEEDBACKS (SRCODE, FEEDBACKS, DATEFB) VALUES (@SRCODE, @FEEDBACKS, @DATEFB)";

                    // Open connection and execute the insertion query
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@SRCODE", srCode);
                            cmd.Parameters.AddWithValue("@FEEDBACKS", feedback);
                            cmd.Parameters.AddWithValue("@DATEFB", dateFb);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Refresh the DataGridView
                    LoadFeedbackData();
                }
            }
            else
            {
                MessageBox.Show("Feedback cannot be empty.");
            }
        }


        private void updateFeedbackBtn_Click(object sender, EventArgs e)
        {
            int srCode = SessionData.CurrentStudentSRCODE; // Use current student's SRCODE
            string feedback = feedbackTextBox.Text; // Assume you have a TextBox for feedback

            if (feedbackDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = feedbackDataGridView.SelectedRows[0];
                int selectedSrCode = int.Parse(selectedRow.Cells["SRCODE"].Value.ToString());

                if (selectedSrCode == srCode) // Only allow update if SRCODE matches the current student
                {
                    string query = "UPDATE FEEDBACKS SET FEEDBACKS = @FEEDBACKS WHERE SRCODE = @SRCODE";

                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@SRCODE", srCode);
                            cmd.Parameters.AddWithValue("@FEEDBACKS", feedback);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadFeedbackData(); // Refresh the DataGridView
                }
                else
                {
                    MessageBox.Show("You can only update your own feedback.");
                }
            }
        }

        private void deleteFeedbackBtn_Click(object sender, EventArgs e)
        {
            if (feedbackDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = feedbackDataGridView.SelectedRows[0];
                int srCode = int.Parse(selectedRow.Cells["SRCODE"].Value.ToString());

                if (srCode == SessionData.CurrentStudentSRCODE) // Only allow deletion if SRCODE matches the current student
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this feedback?", "Delete Feedback", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string query = "DELETE FROM FEEDBACKS WHERE SRCODE = @SRCODE";

                        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                        {
                            connection.Open();
                            using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@SRCODE", srCode);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        LoadFeedbackData(); // Refresh the DataGridView
                    }
                }
                else
                {
                    MessageBox.Show("You can only delete your own feedback.");
                }
            }
        }

        private void myFeedbackBtn_Click(object sender, EventArgs e)
        {
            int srCode = SessionData.CurrentStudentSRCODE; // Use current student's SRCODE
            string query = "SELECT SRCODE, FEEDBACKS, DATEFB FROM FEEDBACKS WHERE SRCODE = @SRCODE";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@SRCODE", srCode);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                feedbackDataGridView.DataSource = dataTable;
            }
        }
    }
}
