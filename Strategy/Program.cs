using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    // stretegy=> stratejiye göre methodların çalıştırılmasıs
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager();
            customerManager.CreditCalculatorBase = new After2010CreditCalculator();
            customerManager.SaveCredit();

            customerManager.CreditCalculatorBase = new Before2010CreditCalculator();
            customerManager.SaveCredit();
            Console.ReadLine();
        }
    }

    //1.) kredi hesaplama base'i
    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    //2.) 2010'dan önce müsteri için
    class Before2010CreditCalculator:CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before2010");
        }
    }
    //3.) 2010'dan sonra müsteri için
    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after2010");
        }
    }

    // 4.) kullanım
    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }

        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            CreditCalculatorBase.Calculate();

        }
    }
}
