using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // builder => bir nesne örneği ortaya çıkarma. bu nesne orneği birbiri arkasına atılacak adımalrın sırasıyla işlenmesi sonucuyla ortaya çıkar
    class Program
    {
        static void Main(string[] args)
        {
            // 6.) kullanımı
            ProductDirector director = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            director.GenerateProduct(builder); //directore eski müsteri gönderdim
            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);

            Console.ReadLine();

        }
    }

    //1.) product nesnesi oluşturduk
    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    // 2.) business katmanında kullanacak product operasyonlar
    abstract class ProductBuilder
    {
        // ürünleri gösterme
        public abstract void GetProductData();
        //indirim uygulama operasyonu
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }


    // 3.) yeni müsteriler için operasyonlar
    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }


    // 4.) eski müsteriler için operasyonlar
    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    //5.) Producti yönetecek bir director yazıyoruz
    class ProductDirector
    {
        // buraya kullanırken hangi builderi kullanacaksak onu göndericez ve onu ilgili gönderilendeki operasyonları çalışsıracak
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }


}
