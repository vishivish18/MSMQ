using System;
using System.Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Latest Message");

            MessageQueue MyQueue;
            MyQueue = new MessageQueue(@".\Private$\MyQueue");

            MyQueue = new MessageQueue(@".\Private$\MyQueue");

            Message MyMessage = MyQueue.Receive();
            MyMessage.Formatter = new BinaryMessageFormatter();

            Console.WriteLine(MyMessage.Body.ToString());
            Console.ReadKey();


        }
    }
}
