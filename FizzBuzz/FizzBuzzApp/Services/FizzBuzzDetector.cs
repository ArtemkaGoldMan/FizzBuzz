using FizzBuzzApp.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace FizzBuzzApp.Services
{
    public class FizzBuzzDetector : IFizzBuzzDetector
    {
        public FizzBuzzResult GetOverlappings(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            }

            if (input.Length < 7 || input.Length > 100)
            {
                throw new ArgumentException("Input string length must be between 7 and 100 characters.", nameof(input));
            }

            var tokens = Regex.Split(input, @"(\s+|[,!?.])").ToList();

            int wordCount = 0;
            int coincedencesCount = 0;
            var outputTokens = new List<string>();


            foreach (var token in tokens)
            {
                if (string.IsNullOrWhiteSpace(token) || Regex.IsMatch(token, @"^[\W_]+$"))
                {
                    outputTokens.Add(token);
                }
                else
                {
                    wordCount++;
                    if (wordCount % 3 == 0 && wordCount % 5 == 0)
                    {
                        outputTokens.Add("FizzBuzz");
                        coincedencesCount++;
                    }
                    else if (wordCount % 3 == 0)
                    {
                        outputTokens.Add("Fizz");
                        coincedencesCount++;
                    }
                    else if (wordCount % 5 == 0)
                    {
                        outputTokens.Add("Buzz");
                        coincedencesCount++;
                    }
                    else
                    {
                        outputTokens.Add(token);
                    }
                }
            }

            var outputString = string.Join("", outputTokens);

            return new FizzBuzzResult
            {
                OutputString = outputString,
                Count = coincedencesCount,
            };
        }
    }
}