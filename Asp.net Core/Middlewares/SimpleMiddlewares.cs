using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RequestPipeline.Middlewares{
    public class SimpleMiddleware{
        private readonly RequestDelegate _next;
        public SimpleMiddleware(RequestDelegate next){
            _next = next;
        }

        public async Task Invoke(HttpContext context){
            Console.WriteLine($"Scheme: {context.Request.Scheme}");
            await context.Response.WriteAsync($"<p>Scheme: {context.Request.Scheme}</p>");
            await _next(context);

            Console.WriteLine($"Host: {context.Request.Host.Value}");
            await context.Response.WriteAsync($"<p>Host: {context.Request.Host.Value}</p>");
            await _next(context);

            Console.WriteLine($"Path: {context.Request.Path.ToString()}");
            await context.Response.WriteAsync($"<p>Path: {context.Request.Path.ToString()}</p>");
            await _next(context);

            Console.WriteLine($"QueryString: {context.Request.QueryString.Value}");
            await context.Response.WriteAsync($"<p>QueryString: {context.Request.QueryString.Value}</p>");
            await _next(context);

            Console.WriteLine($"Request Body: {context.Request.Body}");
            await context.Response.WriteAsync($"<p>Request Body: {context.Request.Body}</p>");
            await _next(context);
            
        }
    }
}