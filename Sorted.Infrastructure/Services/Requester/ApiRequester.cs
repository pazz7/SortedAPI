namespace Sorted.Infrastructure.Services.Requester
{
    public class ApiRequester : IApiRequester
    {
        private readonly HttpClient _httpClient;

        public ApiRequester()
        {
            _httpClient = new HttpClient() { Timeout = Timeout.InfiniteTimeSpan };
        }

        public async Task<string> GetContentAsStringAsync(
            HttpMethod httpMethod,
            string basePath,
            Dictionary<string, string> headers,
            Dictionary<string, string> queryParams)
        {
            using var response = await GetResponseAsync(httpMethod, basePath, headers, queryParams);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        private async Task<HttpResponseMessage> GetResponseAsync(
            HttpMethod httpMethod,
            string basePath,
            Dictionary<string, string> headers,
            Dictionary<string, string> queryParams)
        {
            var request = new HttpRequestMessage(httpMethod, new Uri(BuildUrlWithQueryStringUsingUriBuilder(basePath, queryParams)));

            foreach (var header in headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return await _httpClient.SendAsync(request);
        }

        private static string BuildUrlWithQueryStringUsingUriBuilder(string basePath, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(basePath)
            {
                Query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}{GetParamValue(kvp.Value)}"))
            };

            return uriBuilder.Uri.AbsoluteUri;
        }

        private static string GetParamValue(string paramValue)
        {
            return !string.IsNullOrEmpty(paramValue) ? $"={paramValue}" : "";
        }
    }
}
