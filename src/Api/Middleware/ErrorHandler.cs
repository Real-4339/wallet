using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Net;
using Api.Errors;

namespace Api.Middleware;

public class ErrorHandler
{
   private readonly RequestDelegate _next;
   public ErrorHandler(RequestDelegate next)
   {
      _next = next;
   }

   public async Task Invoke(HttpContext context)
   {
      try
      {
         await _next(context);
      }
      catch (Exception ex)
      {
         await HandleExceptionAsync(context, ex);
      }
   } 

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected
    
        if (exception is BadRequestError) code = HttpStatusCode.BadRequest; // 400
        else if (exception is KeyNotFoundException) code = HttpStatusCode.NotFound; // 404
        else if (exception is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized; // 401
        else if (exception is ValidationException) code = HttpStatusCode.Conflict; // 409
        else if (exception is HttpRequestException) code = HttpStatusCode.Forbidden; // 403
    
        var result = JsonSerializer.Serialize(new 
        {
            error = new 
            {   
               code = code,
               message = exception.Message,
            }
        });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    } 
}

