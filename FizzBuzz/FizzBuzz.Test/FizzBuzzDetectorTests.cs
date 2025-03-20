using FizzBuzzApp.Models;
using FizzBuzzApp.Services;

namespace FizzBuzz.Test
{
    public class FizzBuzzDetectorTests
    {
        private readonly IFizzBuzzDetector _detector;

        public FizzBuzzDetectorTests()
        {
            _detector = new FizzBuzzDetector();
        }

        [Fact]
        public void GetOverlappings_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string? input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _detector.GetOverlappings(input!));
        }

        [Theory]
        [InlineData("short")]  // 5 characters, less than minimum 7
        [InlineData("AaaaaaaaaaAaaaaaaaaaAaaaaaaaaaAaaaaaaaaa" +
                    "AaaaaaaaaaAaaaaaaaaaAaaaaaaaaaAaaaaaaaaa" +
                    "AaaaaaaaaaAaaaaaaaaaA")]  // 101 characters, more than maximum 100
        public void GetOverlappings_InvalidLength_ThrowsArgumentException(string input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _detector.GetOverlappings(input));
        }

        [Fact]
        public void GetOverlappings_ThirdWordIsFizz_ReturnsCorrectResult()
        {
            // Arrange
            string input = "Word1 word2 word3 word4 word5 word6 word7 word8";

            // Act
            FizzBuzzResult result = _detector.GetOverlappings(input);

            // Assert
            Assert.Equal("Word1 word2 Fizz word4 Buzz Fizz word7 word8", result.OutputString);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetOverlappings_FifteenthWordIsFizzBuzz_ReturnsCorrectResult()
        {
            // Arrange
            string input = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15";

            // Act
            FizzBuzzResult result = _detector.GetOverlappings(input);

            // Assert
            string expected = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz";
            Assert.Equal(expected, result.OutputString);
            Assert.Equal(7, result.Count);
        }

        [Fact]
        public void GetOverlappings_OnlySpacesAndPunctuation_ReturnsZeroCount()
        {
            // Arrange
            string input = "   , . ! ? ! , . ! ? !  , . ! ? !   ";

            // Act
            FizzBuzzResult result = _detector.GetOverlappings(input);

            // Assert
            Assert.Equal(0, result.Count);
            Assert.Equal(input, result.OutputString);
        }

        [Fact]
        public void GetOverlappings_WithPunctuation_CountsOnlyWords()
        {
            // Arrange
            string input = "Word1, word2. word3! word4? word5 word6 word7 word8";

            // Act
            FizzBuzzResult result = _detector.GetOverlappings(input);

            // Assert
            Assert.Equal("Word1, word2. Fizz! word4? Buzz Fizz word7 word8", result.OutputString);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetOverlappings_WithMultipleSpaces_HandlesCorrectly()
        {
            // Arrange
            string input = "Word1  word2   word3    word4     word5";

            // Act
            FizzBuzzResult result = _detector.GetOverlappings(input);

            // Assert
            Assert.Equal("Word1  word2   Fizz    word4     Buzz", result.OutputString);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetOverlappings_ComplexTestCase_ReturnsCorrectResult()
        {
            // Arrange
            string input = "Mary had a little lamb Little lamb, little lamb Mary had a little lamb It's fleece was white as snow";

            // Act
            FizzBuzzResult result = _detector.GetOverlappings(input);

            // Assert
            string expected = "Mary had Fizz little Buzz Fizz lamb, little Fizz Buzz had Fizz little lamb FizzBuzz fleece was Fizz as Buzz";
            Assert.Equal(expected, result.OutputString);
            Assert.Equal(9, result.Count);
        }
    }
}