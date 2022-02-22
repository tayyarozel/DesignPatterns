using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    // Composite => nesneler arası  hiyerarsi ve bu hiyerarsı nesnelere istediğimiz zaman ulaşma
    class Program
    {

        //
        static void Main(string[] args)
        {
            Employee engin = new Employee {Name = "Engin Demiroğ"};

            Employee salih = new Employee { Name = "Salih Demiroğ" };

            engin.AddSubordinate(salih); // salih enginin' alt çalışanı

            Employee derin = new Employee { Name = "Derin Demiroğ" };
            engin.AddSubordinate(derin);// derin enginin alt çalısanı

            Contractor ali = new Contractor {Name = "Ali"};
            derin.AddSubordinate(ali); 

            Employee ahmet = new Employee { Name = "Ahmet" };
            salih.AddSubordinate(ahmet);

            Console.WriteLine(engin.Name);
            foreach (Employee manager in engin)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}", employee.Name);
                }

            }

            Console.ReadLine();

        }
    }

    // 1.) çalışanlar 
    interface IPerson
    {
        string Name { get; set; }
    }

    // 2.)
    class Contractor:IPerson
    {
        public string Name { get; set; }
    }

    // 2.) Çalışanlar
    class Employee:IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates =new List<IPerson>(); // kurumsal hiyerarsı kurduk // subordinates=> "alt" alt çalısan demek gibi

        // hiyerarsıye ekleme
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        //hiyerarsiden çıkarma
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        //hiyerarsideki kisiye,nesneye ulaşma
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
