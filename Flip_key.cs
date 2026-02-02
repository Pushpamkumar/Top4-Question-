using System;
using System.Text;

/// <summary>
/// Contains methods to process and transform input strings
/// based on validation and character manipulation rules.
/// </summary>
public class Program
{
    /// <summary>
    /// Cleanses the input string by validating it, removing characters
    /// with even ASCII values, reversing the result, and converting
    /// characters at even positions to uppercase.
    /// </summary>
    /// <param name="input">
    /// Input string that must contain only alphabets
    /// and have a minimum length of 6 characters.
    /// </param>
    /// <returns>
    /// A transformed string generated according to the rules,
    /// or an empty string if the input is invalid.
    /// </returns>
    public string CleanseAndInvert(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return string.Empty;
        }

        foreach (char ch in input)
        {
            if (!char.IsLetter(ch))
            {
                return string.Empty;
            }
        }

        input = input.ToLower();

        StringBuilder filtered = new StringBuilder();
        foreach (char ch in input)
        {
            if ((int)ch % 2 != 0)
            {
                filtered.Append(ch);
            }
        }

        char[] reversedArray = filtered.ToString().ToCharArray();
        Array.Reverse(reversedArray);

        for (int i = 0; i < reversedArray.Length; i++)
        {
            if (i % 2 == 0)
            {
                reversedArray[i] = char.ToUpper(reversedArray[i]);
            }
        }

        return new string(reversedArray);
    }

    /// <summary>
    /// Entry point of the application.
    /// Reads input from the user, invokes the string processing method,
    /// and displays the generated result.
    /// </summary>
    /// <param name="args">Command-line arguments</param>
    public static void Main(string[] args)
    {
        Program obj = new Program();

        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        string result = obj.CleanseAndInvert(input);

        if (string.IsNullOrEmpty(result))
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + result);
        }
    }
}
