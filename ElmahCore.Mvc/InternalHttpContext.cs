using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace ElmahCore.Mvc;

internal static class InternalHttpContext
{
    [CanBeNull] private static IHttpContextAccessor _contextAccessor;

    public static HttpContext Current => _contextAccessor?.HttpContext;

    internal static void Configure(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
}