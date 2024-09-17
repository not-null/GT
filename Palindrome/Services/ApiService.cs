using Palindrome.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Palindrome.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private const string GetEndpoint = "api/get/erik";
        private const string PostEndpoint = "api/submit/erik";
        private const string Code = "DRuQSdrjDG_syswkTpRhz2l0wt_tDoOmFTGLhCCni_MDAzFuYF6Bkg==";

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetWords()
        {
            var getResponse = await _httpClient.GetAsync($"{GetEndpoint}?code={Code}");

            if (getResponse.IsSuccessStatusCode)
            {
                var responseContent = await getResponse.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<string>>(responseContent) ?? throw new JsonException("Failed to deserialize http response");
            }
            else
            {
                throw new HttpRequestException($"Http error: {getResponse.StatusCode}");
            }
        }

        public async Task<bool> SubmitAnswer(PalindromeDto dto)
        {
            // Avoid 429 response
            await Task.Delay(5000);

            HttpResponseMessage postResponse;

            do
            {
                postResponse = await _httpClient.PostAsJsonAsync($"{PostEndpoint}?code={Code}", dto);

                if (postResponse.IsSuccessStatusCode)
                {
                    // response content = {"IsValid":false,"Errors":[{"PropertyName":"NonPalindromes","ErrorMessage":"\u0027Non Palindromes\u0027 must not be empty.","AttemptedValue":null,"CustomState":null,"Severity":0,"ErrorCode":"NotEmptyValidator","FormattedMessagePlaceholderValues":{"PropertyName":"Non Palindromes","PropertyValue":null,"PropertyPath":"NonPalindromes"}}],"RuleSetsExecuted":["default"]}
                    return true;
                }
                else if (postResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    Console.WriteLine("Internal Server Error - Trying again");
                    await Task.Delay(1000);
                }
                else
                {
                    throw new HttpRequestException($"Http error: {postResponse.StatusCode}");
                }
            } while (postResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError); // never give up 💪

            return false;
        }
    }

    public interface IApiService
    {
        Task<List<string>> GetWords();
        Task<bool> SubmitAnswer(PalindromeDto dto);
    }
}
