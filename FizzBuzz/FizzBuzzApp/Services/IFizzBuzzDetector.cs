using FizzBuzzApp.Models;

namespace FizzBuzzApp.Services
{
    public interface IFizzBuzzDetector
    {
       FizzBuzzResult GetOverlappings(string input);
    }
} 