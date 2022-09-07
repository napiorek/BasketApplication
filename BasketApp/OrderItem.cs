
namespace BasketApp
{
    public class OrderItem
    {
        private decimal _price;
        private string _code;
        private int _quantity;
        private List<Discount> _discounts;

        public OrderItem(string code, decimal price, int qty)
        {
            Code = code;
            Price = price;
            Quantity = qty;
        }

        public decimal Price { get => _price; set => _price = value; }
        public string Code { get => _code; set => _code = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }

        public void AddDiscount(Discount discount)
        {
            if(_discounts == null)
            {
                _discounts = new List<Discount>();
                _discounts.Add(discount);
            }
            else
            {
                _discounts.Add(discount);
            }
        }

        public List<Discount> GetDiscounts()
        {
            if (_discounts == null)
            {
                return new List<Discount>();
            }
            return _discounts;
        }
    }
}
