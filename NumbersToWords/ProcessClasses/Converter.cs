using System;
using System.Text;

namespace NumbersToWatch.ProcessClasses
{
    public static class Converter
    {
        enum powerFlags : int { None, Thousands, Millions, Billions };

        public static string NumbersToWordsConverter(Decimal inAmount)
        {
            String resultString = String.Empty;

            //long integralAmount = (long)Math.Floor(inAmount);
            long integralAmount = (long)Decimal.Truncate(inAmount);
            int fractionalAmount = (int)((inAmount - Decimal.Truncate(inAmount)) * 100);

            long numBillions = integralAmount > 999999999 ? (integralAmount / 1000000000) : 0;
            integralAmount -= (numBillions * 1000000000);

            int numMillions = integralAmount > 999999 ? (int)(integralAmount / 1000000) : 0;
            integralAmount -= (numMillions * 1000000);

            int numThousands = integralAmount > 999 ? (int)(integralAmount / 1000) : 0;
            integralAmount -= (numThousands * 1000);

            if (numBillions > 0)
            {
                resultString = ProcessHundreds(numBillions, (int)powerFlags.Billions, resultString);
            }

            if (numMillions > 0)
            {
                resultString = ProcessHundreds(numMillions, (int)powerFlags.Millions, resultString);
            }

            if (numThousands > 0)
            {
                resultString = ProcessHundreds(numThousands, (int)powerFlags.Thousands, resultString);
            }

            resultString = ProcessHundreds(integralAmount, (int)powerFlags.None, resultString) + " Dollars and " + fractionalAmount.ToString() + @"/100";

            return resultString.TrimEnd();
        }

        private static string ProcessHundreds(long inAmount, int inPower, string inString)
        {
            StringBuilder resultString = new StringBuilder(inString);
            String[] digitWords = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
            String[] teenWords = { "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            String[] tenMultipleWords = { String.Empty, "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            String[] powerWords = { "Thousand", "Million", "Billion" };

            long numHundred = inAmount / 100;

            if (numHundred > 0)
            {
                resultString.Append(digitWords[numHundred - 1] + " Hundred ");
            }

            long numTens = (inAmount -= (numHundred * 100)) / 10;

            if ((inAmount > 10) && (inAmount < 20))
            {
                resultString.Append(teenWords[inAmount - 11]);
            }
            else if ((inAmount % 10) == 0)
            {
                resultString.Append(tenMultipleWords[inAmount / 10]);
            }
            else
            {
                resultString.Append(tenMultipleWords[inAmount / 10] + " ");
                resultString.Append(digitWords[(inAmount % 10) - 1]);
            }

            switch(inPower)
            {
                case (int)powerFlags.Thousands:
                    resultString.Append(" Thousand ");
                    break;
                case (int)powerFlags.Millions:
                    resultString.Append(" Million ");
                    break;
                case (int)powerFlags.Billions:
                    resultString.Append(" Billion ");
                    break;
                default:
                    break;
            }

            return resultString.ToString();
        }
    }
}
