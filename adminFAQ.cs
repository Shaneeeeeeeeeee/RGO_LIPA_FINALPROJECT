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
    public partial class adminFAQ : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";



        public adminFAQ()
        {
            InitializeComponent();
            faqDataGridView.RowTemplate.Height = 150;

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form (studentOrders form)
            this.Close();

            // Open the login form
            login loginForm = new login();
            loginForm.Show();
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

        private void adminFAQ_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rGO_LIPADataSet.faq' table. You can move, or remove it, as needed.
            this.faqTableAdapter.Fill(this.rGO_LIPADataSet.faq);

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check if the user confirmed
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Save changes to the database
                    SaveChanges();
                }
                catch (Exception ex)
                {
                    // Display an error message if an exception occurs
                    MessageBox.Show("An error occurred while saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveChanges()
        {
            // Update the database with changes from the DataGridView
            this.Validate();
            this.faqBindingSource.EndEdit();
            this.faqTableAdapter.Update(this.rGO_LIPADataSet.faq);
            MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
