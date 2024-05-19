using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGO_LIPA_FINALPROJECT
{
    public partial class studentAnnouncement : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";


        public studentAnnouncement()
        {
            InitializeComponent();
            announcementDataGridView.RowTemplate.Height = 150;
            LoadAnnouncementData();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form (studentOrders form)
            this.Close();

            // Open the login form
            login loginForm = new login();
            loginForm.Show();
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

        private void LoadAnnouncementData()
        {
            string query = "SELECT TITLE, ANNOUNCEMENT, DATEANNOUNCED FROM ANNOUNCEMENT";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                announcementDataGridView.DataSource = dataTable;                
            }
        }


        private void announcementDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on a valid cell
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewRow row = announcementDataGridView.Rows[e.RowIndex];
                string title = row.Cells["TITLE"].Value.ToString();
                string announcement = row.Cells["ANNOUNCEMENT"].Value.ToString();
                string dateAnnounced = row.Cells["DATEANNOUNCED"].Value.ToString();

                // Handle the cell click event, e.g., display the details in a MessageBox
                MessageBox.Show($"Title: {title}\nAnnouncement: {announcement}\nDate Announced: {dateAnnounced}");
            }
        }
    }
}
