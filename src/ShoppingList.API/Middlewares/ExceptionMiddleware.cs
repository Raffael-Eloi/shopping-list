using System.Net;
using System.Text.Json;

namespace ShoppingList.API.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        string exceptionDetailsJson = GetExpectionDetail(context, exception);

        return context.Response.WriteAsync(exceptionDetailsJson);
    }

    private static string GetExpectionDetail(HttpContext context, Exception exception)
    {
        object exceptionDetails = new
        {
            context.Response.StatusCode,
            exception.Message,
            exception.StackTrace
        };

        return JsonSerializer.Serialize(exceptionDetails);
    }
}