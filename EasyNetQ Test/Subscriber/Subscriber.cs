using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Messages;

namespace Subscriber
{
    class Subscriber
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost;username=user2;password=password"))
            {
                bus.Subscribe<NewDevice>("Devices.New", x => Console.WriteLine("Id: " + x.Id + ", Name: "  + x.Name + ", Created: " + x.DateCreated));
                Console.WriteLine("waiting");
                Console.ReadLine();
            }
        }
    }
}
