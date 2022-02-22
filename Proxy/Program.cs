using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    // Proxy=> Sınıfın çağırdığı işlem ilk kez çağırılmış ise onu yapacak ama 2.kez çağrılmış ise kullanım şekli üzerinde bir yapıdır.s
    class Program
    {
        static void Main(string[] args)
        {
            CreditBase manager =new CreditManagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());

            Console.ReadLine();
        }
    }

    // 1.) kredi hesaplama base'i
    abstract class CreditBase
    {
        // hesaplama operasyonu
        public abstract int Calculate();
    }

    class CreditManager:CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
    }

    class CreditManagerProxy:CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            //daha önce çağrılmadıysa çalışacak ve 5 saniyelik bir  zaman geçeçek
            if (_creditManager==null)
            {
                _creditManager=new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }
            // eğer çağırılmıs isede 5 saniyelik süre artık geçmeyecek direkt kullanıcıya verilecek
            return _cachedValue;
        }
    }
}
