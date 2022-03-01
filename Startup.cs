using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Newtonsoft.Json;

namespace SampleWebApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCustomMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/request/{data}", async context =>
                {
                    var rand = new Random();

                    if (rand.Next(0, 2) == 0)
                    {
                        var resp = new
                        {
                            echo = context.Request.RouteValues["data"].ToString()
                        };

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(resp));
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsync("Error");
                    }
                });
            });
        }
    }
}
