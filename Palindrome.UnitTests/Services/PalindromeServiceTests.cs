using Moq;
using Palindrome.Models;
using Palindrome.Services;

namespace Palindrome.UnitTests.Services
{
    [TestClass]
    public class PalindromeServiceTests
    {
        private static readonly Mock<IApiService> _apiService = new();
        private IPalindromeService _palindromeService = new PalindromeService(_apiService.Object);

        [TestMethod]
        public async Task Run_ShouldReturnCorrectlyGroupedWords()
        {
            _apiService.Setup(x => x.GetWords()).ReturnsAsync(["Level", "Madam", "Racecar", "Radar", "Rotator", "Apple", "Carrot", "Giraffe", "Penguin", "Tiger"]);
            _apiService.Setup(x => x.SubmitAnswer(It.IsAny<PalindromeDto>())).ReturnsAsync(true);

            var expected = new PalindromeDto(
                NonPalindromes: ["Apple", "Carrot", "Giraffe", "Penguin", "Tiger"],
                Palindromes: ["Level", "Madam", "Racecar", "Radar", "Rotator",]);

            var result = await _palindromeService.Run();

            Assert.IsTrue(expected.NonPalindromes.ToHashSet().SetEquals(result.NonPalindromes.ToHashSet()));
            Assert.IsTrue(expected.Palindromes.ToHashSet().SetEquals(result.Palindromes.ToHashSet()));
        }
    }
}
