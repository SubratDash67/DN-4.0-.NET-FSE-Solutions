using System;

class Program
{
  static void Main()
  {
    Book[] books = new Book[]
    {
            new Book(1, "The Hobbit", "J.R.R. Tolkien"),
            new Book(2, "1984", "George Orwell"),
            new Book(3, "To Kill a Mockingbird", "Harper Lee"),
            new Book(4, "The Catcher in the Rye", "J.D. Salinger"),
            new Book(5, "Brave New World", "Aldous Huxley")
    };

    Console.WriteLine("Linear Search:");
    var result1 = LinearSearch(books, "1984");
    Console.WriteLine(result1 != null ? $"Found: {result1.Title} by {result1.Author}" : "Not Found");

    Array.Sort(books, (a, b) => a.Title.CompareTo(b.Title)); // Sort before binary search

    Console.WriteLine("Binary Search:");
    var result2 = BinarySearch(books, "1984");
    Console.WriteLine(result2 != null ? $"Found: {result2.Title} by {result2.Author}" : "Not Found");
  }

  static Book? LinearSearch(Book[] books, string title)
  {
    foreach (var book in books)
    {
      if (book.Title == title)
        return book;
    }
    return null;
  }

  static Book? BinarySearch(Book[] books, string title)
  {
    int left = 0, right = books.Length - 1;
    while (left <= right)
    {
      int mid = (left + right) / 2;
      int cmp = books[mid].Title.CompareTo(title);
      if (cmp == 0)
        return books[mid];
      else if (cmp < 0)
        left = mid + 1;
      else
        right = mid - 1;
    }
    return null;
  }
}
