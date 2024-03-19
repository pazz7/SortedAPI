namespace Sorted.Infrastructure.Services.Requester
{
    public interface IApiRequester
    {
        Task<string> GetContentAsStringAsync(HttpMethod httpMethod, string basePath, Dictionary<string, string> headers, Dictionary<string, string> queryParams);
    }
}