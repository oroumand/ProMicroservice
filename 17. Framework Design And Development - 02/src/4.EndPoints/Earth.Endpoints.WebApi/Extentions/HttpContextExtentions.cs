using Earth.Core.Contracts.ApplicationServices.Commands;
using Earth.Core.Contracts.ApplicationServices.Events;
using Earth.Core.Contracts.ApplicationServices.Queries;
using Earth.Utilities;

namespace Earth.Endpoints.WebApi.Extentions;

public static class HttpContextExtentions
{
    public static ICommandDispatcher CommandDispatcher(this HttpContext httpContext) =>
        (ICommandDispatcher)httpContext.RequestServices.GetService(typeof(ICommandDispatcher));

    public static IQueryDispatcher QueryDispatcher(this HttpContext httpContext) =>
        (IQueryDispatcher)httpContext.RequestServices.GetService(typeof(IQueryDispatcher));
    public static IEventDispatcher EventDispatcher(this HttpContext httpContext) =>
        (IEventDispatcher)httpContext.RequestServices.GetService(typeof(IEventDispatcher));
    public static ZaminServices ZaminApplicationContext(this HttpContext httpContext) =>
        (ZaminServices)httpContext.RequestServices.GetService(typeof(ZaminServices));
}