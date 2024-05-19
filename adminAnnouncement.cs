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
    public partial class adminAnnouncement : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public adminAnnouncement()
        {
            InitializeComponent();
            // Display staff information when the form loads
            DisplayCurrentStaffInformation();
        }

        private void DisplayCurrentStaffInformation()
        {
            // Retrieve staff ID of the current RGO staff member
            int currentStaffId = SessionData.StaffID;

            string query = "SELECT NAME FROM RGO_STAFFS WHERE STAFFID = @StaffID";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", currentStaffId);

                    try
                    {
                        connection.Open();
                        NpgsqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            nameLabel.Text = "NAME: " + reader["NAME"].ToString();
                            staffidLabel.Text = "STAFFID: " + currentStaffId.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions, e.g., log the error
                        Console.WriteLine("Error retrieving staff information: " + ex.Message);
                    }
                }
            }
        }


        private void LoadData()
        {
            // DONT REMOVE
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT announcementid, title, staffid, announcement, dateannounced FROM announcement";
                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    feedbackDataGridView.DataSource = dt;
                }
            }
        }

        private void feedbackDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // DONT REMOVE
        }


        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {
            // DONT REMOVE
        }

        private void myAnnouncementBtn_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT announcementid, title, announcement, dateannounced FROM announcement WHERE staffid = @staffid";
                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("staffid", SessionData.StaffID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    feedbackDataGridView.DataSource = dt;
                }
            }
        }

        private void adminAnnouncement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rGO_LIPADataSet.announcement' table. You can move, or remove it, as needed.
            this.announcementTableAdapter.Fill(this.rGO_LIPADataSet.announcement);

            // Load data into the DataGridView
            LoadData();

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form (studentOrders form)
            this.Close();

            // Open the login form
            login loginForm = new login();
            loginForm.Show();
        }

        private void addAnnouncementBtn_Click(object sender, EventArgs e)
        {
            // DONT REMOVE
            string title = titleTextBox.Text;
            string announcement = announcementTextBox.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(announcement))
            {
                MessageBox.Show("Title and Announcement cannot be empty.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to add this announcement?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO announcement (title, staffid, announcement, dateannounced) VALUES (@title, @staffid, @announcement, @dateannounced)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("title", title);
                        cmd.Parameters.AddWithValue("staffid", SessionData.StaffID);
                        cmd.Parameters.AddWithValue("announcement", announcement);
                        cmd.Parameters.AddWithValue("dateannounced", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
        }

        private void updateAnnouncementBtn_Click(object sender, EventArgs e)
        {
            // DONT REMOVE
            if (feedbackDataGridView.SelectedRows.Count > 0)
            {
                int selectedAnnouncementId = Convert.ToInt32(feedbackDataGridView.SelectedRows[0].Cells["announcementid"].Value);

                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE announcement SET title = @title, announcement = @announcement WHERE announcementid = @announcementid AND staffid = @staffid";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("title", titleTextBox.Text);
                        cmd.Parameters.AddWithValue("announcement", announcementTextBox.Text);
                        cmd.Parameters.AddWithValue("announcementid", selectedAnnouncementId);
                        cmd.Parameters.AddWithValue("staffid", SessionData.StaffID);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
        }

        private void deleteAnnouncementBtn_Click(object sender, EventArgs e)
        {
            // DONT REMOVE
            if (feedbackDataGridView.SelectedRows.Count > 0)
            {
                int selectedAnnouncementId = Convert.ToInt32(feedbackDataGridView.SelectedRows[0].Cells["announcementid"].Value);

                // Ensure the announcement belongs to the current staff
                int staffIdOfSelectedAnnouncement = GetStaffIdOfAnnouncement(selectedAnnouncementId);
                if (staffIdOfSelectedAnnouncement != SessionData.StaffID)
                {
                    MessageBox.Show("You can't delete announcements that do not belong to you.");
                    return;
                }

                // Ask for confirmation before deletion
                if (MessageBox.Show("Are you sure you want to delete this announcement?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM announcement WHERE announcementid = @announcementid AND staffid = @staffid";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("announcementid", selectedAnnouncementId);
                            cmd.Parameters.AddWithValue("staffid", SessionData.StaffID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadData();
                }
            }
        }

        // Method to get the staff ID of the announcement
        private int GetStaffIdOfAnnouncement(int announcementId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT staffid FROM announcement WHERE announcementid = @announcementid";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("announcementid", announcementId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return -1; // Return -1 if announcement is not found or an error occurs
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
