using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    // bridge=> bir nesnenin içerisinde soyutlanabilir yani değiştirebilir kısımlar varsa onları soyutlama teknikleri ile gerçekleştirip kullanmak
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager();
            customerManager.MessageSenderBase =new SmsSender();
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }

    // 1.) mesaj gönderme bilgileri nesnesi
    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    // 2.) mesaj gönderme sınıfı
    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }

        public abstract void Send(Body body);
    }

   
    // 3.) sms ile gönderme
    class SmsSender:MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender",body.Title);
        }
    }

    //4.) mail ile gönderme
    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EmailSender", body.Title);
        }
    }

    //...5.) kullanım

    class CustomerManager
    {
        // normalde dependency injection yapılır ama bu desene göre böyle yapılır
        public MessageSenderBase MessageSenderBase { get; set; }

        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body{Title = "About the course!"});
            Console.WriteLine("Customer updated");
        }
        
    }
}
