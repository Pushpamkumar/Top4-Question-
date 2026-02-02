using System;
using System.Text;

public class Program
{
    // Method to cleanse and invert the input string
    public string CleanseAndInvert(string input)
    {
        // Rule 1: Input must not be null and must have at least 6 characters
        if (string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return string.Empty;
        }

        // Rule 2: Input must contain only alphabets (no space, digit, or special characters)
        foreach (char ch in input)
        {
            if (!char.IsLetter(ch))
            {
                return string.Empty;
            }
        }

        // Convert input to lowercase
        input = input.ToLower();

        // Remove characters with even ASCII values
        StringBuilder filtered = new StringBuilder();
        foreach (char ch in input)
        {
            if ((int)ch % 2 != 0)
            {
                filtered.Append(ch);
            }
        }

        // Reverse the filtered string
        char[] reversedArray = filtered.ToString().ToCharArray();
        Array.Reverse(reversedArray);

        // Convert characters at even positions to uppercase
        for (int i = 0; i < reversedArray.Length; i++)
        {
            if (i % 2 == 0)
            {
                reversedArray[i] = char.ToUpper(reversedArray[i]);
            }
        }

        // Return the final generated key
        return new string(reversedArray);
    }

    // Main method
    public static void Main(string[] args)
    {
        Program obj = new Program();

        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        // Call the method
        string result = obj.CleanseAndInvert(input);

        // Display result based on return value
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
