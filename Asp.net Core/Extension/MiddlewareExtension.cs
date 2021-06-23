using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RequestPipeline.Middlewares;

namespace RequestPipeline.Extensions
{
    public static class MiddlewareExtensions{
        public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleMiddleware>();
        }
    }
}