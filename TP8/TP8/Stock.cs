using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public class Stock : AbstractPublisher, IStockData, IStockBehaviour
    {
        private decimal _currentBalance;

        public decimal CurrentBalance { get => _currentBalance; }

        public Dictionary<Product, int> StockProduct { get; set; }

        private readonly IOrderingRepository _repository;

        public Stock(decimal balance, IOrderingRepository orderingRepository)
        {
            StockProduct = new Dictionary<Product, int>();
            _currentBalance = balance;
            _repository = orderingRepository;
        }

        public Product GetProductByName(string name)
        {
            return StockProduct.FirstOrDefault(kvp => kvp.Key._productName.ToUpper().Equals(name.ToUpper())).Key;
        }

        public int GetProductQuantity(string name)
        {
            return StockProduct[GetProductByName(name)];
        }

        private void AddProduct(Order order)
        {
            Product currentProduct = GetProductByName(order._product._productName);
            int quantity = order._quantity;
            if (quantity > 0)
            {
                if (currentProduct == null)
                {
                    StockProduct.Add(order._product, quantity);
                    SetBalance(-quantity * order._product.BuyPrice);
                }
                else if (_currentBalance >= quantity * currentProduct.BuyPrice)
                {
                    CheckStockChange(order);
                    SetBalance(-quantity * currentProduct.BuyPrice);
                }
            }
        }

        public void AddToStock(Order order)
        {
            _repository.SaveOrder(order);

            AddProduct(order);
        }

        private void CheckStockChange(Order order)
        {
            Product product = GetProductByName(order._product._productName);

            if (product != default && StockProduct[product] + order._quantity >= 0)
            {
                StockProduct[product] += order._quantity;
            }
            if (GetProductQuantity(product._productName) < 10)
            {
                Notify(product);
            }
        }
        private Order GetNegativeQuantity(Order order)
        {
            order._quantity *= -1;
            return order;
        }

        public void SellingOperations(decimal appropriatePrice, Order order)
        {
            CheckStockChange(GetNegativeQuantity(order));
            SetBalance(appropriatePrice);
        }

        private void SetBalance(decimal amount)
        {
            _currentBalance += amount;
        }

        public void Notify(Product product)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Update(product);
            }
        }

        public void DisplayStockConsole()
        {
            foreach (KeyValuePair<Product, int> product in StockProduct)
            {
                Console.WriteLine("\t{0}: {1}", product.Key._productName, product.Value);
            }
        }
    }
}
