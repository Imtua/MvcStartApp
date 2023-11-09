using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using MvcStartApp.Models;
using Microsoft.Extensions.DependencyInjection;
using MvcStartApp.Models.Db;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Repositories;
using MvcStartApp.Models.Interfaces;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Метод-конструктор компонента Middleware.
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Асинхронный метод Middleware компонента.
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            var repository = context.RequestServices.GetRequiredService<IRequestRepository>();

            await repository.AddRequest(new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = context.Request.Host.Value + context.Request.Path
            });

            await _next.Invoke(context);
        }
    }
}
