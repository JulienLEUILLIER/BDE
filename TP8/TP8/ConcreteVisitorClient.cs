using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public class ConcreteVisitorClient : IVisitor
    {
        private readonly Dictionary<Client, decimal> ClientsTransactions;

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

        private KeyValuePair<Client, decimal> GetBestClient()
        {
            
        }

        private void DisplayBestClient(KeyValuePair<Client,decimal> kvp)
        {

        }
        
    }
}
