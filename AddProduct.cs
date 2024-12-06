using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

        private int ProductIDgenerator()
        {
            Random rand = new Random();
            int randomIDgenerator = rand.Next(10000000, 99999999);
            return randomIDgenerator;
        }


        //Adding a product button
        private void AddBtn_Click(object sender, EventArgs e)
        {
            int quantityresult = 0;
            decimal priceresult = 0;
            string chosenCategoryName = categoryComboBox.SelectedItem.ToString();
            Handler chosenCategory = category_handler.FirstOrDefault(c => c.Name == chosenCategoryName);



            if (!decimal.TryParse(priceTextBox.Text, out priceresult) || !int.TryParse(quantityTextBox.Text, out quantityresult) || string.IsNullOrWhiteSpace(priceTextBox.Text) || string.IsNullOrWhiteSpace(quantityTextBox.Text) || string.IsNullOrWhiteSpace(productnameTextBox.Text))
            {
                MessageBox.Show("My deepest regret sire that tis not valid");
                return;
            }
            if (chosenCategory != null && !string.IsNullOrEmpty(productnameTextBox.Text))
            {
                int productID = ProductIDgenerator();
                string datetime = DateTime.Now.ToString("MM-dd-yyyy");
                Product newProduct = new Product(productID, productnameTextBox.Text, priceresult, quantityresult, datetime);
                MessageBox.Show("Added");
                productnameTextBox.Text = "";
                quantityTextBox.Text = "";
                priceTextBox.Text = "";

                chosenCategory.Addproduct(newProduct);

                //Save the data
                DashBoard db = (DashBoard)Application.OpenForms["DashBoard"];
                db.SaveToTxt("dbs.txt", category_handler);
            }
            
            else
            {
                MessageBox.Show("Deeym sheesd");
            }
        }

        //save changes
        private void SaveCategoryChanges()
        {
            // Access the Dashboard form
            DashBoard db = Application.OpenForms.OfType<DashBoard>().FirstOrDefault();
            if (db != null)
            {
                db.SaveToTxt(db.filepath, category_handler); 
            }
            else
            {
                MessageBox.Show("Unable to save changes. Dashboard is not accessible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
