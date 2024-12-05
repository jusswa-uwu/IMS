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
using System.Windows.Forms.VisualStyles;

namespace InventoryIMSSystemt
{
    public partial class DashBoard : Form
    {
        private List<User> users;
        private User currentUser;
        private List<Handler> categories_handler;
        string filepath = "categorydbs.txt";
        public DashBoard()
        {
            InitializeComponent();
            rmhdr();
            categories_handler = LoadFromdbs(filepath);

            dataGridView1.CellContentDoubleClick += dataGridView1_CellContentClick;
            DisplayCategories();
        }
        private void rmhdr()
        {
            dataGridView1.AutoResizeColumnHeadersHeight();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
        }
        //Display Categories
        private void DisplayCategories()
        {
            dataGridView1.Rows.Clear();
            foreach (Handler category in currentUser.Categories)
            {
                dataGridView1.Rows.Add(category.Name);
            }
        }
        //Loading User from txt database
        private List<User> LoadUserFromFile(string filepath)
        {
            var loadedUser = new List<User>();
            if (File.Exists(filepath))
            {
              

                string[] lines = File.ReadAllLines(filepath);
                User current = null;
                Handler currentCat = null;
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
                        currentCat = new Handler(categoryDetails[1].Trim());
                        current.Categories.Add(currentCat);
                    }
                    else if (line.StartsWith("PRODUCT") && current != null)
                    {
                        var productDetails = line.Split(',');
                        if (productDetails.Length == 6 && int.TryParse(productDetails[1].Trim(), out int productID) && decimal.TryParse(productDetails[3].Trim(), out decimal productPrice)&& int.TryParse(productDetails[4].Trim(), out int quantity))
                        {
                            string productName = productDetails[2].Trim();
                            string productDT = productDetails[5].Trim();

                            Product product = new Product(productID, productName, productPrice, quantity, productDT);
                            currentCat.Addproduct(product);
                        }
                    }
                }
            }
            return loadedUser;
        }


        //Login 
        public void Login(string username, string password)
        {
            currentUser = users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (currentUser != null)
            {
                DisplayCategories();
            }
            else
            {
                MessageBox.Show("Account not found");
            }
        }

        //Save users info
        private void SaveUserstoFile(string filepath)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                foreach (var user in users)
                {
                    sw.WriteLine($"USER,{user.UserName},{user.Password}");
                    foreach (var cat in user.Categories)
                    {
                        sw.WriteLine($"CATEGORY,{cat.Name}");
                        foreach (var product in cat.GetProducts())
                        {
                            sw.WriteLine($"PRODUCT,{product.ProductID},{product.Name},{product.Price},{product.Quantity},{product.ProductDT}");
                        }
                    }
                }
            }
        }

        //Saving Categories and products
        public void SaveToTxt(string filepath, List<Handler> categ)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                foreach (var itms in categ)
                {
                    sw.WriteLine(itms.Name);
                    foreach (var product in itms.GetProducts())
                    {
                        sw.WriteLine($"{product.ProductID},{product.Name},{product.Price},{product.Quantity},{product.ProductDT}");
                    }
                    sw.WriteLine();

                }
            }
            MessageBox.Show("Saved");
        }

        //Loading product from categories
        public List<Handler> LoadFromdbs(string filepath)
        {
            var cat = new List<Handler>();
            Handler current = null;

            foreach (var line in File.ReadLines(filepath))
            {
                if (string.IsNullOrWhiteSpace(line))
                continue;

                if (!line.Contains(","))
                {
                    current = new Handler(line.Trim());
                    cat.Add(current);
                }
                else if (current != null)
                {
                    var productDetails = line.Split(',');
                    if (int.TryParse(productDetails[0].Trim(), out int productID) && productDetails.Length == 5 && decimal.TryParse(productDetails[2].Trim(), out decimal price) && int.TryParse(productDetails[3].Trim(), out int quantity))
                    {

                        string ProductName = productDetails[1].Trim();
                        string DateTime = productDetails[4].Trim();

                        Product product = new Product(productID,ProductName, price, quantity, DateTime);
                        current.Addproduct(product);
                    }
                }
                
            }
            return cat;
        }

        //Add new Category
        private void AddNewCategoryBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddCategory addCategory = new AddCategory();

            if (addCategory.ShowDialog() == DialogResult.OK)
            {
                string newCategory = addCategory.GetCategoryName;
                Handler newCategoryname = new Handler(newCategory);
                categories_handler.Add(newCategoryname);
                DisplayCategories();
            }
        }
        //Display Product
        private void DisplayProduct(Handler cat)
        {
           
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            
            // Add columns for product details
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ProductID", "ProductID");
            dataGridView1.Columns.Add("ProductName", "Product Name");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("Quantity","Quantity");
            dataGridView1.Columns.Add("Date", "Date");
            
            foreach (var product in cat.GetProducts())
            {
                dataGridView1.Rows.Add(product.ProductID,product.Name, product.Price, product.Quantity, product.ProductDT);
            }
            
        }

        
        
        //ClickHandler for datagrid
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedCategoryName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var selectedCategory = currentUser.Categories.Find(c => c.Name.Equals(selectedCategoryName, StringComparison.OrdinalIgnoreCase));
                if (selectedCategory != null)

                {
                    // Display products for the selected category
                    DisplayProduct(selectedCategory);
                }
            }
        }
        //Add new Product
        private void AddProductLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddProduct ap = new AddProduct(categories_handler);
            ap.ShowDialog();
        }
    }
}
