class Program
{
  static void Main(string[] args)
  {
    var logger1 = Logger.Instance;
    var logger2 = Logger.Instance;

    logger1.Log("First message");
    logger2.Log("Second message");

    if (ReferenceEquals(logger1, logger2))
    {
      Console.WriteLine("Same instance used.");
    }
    else
    {
      Console.WriteLine("Different instances!");
    }
  }
}
