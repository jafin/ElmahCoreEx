﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ElmahCore.Mvc.Middleware;

public interface IErrorLogMiddleware
{
    Task<string> LogException(Exception e, HttpContext context, Func<HttpContext, Error, Task> onError,
        string body = null);
}