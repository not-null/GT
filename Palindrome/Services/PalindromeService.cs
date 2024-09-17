using Palindrome.Models;

namespace Palindrome.Services
{
    public class PalindromeService : IPalindromeService
    {
        private readonly IApiService _apiService;

        public PalindromeService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<PalindromeDto> Run()
        {
            var words = await _apiService.GetWords();
            var palindromeResults = words.GroupBy(PalindromeVerifier.IsPalindrome);
            var dto = new PalindromeDto(
                NonPalindromes: palindromeResults.Where(kvp => !kvp.Key).SelectMany(x => x),
                Palindromes: palindromeResults.Where(kvp => kvp.Key).SelectMany(x => x)
            );
            await _apiService.SubmitAnswer(dto);
            return dto;
        }
    }

    public interface IPalindromeService
    {
        Task<PalindromeDto> Run();
    }
}
