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

        Console.WriteLine(input);
        Console.WriteLine((int)input.IndexOf("("));
        Console.WriteLine((int)input.IndexOf(")"));
        string aux = input.Substring((int)input.IndexOf("("), (int)input.IndexOf(")")-1);
        Console.WriteLine(solve_equation(aux));





        Console.WriteLine(aux);

    }

    private static int solve_equation(string aux)
    {
        string[] operators = { "+", "-", "*", "/" };
        int result = 0;

        int operation;

        if ((operation = aux.IndexOf("+")).Equals("+"))
        {
            result = Convert.ToInt32(aux.Substring(operation - 1, operation)) + Convert.ToInt32(aux.Substring(operation, operation + 1));
        }
        else if ((operation = aux.IndexOf("-")).Equals("-"))
        {
            result = Convert.ToInt32(aux.Substring(operation - 1, operation)) - Convert.ToInt32(aux.Substring(operation,operation + 1));
        }
        else if ((operation = aux.IndexOf("*")).Equals("*"))
        {
            result = Convert.ToInt32(aux.Substring(operation - 1, operation)) * Convert.ToInt32(aux.Substring(operation,operation + 1));
        }
        else if ((operation = aux.IndexOf("/")).Equals("/"))
        {
            result = Convert.ToInt32(aux.Substring(operation - 1, operation)) / Convert.ToInt32(aux.Substring(operation,operation + 1));
        }

        Console.WriteLine(result);
        return result;
    }

    private static string clean_equation(string input)
    {
        input = input.Trim();
        input = input.Replace(" ", "");
        return input;
    }

    private static string validate_equation()
    {
        string input;
        do
        {
            Console.WriteLine("Enter a equation");
            input = Console.ReadLine();

        } while (!Regex.IsMatch(input, pattern: @"^[0-9+/*() -]+$"));
        return input;
    }
}