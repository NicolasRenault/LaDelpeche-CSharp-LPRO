using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLib
{
    public class ProductManager
    {
        private String FilePath = "C:/Windows/Temp/product.txt";

        public ProductManager()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
                loadDefaultValues();

            } else if (string.IsNullOrEmpty(File.ReadAllText(FilePath)) || File.ReadAllText(FilePath) == "[]")
            {
                loadDefaultValues();
            }
        }

        private void loadDefaultValues()
        {
            Product product1 = new Product();
            product1.Name = "Michel Delpech - Pour Un Flirt";
            product1.Price = 69;
            product1.Quantity = 10000;

            Product product2 = new Product();
            product2.Name = "Rick Astley - Never Gonna Give You Up";
            product2.Price = 42;
            product2.Quantity = 0;

            Product product3 = new Product();
            product3.Name = "Luis Fonsi - Despacito ft. Daddy Yankee";
            product3.Price = 0;
            product3.Quantity = 0;

            insert(product1);
            insert(product2);
            insert(product3);
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            if (!string.IsNullOrEmpty(File.ReadAllText(FilePath)))
            {
                products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(FilePath));
            }

            return products;
        }

        public void insert(Product product)
        {
            var products = GetAll();
            products.Add(product);
            product.ID = Guid.NewGuid().ToString();

            var jsonProductList = JsonConvert.SerializeObject(products);

            File.WriteAllText(FilePath, jsonProductList);
        }

        public void update(Product product)
        {
            var products = GetAll();
            var dbProduct = products.Where(r => r.ID == product.ID).First();

            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Quantity = product.Quantity;

            var jsonProductList = JsonConvert.SerializeObject(products);

            File.WriteAllText(FilePath, jsonProductList);
        }

        public Product Get(string ID)
        {
            var products = GetAll();

            var dbProduct = products.Where(r => r.ID == ID).First();

            return dbProduct;
        }

        public bool remove(string id)
        {
            var products = GetAll();
            var product = products.Single(r => r.ID == id);
            bool result = products.Remove(product);

            if (result)
            {
                var jsonProductList = JsonConvert.SerializeObject(products);

                File.WriteAllText(FilePath, jsonProductList);
            }

            return result;
        }
    }
}
