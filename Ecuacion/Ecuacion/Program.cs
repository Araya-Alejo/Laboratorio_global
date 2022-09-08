// See https://aka.ms/new-console-template for more information
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {

        string input;
        input = validate_equation();
        input = clean_equation(input);
        char[] input_char = input.ToArray();
        validate_structure(input_char);

        //foreach (char i in input_char) Console.WriteLine(i);


    }

    private static int solve_equation(string aux)
    {
        return 1;
    }

    private static string clean_equation(string input)
    {
        input = input.Trim();
        input = input.Replace(" ", "");
        return input;
    }

    private static string validate_equation()
    {
        string input = "2-(9-3)";
        do
        {
            /*Console.WriteLine("Enter a equation");
            input = Console.ReadLine();*/

        } while (!Regex.IsMatch(input, pattern: @"^[0-9+/*() -]+$"));
        return input;
    }

    private static void validate_structure(char[] input)
    {
        string input_string = "-x)(-";
        Console.WriteLine(@"Regex[ '^)' ] : " + Regex.IsMatch(input_string, pattern: @"^\)+-*/|[-*=+/\(]$"));
        //return input;
    }
}