namespace WebAppCoreProduct.Services
{
    public class DiscountService : IDiscountService
    {
        public decimal CalculateDiscount(decimal price, double discountPercent)
        {
            return price * (decimal)(discountPercent / 100);
        }

        public decimal CalculateFixedDiscount(decimal price, decimal fixedDiscount)
        {
            return price - fixedDiscount;
        }
    }
}