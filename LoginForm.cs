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
    public partial class LoginForm : Form
    {
        private DashBoard dashboard;
        private List<User> users;
        private string filepath = "dbs.txt";
        public LoginForm()
        {
            InitializeComponent();
            dashboard = new DashBoard();
            

        }


        private List<User> Loaduserfromfile()
        {
            var userList = new List<User>();  

            if (File.Exists(filepath))
            {
                string[] lines = File.ReadAllLines(filepath);

                foreach (var line in lines)
                {
                    if (line.StartsWith("USER"))
                    {
                        var userDetails = line.Split(',');
                        userList.Add(new User(userDetails[1], userDetails[2]));
                    }
                }
            }
            return userList;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            dashboard.Login(username, password);
            this.Hide();
            dashboard.Show();
        }

        private void createaccountLinkText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccount ca = new CreateAccount(users);
            ca.ShowDialog();
            users = Loaduserfromfile();

        }
    }
}
