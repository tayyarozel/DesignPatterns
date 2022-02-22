using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    // facade => dış görünüs,cephe her sınıfta ortak operasyonlar varsa bunlara ayrı ayrı ulaşmak yerine, tek bir yere toplayıp ordan ulaşma
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }
    
    interface ILogging
    {
        void Log();
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    
    interface ICaching
    {
        void Cache();
    }

    class Caching:ICaching
    {

        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    
    internal interface IValidate
    {
        void Validate();
    }

    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }


    

    class CrossCuttongConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validation;


        public CrossCuttongConcernsFacade()
        {
            Logging =new Logging();
            Caching=new Caching();
            Authorize=new Authorize();
            Validation =new Validation();
        }
    }


    class CustomerManager
    {
        private CrossCuttongConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttongConcernsFacade();
        }

        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.Logging.Log();
            _concerns.Validation.Validate();
            Console.WriteLine("Saved");
        }
    } 
}
