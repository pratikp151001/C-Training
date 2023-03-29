using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
        start:
            Console.WriteLine("Enter number 1 to 5 to execute Programs and Enter 6 to stop execution");
            var programNumber = Console.ReadLine();
            int ProgramNumber;

            if (int.TryParse(programNumber, out ProgramNumber))
            {
                //  Console.WriteLine(ProgramNumber);

                switch (ProgramNumber)
                {
                    case 1:
                        Program1();
                        goto start;
                    //break;
                    case 2:
                        Program2();
                        goto start;
                    // break;
                    case 3:
                        Program3();
                        goto start;
                    // break;
                    case 4:
                        Program4();
                        goto start;
                    // break;
                    case 5:
                        Program5();
                        goto start;
                    // break;
                    case 6:
                        Console.WriteLine("thank you for Executing Program");
                        break;
                    default:
                        Console.WriteLine("Please Enter number between 1 to 5");
                        goto start;
                        //  break;
                }
                /* if (ProgramNumber == 1)
                 {
                     Program1();
                 }
                 else if (ProgramNumber == 2)
                     Program2();
                 else if (ProgramNumber == 3)
                     Program3();
                 else if (ProgramNumber == 4)
                     Program4();*/

            }
            else
            {
                Console.WriteLine("Please EnteR digits");
                goto start;
            }

        }

        public static void Program1()
        {
            Console.WriteLine("Enter number");
            var number = Console.ReadLine();
            //Console.WriteLine(number);

            double Number;
            if (double.TryParse(number, out Number))
            {
                if (Number > 0)
                {
                    Console.WriteLine("Number is positive");
                }
                else if (Number < 0)
                {
                    Console.WriteLine("Number is Negative");
                }
                else
                {
                    Console.WriteLine("Number is Zero");
                }
            }
            else
            {
                Console.WriteLine("Please Enter digits");
            }
        }


        public static void Program2()
        {
            Console.WriteLine("Enter Week day number");
            var weekDayNumber = Console.ReadLine();
            int weekDAYNumber;
            if (int.TryParse(weekDayNumber, out weekDAYNumber))
            {
                switch (weekDAYNumber)
                {
                    case 1:
                        Console.WriteLine("First Day of week is Sunday");
                        break;
                    case 2:
                        Console.WriteLine("Second  Day of week is Monday");
                        break;
                    case 3:
                        Console.WriteLine("third  Day of week is Tuesday");
                        break;
                    case 4:
                        Console.WriteLine("Fourth  Day of week is Wenusday");
                        break;
                    case 5:
                        Console.WriteLine("Fifth  Day of week is Thrusday");
                        break;
                    case 6:
                        Console.WriteLine("Sixth  Day of week is Friday");
                        break;
                    case 7:
                        Console.WriteLine("Seventh  Day of week is Saturday");
                        break;
                }
                /* if (weekDAYNumber == 1)
                 {
                     Console.WriteLine("First Day of week is Sunday");
                 }
                 else if (weekDAYNumber == 2)
                 {
                     Console.WriteLine("Second  Day of week is Monday");
                 }
                 else if (weekDAYNumber == 3)
                 {
                     Console.WriteLine("third  Day of week is Tuesday");
                 }
                 else if (weekDAYNumber == 4)
                 {
                     Console.WriteLine("Fourth  Day of week is Wenusday");
                 }
                 else if (weekDAYNumber == 5)
                 {
                     Console.WriteLine("Fifth  Day of week is Thrusday");
                 }
                 else if (weekDAYNumber == 6)
                 {
                     Console.WriteLine("Sixth  Day of week is Friday");
                 }
                 else if (weekDAYNumber == 7)
                 {
                     Console.WriteLine("Seventh  Day of week is Saturday");
                 }
                 else
                 {
                 Console.WriteLine("Enter digits between 1 to 7");
                 }*/

            }
            else
            {
                Console.WriteLine("Please Enter digits");
            }
        }
        public static void Program3()
        {
            Console.WriteLine("Please Enter number 1");
            var numberOne = Console.ReadLine();
            Console.WriteLine("Please Enter number 2");
            var numberTwo = Console.ReadLine();
            double number1;
            double number2;
            if (double.TryParse(numberOne, out number1) && double.TryParse(numberTwo, out number2))
            {
                Console.WriteLine("Please Enter maximun for finding maximum and minimum for finding minimun");
                var MinOrMax = Console.ReadLine();

                if (MinOrMax.ToLower().Trim() == "maximum")
                {
                    double max = Math.Max(number1, number2);
                    Console.WriteLine("Maximum value of 2 number is " + max);
                }
                else if (MinOrMax.ToLower().Trim() == "minimum")
                {
                    double min = Math.Min(number1, number2);
                    Console.WriteLine("Minimum value of 2 number is " + min);
                }
                else
                {
                    Console.WriteLine("Please Enter proper word");
                }
            }
            else
            {
                Console.WriteLine("Please Enter Digits");
            }
        }
        public static void Program4()
        {
            Console.WriteLine("Please Enter Temperature");
            var temerature = Console.ReadLine();

            double Temperature;

            if (double.TryParse(temerature, out Temperature))
            {
                if (Temperature <= 0)
                    Console.WriteLine("it's Freezing weather");
                else if (Temperature > 0 && Temperature <= 10)
                    Console.WriteLine("it's Very Cold weather");
                else if (Temperature > 10 && Temperature <= 20)
                    Console.WriteLine("it's Cold weather");
                else if (Temperature > 20 && Temperature <= 30)
                    Console.WriteLine("it's Normal Temp");
                else if (Temperature > 30 && Temperature <= 40)
                    Console.WriteLine("it's hot Temp");
                else if (Temperature > 40)
                    Console.WriteLine("it's very hot");
            }
            else
            {
                Console.WriteLine("Please enter digits");
            }


        }
        public static void Program5()
        {
            Console.WriteLine("Please Enter number 1");
            var numberOne = Console.ReadLine();
            Console.WriteLine("Please Enter number 2");
            var numberTwo = Console.ReadLine();
            double number1;
            double number2;
            if (double.TryParse(numberOne, out number1) && double.TryParse(numberTwo, out number2))
            {
                Console.WriteLine("Please Enter Operator(+,-,*,%) to perform opration");
                var oprator = Console.ReadLine();

                switch (oprator)
                {
                    case "+":
                        double additionAns = number1 + number2;
                        Console.WriteLine(additionAns);
                        break;
                    case "-":
                        double subtractionAns = number1 - number2;
                        Console.WriteLine(subtractionAns);
                        break;
                    case "*":
                        double multiplicationAns = number1 * number2;
                        Console.WriteLine(multiplicationAns);
                        break;
                    case "%":
                        double moduloAns = number1 % number2;
                        Console.WriteLine(moduloAns);
                        break;
                    default:
                        Console.WriteLine("Please Enter Proper Symbol");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Please Enter digits");
            }

        }


    }
}
