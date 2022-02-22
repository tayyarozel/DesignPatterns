using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    //singleton design patterns: bir nesne örneğinden sadece 1 kere üretilip her zaman herkesin kullanılması.
    // NOT: BİZ PROJELERDE SINGLETON DESİGN PATTERNİNİN BÖYLE KULLANMAYIZ. FACTORY DESİGN PATTERNİNİ KULLANARAK ORTAK BİR YAPI KURARIZ VE O NESNE ÜZERİNDEN SİNGLETON ÜRETİRİZ( IOC CONTAİNER=> NİNJECT,AUTOFAC)
    class Program
    {
        static void Main(string[] args)
        {
            //4.) kullanımı => artık bunu newlemiyoruz method üzerinden ulaşabiliriz
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        // 3.) daha öncden varmı yok mu diye kontrol edeceğimiz bir nesneye ihtiyacımız var onu oluştur. static oluşturulur.
        private static CustomerManager _customerManager;
        
        //5.) iki kişi aynı anda üretmesin diye böyle bir kontrol yapılır
        static object _lockObject =new object();

        // 1.) Private olan bir constructor yazılır
        private CustomerManager()
        {
            
        }


        // 2.) Singleton örneği oluşturulacak method yazılır. Static olarak yazılr
        // daha önce CustomerManager oluşturulmuş mu oluşturulmussa döndür oluşturulmamıssa  oluştur döndür.
        public static CustomerManager CreateAsSingleton()
        {
            // ilk önce ilk yapılan bir istek yapılsın işlem bitsin sonra 2. sıradakıne geçsin onada üretileceği için üretilmiş olan verilecek
            lock (_lockObject)
            {
                //önceden üretillmis mi 
                if (_customerManager==null)
                {
                    //üretilmemis ise oluştur ver
                    _customerManager=new CustomerManager();
                }
            }
            // üretilmis ise  hali hazırda olana ver
            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved!!");
        }

    }
}
