using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Todo.Shared.Exceptions.Handler
{
    public class TodoExceptionHandler(ILogger<TodoExceptionHandler> _logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError($"Error log start at {DateTime.Now}");

            (string Details, string Title, int StatusCode) details = exception switch
            {
                InternalServerException =>
                (
                    exception.Message,
                    exception.GetType().Name,
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError
                ),
                BadRequestException =>
                (
                    exception.Message,
                    exception.GetType().Name,
                    context.Response.StatusCode = StatusCodes.Status400BadRequest
                 ),
                NotFoundException =>
                (
                   exception.Message,
                   exception.GetType().Name,
                   context.Response.StatusCode = StatusCodes.Status404NotFound
                ),
                _ =>
                 (
                    exception.Message,
                   exception.GetType().Name,
                   context.Response.StatusCode = StatusCodes.Status500InternalServerError
                )
            };


            var problemDetails = new ProblemDetails()
            {
                Title = details.Title,
                Detail = details.Details,
                Status = details.StatusCode
            };

            problemDetails.Extensions.Add("endpoint", context.Request.Path);

            if (exception is ValidationException validationException)
            {

                problemDetails.Extensions.Add("validationErrors", validationException.Errors);

            }

            await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;

        }
    }
}
