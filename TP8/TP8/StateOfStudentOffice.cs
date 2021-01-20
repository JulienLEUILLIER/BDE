using System.Collections.Generic;

namespace TP8
{
    internal class StateOfStudentOffice : IMemento
    {
        private readonly Dictionary<Client, decimal> _clientsSnapshot;

        private readonly IStockData _stockSnapshot;

        private readonly List<Transaction> _transactionsSnapshot;

        public StateOfStudentOffice(
            Dictionary<Client, decimal> clients, 
            IStockData stock, 
            List<Transaction> transactions){

            _clientsSnapshot = clients;
            _stockSnapshot = stock;
            _transactionsSnapshot = transactions;
        }

        public Dictionary<Client, decimal> GetClientsSnapshot()
        {
            return _clientsSnapshot;
        }

        public IStockData GetStockSnapshot()
        {
            return _stockSnapshot;
        }

        public List<Transaction> GetTransactionsSnapshot()
        {
            return _transactionsSnapshot;
        }
    }
}