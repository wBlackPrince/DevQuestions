﻿using DevQuestions.Application.Exceptions;
using System.Text.Json;
using Shared;

namespace DevQuestions.Web.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, exception.Message);

        var (code, errors) = exception switch
        {
            BadRequestException => (
                StatusCodes.Status500InternalServerError, JsonSerializer.Deserialize<Error[]>(exception.Message)),

            NotFoundException => (
                StatusCodes.Status404NotFound, JsonSerializer.Deserialize<Error[]>(exception.Message)),

            _ => (
                StatusCodes.Status500InternalServerError, [Error.Failure(null, "Something went wrong")]),
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;
        await context.Response.WriteAsJsonAsync(errors);
    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this WebApplication app)
        => app.UseMiddleware<ExceptionMiddleware>();

}