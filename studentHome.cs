using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGO_LIPA_FINALPROJECT
{
    public partial class studentHome : Form
    {
        // Connection string
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public studentHome()
        {
            InitializeComponent();

            // Display SRCODE of the current student when the form loads
            DisplayCurrentStudentSRCODE();

            // Display student information when the form loads
            DisplayStudentInformation(SessionData.CurrentStudentSRCODE);

            // Start the timer to update the time and date
            timer1.Start();
        }

        private void DisplayCurrentStudentSRCODE()
        {
            // Retrieve SRCODE of the current student
            int currentStudentSRCODE = SessionData.CurrentStudentSRCODE;

            // Display SRCODE in the srcodeLabel
            srcodeLabel.Text = $"SRCODE: {currentStudentSRCODE}";
        }


        // Method to retrieve image data from pg_largeobject table
        private byte[] RetrieveImageData(int profileImageOid)
        {
            string query = "SELECT data FROM pg_largeobject WHERE loid = @LOID ORDER BY pageno";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LOID", profileImageOid);

                    try
                    {
                        connection.Open();
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            List<byte[]> chunks = new List<byte[]>();
                            while (reader.Read())
                            {
                                byte[] chunk = (byte[])reader["data"];
                                chunks.Add(chunk);
                            }
                            // Concatenate all chunks into a single byte array
                            return chunks.SelectMany(x => x).ToArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions, e.g., log the error
                        Console.WriteLine("Error retrieving image data: " + ex.Message);
                        return null;
                    }
                }
            }
        }

        // Method to display student information
        private void DisplayStudentInformation(int srcode)
        {
            string query = "SELECT NAME, EMAIL, DEPARTMENT, PROFILE_IMAGE FROM STUDENT WHERE SRCODE = @SRCODE";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SRCODE", srcode);

                    try
                    {
                        connection.Open();
                        NpgsqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            nameLabel.Text = reader["NAME"].ToString();
                            emailLabel.Text = "EMAIL: " + reader["EMAIL"].ToString();
                            departmentLabel.Text = "DEPARTMENT: " + reader["DEPARTMENT"].ToString();

                            // Check if profile image OID exists
                            if (!reader.IsDBNull(reader.GetOrdinal("PROFILE_IMAGE")))
                            {
                                int profileImageOid = Convert.ToInt32(reader["PROFILE_IMAGE"]);
                                byte[] imageData = RetrieveImageData(profileImageOid);
                                if (imageData != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        profilePictureBox.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    profilePictureBox.Image = null; // No profile image available
                                }
                            }
                            else
                            {
                                profilePictureBox.Image = null; // No profile image available
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions, e.g., log the error
                        Console.WriteLine("Error retrieving student information: " + ex.Message);
                    }
                }
            }
        }

       

        private void addProfileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Select Profile Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;

                // Use lo_import to insert the image file into pg_largeobject
                string query = "SELECT lo_import(:FileName)";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(":FileName", selectedFileName);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                int loId = Convert.ToInt32(result);

                                // Update the PROFILE_IMAGE column with the OID of the inserted image
                                UpdateProfileImage(loId);
                            }
                            else
                            {
                                MessageBox.Show("Failed to insert profile picture.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting profile picture: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void UpdateProfileImage(int loId)
        {
            int currentStudentSRCODE = SessionData.CurrentStudentSRCODE;
            string query = "UPDATE STUDENT SET PROFILE_IMAGE = @LOID WHERE SRCODE = @SRCODE";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LOID", loId);
                    command.Parameters.AddWithValue("@SRCODE", currentStudentSRCODE);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile picture added successfully.");
                            // Refresh student information to display the updated profile picture
                            DisplayStudentInformation(currentStudentSRCODE);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add profile picture.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding profile picture: " + ex.Message);
                    }
                }
            }
        }



        private void deleteProfileBtn_Click(object sender, EventArgs e)
        {
            int currentStudentSRCODE = SessionData.CurrentStudentSRCODE;
            string query = "UPDATE STUDENT SET PROFILE_IMAGE = NULL WHERE SRCODE = @SRCODE";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SRCODE", currentStudentSRCODE);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile picture deleted successfully from STUDENT table.");
                            // Refresh student information to remove the profile picture from display
                            DisplayStudentInformation(currentStudentSRCODE);

                            // Retrieve the profile image OID
                            string getImageOidQuery = "SELECT PROFILE_IMAGE FROM STUDENT WHERE SRCODE = @SRCODE";
                            command.CommandText = getImageOidQuery;
                            int profileImageOid = Convert.ToInt32(command.ExecuteScalar());

                            // Delete the profile picture from pg_largeobject
                            deleteProfilePictureFromLargeObject(profileImageOid);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete profile picture from STUDENT table.");
                        }
                    }
                    catch (Exception)
                    {
                        // Exception handling removed
                    }
                }
            }
        }


        private void deleteProfilePictureFromLargeObject(int profileImageOid)
        {
            string query = "SELECT lo_unlink(@LOID)";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LOID", profileImageOid);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Profile picture deleted from pg_largeobject successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting profile picture from pg_largeobject: " + ex.Message);
                    }
                }
            }
        }



        private void studentHome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rGO_LIPADataSet.order_table' table. You can move, or remove it, as needed.
            this.order_tableTableAdapter.Fill(this.rGO_LIPADataSet.order_table);

            LoadOrders();

        }

        private void guna2Button1_Click(object sender, EventArgs e) // ORDERS E2
        {
            // Create an instance of the student form
            studentOrders studentOrdersForm = new studentOrders();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentOrdersForm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update the label text with the current date and time
            labelDateTime.Text = DateTime.Now.ToString("MMMM dd, yyyy  hh:mm:ss tt");
        }

        private void orderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // NONE
        }

        private void LoadOrders()
        {
            int currentStudentSRCODE = SessionData.CurrentStudentSRCODE;
            string query = @"
    SELECT
        o.ORDERID,
        o.SRCODE,
        o.DATEORDERED,
        i.NAMEOFITEM,
        o.PRICE,
        p.NOTE AS payment_note,
        p.DATEPAID AS date_paid
    FROM
        ORDER_TABLE o
    JOIN
        ITEM i ON o.ITEMID = i.ITEMID
    LEFT JOIN
        PAYMENT p ON o.ORDERID = p.ORDERID
    WHERE
        o.SRCODE = @SRCODE";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SRCODE", currentStudentSRCODE);

                    try
                    {
                        connection.Open();
                        NpgsqlDataReader reader = command.ExecuteReader();

                        // Clear the existing data source
                        orderDataGridView.DataSource = null;

                        // Create a new DataTable to hold the data
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Bind the DataTable to the DataGridView
                        orderDataGridView.RowTemplate.Height = 60;
                        orderDataGridView.DataSource = dt;

                        // Set column headers if necessary
                        orderDataGridView.Columns["ORDERID"].HeaderText = "Order ID";
                        orderDataGridView.Columns["SRCODE"].HeaderText = "SRCODE";
                        orderDataGridView.Columns["DATEORDERED"].HeaderText = "Date Ordered";
                        orderDataGridView.Columns["NAMEOFITEM"].HeaderText = "Item Name";
                        orderDataGridView.Columns["PRICE"].HeaderText = "Price";
                        orderDataGridView.Columns["payment_note"].HeaderText = "Payment Note";
                        orderDataGridView.Columns["date_paid"].HeaderText = "Date Paid";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading orders: " + ex.Message);
                    }
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (orderDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to cancel.");
                return;
            }

            // Get the selected order's ID and payment date
            int selectedOrderID = Convert.ToInt32(orderDataGridView.SelectedRows[0].Cells["ORDERID"].Value);
            object datePaidObj = orderDataGridView.SelectedRows[0].Cells["date_paid"].Value;

            if (datePaidObj != DBNull.Value)
            {
                MessageBox.Show("Order cannot be cancelled because it has already been paid.");
                return;
            }

            // Confirm the deletion with the user
            DialogResult result = MessageBox.Show("Are you sure you want to cancel this order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteOrder(selectedOrderID);
            }
        }

        private void DeleteOrder(int orderID)
        {
            string query = "DELETE FROM ORDER_TABLE WHERE ORDERID = @OrderID";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", orderID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order cancelled successfully.");
                            // Reload orders after deletion
                            LoadOrders();
                        }
                        else
                        {
                            MessageBox.Show("Failed to cancel order.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error cancelling order: " + ex.Message);
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the student form
            studentFeedback studentFeedbackForm = new studentFeedback();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentFeedbackForm.ShowDialog();
        }

        private void announcementBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the student form
            studentAnnouncement studentAnnouncementForm = new studentAnnouncement();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentAnnouncementForm.ShowDialog();
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

        private void changepasswordBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the student form
            studentChangePassword studentChangePasswordForm = new studentChangePassword();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentChangePasswordForm.ShowDialog();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // Close the current form (studentOrders form)
            this.Close();

            // Open the login form
            login loginForm = new login();
            loginForm.Show();
        }
    }
}

