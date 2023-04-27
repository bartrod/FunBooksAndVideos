using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ShawBrook.Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                ProblemDetails problemDetails = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server error",
                    Title = "Server error",
                    Detail = "An internal server has occurred"
                };

                var json = JsonSerializer.Serialize(problemDetails);

                await context.Response.WriteAsync(json);
            }

        }
    }
}
