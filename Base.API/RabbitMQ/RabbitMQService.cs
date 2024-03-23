using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace Base.API.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        public void SendingMessage<T>(T message, string queueName)
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "123456",
                Port = 5672,
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false);

            var jsonString = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish(exchange: "", routingKey: queueName, body: body);
            Console.WriteLine("Connection successful!");
        }
    }
}
