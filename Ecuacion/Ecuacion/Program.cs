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

        string aux = input.Substring((int)input.IndexOf("("), (int)input.IndexOf(")")-1);
        
        input = input.Substring(0, (int)input.IndexOf("("));
        input = input + solve_equation(aux);

        input = solve_equation(input).ToString();
        Console.WriteLine(input);
        

    }

    private static int solve_equation(string aux)
    {
        string[] operators = { "+", "-", "*", "/" };
        int result = 0;

        foreach (string o in operators)
        {
            if (aux.Contains(o))
            {
                int value = aux.IndexOf(o);
                Console.WriteLine("index of operation is " + value);
                Console.WriteLine("operation is " + aux.Substring(value, value - 1));
                if (aux.Substring(value, value - 1).Equals("-"))
                {
                    Console.WriteLine("fist number is " + aux.Substring(value - 1, value - 1));
                    Console.WriteLine("second number is " + aux.Substring(value + 1, value - 1));
                    Console.WriteLine();


                    result = Convert.ToInt32(aux.Substring(value - 1, value - 1)) - Convert.ToInt32(aux.Substring(value + 1, value - 1));
                }
            } 
        }
        Console.WriteLine("result is " + result);
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
        string input = "2-(9-3)";
        do
        {
            /*Console.WriteLine("Enter a equation");
            input = Console.ReadLine();*/

        } while (!Regex.IsMatch(input, pattern: @"^[0-9+/*() -]+$"));
        return input;
    }
}