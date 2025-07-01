using System;

class Program
{
  static void Main(string[] args)
  {
    var basicComputer = new Computer.Builder()
        .SetCPU("Intel i3")
        .SetRAM("8GB")
        .Build();

    var gamingComputer = new Computer.Builder()
        .SetCPU("Intel i9")
        .SetRAM("32GB")
        .SetStorage("2TB SSD")
        .Build();

    Console.WriteLine("Basic Computer:\n" + basicComputer);
    Console.WriteLine("\nGaming Computer:\n" + gamingComputer);
  }
}
