using System;
using NumbersToWatch.ProcessClasses;

namespace NumbersToWatch.Extensions
{
    public static class ConvertExtensions
    {
        public static string ProvideChequeText(this Decimal inAmount)
        {
            return Converter.NumbersToWordsConverter(inAmount);
        }
    }
}
