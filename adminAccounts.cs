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
using Microsoft.VisualBasic;

namespace RGO_LIPA_FINALPROJECT
{
    public partial class adminAccounts : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public adminAccounts()
        {
            InitializeComponent();
            LoadStudentData();
            studentDataGridView.CellEndEdit += StudentDataGridView_CellEndEdit;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form (adminAccounts form)
            this.Close();

            // Open the login form
            login loginForm = new login();
            loginForm.Show();
        }

        private void LoadStudentData()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT SRCODE, NAME, DEPARTMENT, EMAIL FROM STUDENT";
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

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            (studentDataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("NAME LIKE '%{0}%' OR DEPARTMENT LIKE '%{0}%' OR EMAIL LIKE '%{0}%'", searchTextBox.Text);
        
        
        }

        private void StudentDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Capture the edited cell value if needed
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (studentDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = studentDataGridView.SelectedRows[0];
                int srcode = int.Parse(row.Cells["SRCODE"].Value.ToString());
                string name = row.Cells["NAME"].Value.ToString();
                string department = row.Cells["DEPARTMENT"].Value.ToString();
                string email = row.Cells["EMAIL"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to update the selected student details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var connection = new NpgsqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "UPDATE STUDENT SET NAME=@name, DEPARTMENT=@department, EMAIL=@email WHERE SRCODE=@srcode";
                            using (var cmd = new NpgsqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("name", name);
                                cmd.Parameters.AddWithValue("department", department);
                                cmd.Parameters.AddWithValue("email", email);
                                cmd.Parameters.AddWithValue("srcode", srcode);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Student details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadStudentData();
                            }
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
                MessageBox.Show("No student selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (studentDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = studentDataGridView.SelectedRows[0];
                int srcode = int.Parse(row.Cells["SRCODE"].Value.ToString());

                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete the selected student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (var connection = new NpgsqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "DELETE FROM STUDENT WHERE SRCODE=@srcode";
                            using (var cmd = new NpgsqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("srcode", srcode);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Student details deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadStudentData();
                            }
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
                MessageBox.Show("No student selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void studentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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


        // Inside your main form class

        private void viewPasswordsBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the PasswordPromptForm
            using (var passwordPromptForm = new PasswordPromptForm())
            {
                // Show the PasswordPromptForm to enter the password
                if (passwordPromptForm.ShowDialog() == DialogResult.OK)
                {
                    // Hide the current form
                    this.Hide();

                    // Create an instance of the viewPasswordsForm
                    var viewPasswordsForm = new viewPasswords();

                    // Show the viewPasswordsForm
                    viewPasswordsForm.ShowDialog();

                    // After the viewPasswordsForm is closed, show the current form again
                    this.Show();
                }
            }
        }



    }
}
