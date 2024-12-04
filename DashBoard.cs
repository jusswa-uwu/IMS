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
            dataGridView1.ColumnHeadersVisible = false;
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

                dataGridView1.CellClick += DataGridView1_CellClick;
            }
        }
        //Display Product
        private void DisplayProduct(Handler cat)
        {
            foreach (Product product in cat.GetProducts())
            {
                dataGridView1.Rows.Add(product.Name, product.Price);
            }
        }

        //ClickHandler for datagrid
        private void DataGridView1_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedCategoryName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Handler selectedCategory = categories_handler.Find(c => c.Name.Equals(selectedCategoryName, StringComparison.OrdinalIgnoreCase));
                if (selectedCategory != null)
                {
                    // Display products for the selected category
                    DisplayProduct(selectedCategory);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
