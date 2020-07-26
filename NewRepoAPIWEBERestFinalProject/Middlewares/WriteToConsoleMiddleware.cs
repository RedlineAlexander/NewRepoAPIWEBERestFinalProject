using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace NewRepoAPIWEBERestFinalProject.Middlewares
{
    public class WriteToConsoleMiddleware
    {
        private RequestDelegate _next { get; }

        private string _output { get; }

        public WriteToConsoleMiddleware(RequestDelegate next, string output)
        {
            _next = next;
            _output = output;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine(_output + "before");
            await _next(context);
            Console.WriteLine(_output + "after");
        }
    }
}
