using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Messages;
using System.Threading;

namespace Publisher
{
    class Publisher
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost;username=user1;password=password"))
            {
                for (int i = 0; i < 100; i++)
                {
                    bus.Publish<NewDevice>(new NewDevice { Id = i, Name = "ITEM" + i, DateCreated = DateTime.UtcNow });
                    Console.WriteLine("sent");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("done");
                Console.ReadLine();
            }
        }
    }
}
