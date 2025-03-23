namespace WebAppCoreProduct.Services
{
    public interface IDiscountService
    {
        decimal CalculateDiscount(decimal price, double discountPercent);
        decimal CalculateFixedDiscount(decimal price, decimal fixedDiscount);
    }
}