using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryIMSSystemt
{
    public partial class LoginForm : Form
    {
        private DashBoard dashboard;
        public LoginForm()
        {
            InitializeComponent();
            dashboard = new DashBoard();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            dashboard.Login(username, password);
            this.Hide();
            dashboard.Show();
        }
    }
}
