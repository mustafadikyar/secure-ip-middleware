using System.Net;

namespace SecureIP.Middlewares;

public class SecureIpMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IPAddress[] _ipBlackList = { IPAddress.Parse("127.0.0.1") /*ipv4*/,  IPAddress.Parse("::1") /*ipv6*/ };

    public SecureIpMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        IPAddress? requestIpAddress = context.Connection.RemoteIpAddress;

        if (IsIpAddressInBlackList(requestIpAddress!))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return;
        }

        await _next(context);
    }

    private bool IsIpAddressInBlackList(IPAddress ipAddress)
    {
        return _ipBlackList.Contains(ipAddress);
    }
}