using FizzBuzzApp.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace FizzBuzzApp.Services
{
    /// <summary>
    /// FizzBuzzDetector provides the functionality to process a string and replace every third word with "Fizz" and every fifth word with "Buzz". If the third and fifth words are the same, then replace with "FizzBuzz" 
    /// </summary>
    public class FizzBuzzDetector : IFizzBuzzDetector
    {
        /// <summary>
        /// Processes the input string and returns a result with words replaced by "Fizz", "Buzz", or "FizzBuzz" based on their positions.
        /// Counts occurrences of "Fizz", "Buzz", and "FizzBuzz".
        /// </summary>
        /// <param name="input">The input string to be processed.</param>
        /// <returns>A FizzBuzzResult containing the processed string and the count of Fizz, Buzz, and FizzBuzz occurrences.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the input length is outside the 7 to 100 characters range.</exception>
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

            int wordCount = 0; // index for words ONLY(no other symbols, spaces, etc.)
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