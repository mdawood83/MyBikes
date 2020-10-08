using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClassLibraryBikesBusLayer;
using ClassLibraryBikesDataLayer;

namespace BikesPresentationLayer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string[] usernames = { "admin1", "admin2" };
        string[] passwords = { "123", "456" };
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (usernames.Contains(textBoxUser.Text) && passwords.Contains(textBoxPass.Text)
                && Array.IndexOf(usernames, textBoxUser.Text) == Array.IndexOf(passwords, textBoxPass.Text))
            {
                this.Hide();
                MyBikes mainForm = new MyBikes();
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please check your username and password");
            }
        }
    }
}
