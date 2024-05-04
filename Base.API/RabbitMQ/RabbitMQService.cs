using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace Base.API.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConfiguration _configuration;
        public RabbitMQService(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        public void SendingMessage<T>(T message, string exchangeName, string queueName, string routingKey)
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ:HostName"],
                UserName = _configuration["RabbitMQ:UserName"],
                Password = _configuration["RabbitMQ:Password"],
                Port = int.Parse(_configuration["RabbitMQ:Port"]),
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // Declare the exchange
            channel.ExchangeDeclare(exchange: exchangeName,durable:true,type: ExchangeType.Direct);

            // Declare the queue
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: true);

            // Bind the queue to the exchange with the routing key
            channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: routingKey);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            // Publish the message to the exchange with the specified routing key
            channel.BasicPublish(exchange: exchangeName, routingKey: routingKey, body: body);
            Console.WriteLine("Message sent successfully!");
        }
    }
}
