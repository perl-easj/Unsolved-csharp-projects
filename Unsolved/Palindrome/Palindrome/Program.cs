using System;
using System.Collections.Generic;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            IPalindromeChecker checker = new PalindromeChecker();
            Dictionary<string, bool> testData = new Dictionary<string, bool>();

            testData.Add("rotor", true);
            testData.Add("motor", false);
            testData.Add("regninger", true);
            testData.Add("Regninger", true);
            testData.Add("", true);
            testData.Add("kat", false);
            testData.Add("En af dem der tit red med fane", true);

            foreach (var testItem in testData)
            {
                bool isPalindrome = checker.IsPalindrome(testItem.Key);
                string result = isPalindrome == testItem.Value ? "OK" : "FAIL";

                Console.WriteLine($"\"{testItem.Key}\" is a palindrome -> {isPalindrome}  ({result})");
            }


            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
