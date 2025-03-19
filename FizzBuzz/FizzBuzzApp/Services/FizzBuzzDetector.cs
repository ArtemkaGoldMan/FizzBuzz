using FizzBuzzApp.Models;
using System.Text;

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

            // TODO: Implement the FizzBuzz logic

            return new FizzBuzzResult
            {
                OutputString = string.Empty,
                Count = 0
            };
        }
    }
} 