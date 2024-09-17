namespace Palindrome
{
    public class PalindromeVerifier
    {
        public static bool IsPalindrome(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (char.ToLower(str[i]) != char.ToLower(str[str.Length - 1 - i]))
                    return false;
            }
            return true;
        }
    }
}
