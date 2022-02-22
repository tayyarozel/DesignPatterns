using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{

    // factory method: 
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager(new LoggerFactory());
            customerManager.Save();

            Console.ReadLine();
        }
    }
    
    
    //1.) Loglama işlemi yapan bir interface ürettik ve loglama operasyonu yazdık
    public interface ILogger
    {
        void Log();
    }

    //2.) Loglama fabrikası ürettik. ve ILogeer türünde loglama yapan bir operasyon yazdık
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

   
    //3.) EdLogger teknolojisini kullanarak loglama yapan sınıf ürettik
    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }

    //4.) Log4NetLogger teknolojisini kullanarak loglama yapan sınıf ürettik
    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }


    //5.) fabrikamızı işleme aldık ve hangi teknoloji ile loglama yapacağını söyledik

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new EdLogger();
        }
    }

  

  

    public class CustomerManager
    {
        //bağımlı kalmamak adına sonradan 2.bir fabrika eklersek onuda rahatlıkla ekleyebilelim dite
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log(); // 6.) burada artık yukarıda fabrikamızda hangi teknolojiyi vermisisek artık o çalışır 
        }
    }
}
