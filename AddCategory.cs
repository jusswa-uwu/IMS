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
    public partial class AddCategory : Form
    {
        private readonly List<string> existingCategories;

        public string GetCategoryName { get; set; }
        public AddCategory(List<string> existing_category)
        {
            InitializeComponent();
            this.existingCategories = existing_category;
        }

        public bool verifier()
        {
            if (!string.IsNullOrEmpty(CategoryTxtBox.Text))
            {
                return true;
            }
            return false;

        }

        

        //Checking for duplicated user
        private bool userValidator(string categoryname)
        {
            return !string.IsNullOrEmpty(categoryname) && !existingCategories.Contains(categoryname, StringComparer.OrdinalIgnoreCase);
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            string getName = CategoryTxtBox.Text;
            if (userValidator(getName))
            {
                GetCategoryName = getName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (string.IsNullOrWhiteSpace(getName))
            {
                MessageBox.Show("Empty");
            }
            else
            {
                MessageBox.Show("User name is already in use");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
