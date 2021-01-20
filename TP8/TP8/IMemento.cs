using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public interface IMemento
    {
        Dictionary<Client, decimal> GetClientsSnapshot();
        IStockData GetStockSnapshot();
        List<Transaction> GetTransactionsSnapshot();
    }
}
