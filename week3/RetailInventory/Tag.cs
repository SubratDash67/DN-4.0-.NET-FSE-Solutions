using System.Collections.Generic;

public class Tag
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public List<Product> Products { get; set; } = new();
}
