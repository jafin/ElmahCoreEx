using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ElmahCore.WebUi;

public static class BuilderHelper
{
    [UsedImplicitly]
    public static IApplicationBuilder UseElmah(this IApplicationBuilder app)
    {
        app.UseStaticHttpContext();
        app.UseMiddleware<ErrorLogWebUiMiddleware>();
        return app;
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public static IServiceCollection AddElmahWebUi<T>(this IServiceCollection services) where T : ErrorLog
    {
        services.AddHttpContextAccessor();
        return services.AddSingleton<ErrorLog, T>();
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public static IServiceCollection AddElmahWebUi<T>(this IServiceCollection services, Action<ElmahOptions> setupAction)
        where T : ErrorLog
    {
        var builder = services.AddElmahWebUi<T>();
        builder.Configure(setupAction);
        return builder;
    }
}