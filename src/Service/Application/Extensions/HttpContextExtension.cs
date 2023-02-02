using Microsoft.AspNetCore.Http;

namespace Service.Application.Extensions;
internal static class HttpContextExtension
{
    internal static string GetContentOrEmpty(this HttpResponse response)
    {
        return response.Headers?.Any() == true
            ? response.Headers.GetHeaders()
            : string.Empty;
    }

    internal static string GetContentOrEmpty(this HttpRequest request)
    {
        return request.Headers?.Any() == true
            ? request.Headers.GetHeaders()
            : string.Empty;
    }

    private static string GetHeaders(this IHeaderDictionary headers) 
        => string.Join(", ", headers.Select(x => $"Key: {x.Key}, Value: {x.Value}"));
}