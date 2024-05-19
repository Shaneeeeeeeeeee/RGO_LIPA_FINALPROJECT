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
    public partial class otherStaffsView : Form
    {
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public otherStaffsView()
        {
            InitializeComponent();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form (otherStaffsView)
            this.Close();

            // Open the login form
            login loginForm = new login();
            loginForm.Show();
        }

        private void LoadDataToDataGridView(string query)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    otherStaffDataGridView.DataSource = dataTable;
                }
            }
        }

        private void announcementBtn_Click(object sender, EventArgs e)
        {
            // SELECT * FROM ANNOUNCEMENT
            string query = "SELECT * FROM ANNOUNCEMENT";
            LoadDataToDataGridView(query);
        }

        private void studentBtn_Click(object sender, EventArgs e)
        {
            // SELECT * FROM STUDENT
            string query = "SELECT * FROM STUDENT";
            LoadDataToDataGridView(query);
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            // SELECT * FROM RGO_STAFFS
            string query = "SELECT * FROM RGO_STAFFS";
            LoadDataToDataGridView(query);
        }

        private void productBtn_Click(object sender, EventArgs e)
        {
            // SELECT * FROM ITEM
            string query = "SELECT * FROM ITEM";
            LoadDataToDataGridView(query);
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            // SELECT * FROM ORDER_TABLE
            string query = "SELECT * FROM ORDER_TABLE";
            LoadDataToDataGridView(query);
        }

        private void paymentBtn_Click(object sender, EventArgs e)
        {
            // SELECT * FROM PAYMENT
            string query = "SELECT * FROM PAYMENT";
            LoadDataToDataGridView(query);
        }

        private void faqBtn_Click(object sender, EventArgs e)
        {
            // SELECT * FROM FAQ
            string query = "SELECT * FROM FAQ";
            LoadDataToDataGridView(query);
        }

        private void feedbackBtn_Click(object sender, EventArgs e)
        {
            // SELECT * FROM FEEDBACKS
            string query = "SELECT * FROM FEEDBACKS";
            LoadDataToDataGridView(query);
        }
    }
}
