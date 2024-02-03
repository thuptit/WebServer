using WebServer.Abstractions;

namespace WebServer
{
    public static class UseMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware<TMiddleware>(this IApplicationBuilder app)
        {
            return app.UseMiddleware(typeof(TMiddleware));
        }
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app, Type typeMiddleware)
        {
            if(!typeof(IMiddleware).IsAssignableFrom(typeMiddleware))
            {
                throw new NotSupportedException("Currently, this method is not support middle when it don't implement IMiddleware interface");
            }
            return UseMiddlewareInterface(app, typeMiddleware);
        }

        private static IApplicationBuilder UseMiddlewareInterface(IApplicationBuilder app, Type middlewareType)
        {
            return app.Use((next) => async (context) =>
            {
                var middlewareFactory = (IMiddlewareFactory?) context.RequestServices.GetService(typeof(IMiddlewareFactory));
                var middleware = middlewareFactory != null ? middlewareFactory.Create(middlewareType) : throw new InvalidOperationException(nameof(IMiddlewareFactory));
                if (middleware == null)
                    throw new InvalidOperationException(nameof(IMiddleware));

                try
                {
                    await middleware.InvokeAsync(context, next);
                }
                finally
                {
                    //TODO; release middleware
                }

                middlewareFactory = null;
                middleware = null;
            });
        }
    }
}
