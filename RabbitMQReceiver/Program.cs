using System;
using MassTransit;
using RabbitMQCommon;

namespace RabbitMQReceiver
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

                sbc.ReceiveEndpoint(host, "guest_queue", ep =>
                {
                    ep.Handler<Message>(context => Console.Out.WriteLineAsync($"Received from {context.Message.Sender}[{context.Message.Id}]: {context.Message.Text}"));
                });
            });

            bus.Start();

            Console.WriteLine("Receiver Started.");
            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
