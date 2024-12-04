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
        public string GetCategoryName { get; set; }
        public AddCategory()
        {
            InitializeComponent();
        }

        public bool verifier()
        {
            if (!string.IsNullOrEmpty(CategoryTxtBox.Text))
            {
                return true;
            }
            return false;

        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            GetCategoryName = CategoryTxtBox.Text;
            if (verifier() == true)
            {

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Empty");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
