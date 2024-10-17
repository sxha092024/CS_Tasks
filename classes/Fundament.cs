
using System.Globalization;
using System.Numerics;

public class Fundament : IFundament
{
    public void CheckOddOrEven(double a)
    {
        double odd_or_even = a % 2;

        if (odd_or_even == 0)
        {
            Console.WriteLine($"{a} is even");
        }
        else
        {
            Console.WriteLine($"{a} is odd, remainder after modulo = {odd_or_even}");
        }
    }

    public string GetAInterestingFact(string fact)
    {

        return $"Did you know? You passed in: '{fact}'. Neat right?";
    }

    /// <summary>
    /// Sums two numbers together.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public void SumTwoNumbers()
    {
        // usage of dynamic here is due to the inability to do late binding
        // of the type information with the usage of the `var` variable declaration.
        // As such, resorting to dynamic to fulfill the interface requirements of being able to 
        // chose the underlying numerical types of int, long, or double.
        // (There may be a way to achieve this without the usage of dynamic but eeeeeehhhhhh)
        dynamic num1;
        dynamic num2;
        AskForNum(out num1);
        AskForNum(out num2);

        var sum = num1 + num2;
        Console.WriteLine($"Sum of {num1} + {num2} = {sum}");
    }

    private void AskForNum(out dynamic num)
    {
        Console.WriteLine("Specify number type: int, long, or double");
        string? num_type = Console.ReadLine();
        switch (num_type)
        {
            case "int":
                num = GetNum<int>();
                break;
            case "long":
                num = GetNum<long>();
                break;
            case "double":
                num = GetNum<double>();
                break;
            default:
                throw new ArgumentException($"Cannot resolve `{num_type}` to int, long, or double");
        }
    }

    private T GetNum<T>()
    where T : IParsable<T>, INumber<T>
    {
        Console.WriteLine("Enter a number");
        string? number = Console.ReadLine();
        if (number != null)
        {
            return T.Parse(number, NumberStyles.Number, provider: null);
        }
        else
        {
            throw new ArgumentException($"Cannot parse `{number}` as a number");
        }
    }

    public double SumTwoNumbersOfGivenType(double a, double b)
    {
        return a + b;
    }


    // Extra challenges

    public void PrintFibonnaciSeries()
    {
        Console.WriteLine("Fibonnaci Sequence");
        int a = 0;
        int b = 1;
        int c = a + b;

        Console.Write($"{c}");

        while (c >= 0)
        {
            try
            {
                checked
                {
                    c = a + b;
                    Console.Write($", {c}");
                }
            }
            catch (OverflowException)
            {
                break;
            }
            a = b;
            b = c;
        }

        Console.WriteLine("\nDatatype has overflowed");
    }

    public string ReverseString(string str)
    {
        return new string(str.Reverse().ToArray());
    }

    public int RecursiveFactorial(int n)
    {
        // To Check the factorial of a number(norsk: Fakultet) we look at n!, where n = n * 1 * 2 * 3...
        if (n == 0)
        {
            return 1;
        }
        return n * RecursiveFactorial(n - 1);
    }


}
