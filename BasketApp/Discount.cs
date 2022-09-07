namespace BasketApp
{
    public class Discount
    {
        private int _minQuantity;
        private decimal _discountValue;

        public Discount(decimal price, int minQty, bool isPriceBasedDiscountTypes)
        {
            DiscountValue = price;
            MinQuantity = minQty;
            IsPriceBasedDiscountTypes = isPriceBasedDiscountTypes;
        }

        public int MinQuantity { get => _minQuantity; set => _minQuantity = value; }
        public decimal DiscountValue { get => _discountValue; set => _discountValue = value; }

        public bool IsPriceBasedDiscountTypes { get; set; }
        public bool ValidateDiscount(int itemQty, int minQty)
        {
            return itemQty >= minQty;
        }
    }
}
