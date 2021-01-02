namespace TP8
{
    public class Order
    {
        public Product _product;
        public int _quantity;
        public Order(Product product, int quantity)
        {
            _product = product;
            _quantity = quantity;
        }
    }
}