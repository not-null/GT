namespace Palindrome.Models
{
    public record class PalindromeDto(
        IEnumerable<string> NonPalindromes,
        IEnumerable<string> Palindromes
        );
}
