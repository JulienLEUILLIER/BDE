using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public class BestClientVisitor : IVisitor
    {
        private readonly Dictionary<Client, decimal> ClientsTransactions;

        public BestClientVisitor()
        {
            ClientsTransactions = new Dictionary<Client, decimal>();
        }

        private Client GetClientInDictionary(string name)
        {
            return ClientsTransactions.FirstOrDefault(kvp => kvp.Key.GetName().ToUpper().Equals(name.ToUpper())).Key;
        }
        public void visitTransaction(Transaction transaction)
        {
            Client transactionClient = transaction._client;
            Client checkedClient = GetClientInDictionary(transactionClient.GetName());
            decimal price = checkedClient.GetAppropriatePrice(transaction._product);

            if (checkedClient == null)
            {
                ClientsTransactions.Add(checkedClient, price);
            }
            else
            {
                ClientsTransactions[checkedClient] += price;
            }
        }

        private Client GetBestClient()
        {
            return ClientsTransactions.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }

        public void DisplayBestClient()
        {
            Client bestClient = GetBestClient();
            Console.WriteLine($"Best client is {bestClient} who spent {ClientsTransactions[bestClient]}.");
        }        
    }
}
