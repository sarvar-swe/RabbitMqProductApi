namespace RabbitMqProductsAPI.RabbitMQ;

public interface IRabbitMQProducer
{
    public void SendProductMessage <T> (T message);
}