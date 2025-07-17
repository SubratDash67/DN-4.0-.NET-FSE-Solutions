// C:\Users\KIIT\Desktop\DN 4.0 .NET solutions\week5\Consumer\Program.cs
using System;
using System.Threading;
using Confluent.Kafka;

class Consumer
{
  public static void Main(string[] args)
  {
    var conf = new ConsumerConfig
    {
      GroupId = "chat-group",
      BootstrapServers = "localhost:9092",
      AutoOffsetReset = AutoOffsetReset.Earliest
    };

    using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
    {
      c.Subscribe("chat-topic");

      CancellationTokenSource cts = new CancellationTokenSource();
      Console.CancelKeyPress += (_, e) =>
      {
        e.Cancel = true;
        cts.Cancel();
      };

      Console.WriteLine("Waiting for messages... (Press Ctrl+C to exit)");

      try
      {
        while (true)
        {
          try
          {
            var cr = c.Consume(cts.Token);
            Console.WriteLine($"Consumed message: '{cr.Message.Value}'");
          }
          catch (ConsumeException e)
          {
            Console.WriteLine($"Error occured: {e.Error.Reason}");
          }
        }
      }
      catch (OperationCanceledException)
      {
        c.Close();
      }
    }
  }
}
