using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kotias
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(reverseStarter("Türkiye Cumhuriyeti, Amerika Birleşik Devletleri ve Almanya Federal Cumhuriyeti"));
        }

        static string reverseStarter(string inputString)
        {
            string nwe = null;
            int counter = 1;

            return forReverse(inputString, nwe, counter);
        }

        static string forReverse(string inputString, string nwe, int counter)
        {
            if (counter != inputString.Length + 1)
            {
                nwe += inputString[inputString.Length - counter];
                counter++;
                nwe = forReverse(inputString, nwe, counter);
            }

            return nwe;
        }
    }
}