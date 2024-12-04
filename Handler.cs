using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryIMSSystemt
{

    public class Product
    {
        //product class
        public string Name;
        public int Quantity;
        public string ProductDT;
        public decimal Price;
        public Product(string name, decimal price, int quantity, string productDT)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            ProductDT = productDT;
        }
        public override string ToString()
        {
            return $"{Name},{Quantity},{Price},{ProductDT}";
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
