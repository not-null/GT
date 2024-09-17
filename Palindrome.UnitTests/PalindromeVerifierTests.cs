namespace Palindrome.UnitTests
{
    [TestClass]
    public class PalindromeVerifierTests
    {
        [TestMethod]
        public void IsPalindrome_Palindrome_ShouldReturnTrue()
        {
            Assert.IsTrue(PalindromeVerifier.IsPalindrome("rotator"));
        }

        [TestMethod]
        public void IsPalindrome_CapitalizedPalindrome_ShouldReturnTrue()
        {
            Assert.IsTrue(PalindromeVerifier.IsPalindrome("Anna"));
        }

        [TestMethod]
        public void IsPalindrome_NonPalindrome_ShouldReturnFalse()
        {
            Assert.IsFalse(PalindromeVerifier.IsPalindrome("Erik"));
        }
    }
}
