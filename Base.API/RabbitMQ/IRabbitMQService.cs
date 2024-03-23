namespace Base.API.RabbitMQ
{
    public interface IRabbitMQService
    {
        public void SendingMessage<T>(T message, string queueName);
    }
}
