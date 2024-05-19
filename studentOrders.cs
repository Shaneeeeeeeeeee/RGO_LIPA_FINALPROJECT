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
    public partial class studentOrders : Form
    {
        private string connectionString = "Server=localhost;Port=5432;Database=RGO_LIPA;User Id=postgres;Password=postgres;";

        public studentOrders()
        {
            InitializeComponent();
            DisplayCurrentStudentSRCODE();
            PopulateComboBoxes();
            timer1.Start();

            itemDataGridView.RowTemplate.Height = 150;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("MMMM dd, yyyy  hh:mm:ss tt");
        }

        private void DisplayCurrentStudentSRCODE()
        {
            int currentStudentSRCODE = SessionData.CurrentStudentSRCODE;
            srcodeLabel.Text = currentStudentSRCODE.ToString();
            DisplayCurrentStudentName(currentStudentSRCODE);
        }

        private void DisplayCurrentStudentName(int srcode)
        {
            string query = "SELECT NAME FROM STUDENT WHERE SRCODE = @SRCODE";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SRCODE", srcode);
                    try
                    {
                        connection.Open();
                        string studentName = (string)command.ExecuteScalar();
                        if (!string.IsNullOrEmpty(studentName))
                        {
                            nameLabel.Text = studentName;
                        }
                        else
                        {
                            MessageBox.Show("Student name not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void PopulateComboBoxes()
        {
            whiteComboBox.SelectedIndexChanged -= whiteComboBox_SelectedIndexChanged;
            checkeredComboBox.SelectedIndexChanged -= checkeredComboBox_SelectedIndexChanged;
            remingtonComboBox.SelectedIndexChanged -= remingtonComboBox_SelectedIndexChanged;
            peComboBox.SelectedIndexChanged -= peComboBox_SelectedIndexChanged;
            pinComboBox.SelectedIndexChanged -= pinComboBox_SelectedIndexChanged;
            laceComboBox.SelectedIndexChanged -= laceComboBox_SelectedIndexChanged;
            newComboBox.SelectedIndexChanged -= newComboBox_SelectedIndexChanged;

            PopulateComboBox("White Fabric", whiteComboBox);
            PopulateComboBox("Checkered Fabric", checkeredComboBox);
            PopulateComboBox("Pants", remingtonComboBox);
            PopulateComboBox("PE Uniform", peComboBox);
            PopulateComboBox("Uniform Pins", pinComboBox);
            PopulateComboBox("ID Lace", laceComboBox);
            PopulateNewItemsComboBox();

            whiteComboBox.SelectedIndexChanged += whiteComboBox_SelectedIndexChanged;
            checkeredComboBox.SelectedIndexChanged += checkeredComboBox_SelectedIndexChanged;
            remingtonComboBox.SelectedIndexChanged += remingtonComboBox_SelectedIndexChanged;
            peComboBox.SelectedIndexChanged += peComboBox_SelectedIndexChanged;
            pinComboBox.SelectedIndexChanged += pinComboBox_SelectedIndexChanged;
            laceComboBox.SelectedIndexChanged += laceComboBox_SelectedIndexChanged;
            newComboBox.SelectedIndexChanged += newComboBox_SelectedIndexChanged;
        }

        private void PopulateComboBox(string itemName, ComboBox comboBox)
        {
            string query = "SELECT SIZEOFITEM FROM ITEM WHERE NAMEOFITEM = @NAMEOFITEM";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NAMEOFITEM", itemName);

                    try
                    {
                        connection.Open();
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            comboBox.Items.Clear();
                            comboBox.Items.Add("--NONE--");

                            while (reader.Read())
                            {
                                comboBox.Items.Add(reader["SIZEOFITEM"].ToString());
                            }

                            comboBox.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void PopulateNewItemsComboBox()
        {
            string query = "SELECT ITEMID FROM ITEM";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            newComboBox.Items.Clear();
                            newComboBox.Items.Add("--NONE--");

                            while (reader.Read())
                            {
                                newComboBox.Items.Add(reader["ITEMID"].ToString());
                            }

                            newComboBox.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private int GetItemID(string size, string itemName)
        {
            string query = "SELECT ITEMID FROM ITEM WHERE NAMEOFITEM = @NAMEOFITEM AND SIZEOFITEM = @SIZEOFITEM";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NAMEOFITEM", itemName);
                    command.Parameters.AddWithValue("@SIZEOFITEM", size);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Invalid size or item name selected.");
                            return -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return -1;
                    }
                }
            }
        }

        private int GetItemIDByName(string itemName)
        {
            int itemID = -1;
            string query = "SELECT ITEMID FROM ITEM WHERE NAMEOFITEM = @itemName";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@itemName", itemName);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        itemID = Convert.ToInt32(result);
                    }
                }
            }

            return itemID;
        }

        private void InsertOrder(int srcode, int itemID)
        {
            string query = "INSERT INTO ORDER_TABLE (DATEORDERED, SRCODE, ITEMID, PRICE) " +
                           "VALUES (CURRENT_TIMESTAMP, @SRCODE, @ITEMID, " +
                           "(SELECT CAST(PRICE AS DECIMAL(10, 2)) FROM ITEM WHERE ITEMID = @ITEMID))";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SRCODE", srcode);
                    command.Parameters.AddWithValue("@ITEMID", itemID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add item.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void whiteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (whiteComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = whiteComboBox.SelectedItem.ToString();
                string itemName = "White Fabric";
                int itemID = GetItemID(selectedSize, itemName);
                MessageBox.Show("Selected ITEMID: " + itemID.ToString());
            }
        }

        private void addWhiteBtn_Click(object sender, EventArgs e)
        {
            if (whiteComboBox.SelectedItem != null && whiteComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = whiteComboBox.SelectedItem.ToString();
                string itemName = "White Fabric";
                int itemID = GetItemID(selectedSize, itemName);
                int currentSRCODE = SessionData.CurrentStudentSRCODE;

                if (itemID != -1 && currentSRCODE != -1)
                {
                    InsertOrder(currentSRCODE, itemID);
                }
            }
            else
            {
                MessageBox.Show("Please select a size for White Fabric.");
            }
        }

        private void resetWhiteBtn_Click(object sender, EventArgs e)
        {
            whiteComboBox.SelectedIndex = 0;
        }

        private void checkeredComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkeredComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = checkeredComboBox.SelectedItem.ToString();
                string itemName = "Checkered Fabric";
                int itemID = GetItemID(selectedSize, itemName);
                MessageBox.Show("Selected ITEMID: " + itemID.ToString());
            }
        }

        private void addCheckeredBtn_Click(object sender, EventArgs e)
        {
            if (checkeredComboBox.SelectedItem != null && checkeredComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = checkeredComboBox.SelectedItem.ToString();
                string itemName = "Checkered Fabric";
                int itemID = GetItemID(selectedSize, itemName);
                int currentSRCODE = SessionData.CurrentStudentSRCODE;

                if (itemID != -1 && currentSRCODE != -1)
                {
                    InsertOrder(currentSRCODE, itemID);
                }
            }
            else
            {
                MessageBox.Show("Please select a size for Checkered Fabric.");
            }
        }

        private void resetCheckeredBtn_Click(object sender, EventArgs e)
        {
            checkeredComboBox.SelectedIndex = 0;
        }

        private void remingtonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (remingtonComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = remingtonComboBox.SelectedItem.ToString();
                string itemName = "Pants";
                int itemID = GetItemID(selectedSize, itemName);
                MessageBox.Show("Selected ITEMID: " + itemID.ToString());
            }
        }

        private void addRemingtonBtn_Click(object sender, EventArgs e)
        {
            if (remingtonComboBox.SelectedItem != null && remingtonComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = remingtonComboBox.SelectedItem.ToString();
                string itemName = "Pants";
                int itemID = GetItemID(selectedSize, itemName);
                int currentSRCODE = SessionData.CurrentStudentSRCODE;

                if (itemID != -1 && currentSRCODE != -1)
                {
                    InsertOrder(currentSRCODE, itemID);
                }
            }
            else
            {
                MessageBox.Show("Please select a size for Pants.");
            }
        }

        private void resetRemingtonBtn_Click(object sender, EventArgs e)
        {
            remingtonComboBox.SelectedIndex = 0;
        }

        private void peComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (peComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = peComboBox.SelectedItem.ToString();
                string itemName = "PE Uniform";
                int itemID = GetItemID(selectedSize, itemName);
                MessageBox.Show("Selected ITEMID: " + itemID.ToString());
            }
        }

        private void addPeBtn_Click(object sender, EventArgs e)
        {
            if (peComboBox.SelectedItem != null && peComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = peComboBox.SelectedItem.ToString();
                string itemName = "PE Uniform";
                int itemID = GetItemID(selectedSize, itemName);
                int currentSRCODE = SessionData.CurrentStudentSRCODE;

                if (itemID != -1 && currentSRCODE != -1)
                {
                    InsertOrder(currentSRCODE, itemID);
                }
            }
            else
            {
                MessageBox.Show("Please select a size for PE Uniform.");
            }
        }

        private void resetPeBtn_Click(object sender, EventArgs e)
        {
            peComboBox.SelectedIndex = 0;
        }

        private void pinComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pinComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = pinComboBox.SelectedItem.ToString();
                string itemName = "Uniform Pins";
                int itemID = GetItemID(selectedSize, itemName);
                MessageBox.Show("Selected ITEMID: " + itemID.ToString());
            }
        }

        private void addPinBtn_Click(object sender, EventArgs e)
        {
            if (pinComboBox.SelectedItem != null && pinComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = pinComboBox.SelectedItem.ToString();
                string itemName = "Uniform Pins";
                int itemID = GetItemID(selectedSize, itemName);
                int currentSRCODE = SessionData.CurrentStudentSRCODE;

                if (itemID != -1 && currentSRCODE != -1)
                {
                    InsertOrder(currentSRCODE, itemID);
                }
            }
            else
            {
                MessageBox.Show("Please select a type for Uniform Pins.");
            }
        }

        private void resetPinBtn_Click(object sender, EventArgs e)
        {
            pinComboBox.SelectedIndex = 0;
        }

        private void laceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (laceComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = laceComboBox.SelectedItem.ToString();
                string itemName = "ID Lace";
                int itemID = GetItemID(selectedSize, itemName);
                MessageBox.Show("Selected ITEMID: " + itemID.ToString());
            }
        }

        private void addLaceBtn_Click(object sender, EventArgs e)
        {
            if (laceComboBox.SelectedItem != null && laceComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedSize = laceComboBox.SelectedItem.ToString();
                string itemName = "ID Lace";
                int itemID = GetItemID(selectedSize, itemName);
                int currentSRCODE = SessionData.CurrentStudentSRCODE;

                if (itemID != -1 && currentSRCODE != -1)
                {
                    InsertOrder(currentSRCODE, itemID);
                }
            }
            else
            {
                MessageBox.Show("Please select a type for ID Lace.");
            }
        }

        private void resetLaceBtn_Click(object sender, EventArgs e)
        {
            laceComboBox.SelectedIndex = 0;
        }

        private void newComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (newComboBox.SelectedItem.ToString() != "--NONE--")
            {
                string selectedItem = newComboBox.SelectedItem.ToString();
                int itemID = Convert.ToInt32(selectedItem);
                MessageBox.Show("Selected ITEMID: " + itemID.ToString());
            }
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

        private void feedbackBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the student form
            studentFeedback studentFeedbackForm = new studentFeedback();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentFeedbackForm.ShowDialog();
        }


        private void guna2HtmlLabel19_Click(object sender, EventArgs e)
        {
            // wala lanG TO!! DON'T REMOVE
        }

        private void srcodeLabel_Click(object sender, EventArgs e)
        {
            // DON'T REMOVE BALE WALA NA TO ( IF PAPALTAN DESIGN SAME NAME PARIN DAPAT "srcodeLabel")
        }

        private void studentOrders_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rGO_LIPADataSet.item' table. You can move, or remove it, as needed.
            this.itemTableAdapter.Fill(this.rGO_LIPADataSet.item);

        }

        private void addNewBtn_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the newComboBox and it's not "--NONE--"
            if (newComboBox.SelectedItem != null && newComboBox.SelectedItem.ToString() != "--NONE--")
            {
                // Get the selected ITEMID
                int itemID = Convert.ToInt32(newComboBox.SelectedItem.ToString());

                // Retrieve the current SRCODE
                int currentSRCODE = SessionData.CurrentStudentSRCODE;

                if (itemID != -1 && currentSRCODE != -1)
                {
                    // Insert a new record into the ORDER_TABLE
                    InsertOrder(currentSRCODE, itemID);

                    // Display the newly inserted ITEMID
                    MessageBox.Show("ADDED ORDER ITEMID: " + itemID.ToString());
                }
            }
            else
            {
                // Display a message if "--NONE--" is selected in the newComboBox
                MessageBox.Show("No item selected.");
            }
        }


        private void resetNewBtn_Click(object sender, EventArgs e)
        {
            // Find the index of the "--NONE--" item in the ComboBox
            int noneIndex = newComboBox.FindStringExact("--NONE--");

            // Set the selected index to the index of the "--NONE--" item
            newComboBox.SelectedIndex = noneIndex;
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel55_Click(object sender, EventArgs e)
        {

        }
    }
}
