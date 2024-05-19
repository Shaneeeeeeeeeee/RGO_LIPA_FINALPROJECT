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
using Npgsql;

namespace RGO_LIPA_FINALPROJECT
{
    public partial class adminOrders : Form
    {
        private DataTable dataTable;
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public adminOrders()
        {
            InitializeComponent();
        }

        private void adminOrders_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(string srcodeFilter = null)
        {
            try
            {
                string query = @"
                WITH OrderSummary AS (
                    SELECT
                        s.SRCODE,
                        string_agg(i.NAMEOFITEM, ', ') AS ordered_items,
                        o.PRICE AS item_price,
                        o.DATEORDERED,
                        p.STAFFID,
                        p.PAYMENTID,
                        p.NOTE AS payment_note,
                        p.DATEPAID
                    FROM
                        ORDER_TABLE o
                    JOIN
                        ITEM i ON o.ITEMID = i.ITEMID
                    JOIN
                        PAYMENT p ON o.ORDERID = p.ORDERID
                    JOIN
                        STUDENT s ON o.SRCODE = s.SRCODE
                    WHERE
                        (@SRCODE::int IS NULL OR s.SRCODE = @SRCODE::int)
                        AND p.DATEPAID IS NULL
                    GROUP BY
                        s.SRCODE,
                        o.PRICE,
                        o.DATEORDERED,
                        p.STAFFID,
                        p.PAYMENTID,
                        p.NOTE,
                        p.DATEPAID
                ),
                TotalOrders AS (
                    SELECT
                        SRCODE,
                        PRICE AS total_all_orders
                    FROM
                        ORDER_TABLE
                    WHERE
                        (@SRCODE::int IS NULL OR SRCODE = @SRCODE::int)
                )
                SELECT 
                    os.SRCODE, 
                    os.ordered_items, 
                    os.item_price, 
                    os.DATEORDERED, 
                    os.STAFFID, 
                    os.PAYMENTID, 
                    os.payment_note, 
                    os.DATEPAID
                FROM 
                    OrderSummary os
                
                ";

                dataTable = new DataTable();
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connectionString))
                {
                    if (!string.IsNullOrEmpty(srcodeFilter))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@SRCODE", int.Parse(srcodeFilter));
                    }
                    else
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@SRCODE", DBNull.Value);
                    }

                    adapter.Fill(dataTable);
                }

                orderDataGridView.DataSource = dataTable.Rows.Count > 0 ? dataTable : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadData(searchTextBox.Text);
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            login loginForm = new login();
            loginForm.Show();
        }

        private void viewMyAccountBtn_Click(object sender, EventArgs e)
        {
            adminMyAccount adminMyAccountForm = new adminMyAccount();
            this.Hide();
            adminMyAccountForm.ShowDialog();
            this.Show();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            int srcode;
            if (!int.TryParse(searchTextBox.Text, out srcode))
            {
                MessageBox.Show("Please enter a valid SRCODE to print.");
                return;
            }

            string query = @"
        WITH OrderSummary AS (
            SELECT
                s.SRCODE,
                string_agg(i.NAMEOFITEM, ', ') AS ordered_items,
                SUM(o.PRICE) AS total_price,
                o.DATEORDERED,
                p.STAFFID,
                p.PAYMENTID,
                p.NOTE AS payment_note,
                p.DATEPAID
            FROM
                ORDER_TABLE o
            JOIN
                ITEM i ON o.ITEMID = i.ITEMID
            JOIN
                PAYMENT p ON o.ORDERID = p.ORDERID
            JOIN
                STUDENT s ON o.SRCODE = s.SRCODE
            WHERE
                s.SRCODE = @SRCODE::int
                AND p.DATEPAID IS NULL
            GROUP BY
                s.SRCODE,
                o.DATEORDERED,
                p.STAFFID,
                p.PAYMENTID,
                p.NOTE,
                p.DATEPAID
        ),
        TotalOrders AS (
            SELECT
                SRCODE,
                SUM(PRICE) AS total_all_orders
            FROM
                ORDER_TABLE o
            JOIN
                PAYMENT p ON o.ORDERID = p.ORDERID
            WHERE
                SRCODE = @SRCODE::int
                AND p.DATEPAID IS NULL
            GROUP BY
                SRCODE
        )
        SELECT 
            os.SRCODE, 
            os.ordered_items, 
            os.total_price, 
            os.DATEORDERED, 
            os.STAFFID, 
            os.PAYMENTID, 
            os.payment_note, 
            os.DATEPAID
        FROM 
            OrderSummary os
        UNION ALL
        SELECT 
            SRCODE, 
            NULL AS ordered_items, 
            total_all_orders AS total_price, 
            NULL AS DATEORDERED, 
            NULL AS STAFFID, 
            NULL AS PAYMENTID, 
            NULL AS payment_note, 
            NULL AS DATEORDERED 
        FROM 
            TotalOrders;
    ";

            dataTable = new DataTable();

            try
            {
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@SRCODE", srcode);
                    adapter.Fill(dataTable);
                }

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No orders found for the provided SRCODE.");
                    return;
                }

                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                PrintDocument printDocument = new PrintDocument();
                printDocument.DefaultPageSettings.Landscape = true; // Set to landscape
                printDocument.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50); // Set margins
                printDocument.PrintPage += PrintDocument_PrintPage;
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while preparing data for printing: " + ex.Message);
            }
        }



        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;
            Pen pen = new Pen(Brushes.Black, 1f); // Pen for drawing lines
            float lineHeight = font.GetHeight() + 50; // Increased line height
            float startX = e.MarginBounds.Left;
            float startY = e.MarginBounds.Top;
            float currentY = startY;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;

            // Define column widths
            int[] columnWidths = { 100, 200, 100, 250, 100, 100, 100, 150 }; // Adjusted column widths
            string[] headers = { "SRCODE", "Ordered Items", "Total Price", "Date Ordered", "Staff ID", "Payment ID", "Payment Note", "Date Paid" };

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
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    currentX = startX;
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        string text = row[i].ToString();
                        // Wrap text if it's too long
                        if (text.Length > 25) // Adjust the length threshold as needed
                        {
                            text = text.Substring(0, 20) + "\n" + text.Substring(20);
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





        private void orderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if needed
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
