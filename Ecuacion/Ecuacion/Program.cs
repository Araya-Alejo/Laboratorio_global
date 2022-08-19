// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Console.WriteLine(Regex.IsMatch(input, pattern: @"^[0-9+/*() -]+$"));



    }
}