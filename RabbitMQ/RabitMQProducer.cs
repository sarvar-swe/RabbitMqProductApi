using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMqProductsAPI.RabbitMQ;

public class RabitMQProducer : IRabbitMQProducer
{
    public void SendProductMessage<T>(T message)
    {
        var factory = new ConnectionFactory {
            HostName = "localhost",
        };

        var connection = factory.CreateConnection();
        using
        var channel = connection.CreateModel();
        channel.QueueDeclare("product", exclusive: false);
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);
        channel.BasicPublish(exchange: "", routingKey: "product", body: body);
    }
}