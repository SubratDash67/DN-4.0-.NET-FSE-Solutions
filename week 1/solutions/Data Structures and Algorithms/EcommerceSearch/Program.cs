using System;

class Program
{
  static void Main()
  {
    Product[] products = new Product[]
    {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Phone", "Electronics"),
            new Product(103, "Shirt", "Apparel"),
            new Product(104, "Shoes", "Footwear"),
            new Product(105, "Watch", "Accessories")
    };

    Console.WriteLine("Linear Search:");
    var result1 = LinearSearch(products, "Shoes");
    Console.WriteLine(result1 != null ? $"Found: {result1.ProductName}" : "Not Found");

    Array.Sort(products, (a, b) => a.ProductName.CompareTo(b.ProductName));

    Console.WriteLine("Binary Search:");
    var result2 = BinarySearch(products, "Shoes");
    Console.WriteLine(result2 != null ? $"Found: {result2.ProductName}" : "Not Found");
  }

  static Product? LinearSearch(Product[] products, string name)
  {
    foreach (var product in products)
    {
      if (product.ProductName == name)
        return product;
    }
    return null;
  }

  static Product? BinarySearch(Product[] products, string name)
  {
    int left = 0, right = products.Length - 1;
    while (left <= right)
    {
      int mid = (left + right) / 2;
      int cmp = products[mid].ProductName.CompareTo(name);
      if (cmp == 0)
        return products[mid];
      else if (cmp < 0)
        left = mid + 1;
      else
        right = mid - 1;
    }
    return null;
  }
}
