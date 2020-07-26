using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseWriteToConsole(this IApplicationBuilder app, string output)
        {
            return app.UseMiddleware<WriteToConsoleMiddleware>(output);
        }
    }
}
