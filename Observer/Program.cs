using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    // observer=> kendisine abone olan sistemleri bir işlem olduğunda devreye girmesini sağlanayn desen
    class Program
    {
        static void Main(string[] args)
        {  
            ProductManager productManager=new ProductManager();
            var customerObserver =new CustomerObserver();
            productManager.Attach(customerObserver);
            productManager.Attach(new EmployeeObserver());
            productManager.Detach(customerObserver);
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }
    // ürünün fiyatı dustugunde haber ver sistemi
    
    // 1.) standard kod
    abstract class Observer
    {
        public abstract void Update();
    }

    // 2.) musterilere mesaj gönderme
    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer : Product price changed!");
        }
    }

    // 3.) calısanlara mesaj gönderme
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee : Product price changed!");
        }
    }

    // kullanım
    class ProductManager
    {
        // prodyct managere abone olanları liste seklinde tutma
        List<Observer> _observers=new List<Observer>();

        // ürün fiyatı guncelleme operasyonu
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }
        
        // listeye abone, observer ekleme operasyonu
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        // listedeki aboneyi silme
        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        // kullanıcı bılgılendirme methodu
        private void Notify()
        {
            // bütün kullanıcıları bilgilendirdik
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

   


}
