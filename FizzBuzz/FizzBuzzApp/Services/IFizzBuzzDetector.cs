using FizzBuzzApp.Models;

namespace FizzBuzzApp.Services
{
    /// <summary>
    /// The IFizzBuzzDetector interface defines the method to process input strings
    /// and return a result containing the processed string and the count of Fizz, Buzz, and FizzBuzz words.
    /// </summary>
    public interface IFizzBuzzDetector
    {
        /// <summary>
        /// Processes an input string and returns the result containing the processed string and word count.
        /// </summary>
        /// <param name="input">The input string to be processed.</param>
        /// <returns>A FizzBuzzResult containing the processed string and the count of Fizz, Buzz, and FizzBuzz occurrences.</returns>
        FizzBuzzResult GetOverlappings(string input);
    }
} 