using System.Net;
using TestBackEnd.Dto;
using TestBackEnd.Exceptions;

namespace TestBackEnd.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal server error.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        string message = ex.Message;

        if (ex is NotFoundException)
        {
            statusCode = HttpStatusCode.NotFound;
        }
        // я сделал это исключение но не использую его, я так понял что валидация запроса в контроллере проходит автоматически
        // через ModelState или я не прав и это лучше сделать в ручную?)))
        else if (ex is BadRequestException)
        {
            statusCode = HttpStatusCode.BadRequest;
        }

        var errorDto = new ErrorDto
        {
            StatusCode = (int)statusCode,
            Message = message
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsJsonAsync(errorDto);
    }
}
