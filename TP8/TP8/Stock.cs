using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public class Stock : AbstractPublisher
    {
        private decimal _currentBalance;

        public decimal CurrentBalance { get => _currentBalance; }

        public Dictionary<Product, int> _StockProduct = new Dictionary<Product, int>();

        public IOrderingRepository Repository { get; set; }

        public Stock(decimal balance, IOrderingRepository repository)
        {
            _currentBalance = balance;
            Repository = repository;
        }

        public Stock(decimal balance) : this(balance, new OrderingRepository())
        {
        }

        public Product GetProductByName(string name)
        {
            return _StockProduct.FirstOrDefault(kvp => kvp.Key._productName.ToUpper().Equals(name.ToUpper())).Key;
        }

        public int GetProductQuantity(string name)
        {
            return _StockProduct[GetProductByName(name)];
        }

        public void AddProduct(Order OrderType)
        {
            Product currentProduct = GetProductByName(OrderType._product._productName);
            int quantity = OrderType._quantity;
            
            if (currentProduct == null)
            {
                _StockProduct.Add(OrderType._product, quantity);
                SetBalance(-quantity * OrderType._product._buyPrice);
            }
            else if (_currentBalance >= quantity * currentProduct._buyPrice && quantity > 0)
            {
                CheckStockChange(currentProduct, quantity);
                SetBalance(-quantity * currentProduct._buyPrice);
            }            
        }

        public void CheckStockChange(Product product, int quantity)
        {
            product = GetProductByName(product._productName);
            if (product != default && _StockProduct[product] + quantity >= 0)
            {
                _StockProduct[product] += quantity;
            }
            if (GetProductQuantity(product._productName) < 10)
            {
                Notify(product);
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

        public override void Notify(Product product)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(product);
            }
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
