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
            _logger.LogError(ex, "Внутренняя ошибка сервера.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        string message = ex.Message;

        // Тут пока просто исключения покрывают базовые сценарии
        // - NotFoundException (404) - ресурс не найден
        //- BadRequestException (400) - некорректный запрос
        // При необходимости можно добавить обработку других HTTP статусов


        if (ex is NotFoundException)
        {
            statusCode = HttpStatusCode.NotFound;
        }
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
