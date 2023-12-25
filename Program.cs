using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversii_ASC
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introdu un numar: ");
            string sourceNr = Console.ReadLine();

            string[] parts = sourceNr.Split('.');
            string decPart = parts[0];
            string fracPart = parts.Length > 1 ? parts[1] : "";

            Console.Write("Introdu baza din care face parte (intre 2 si 16): ");
            int sourceBase = int.Parse(Console.ReadLine());

            if (sourceBase < 2 || sourceBase > 16)
            {
                Console.WriteLine($"Baza {sourceBase} este invalida. (baza trebuie sa fie intre 2 si 16)");
                return;
            }

            Console.Write("Introdu baza in care sa se faca conversia (intre 2 si 16): ");
            int targetBase = int.Parse(Console.ReadLine());

            if (targetBase < 2 || targetBase > 16)
            {
                Console.WriteLine($"Baza {targetBase} este invalida. (baza trebuie sa fie intre 2 si 16)");
                return;
            }

            int decIntPart = ConvertToInt10(sourceBase, decPart);
            string resIntPart = ConvertToBase(decIntPart, targetBase);


            int decFracPart = ConvertToInt10(sourceBase, fracPart);
            string resFracPart = ConvertToBase(decFracPart, targetBase);

            Console.WriteLine($"{sourceNr} din baza sursa {sourceBase} este: {resIntPart}.{resFracPart} in baza tinta {targetBase}.");
        }

        static int ConvertToInt10(int sourceBase, string baseNr)
        {
            int decNumber = 0;
            int power = 0;

            for (int i = baseNr.Length - 1; i >= 0; i--)
            {
                int digit = StringToNr(baseNr[i]);
                decNumber += digit * (int)Math.Pow(sourceBase, power);
                power++;
            }

            return decNumber;
        }

        static string ConvertToBase(int decNumber, int targetBase)
        {
            if (decNumber == 0)
                return "0";

            string result = "";
            while (decNumber > 0)
            {
                int remainder = decNumber % targetBase;
                result = NrToString(remainder) + result;
                decNumber /= targetBase;
            }

            return result;
        }

        static int StringToNr(char c)
        {
            switch (c)
            {
                case 'a':
                    return 10;
                case 'b':
                    return 11;
                case 'c':
                    return 12;
                case 'd':
                    return 13;
                case 'e':
                    return 14;
                case 'f':
                    return 15;
                default:
                    return int.Parse(c.ToString());
            }
        }

        static char NrToString(int value)
        {
            if (value < 10)
                return (char)('0' + value);
            else
                return (char)('A' + (value - 10));
        }
    }
}
