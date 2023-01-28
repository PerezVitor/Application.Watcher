using Microsoft.AspNetCore.Http;

namespace Service.Application.Extensions;
internal static class HttpContextExtension
{
    internal static string GetContentOrEmpty(this HttpResponse response)
    {
        return response.ContentLength > 0
            ? response.Headers.Select(x => x.ToString()).Aggregate((a, b) => a + ": " + b) 
            : string.Empty;
    }

    internal static string GetContentOrEmpty(this HttpRequest request)
    {
        return request.ContentLength > 0
            ? request.Headers.Select(x => x.ToString()).Aggregate((a, b) => a + ": " + b)
            : string.Empty;
    }
}
