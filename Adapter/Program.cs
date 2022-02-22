using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    // Adapter => farklı sistemlerin kendi sistemize entegre edilmesi sırasında kendi sistemimizin bozulmadan farklı sistemin sanki bizim sistemimiz gibi davranmasını sağlamak 
    class Program
    {
        static void Main(string[] args)
        {
            // 4.) kullanımı
            ProductManager productManager=new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();
        }
    }
    
    
    interface ILogger
    {
        void Log(string message);
    }
    
    // 1.) kendi sistemimiz diyelim
    class EdLogger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, {0}",message);
        }
    }

    // 2.)  dışarıdan bir loglama sistemi ekledik diyelim. ve bunu baskası yazdığı için bu classa kesinlikle dokunamıyoruz
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with log4net, {0}", message);
        }
    }


    // 3.) Adapter deseni burda devreye giriyor => ben neyle çalısacağıma kendim karar veriyorum
    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            // burayı ister log4Net istersen EdLogger yap
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    

    

   

    
}
