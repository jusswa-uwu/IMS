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
    public partial class AddProduct : Form
    {
        //calling the category handler
        private List<Handler> category_handler;
        public AddProduct(List<Handler> category)
        {
            InitializeComponent();
            this.category_handler = category;
            categoryComboBox.DataSource = category.Select(c => c.Name).ToList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Adding a product button
        private void AddBtn_Click(object sender, EventArgs e)
        {
            int quantityresult = 0;
            decimal priceresult = 0;
            string chosenCategoryName = categoryComboBox.SelectedItem.ToString();
            Handler chosenCategory = category_handler.FirstOrDefault(c => c.Name == chosenCategoryName);
            if (decimal.TryParse(priceTextBox.Text, out priceresult) || int.TryParse(quantityTextBox.Text, out quantityresult) || priceTextBox.Text =="" || quantityTextBox.Text == "" || productnameTextBox.Text == "")
            {
                if (chosenCategory != null && !string.IsNullOrEmpty(productnameTextBox.Text))
                {
                    DateTime dt = new DateTime();
                  
                    string datetime = dt.ToString("MM-dd-yyy");
                    Product newProduct = new Product(productnameTextBox.Text, priceresult, quantityresult, datetime);
                    MessageBox.Show("Added");
                    productnameTextBox.Text = "";
                    quantityTextBox.Text = "";
                    priceTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid input sir");
                }

            }
            else
            {
                MessageBox.Show("My deepest regret sire that tis not valid");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
