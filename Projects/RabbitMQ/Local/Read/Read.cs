using RabbitMQ.Client;
using System;
using System.Threading;

internal class Receive
{
    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(
                queue: "downloader",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            while (true)
            {
                Console.Clear();
                Console.Write($"Current Message Count: {channel.MessageCount(queue: "downloader")}");
                Thread.Sleep(500);
            }
        }
    }
}