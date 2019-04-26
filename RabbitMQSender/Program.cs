using System;
using MassTransit;
using RabbitMQCommon;

namespace RabbitMQSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            bus.Start();


            Console.WriteLine("Sender Started.");
            Console.WriteLine("Enter your name: ");
            var sender = Console.ReadLine();

            var messageId = 1;
            while (true)
            {
                Console.WriteLine("Enter your message here (type 'EXIT' to exit): ");
                var message = Console.ReadLine();
                if (message == null || message.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
                {
                    bus.Stop();
                    break;
                }
                bus.Publish(new Message { Id = messageId, Sender = sender, Text = message });
                messageId++;
            }

        }
    }
}
