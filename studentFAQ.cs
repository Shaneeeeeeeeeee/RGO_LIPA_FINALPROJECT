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
    public partial class studentFAQ : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";


        public studentFAQ()
        {
            InitializeComponent();
            LoadFAQData();
            faqDataGridView.CellContentClick += faqDataGridView_CellContentClick;
            faqDataGridView.RowTemplate.Height = 150;
        }

        private void guna2Button3_Click(object sender, EventArgs e) // STUDENT HOME
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

        private void annoucementBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the student form
            studentAnnouncement studentAnnouncementForm = new studentAnnouncement();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentAnnouncementForm.ShowDialog();
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

        private void LoadFAQData()
        {
            string query = "SELECT TITLE, FAQ, DATEFAQ FROM FAQ";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                faqDataGridView.DataSource = dataTable;
            }
        }


        private void faqDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // wala 
        }
    }
}
