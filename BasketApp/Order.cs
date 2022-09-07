
namespace BasketApp
{
    public class Order
    {
        private readonly Discount _bigOrderDiscountValue = new Discount(0.1m, 10, false);
        private List<OrderItem> _items;
        private decimal _totalPrice;

        public Order()
        {
        }

        public Order(List<OrderItem> items)
        {
            _items = items;
        }

        public decimal TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = value;
            }
        }

        public int Quantity => Items.Count;
        public List<OrderItem> Items { get; internal set; }

        private void UpdateTotalPrice()
        {
            var items = _items.GroupBy(x => x.Code).ToList();
            _totalPrice = 0;
            decimal rawPrice = 0;
            foreach (var group in items)
            {
                var itemCode = group.Key;
                var itemQty = group.Count();
                var item = group.FirstOrDefault();

                rawPrice = item.Price * itemQty;

                var discounts = item.GetDiscounts();
                if (discounts.Count > 0)
                {
                    decimal currentDiscount = 0;
                    decimal nextDiscount = decimal.MaxValue;
                    foreach (var discount in discounts)
                    {
                        var isValid = discount.ValidateDiscount(itemQty, discount.MinQuantity);
                        if (isValid)
                        {
                            if (discounts.Count() > 1)
                            {
                                currentDiscount = ApplyDiscount(discount, item, itemQty);
                                // get the cheapest discount 
                                if (currentDiscount < nextDiscount)
                                {
                                    nextDiscount = currentDiscount;
                                }
                            }
                            else
                            {
                                currentDiscount = ApplyDiscount(discount, item, itemQty);
                            }
                        }
                    }

                    if (currentDiscount > 0)
                    {
                        // get the cheapest discount 
                        _totalPrice += Math.Min(currentDiscount, nextDiscount);
                        continue;
                    }
                }

                _totalPrice += rawPrice;
            }

            if (_items.Count() >= _bigOrderDiscountValue.MinQuantity)
            {
                _totalPrice -= (_totalPrice * _bigOrderDiscountValue.DiscountValue);
            }
        }

        public decimal ApplyDiscount(Discount discount, OrderItem product, int quantity)
        {
            decimal newPrice = 0;
            var threshold = discount.MinQuantity;
            var productQty = quantity;

            while (productQty >= threshold)
            {
                productQty -= threshold;
                if (discount.IsPriceBasedDiscountTypes)
                {
                    newPrice += discount.DiscountValue;
                }
                else
                {
                    newPrice += product.Price * discount.DiscountValue;
                }
            }

            if (productQty > 0)
            {
                newPrice += product.Price * productQty;
            }

            return newPrice;
        }

        public void AddItem(OrderItem newItem)
        {
            if (_items == null)
            {
                _items = new List<OrderItem>();
            }
            _items.Add(newItem);
            UpdateTotalPrice();
        }
    }
}
