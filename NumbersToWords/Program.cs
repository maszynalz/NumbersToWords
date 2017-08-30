using NumbersToWatch.Extensions;

namespace System
{
    class Program
    {
        static void Main(string[] args)
        {
            Decimal testValue = 345763.21m;

            String resultText = testValue.ProvideChequeText();

            Console.WriteLine("Example test value: " + testValue);

            Console.WriteLine("Example resulting text: " + resultText);

            Console.WriteLine("NOW YOU!: ");

            String enteredValue = Console.ReadLine();

            resultText = Decimal.Parse(enteredValue).ProvideChequeText();

            Console.WriteLine(resultText);
            
            Console.ReadKey();
        }
    }
}
