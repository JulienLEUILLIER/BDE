using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public sealed class StudentOffice
    {
        //private static StudentOffice instance = new StudentOffice();

        //static StudentOffice()
        //{ 
        //}

        //private StudentOffice()
        //{
        //    _currentStock = new Stock();
        //}

        //public static StudentOffice Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}

        //public static void DestructStudentOffice()
        //{
        //    instance = null;
        //}

        public readonly Dictionary<Client, decimal> _ClientList = new Dictionary<Client, decimal>();

        public readonly Stock _currentStock;

        public StudentOffice()
        {
            _currentStock = new Stock();
        }

        public bool GetClientByName(string name)
        {
            return _ClientList.Any(KeyValuePair => KeyValuePair.Key.GetName().ToUpper().Equals(name.ToUpper()));
        }

        public void AddClient(Client client, decimal balance)
        {
            if (!GetClientByName(client.GetName()))
            {
                _ClientList.Add(client, balance);
            }
        }

        public void SellProduct(Client client, Product product, int number)
        {
            if (number > 0)
            {
                decimal appropriatePrice = client.GetAppropriatePrice(product) * number;
                _currentStock.CheckStockChange(product, -number);
                _ClientList[client] -= appropriatePrice;
                _currentStock.SetBalance(appropriatePrice);
            }
        }

        public List<Client> WrongBalance(decimal minimalBalance)
        {
            return _ClientList.Keys.Where(kvp => _ClientList[kvp] < minimalBalance).ToList();
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
