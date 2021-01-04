using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public sealed class StudentOffice : ISubscriber
    {

        public readonly Stock _stock;
        public readonly Commercial _commercial;

        public Dictionary<Client, decimal> ClientList { get; set; }

        public StudentOffice(decimal balance)
        {
            _stock = new Stock(balance, new OrderingRepository());
            _commercial = new Commercial();
            ClientList = new Dictionary<Client, decimal>();
        }

        public StudentOffice() 
        { 
        }

        public Client CreateClient(string lastname, string firstname, short age, short year = 0)
        {
            return (year == 0) switch
            {
                true => new OtherClient(lastname, firstname, age),
                false => new Student(lastname, firstname, age, year),
            };
        }

        public bool GetClientByName(string name)
        {
            return ClientList.Any(KeyValuePair => KeyValuePair.Key.GetName().ToUpper().Equals(name.ToUpper()));
        }

        public void AddClient(Client client, decimal balance)
        {
            if (!GetClientByName(client.GetName()))
            {
                ClientList.Add(client, balance);
            }
        }
        public void Update(Product product)
        {
            Order newOrder = _commercial.OrderedProduct(product._productName, 40);
            _stock.AddToStock(newOrder);
        }


        public void SellProduct(Client client, Order order)
        {
            if (order._quantity > 0)
            {
                decimal appropriatePrice = client.GetAppropriatePrice(order._product) * order._quantity;
                _stock.CheckStockChange(_stock.GetNegativeQuantity(order));
                ClientList[client] -= appropriatePrice;
                _stock.SetBalance(appropriatePrice);
            }
        }

        public void SellMealPlan(IAssembler assembler, Client client)
        {
            MealPlan mealPlan = assembler.GetMealPlan();
            foreach (var product in mealPlan.MealProducts)
            {
                SellProduct(client, new Order(product, 1));
            }
        }

        public List<Client> WrongBalance(decimal minimalBalance)
        {
            return ClientList.Keys.Where(kvp => ClientList[kvp] < minimalBalance).ToList();
        }

        public List<Client> WrongBalance()
        {
            return WrongBalance(0m);
        }

        public void DisplayUsersConsole(Dictionary<Client, decimal> list)
        {
            Console.WriteLine("Liste des étudiants de la BDE ayant accès au prix préférentiel :\n");

            foreach (KeyValuePair<Client, decimal> pair in list)
            {
                Console.WriteLine("\t{0} : {1}", pair.Key.GetName(), pair.Value);
            }
            Console.ReadLine();
        }

        public void DisplayWrongBalanceClients(decimal number)
        {
            Console.WriteLine("Liste des mauvais payeurs :\n");

            foreach (Client client in WrongBalance(number))
            {
                Console.WriteLine(client.GetName());
            }
            Console.WriteLine();
        }
    }
}
