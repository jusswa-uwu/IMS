using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace InventoryIMSSystemt
{

    public class User
    {

      
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Handler> Categories { get; set; }
        public User(string username,string password) 
        { 
            UserName = username;
            Password = password;
            Categories = new List<Handler>();
        }

        public void LoadCategoriesAndProducts(string filepath)
        {
            if (File.Exists(filepath))
            {
                string[] lines = File.ReadAllLines(filepath);   
                Handler current = null;

                foreach (var line in lines)
                {
                    if (line.StartsWith("CATEGORY"))
                    {
                        var categoryDetails = line.Split(',');
                        current = new Handler(categoryDetails[0]);
                        Categories.Add(current);
                    }
                    else if (current != null && line.StartsWith("PRODUCT"))
                    {
                        var productDetails = line.Split(',');
                        int productID = int.Parse(productDetails[0]);
                        string productName = productDetails[1];
                        decimal productPrice = int.Parse(productDetails[2]);
                        int productQuantity = int.Parse(productDetails[3]);
                        string productDT = productDetails[4];

                        Product product = new Product(productID, productName, productPrice, productQuantity, productDT);

                        current.Addproduct(product);

                    }   
                }
            }
        }

    }

    public class Product
    {
        //product class
        public string Name;
        public int Quantity;
        public int ProductID;
        public string ProductDT;
        public decimal Price;
        public Product(int productid,string name, decimal price, int quantity, string productDT)
        {

            ProductID = productid;    
            Name = name;
            Quantity = quantity;
            Price = price;
            ProductDT = productDT;


        }
        public override string ToString()
        {
            return $"{ProductID},{Name},{Quantity},{Price},{ProductDT}";
        }
    }

    public class Handler
    {
        //Multiple Categories with unique products
        public string Name { get; set; }
        private List<Product> products;
        public Handler(string name)
        {
            Name = name;
            products = new List<Product>();

        }

        public void Addproduct(Product product)
        {
            products.Add(product);
        }
        public override string ToString()
        {
            return Name;
        }
        public List<Product> GetProducts()
        {
            return new List<Product>(products);
        }
        public Product getProductname(string name)
        {
            return products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }


    }
}
