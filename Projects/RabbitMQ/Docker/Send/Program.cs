using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Send
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var polly = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(5, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, context) =>
                    {
                        Console.WriteLine("Failed to connect to queues", exception);
                    }
                )
                .ExecuteAsync(() =>
                {
                    var factory = new ConnectionFactory() { HostName = "queues", Password = "guest", UserName = "guest" };
                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "hello",
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                        var message = JsonConvert.SerializeObject(new { id = 1, message = "Hello, world!" });
                        var body = Encoding.UTF8.GetBytes(message);

                        while (true)
                        {
                            channel.BasicPublish(exchange: "",
                                                 routingKey: "hello",
                                                 basicProperties: null,
                                                 body: body);
                            Console.WriteLine(" [x] Sent {0}", message);

                            Thread.Sleep(5000);
                        }
                    }
                });

            polly.Wait();
        }
    }
}
