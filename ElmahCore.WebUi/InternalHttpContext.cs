using Microsoft.AspNetCore.Http;

namespace ElmahCore.WebUi;

internal static class InternalHttpContext
{
    private static IHttpContextAccessor _contextAccessor;

    public static HttpContext Current => _contextAccessor.HttpContext;

    internal static void Configure(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
}