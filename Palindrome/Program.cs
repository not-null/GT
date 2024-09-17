using Palindrome.Services;

// setup
IPalindromeService _palindromeService = new PalindromeService(new ApiService(new HttpClient()
{
    BaseAddress = new Uri("https://gt-code-test.azurewebsites.net/")
}));

// execution
var result = await _palindromeService.Run();

// result
Console.WriteLine("Palindromes: " + String.Join(", ", result.Palindromes));
Console.WriteLine("Non palindromes: " + String.Join(", ", result.NonPalindromes));
