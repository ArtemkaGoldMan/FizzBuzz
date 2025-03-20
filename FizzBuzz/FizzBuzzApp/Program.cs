using FizzBuzzApp.Models;
using FizzBuzzApp.Services;

namespace FizzBuzzApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            IFizzBuzzDetector detector = new FizzBuzzDetector();

            Console.WriteLine("Enter a string (7 - 100 characters):");

            string input;
            do
            {
                input = Console.ReadLine()!;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty or just whitespace.");
                }
            } while (string.IsNullOrEmpty(input));

            try
            {
                FizzBuzzResult result = detector.GetOverlappings(input);

                Console.WriteLine("Output String:");
                Console.WriteLine(result.OutputString);
                Console.WriteLine("Fizz, Buzz, and FizzBuzz count: " + result.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }


        }
    }
}
