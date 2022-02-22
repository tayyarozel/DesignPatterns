using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    // Abstract Factory=> factory desing patterni'ne ek olarak toplu nesne kullanımı ihtiyaçlarında nesne kullanımı kolaylaştırmak. 
    class Program
    {
        static void Main(string[] args)
        {   
            //9) kullanımları
            ProductManager productManager=new ProductManager(new Factory1());
            productManager.GetAll(); // BURADA FACTORY1 i çağırdığımız için ondakilere göre çalısacak
            Console.ReadLine();
        }
    }

    // 1.) loglama abstract sınıfı oluşturduk ve loglama operasyonu içeriyor
    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    // 2.)  Log4NetLogger teknoloji kullanarak loglama yapma 
    public class Log4NetLogger:Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }

    // 3.)  NLogger teknoloji kullanarak loglama yapma 
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with nLogger");
        }
    }


    //---------------------------------------------------------------------------
    
    // 4.) cachleme abstract sınıfı oluşturduk ve cache operasyonu içeriyor
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    // 5.)  MemCache teknoloji kullanarak cachleme yapma 
    public class MemCache:Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }

    // 6.)  RedisCache teknoloji kullanarak cachleme yapma 
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with Redis");
        }
    }

    // 7.) BİR FABRİKA ÜRETTİK 
    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    // 8.) FABRİKAYİ İŞLEME ALDIK VE HANGİLERİNİ KULLANARAK YAPACAKLARINI SÖYLEDİK
    public class Factory1 : CrossCuttingConcernsFactory
    {
        // LOGLAMAYI Log4NetLogger TEKNOLOJİSİNİ KULLAANRAK YAPL
        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }

        //CACHLEMEYİ RedisCache teknoloji kullanarak yap
        public override Caching CreateCaching()
        {
            return new MemCache();
        }
    }

    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new NLogger();
        }

        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }

    // 8.) KULLANIMA GELDİ SIRA
    //iş katmanı (loglama,cachleme)
    public class ProductManager
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreateLogger();// HANGİ FABRİKAYI ÇALIŞTIRACĞAIMZIA GÖRE DEĞİŞİR 1. FABRİKAYA GÖRE Log4NetLogger 2.FABRİKAYA GÖRE NLogger
            _caching = _crossCuttingConcernsFactory.CreateCaching(); // HANGİ FABRİKAYI ÇALIŞTIRACĞAIMZIA GÖRE DEĞİŞİR 1. FABRİKAYA GÖRE RedisCache 2.FABRİKAYA GÖRE MemCache
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Products listed!");
        }
    }

}
