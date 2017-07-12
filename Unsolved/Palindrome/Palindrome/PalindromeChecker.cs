namespace Palindrome
{
    public class PalindromeChecker : IPalindromeChecker
    {
        public bool IsPalindrome(string phrase)
        {
            string noSpacePhrase = phrase.Replace(" ", string.Empty);
            string noSpaceLowerPhrase = noSpacePhrase.ToLower();

            return IsPalindromeInternal(noSpaceLowerPhrase);
        }

        private bool IsPalindromeInternal(string phrase)
        {
            return false;
        }
    }
}