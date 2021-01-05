using System.Collections.Generic;

namespace TP8
{
    public interface IStockData
    {
        Product GetProductByName(string name);

        int GetProductQuantity(string name);

        Dictionary<Product, int> StockProduct { get; set; }
        decimal CurrentBalance { get; }
    }
}