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
                bus.SubscribeAsync<NewDevice>("Devices.New", x =>
                    Task.Factory.StartNew(() =>
                    {
                        PrintNewDeviceName(x);
                    }));
                Console.WriteLine("waiting");
                Console.ReadLine();
            }
        }

        public static void PrintNewDeviceName(NewDevice device)
        {
            Console.WriteLine("Id: " + device.Id + ", Name: " + device.Name + ", Created: " + device.DateCreated);
        }
    }
}
