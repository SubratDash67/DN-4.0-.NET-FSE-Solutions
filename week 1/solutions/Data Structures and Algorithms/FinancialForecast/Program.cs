using System;

class Program
{
  static void Main()
  {
    double initialValue = 1000;
    double growthRate = 0.05;
    int periods = 10;

    double futureValue = Forecast(initialValue, growthRate, periods);
    Console.WriteLine($"Future Value after {periods} periods: {futureValue:F2}");
  }

  static double Forecast(double value, double rate, int periods)
  {
    if (periods == 0)
      return value;
    return Forecast(value * (1 + rate), rate, periods - 1);
  }
}
