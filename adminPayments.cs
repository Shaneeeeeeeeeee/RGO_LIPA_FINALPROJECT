using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGO_LIPA_FINALPROJECT
{
    public partial class adminPayments : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public adminPayments()
        {
            InitializeComponent();
            // Link the TextChanged event handler to the searchTextBox
            searchTextBox.TextChanged += searchTextBox_TextChanged;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form (adminPayments form)
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

        private void adminPayments_Load(object sender, EventArgs e)
        {
            // Load data from the payment table along with the SRCODE
            LoadPaymentData();
        }

        private void LoadPaymentData(string srcodeFilter = null)
        {
            try
            {
                // Define your SQL query here, selecting all payment data along with SRCODE
                string query = @"
            SELECT o.SRCODE, p.*
            FROM PAYMENT p
            INNER JOIN ORDER_TABLE o ON p.ORDERID = o.ORDERID";

                // Add SRCODE filter if provided
                if (!string.IsNullOrEmpty(srcodeFilter))
                {
                    query += " WHERE o.SRCODE = @SRCODE";
                }

                // Clear existing data in the DataGridView
                paymentDataGridView.DataSource = null;

                // Create a new DataTable to hold the payment data
                DataTable dataTable = new DataTable();

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Add SRCODE parameter if filter is provided
                        if (!string.IsNullOrEmpty(srcodeFilter))
                        {
                            // Parse srcodeFilter as integer
                            if (int.TryParse(srcodeFilter, out int srcode))
                            {
                                command.Parameters.AddWithValue("@SRCODE", srcode);
                            }
                            else
                            {
                                MessageBox.Show("Invalid SRCODE. Please enter a numeric value.");
                                return;
                            }
                        }

                        // Open the connection
                        connection.Open();

                        // Execute the command and fill the DataTable with data from the database
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }

                // Bind the DataTable to the DataGridView
                paymentDataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("An error occurred while loading payment data: " + ex.Message);
            }
        }



        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Get the SRCODE filter from the searchTextBox
            string srcodeFilter = searchTextBox.Text.Trim();

            // If the search box is empty, reload all payment data
            if (string.IsNullOrEmpty(srcodeFilter))
            {
                LoadPaymentData();
                return;
            }

            // Validate if the input can be parsed as an integer
            if (int.TryParse(srcodeFilter, out _))
            {
                // Reload payment data with the SRCODE filter
                LoadPaymentData(srcodeFilter);
            }
            else
            {
                // Display a message if SRCODE is not valid
                MessageBox.Show("Invalid SRCODE. Please enter a numeric value.");
            }
        }


        private void updateBtn_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check if the user confirmed
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Update the database with changes from the DataGridView
                    UpdateDatabase();
                }
                catch (Exception ex)
                {
                    // Display an error message if an exception occurs
                    MessageBox.Show("An error occurred while saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateDatabase()
        {
            // Get the DataTable bound to the DataGridView
            DataTable dataTable = (DataTable)paymentDataGridView.DataSource;

            // Check if there are any changes in the DataTable
            if (dataTable != null && dataTable.GetChanges() != null)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    // Create a new NpgsqlDataAdapter and command builder
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter())
                    {
                        // Specify the SQL update command to update the database
                        string updateCommand = @"
                    UPDATE PAYMENT 
                    SET ORDERID = @ORDERID, 
                        STAFFID = @STAFFID, 
                        DATEPAID = @DATEPAID, 
                        NOTE = @NOTE
                    WHERE PAYMENTID = @PAYMENTID";

                        // Set the update command for the adapter
                        adapter.UpdateCommand = new NpgsqlCommand(updateCommand, connection);

                        // Add parameters for the update command
                        adapter.UpdateCommand.Parameters.Add("@ORDERID", NpgsqlTypes.NpgsqlDbType.Integer, 0, "ORDERID");
                        adapter.UpdateCommand.Parameters.Add("@STAFFID", NpgsqlTypes.NpgsqlDbType.Integer, 0, "STAFFID");
                        adapter.UpdateCommand.Parameters.Add("@DATEPAID", NpgsqlTypes.NpgsqlDbType.Date, 0, "DATEPAID");
                        adapter.UpdateCommand.Parameters.Add("@NOTE", NpgsqlTypes.NpgsqlDbType.Text, 0, "NOTE");
                        adapter.UpdateCommand.Parameters.Add("@PAYMENTID", NpgsqlTypes.NpgsqlDbType.Integer, 0, "PAYMENTID");

                        // Check if SRCODE is being updated
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                var originalSRCODE = row["SRCODE", DataRowVersion.Original];
                                var newSRCODE = row["SRCODE", DataRowVersion.Current];
                                if (!originalSRCODE.Equals(newSRCODE))
                                {
                                    MessageBox.Show("You cannot update SRCODE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                        // Update the database with changes from the DataTable
                        adapter.Update(dataTable);
                    }
                }

                // Refresh the DataGridView to reflect changes from the database
                LoadPaymentData();
            }
        }




        // Method to get NpgsqlDbType based on .NET data type
        // Method to get NpgsqlDbType based on .NET data type
        private NpgsqlTypes.NpgsqlDbType GetNpgsqlDbType(Type type)
        {
            if (type == typeof(int))
            {
                return NpgsqlTypes.NpgsqlDbType.Integer;
            }
            else if (type == typeof(string))
            {
                return NpgsqlTypes.NpgsqlDbType.Text;
            }
            else if (type == typeof(DateTime))
            {
                return NpgsqlTypes.NpgsqlDbType.Date; // Change to Date for DATEPAID column
            }
            // Add more mappings for other data types as needed
            else
            {
                throw new ArgumentException($"Unsupported data type: {type.Name}");
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

        private void paymentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // GRID ONLY
        }


        private DataTable printDataTable;

        private void printBtn_Click(object sender, EventArgs e)
        {
            int srcode;
            if (!int.TryParse(searchTextBox.Text, out srcode))
            {
                MessageBox.Show("Please enter a valid SRCODE to print.");
                return;
            }

            string query =
                @"SELECT 
            s.SRCODE,
            p.PAYMENTID, 
            p.ORDERID, 
            p.STAFFID, 
            p.DATEPAID, 
            p.NOTE, 
            i.ITEMID, 
            i.PRICE, 
            o.DATEORDERED
        FROM PAYMENT p
        INNER JOIN ORDER_TABLE o ON p.ORDERID = o.ORDERID
        INNER JOIN ITEM i ON o.ITEMID = i.ITEMID
        INNER JOIN STUDENT s ON o.SRCODE = s.SRCODE
        WHERE p.DATEPAID IS NOT NULL
        AND s.SRCODE = @SRCODE::int";

            try
            {
                // Create a new DataTable to hold the payment data
                DataTable dataTable = new DataTable();

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SRCODE", srcode);
                        connection.Open();
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No paid orders found for the provided SRCODE.");
                    return;
                }

                // Assign the retrieved data to the printDataTable variable
                printDataTable = dataTable;

                // Create a PrintDocument and set up printing
                PrintDocument printDocument = new PrintDocument();
                printDocument.DefaultPageSettings.Landscape = true; // Set to landscape
                printDocument.PrintPage += PrintDocument_PrintPage;

                // Show print dialog and print if user confirms
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while preparing data for printing: " + ex.Message);
            }
        }




        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 10); // Decreased font size
            Brush brush = Brushes.Black;
            Pen pen = new Pen(Brushes.Black, 1f); // Pen for drawing lines
            float lineHeight = font.GetHeight() + 30; // Decreased line height
            float startX = e.MarginBounds.Left;
            float startY = e.MarginBounds.Top;
            float currentY = startY;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;

            // Define column widths
            int[] columnWidths = { 80, 80, 80, 120, 115, 80, 80, 80, 115 }; // Adjusted column widths
            string[] headers = { "SRCODE", "Payment ID", "Staff ID", "Payment Note", "Date Paid", "Order ID", "Item ID", "Price", "Date Ordered" };

            // Draw header
            float currentX = startX;
            for (int i = 0; i < headers.Length; i++)
            {
                RectangleF headerRect = new RectangleF(currentX, currentY, columnWidths[i], lineHeight);
                graphics.DrawString(headers[i], font, brush, headerRect, format);
                graphics.DrawRectangle(pen, Rectangle.Round(headerRect));
                currentX += columnWidths[i];
            }
            currentY += lineHeight;

            // Draw rows
            if (printDataTable != null)
            {
                foreach (DataRow row in printDataTable.Rows)
                {
                    currentX = startX;
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        string text = row[i].ToString();
                        // Wrap text if it's too long
                        if (text.Length > 8) // Adjust the length threshold as needed
                        {
                            text = text.Substring(0, 15) + "\n" + text.Substring(15);
                        }
                        RectangleF cellRect = new RectangleF(currentX, currentY, columnWidths[i], lineHeight);
                        graphics.DrawString(text, font, brush, cellRect, format);
                        graphics.DrawRectangle(pen, Rectangle.Round(cellRect));
                        currentX += columnWidths[i];
                    }
                    currentY += lineHeight;

                    // Check if we need a new page
                    if (currentY + lineHeight > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
            }

            e.HasMorePages = false;
        }


    }
}
