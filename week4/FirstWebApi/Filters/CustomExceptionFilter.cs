using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstWebApi.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context)
  {
    var ex = context.Exception;
    File.AppendAllText("C:\\Users\\KIIT\\Desktop\\DN 4.0 .NET solutions\\week4\\FirstWebApi\\errorlog.txt",
        $"{DateTime.Now}: {ex.Message}{Environment.NewLine}");

    context.Result = new ObjectResult("An unexpected error occurred.")
    {
      StatusCode = 500
    };
  }
}
