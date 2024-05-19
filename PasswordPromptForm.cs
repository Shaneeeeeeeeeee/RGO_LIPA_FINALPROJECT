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
    public partial class PasswordPromptForm : Form
    {
        // Public property to store the entered password
        public string EnteredPassword { get; private set; }

        public PasswordPromptForm()
        {
            InitializeComponent();
        }

        // Inside the PasswordPromptForm class

        private void confirmButton_Click(object sender, EventArgs e)
        {
            // Check if the entered password is correct
            if (passwordTextBox.Text == "ADMINONLY123")
            {
                // Assign the entered password to the EnteredPassword property
                EnteredPassword = passwordTextBox.Text;

                // Set the DialogResult of the form to OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect password. Please try again.");
            }
        }


        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            // Set the UseSystemPasswordChar property to true to hide the password
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}

