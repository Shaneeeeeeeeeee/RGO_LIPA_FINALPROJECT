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
    public partial class adminStudents : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public adminStudents()
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Gather input from textboxes
            string name = nameTextBox.Text;
            string srcode = srcodeTextBox.Text;
            string department = departmentTextBox.Text;
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;

            // Confirm details with the user
            DialogResult result = MessageBox.Show("Are you 100% sure about the details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Insert into the database
                InsertStudent(srcode, name, department, email, password);
                // Refresh the DataGridView
                LoadStudentData();
            }
        }

        private void InsertStudent(string srcode, string name, string department, string email, string password)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO STUDENT (SRCODE, NAME, DEPARTMENT, EMAIL, PASSWORD) " +
                                   "VALUES (@srcode, @name, @department, @email, crypt(@password, gen_salt('bf')))";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("srcode", int.Parse(srcode));
                        cmd.Parameters.AddWithValue("name", name);
                        cmd.Parameters.AddWithValue("department", department);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("password", password);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student details added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadStudentData()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM STUDENT";
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        studentDataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void adminStudents_Load(object sender, EventArgs e)
        {
            // Load student data when the form loads
            LoadStudentData();
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

        private void staffBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the Admin form
            adminStaffs adminStaffsForm = new adminStaffs();

            // Hide the current form
            this.Hide();

            // Show the admin form
            adminStaffsForm.ShowDialog();
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

        private void studentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click events if needed
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
