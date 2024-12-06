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

namespace InventoryIMSSystemt
{
    public partial class CreateAccount : Form
    {
        private List<User> users;
        private string filepath = "dbs.txt";

        public CreateAccount(List<User> existing_user)
        {
            InitializeComponent();
            users = existing_user;
            confirmpasswordLabel.Text = "Confirm password";
        }

        private bool validator()
        {
            return !string.IsNullOrEmpty(usernameTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox.Text);
        }

        private void saveUserstoFile()
        {
            using (StreamWriter sw = new StreamWriter(filepath, false))
            {
                foreach (var user in users)
                {
                    sw.WriteLine($"USER,{user.UserName},{user.Password}");
                }

            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (validator())
            {
                foreach (User user in users)
                {
                    if (user.UserName == usernameTextBox.Text)
                    {
                        MessageBox.Show("User name already in use");
                        return;
                    }
                }
                User newuser = new User(usernameTextBox.Text, passwordTextBox.Text);
                users.Add(newuser);
                saveUserstoFile();
                
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
