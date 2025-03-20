# FizzBuzz App

This is a simple console application that processes an input string, replaces every third word with "Fizz", every fifth word with "Buzz", and every word that is both the third and fifth word with "FizzBuzz". It also counts the occurrences of "Fizz", "Buzz", and "FizzBuzz" in the processed string.

## Features
- Replace every third word with "Fizz".
- Replace every fifth word with "Buzz".
- Replace every word that is both the third and the fifth with "FizzBuzz".
- Count the number of "Fizz", "Buzz", and "FizzBuzz" occurrences.
  
## Installation

1. Clone this repository:

    ```bash
    git clone https://github.com/yourusername/fizzbuzz-app.git
    ```

2. Navigate to the project folder:

    ```bash
    cd fizzbuzz-app
    ```

3. Restore the project dependencies:

    ```bash
    dotnet restore
    ```

4. Build the project:

    ```bash
    dotnet build
    ```

5. Run the application:

    ```bash
    dotnet run
    ```

## Usage

When you run the application, it will prompt you to:

1. **Enter a string** between 7 and 100 characters.
   
   - The program will process the string, replacing every third word with "Fizz", every fifth word with "Buzz", and any word that is both the third and the fifth with "FizzBuzz".
   
2. **Output**:
   - The processed string with the appropriate replacements.
   - The total count of "Fizz", "Buzz", and "FizzBuzz" occurrences.
