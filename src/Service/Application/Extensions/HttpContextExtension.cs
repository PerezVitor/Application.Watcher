using Azure.Core;
using Microsoft.AspNetCore.Http;

namespace Service.Application.Extensions;
internal static class HttpContextExtension
{
    internal static string GetContentOrEmpty(this HttpResponse response)
    {
        return response.Headers?.Any() == true
            ? string.Join(", ", response.Headers.Select(x => $"Key: {x.Key}, Value: {x.Value}"))
            : string.Empty;
    }

    internal static string GetContentOrEmpty(this HttpRequest request)
    {
        return request.Headers?.Any() == true
            ? string.Join(", ", request.Headers.Select(x => $"Key: {x.Key}, Value: {x.Value}"))
            : string.Empty;
    }
}
