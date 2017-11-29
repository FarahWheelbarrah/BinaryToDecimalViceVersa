using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_to_Decimal___Decimal_to_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            String choice;
            help();
            while ((choice = readString("Choice (d/b/h/x):")) != "x")
                {
                switch (choice)
                {
                    case "b": binarytoDecimal(); break;
                    case "d": decimalToBinary(); break;
                    case "h": help(); break;
                    default: help(); break;
                }
            }
            
        }

        public static String readString(String prompt)
        {
            Console.Write(prompt + " ");
            String input = Console.ReadLine();
            return input;
        }

        public static void binarytoDecimal()
        {
            ulong number;
            String binaryvalue;
            Console.WriteLine("Enter \"back\" to return to the main menu");
            while ((binaryvalue = readString("Enter binary value:")) != "back")
            {
                if (!ulong.TryParse(binaryvalue, out number) || hasOtherNumbers(binaryvalue))
                    Console.WriteLine("ERROR - Invalid input");
                else
                {
                    convertFromBinaryToDecimal(number);
                }
            }



        }

        public static void decimalToBinary()
        {
            ulong number;
            String decimalvalue;
            Console.WriteLine("Enter \"back\" to return to the main menu");
            while ((decimalvalue = readString("Enter decimal value:")) != "back")
            {
                if (!ulong.TryParse(decimalvalue, out number))
                    Console.WriteLine("ERROR - Invalid input");
                else
                {
                    convertFromDecimalToBinary(number);
                }

            }
                

        }

        public static void help()
        {
            Console.WriteLine("--HELP--");
            Console.WriteLine("Enter 'd' to convert from decimal to binary");
            Console.WriteLine("Enter 'b' to convert from binary to decimal");
            Console.WriteLine("Enter 'h' to see this menu again");
            Console.WriteLine("Enter 'x' to exit the program");
            
        }

        public static void convertFromDecimalToBinary(ulong number)
        {
            bool is0 = true;
            int c = (int)Math.Log(number, 2);
            Console.Write("Binary value: ");
            for (int i = c; i >= 0; i--)
            {
                ulong powerof2 = (ulong)Math.Pow(2, i);
                if (number >= powerof2)
                {
                    number -= powerof2;
                    Console.Write(1);
                    is0 = false;

                }
                else
                    Console.Write(0);
            }

            if (is0)
                Console.Write(0);

            Console.WriteLine();
            
            
        }

        public static void convertFromBinaryToDecimal(ulong number)
        {
            ulong sum = 0;
            String stringnumber = "" + number;
            for (int i = 0; i<stringnumber.Length; i++)
            {
                char c = stringnumber[i];
                int x = (int)Char.GetNumericValue(c);
                if (x != 0)
                    sum += (ulong)Math.Pow(2, (stringnumber.Length - 1 - i));
            }
            Console.WriteLine("Decimal value: " + sum);
            sum = 0;
        }

        public static bool hasOtherNumbers(String value)
        {
            String[] othernumbers = { "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (String number in othernumbers)
            {
                if (value.Contains(number))
                    return true;
            }
            return false;
        }
    }
}
