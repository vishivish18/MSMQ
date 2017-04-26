using System;
using System.Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter message to be sent");
            Console.WriteLine("High priority messages should be sent with HP:");
            string MessageToBeSend = Console.ReadLine();

            //Get or Create queue
            MessageQueue MyQueue;
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                MyQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                MyQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }

            //Create Message
            Message MyMessage = new System.Messaging.Message();

            //Set formatter for message
            MyMessage.Formatter = new BinaryMessageFormatter();
            MyMessage.Body = MessageToBeSend;
            MyMessage.Label = "App1Message";

            if (MessageToBeSend.Contains("HP:"))
            {
                MyMessage.Priority = MessagePriority.Highest;
            }
            else
            {
                MyMessage.Priority = MessagePriority.Normal;
            }

            MyQueue.Send(MyMessage);
            Console.WriteLine("Thanks for sending message");
            Console.ReadKey();




            

        }
    }
}
