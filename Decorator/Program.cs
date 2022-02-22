using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    // decoder => elimizde bulunan temel nesneyi farklı kosullarda farklı anlamlar yüklemek 
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar=new PersonalCar{Make = "BMW", Model = "3.20", HirePrice = 2500};

            SpecialOffer specialOffer=new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 10;

            Console.WriteLine("Concrete : {0}", personalCar.HirePrice);
            Console.WriteLine("Special offer : {0}",specialOffer.HirePrice);

            Console.ReadLine();
        }
    }

    // 1.) araba classı oluşturduk
    abstract class CarBase
    {
        public abstract string Make { get; set; }// marka
        public abstract string Model { get; set; } // model
        public abstract decimal HirePrice { get; set; }// kiralama ücreti
    }

    // 2.) binek iraç kıralama
    class PersonalCar:CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    // 3.)  ticari araç kiralama
    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    // 4.) decorator yazdımı buraya neyle calışağımızı göndericez
    abstract class CarDecoratorBase:CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    // 5.) kullanım
    class SpecialOffer:CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }

        public override decimal HirePrice
        {
            get { return _carBase.HirePrice -_carBase.HirePrice * DiscountPercentage/100; }
            set
            {
                
            }
        }
    }
}
