using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

class Program
{
  static async Task Main()
  {
    using var context = new AppDbContext();

    Console.WriteLine("▶ Eager Loading (Products with Categories):");
    var products = await context.Products
        .Include(p => p.Category)
        .ToListAsync();

    foreach (var p in products)
      Console.WriteLine($"{p.Name} - ₹{p.Price} ({p.Category.Name})");

    Console.WriteLine("\n▶ Explicit Loading (First Product’s Category):");
    var single = await context.Products.FirstAsync();
    await context.Entry(single).Reference(p => p.Category).LoadAsync();
    Console.WriteLine($"{single.Name} belongs to {single.Category.Name}");
  }
}
