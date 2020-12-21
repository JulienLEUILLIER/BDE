using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public class Stock
    {
        private decimal _currentBalance;

        public decimal CurrentBalance { get => _currentBalance; }

        public Dictionary<Product, int> _StockProduct = new Dictionary<Product, int>();

        public Product GetProductByName(string name)
        {
            return _StockProduct.FirstOrDefault(KeyValuePair => KeyValuePair.Key._productName.Equals(name)).Key;
        }

        public Stock()
        {
            _currentBalance = 100m;
        }

        public void AddProduct(Product product, int quantity)
        {
            Product currentProduct = GetProductByName(product._productName);
            
            if (currentProduct == null)
            {
                _StockProduct.Add(product, quantity);
            }
            else if (_currentBalance >= quantity * product._buyPrice && quantity > 0)
            {
                CheckStockChange(currentProduct, quantity);
            }
            SetBalance(-quantity * product._buyPrice);
        }

        public void CheckStockChange(Product product, int quantity)
        {
            product = GetProductByName(product._productName);
            if (product != default && _StockProduct[product] + quantity >= 0)
            {
                _StockProduct[product] += quantity;
            }
        }
        public void SubstractProduct(Product product, int quantity, Client client)
        {
            CheckStockChange(product, -quantity);
            SetBalance(client.GetAppropriatePrice(product) * quantity);
        }

        public void SetBalance(decimal amount)
        {
            _currentBalance += amount;
        }

        public void DisplayStockConsole()
        {
            foreach (KeyValuePair<Product, int> product in _StockProduct)
            {
                Console.WriteLine("\t{0}: {1}", product.Key._productName, product.Value);
            }
        }
    }
}
