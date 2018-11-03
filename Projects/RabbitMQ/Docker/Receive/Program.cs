using System;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using Polly;
using System.Threading.Tasks;
using System.Threading;

namespace Receive
{
    class Program
    {
        private static void Main(string[] args)
        {
            var polly = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(5, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, context) =>
                    {
                        Console.WriteLine($"Failed to connect to queues. Retrying in {timeSpan.Seconds}", exception);
                    }
                )
                .ExecuteAsync(async () =>
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

                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            //Console.WriteLine(" [x] Received {0}", message);
                        };
                        channel.BasicConsume(queue: "hello",
                                             autoAck: true,
                                             consumer: consumer);
                        Thread.Sleep(Timeout.Infinite);
                    }
                });

            polly.Wait();
        }
    }
}
