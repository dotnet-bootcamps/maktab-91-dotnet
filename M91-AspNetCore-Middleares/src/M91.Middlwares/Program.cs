using M91.Middlwares.InfraCodes;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;

namespace M91.Middlwares
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigServices(builder);
            var app = builder.Build();
            ConfigPipeLine(app);
            app.Run();
        }

        private static void ConfigServices(WebApplicationBuilder builder)
        {
            builder.Services.AddMvc();
            builder.Services.AddAuthorization();
            builder.Services.AddRazorPages();
            builder.Services.AddHttpClient();

            // *** add my custom services to Di Container ***
            //builder.Services.AddTransient<>();
            //builder.Services.AddScoped<>();
            //builder.Services.AddSingleton<>();
        }

        private static void ConfigPipeLine(WebApplication app)
        {
            // *** add my custom middlewares to aspnetcore request pipeline ***

            //app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMyErrorHandling();

            app.Map("/tehran", tehranApp =>
            {
                tehranApp.Use(async (httpContext, next) =>
                {
                    await next();
                });

                tehranApp.Use(async (httpContext, next) =>
                {
                    httpContext.Response.ContentType = "text/html";
                    await httpContext.Response.WriteAsync("<br /> I am from 1st middleware (before call next middleware)");
                    await next();
                    await httpContext.Response.WriteAsync("<br /> I am from 1st middleware (after call next middleware)");
                });

                tehranApp.Use(async (httpContext, next) =>
                {

                    httpContext.Response.ContentType = "text/html";
                    await httpContext.Response.WriteAsync("<br /> I am from 2nd middleware (before call next middleware) <br />");
                    await next();
                    await httpContext.Response.WriteAsync("<br /> I am from 2nd middleware (after call next middleware)");

                    //throw new Exception("Error....");
                });
            });

            app.Map("/shiraz", shirazApp =>
            {
                shirazApp.Use(async (httpContext, next) =>
                {

                    httpContext.Response.ContentType = "text/html";
                    await httpContext.Response.WriteAsync("Shiraz App");
                    await next();

                });
            });
            
            //app.MapGet("/", () => "<b>Hello World!</b>");

        }

    }
}