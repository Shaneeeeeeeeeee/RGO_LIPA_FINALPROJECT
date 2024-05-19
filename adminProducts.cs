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
    public partial class adminProducts : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public adminProducts()
        {
            InitializeComponent();

            itemDataGridView.RowTemplate.Height = 150;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form
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

        private void adminProducts_Load(object sender, EventArgs e)
        {
            // Set column names if they are not automatically set by DataSource
            itemDataGridView.AutoGenerateColumns = true;
            // Load data into the DataGridView
            LoadData();
        }

        private void LoadData()
        {
            string query = "SELECT ITEMID, NAMEOFITEM, DESCRIPTION, SIZEOFITEM, PRICE, AVAILABLESTOCKS, LAST_UPDATED FROM ITEM";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    itemDataGridView.DataSource = dataTable;

                    // Ensure the columns are named correctly
                    if (itemDataGridView.Columns["ITEMID"] != null)
                    {
                        itemDataGridView.Columns["ITEMID"].HeaderText = "Item ID";
                    }
                    if (itemDataGridView.Columns["NAMEOFITEM"] != null)
                    {
                        itemDataGridView.Columns["NAMEOFITEM"].HeaderText = "Name of Item";
                    }
                    if (itemDataGridView.Columns["DESCRIPTION"] != null)
                    {
                        itemDataGridView.Columns["DESCRIPTION"].HeaderText = "Description";
                    }
                    if (itemDataGridView.Columns["SIZEOFITEM"] != null)
                    {
                        itemDataGridView.Columns["SIZEOFITEM"].HeaderText = "Size of Item";
                    }
                    if (itemDataGridView.Columns["PRICE"] != null)
                    {
                        itemDataGridView.Columns["PRICE"].HeaderText = "Price";
                    }
                    if (itemDataGridView.Columns["AVAILABLESTOCKS"] != null)
                    {
                        itemDataGridView.Columns["AVAILABLESTOCKS"].HeaderText = "Available Stocks";
                    }
                    if (itemDataGridView.Columns["LAST_UPDATED"] != null)
                    {
                        itemDataGridView.Columns["LAST_UPDATED"].HeaderText = "Last Updated";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void addBtn_Click(object sender, EventArgs e)
        {
            // Retrieve data from textboxes
            int itemId = int.Parse(itemidTextBox.Text.Trim()); // Assuming the ITEMID is an integer
            string nameOfItem = nameofitemTextBox.Text.Trim();
            string description = descriptionTextBox.Text.Trim();
            string size = sizeTextBox.Text.Trim();
            decimal price = decimal.Parse(priceTextBox.Text.Trim());
            int availableStocks = int.Parse(stocksTextBox.Text.Trim());

            // Show a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to add this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Insert data into the database
                InsertItem(itemId, nameOfItem, description, size, price, availableStocks);

                // Refresh the DataGridView after insertion
                LoadData();
            }
        }


        private void InsertItem(int itemId, string nameOfItem, string description, string size, decimal price, int availableStocks)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    // SQL query to insert an item
                    string query = @"
                INSERT INTO ITEM (ITEMID, NAMEOFITEM, DESCRIPTION, SIZEOFITEM, PRICE, AVAILABLESTOCKS, LAST_UPDATED)
                VALUES (@ItemId, @NameOfItem, @Description, @Size, @Price, @AvailableStocks, CURRENT_TIMESTAMP)
            ";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@ItemId", itemId);
                        command.Parameters.AddWithValue("@NameOfItem", nameOfItem);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Size", size);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@AvailableStocks", availableStocks);

                        // Open the connection
                        connection.Open();
                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void updateBtn_Click(object sender, EventArgs e)
        {
            // Check if any changes have been made in the DataGridView
            DataTable changes = ((DataTable)itemDataGridView.DataSource).GetChanges();

            if (changes == null)
            {
                MessageBox.Show("No changes to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Show a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        // Open the connection
                        connection.Open();

                        // Begin a transaction
                        using (NpgsqlTransaction transaction = connection.BeginTransaction())
                        {
                            foreach (DataRow row in changes.Rows)
                            {
                                int itemId = Convert.ToInt32(row["ITEMID"]);

                                // Create the update query dynamically
                                StringBuilder queryBuilder = new StringBuilder("UPDATE ITEM SET ");

                                foreach (DataColumn column in changes.Columns)
                                {
                                    if (column.ColumnName != "ITEMID")
                                    {
                                        queryBuilder.Append($"{column.ColumnName} = @{column.ColumnName}, ");
                                    }
                                }

                                // Remove the last comma and space
                                queryBuilder.Length -= 2;

                                // Add the WHERE clause
                                queryBuilder.Append(" WHERE ITEMID = @ItemId");

                                string query = queryBuilder.ToString();

                                using (NpgsqlCommand command = new NpgsqlCommand(query, connection, transaction))
                                {
                                    // Add parameters for each column except ITEMID
                                    foreach (DataColumn column in changes.Columns)
                                    {
                                        if (column.ColumnName != "ITEMID")
                                        {
                                            command.Parameters.AddWithValue($"@{column.ColumnName}", row[column]);
                                        }
                                    }

                                    // Add parameter for ITEMID
                                    command.Parameters.AddWithValue("@ItemId", itemId);

                                    // Execute the update command
                                    command.ExecuteNonQuery();
                                }
                            }

                            // Commit the transaction
                            transaction.Commit();

                            // Show a success message
                            MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Refresh the DataGridView after updating
                LoadData();
            }
        }





        private void deleteBtn_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (itemDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Get the selected row data
                DataRowView selectedRow = (DataRowView)itemDataGridView.SelectedRows[0].DataBoundItem;

                // Get the value of the ITEMID from the selected row
                int itemId = Convert.ToInt32(selectedRow["ITEMID"]);

                // Check for connections before deletion
                if (CheckItemConnections(itemId))
                {
                    MessageBox.Show("This item cannot be deleted because it has connections in orders.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Show a confirmation dialog
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the item
                    DeleteItem(itemId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckItemConnections(int itemId)
        {
            bool hasConnections = false;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    // Check if the item has connections in the ORDER_TABLE
                    string query = "SELECT COUNT(*) FROM ORDER_TABLE WHERE ITEMID = @ItemId";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemId", itemId);

                        connection.Open();

                        // Execute the command and get the number of connections
                        int connectionCount = Convert.ToInt32(command.ExecuteScalar());
                        if (connectionCount > 0)
                        {
                            hasConnections = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking item connections: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return hasConnections;
        }


        private void DeleteItem(int itemId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM ITEM WHERE ITEMID=@ItemId";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ItemId", itemId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh DataGridView
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("No item selected or invalid item ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
    }
}
