// See https://aka.ms/new-console-template for more information
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {

        List<string> inputString = input_equation().Split(" ").ToList();
        inputString.ForEach(i => Console.Write(i + ", "));


        //inputString = solve_equation(inputString);

        //foreach (char i in input_char) Console.WriteLine(i);


    }

    private static string clean_input(string input)
    {
        input = input.Trim();
        input = input.Replace(" ", "");
        return input;
    }

    private static string input_equation()
    {
        Console.WriteLine("\nEnter a equation");
        string input = clean_input(Console.ReadLine());

        if (!Regex.IsMatch(input, pattern: @"^[0-9+/*() -]+$")) { Console.WriteLine("Syntax Error --> ^[0-9+/*() -]+$"); input_equation(); }

        //if (!Regex.IsMatch(input, pattern: @"^\)+-*/|[-*=+/\(]$")) { Console.WriteLine("Syntax Error --> ^\\)+-*/|[-*=+/\\(]$"); input_equation(); }

        if (Regex.IsMatch(input, pattern: @"([*]){2,3}")) { Console.WriteLine("Syntax Error --> ([*]){2,3}"); input_equation(); }
        if (Regex.IsMatch(input, pattern: @"([-]){2,3}")) { Console.WriteLine("Syntax Error --> ([-]){2,3}"); input_equation(); }
        if (Regex.IsMatch(input, pattern: @"([+]){2,3}")) { Console.WriteLine("Syntax Error --> ([+]){2,3}"); input_equation(); }
        if (Regex.IsMatch(input, pattern: @"([/]){2,3}")) { Console.WriteLine("Syntax Error --> ([/]){2,3}"); input_equation(); }


        return input;
    }

    private static List<string> solve_equation(List<string> input)
    {
        Console.WriteLine();
        input.ForEach(Console.WriteLine);
        Console.WriteLine();

        int first_number;
        int second_number;
        int aux;

        for (int i = 0; i < input.Count; i++)
        {
            if(input[i].Equals("-"))
            {
                first_number = Convert.ToInt32(input[i - 1]);
                second_number = Convert.ToInt32(input[i + 1]);

                aux = first_number - second_number;
                input[i] = Convert.ToString(aux);
                input[i + 1] = "";
                input[i - 1] = "";

                break;
            }
        }

        Console.WriteLine();
        input.ForEach(Console.Write);
        Console.WriteLine();

        return input;
    }
}