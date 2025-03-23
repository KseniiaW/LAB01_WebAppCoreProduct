using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;
using WebAppCoreProduct.Services;

namespace WebAppCoreProduct.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IDiscountService _discountService;

        public ProductModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public Product Product { get; set; } = new Product();
        public string? MessageRezult { get; private set; }

        public void OnGet()
        {
            MessageRezult = "��� ������ ����� ���������� ������";
        }

        public void OnPost(string name, decimal? price)
        {
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }

            var discount = _discountService.CalculateDiscount(price.Value, 18);
            MessageRezult = $"��� ������ {name} � ����� {price} ������ �������� {discount}";

            Product.Name = name;
            Product.Price = price;
        }

        public void OnPostDiscont(string name, decimal? price, double discont)
        {
            if (price == null || price < 0 || string.IsNullOrEmpty(name) || discont < 0)
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }

            var result = _discountService.CalculateDiscount(price.Value, discont);
            MessageRezult = $"��� ������ {name} � ����� {price} � ������� {discont}% ��������� {result}";

            Product.Name = name;
            Product.Price = price;
        }

        public void OnPostFixedDiscount(string name, decimal? price, decimal fixedDiscount)
        {
            if (price == null || price < 0 || string.IsNullOrEmpty(name) || fixedDiscount < 0)
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }

            var result = _discountService.CalculateFixedDiscount(price.Value, fixedDiscount);
            MessageRezult = $"��� ������ {name} � ����� {price} � ������������� ������� {fixedDiscount} ��������� {result}";

            Product.Name = name;
            Product.Price = price;
        }
    }
}