namespace M91.Middlwares.InfraCodes
{
    public static class ErrorHandlingMiddlewareExtention
    {
        public static void UseMyErrorHandling(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await httpContext.Response.WriteAsync(e.Message);
            }
        }
    }
}
