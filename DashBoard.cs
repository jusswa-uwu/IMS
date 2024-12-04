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
        private List<Handler> categories_handler;
        public DashBoard()
        {
            InitializeComponent();
            rmhdr();
            categories_handler = new List<Handler>();
            Handler elec = new Handler("elec");
            
            categories_handler.Add(elec);
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
            foreach (Handler category in categories_handler)
            {
                dataGridView1.Rows.Add(category.Name);
            }
        }


        //Saving Categories
        public void SaveToTxt(string filepath, List<Handler> categ)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                foreach (var itms in categ)
                {
                    sw.WriteLine(itms.Name);
                    foreach (var product in itms.GetProducts())
                    {
                        sw.WriteLine($"{product.Name},{product.Price},{product.Quantity},{product.ProductDT}");
                    }
                    sw.WriteLine();

                }
            }
            MessageBox.Show("Saved");
        }

        //loading from txt 

        public List<Handler> loadfromTxt(string filepath)
        {
            List<Handler> categories = new List<Handler>();
            if (File.Exists(filepath))
            {
                string[] lines = File.ReadAllLines(filepath);
                Handler current = null;

                foreach (var line in lines)
                {
                    if (string.IsNullOrEmpty(line))
                    continue;
                    
                    //this will return the categories 
                    if (!line.Contains(","))
                    {
                        current = new Handler(line);
                        categories.Add(current);
                    }
                    else if (current != null)
                    {
                        string[] dataLine = line.Split(',');
                        string productName = dataLine[0].Trim();
                        decimal productPrice = decimal.Parse(dataLine[1].Trim());
                        int productQuantity = int.Parse(dataLine[2].Trim());
                        string DateTime = dataLine[3].Trim();
                        
                        Product prod = new Product(productName, productPrice, productQuantity, DateTime);
                        current.Addproduct(prod);
                    }
                }
            }
            return categories;
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
            

            MessageBox.Show("Works");
            // Add columns for product details
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ProductName", "Product Name");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("Quantity","Quantity");
            dataGridView1.Columns.Add("Date", "Date");
            
            dataGridView1.Rows.Add("Jojo", 23,34,"awdawd");
            
        }

        
        
        //ClickHandler for datagrid
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedCategoryName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Handler selectedCategory = categories_handler.Find(c => c.Name.Equals(selectedCategoryName, StringComparison.OrdinalIgnoreCase));
                if (selectedCategory != null)
                {
                    // Display products for the selected category
                    MessageBox.Show("Samples");
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
