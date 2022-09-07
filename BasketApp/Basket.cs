namespace BasketApp
{
    public class Basket
    {
        private Order _order;
        private decimal _basketTotal;

        public Basket()
        {
            _basketTotal = _order.TotalPrice;
        }

        public Basket(Order order)
        {
            _basketTotal = order.TotalPrice;
            _order = order;
        }

        public decimal Total => _basketTotal;
    }
}