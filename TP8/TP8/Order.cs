namespace TP8
{
    public class Order
    {
        public Product _product;
        public int _quantity;
        public Order(ISellable product, int quantity)
        {
            _product = (Product)product;
            _quantity = quantity;
        }
    }
}