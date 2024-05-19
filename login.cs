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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e) // EXIT BUTTON E2
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e) //ADMIN BUTTON LOGIN E2
        {
            // Create an instance of the admin form
            loginforAdmin loginforAdminForm = new loginforAdmin();

            // Hide the current form
            this.Hide();

            // Show the admin form
            loginforAdminForm.ShowDialog();

           
            
        }

        private void guna2Button2_Click(object sender, EventArgs e) // STUDENT BUTTON LOGIN
        {
            // Create an instance of the student form
            studentLogin studentLoginForm = new studentLogin();

            // Hide the current form
            this.Hide();

            // Show the student form
            studentLoginForm.ShowDialog();


            
        }
    }
}
