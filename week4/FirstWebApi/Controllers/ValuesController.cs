using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ValuesController : ControllerBase
  {
    private static readonly List<string> _values = new() { "Value1", "Value2" };

    [HttpGet]
    public IActionResult Get() => Ok(_values);

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      if (id < 0 || id >= _values.Count)
        return NotFound();
      return Ok(_values[id]);
    }

    [HttpPost]
    public IActionResult Post([FromBody] string value)
    {
      _values.Add(value);
      return Ok(_values);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] string value)
    {
      if (id < 0 || id >= _values.Count)
        return NotFound();
      _values[id] = value;
      return Ok(_values);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      if (id < 0 || id >= _values.Count)
        return NotFound();
      _values.RemoveAt(id);
      return Ok(_values);
    }
  }
}
