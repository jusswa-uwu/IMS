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
        public CreateAccount()
        {
            InitializeComponent();
        }

        private List<User> LoadDatafromFile(string filepath)
        {
            var loadedUser = new List<User>();

            if (File.Exists(filepath))
            {
                string[] lines = File.ReadAllLines(filepath);
                User current = null;
                foreach (var line in lines)
                {
                    if (line.StartsWith("USER"))
                    {
                        var userDetails = line.Split(',');
                        current = new User(userDetails[1], userDetails[2]);
                        loadedUser.Add(current);
                    }
                    else if (current != null && line.StartsWith("CATEGORY"))
                    {
                        var categoryDetails = line.Split(',');
                        Handler currentCat = new Handler(categoryDetails[1].Trim());
                        current.Categories.Add(currentCat);
                    }
                    else if (line.StartsWith("PRODUCT") && current != null)
                    {
                        var productDetails = line.Split(',');
                        int productID = int.Parse(productDetails[1].Trim());
                        string productName = productDetails[2].Trim();
                        decimal productPrice = decimal.Parse(productDetails[3].Trim());
                        int productQuantity = int.Parse(productDetails[4].Trim());
                        string productDT = productDetails[5].Trim();

                        Product product = new Product(productID, productName, productPrice, productQuantity, productDT);
                        current.Categories.Last().Addproduct(product); 
                    }
                }
            }
            return loadedUser;
        }


        private void SaveNewUserToFile(string filepath, User newUser)
        {
            using (StreamWriter sw = new StreamWriter(filepath, true)) // set Append mode on
            {
                sw.WriteLine($"USER,{newUser.UserName},{newUser.Password}");
                sw.WriteLine($"CATEGORY,Category1");
            }
        }


        private void submitBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Check if the username already exists
            var users = LoadDatafromFile("dbs.txt");
            if (users.Any(u => u.UserName == username))
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            // Create a new user and save to file
            if (!(passwordTextBox.Text == confirmpasswordTextBox.Text))
            {
                MessageBox.Show("Password mismatch");
                return;
            }
            User newUser = new User(username, password);
            SaveNewUserToFile("dbs.txt", newUser);
            MessageBox.Show("Account created successfully!");
            this.DialogResult = DialogResult.OK; // Close the form and return OK
            this.Close();
        }
    }
}
