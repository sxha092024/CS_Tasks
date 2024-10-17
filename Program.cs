namespace CS_Tests;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new instance of the Greeting class
            Greetings greetings = new Greetings();
            // English greeting
            greetings.SayHello();
            // Japanese greeting
            greetings.YoiTsuitachi();

            Fundament fundament = new Fundament();

            fundament.CheckOddOrEven(1); // odd
            fundament.CheckOddOrEven(2); // even

            fundament.SumTwoNumbersOfGivenType(1, 2); // 3


            fundament.SumTwoNumbers(); // user input

            string fact = fundament.GetAInterestingFact("Factoid actually means, a statement presented as a fact, which is false");
            Console.WriteLine(fact);

            string rev = fundament.ReverseString(fact);
            Console.WriteLine(rev);

            fundament.PrintFibonnaciSeries(); // 1836311903 before overflowing of the int type

            int factorial = fundament.RecursiveFactorial(6); // 720
            Console.WriteLine($"{factorial}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Environment.Exit(-1);
        }
    }
}
