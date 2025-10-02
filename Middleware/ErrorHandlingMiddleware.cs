using System.Text.Json;
using TranslatorJsonAndXml.Models.Errors;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
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
        catch (InvalidOperationException ex) // Errores de negocio (ej: XML inválido)
        {
            _logger.LogWarning(ex, "Error de negocio");
            await HandleExceptionAsync(context, "ERR_XML_INVALIDO", "El XML recibido no tiene el formato esperado.", ex.Message, 400);
        }
        catch (JsonException ex) // Error en JSON
        {
            _logger.LogError(ex, "Error en JSON");
            await HandleExceptionAsync(context, "ERR_JSON", "Error al procesar el JSON.", ex.Message, 500);
        }
        catch (Exception ex) // Otros errores inesperados
        {
            _logger.LogError(ex, "Error inesperado");
            await HandleExceptionAsync(context, "ERR_GENERAL", "Ocurrió un error inesperado en el servidor.", ex.Message, 500);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, string code, string message, string detail, int statusCode)
    {
        var error = new ApiError
        {
            Codigo = code,
            Mensaje = message,
            Detalle = detail
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(error);
    }
}
