// C:\Users\KIIT\Desktop\DN 4.0 .NET solutions\week5\Producer\Program.cs
using System;
using System.Threading.Tasks;
using Confluent.Kafka;

public class Producer
{
  public static async Task Main(string[] args)
  {
    var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

    using (var p = new ProducerBuilder<Null, string>(config).Build())
    {
      Console.WriteLine("Enter messages (type 'exit' to quit):");

      while (true)
      {
        string message = Console.ReadLine();

        if (message.ToLower() == "exit")
        {
          break;
        }

        try
        {
          var dr = await p.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
          Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
        }
        catch (ProduceException<Null, string> e)
        {
          Console.WriteLine($"Delivery failed: {e.Error.Reason}");
        }
      }
    }
  }
}
