using System.Text;
using System.Text.Json;

namespace PollPulse.Web.HttpClientUtility
{
    public static class HttpClientAPIHelper
    {
        public static async Task<TResponse?> PostAsync<TRequest, TResponse>(HttpClient client, string url, TRequest requestContent) 
        {
            var content = JsonSerializer.Serialize(requestContent);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, bodyContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseContent))
                return default(TResponse);

            return JsonSerializer.Deserialize<TResponse>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
