﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryIMSSystemt
{
    public partial class LoginForm : Form
    {
        private List<User> users;
        public LoginForm()
        {
            InitializeComponent();
            users = LoadUserFromFile("dbs.txt");
        }

        private List<User> LoadUserFromFile(string filepath)
        {
            var loadedUser = new List<User>();
            if (System.IO.File.Exists(filepath))
            {
                string[] lines = System.IO.File.ReadAllLines(filepath);
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


        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            //Validate the credentials
            User currentUser = users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (currentUser != null)
            {
                MessageBox.Show("Login successful!");
                //Open the Dashboard form
                DashBoard dashboard = new DashBoard(currentUser);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }   




        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            User currentUser = users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (currentUser != null)
            {
                MessageBox.Show("Login successful!");
                // Open the Dashboard form
                DashBoard dashboard = new DashBoard(currentUser);
                dashboard.Show();
                this.Hide();
            }  
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void createaccountLinkText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            if (ca.ShowDialog() == DialogResult.OK)
             {
                users = LoadUserFromFile("dbs.txt");
             }

        }
    }
}
