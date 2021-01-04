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

        private readonly IOrderingRepository _repository;

        public Stock(decimal balance, IOrderingRepository orderingRepository)
        {
            _currentBalance = balance;
            _repository = orderingRepository;
        }

        public Product GetProductByName(string name)
        {
            return _StockProduct.FirstOrDefault(kvp => kvp.Key._productName.ToUpper().Equals(name.ToUpper())).Key;
        }

        public int GetProductQuantity(string name)
        {
            return _StockProduct[GetProductByName(name)];
        }

        public void AddProduct(Order order)
        {
            Product currentProduct = GetProductByName(order._product._productName);
            int quantity = order._quantity;
            if (quantity > 0)
            {
                if (currentProduct == null)
                {
                    _StockProduct.Add(order._product, quantity);
                    SetBalance(-quantity * order._product._buyPrice);
                }
                else if (_currentBalance >= quantity * currentProduct._buyPrice)
                {
                    CheckStockChange(order);
                    SetBalance(-quantity * currentProduct._buyPrice);
                }
            }
        }

        public void AddToStock(Order order)
        {
            _repository.SaveOrder(order);

            AddProduct(order);
        }

        public void CheckStockChange(Order order)
        {
            Product product = GetProductByName(order._product._productName);

            if (product != default && _StockProduct[product] + order._quantity >= 0)
            {
                _StockProduct[product] += order._quantity;
            }
            if (GetProductQuantity(product._productName) < 10)
            {
                Notify(product);
            }
        }
        public void SubstractProduct(Order order, Client client)
        {
            SetBalance(client.GetAppropriatePrice(order._product) * order._quantity);
            CheckStockChange(GetNegativeQuantity(order));
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

        public Order GetNegativeQuantity(Order order)
        {
            order._quantity *= -1;
            return order;
        }
    }
}
