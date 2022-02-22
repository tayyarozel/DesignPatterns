using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    //prototoype => nesne üretim maliyetlerini minimize etme
    class Program
    {
        static void Main(string[] args)
        {
            // 3.) kullanımı

            //customer1  oluşturduk
            Customer customer1 = new Customer {FirstName = "Engin", LastName = "Demiroğ", City = "Ankara", Id = 1};
            
            //customer1'i customer 2 ye clonladık yani 2.bir newleme yapmadık
            Customer customer2 = (Customer)customer1.Clone();
            // ve oluşan customer2' bilgilerini değiştirdik
            customer2.FirstName = "Salih";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();

        }
    }

    //1.) Kişi nesnesi oluşturduk.
    public abstract class Person
    {
        // prototype da temel nesneyi yani "Person nesnesini" prototoype hale getirmek için onun soyut bir clone methodundan beslenmesi lazım 
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }


    //2.) Müsteri nesnesini persondan inherit ediyoruz
    public class Customer : Person
    {
        public string City { get; set; }

        // işte burası elimizdeki Customer nesnesini clonlamaya yarıyor
        public override Person Clone()
        {
            // .netteki bir method ile bunu gerçekleştirebiliyoruz
            return (Person) MemberwiseClone();
        }
    }

    
}
