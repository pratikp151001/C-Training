using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2__C__Trainning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var flag = false;
            do
            {
                Console.WriteLine("Please enter program Number");
                var programnumber = Console.ReadLine();

                int programNumber;
                if (int.TryParse(programnumber, out programNumber))
                {
                    switch (programNumber)
                    {
                        case 1:
                            program1();
                            break;
                        case 2:
                            program2();
                            break;
                        case 3:
                            program3();
                            break;
                        case 4:
                            program4();
                            break;
                        case 5:
                            program5();
                            break;
                        case 6:
                            program6();
                            break;
                        case 7:
                            program7();
                            break;
                        default:
                            Console.WriteLine("Please enter number between 1 to 7");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Numbers");
                }


                Console.WriteLine("Please Enter Y for continue and Any Other  for stop execution");
                var check = Console.ReadLine();
                if (check.ToLower() == "y")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Thank you for Executing");
                    flag = false;
                }



            } while (flag);
        }
        public static void program1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Pratik");
            }
        }
        public static void program2()
        {
            string evenNumbers = null;
            for (int i = 0; i < 50; i++)
            {
                if (i % 2 == 0)
                {
                    switch (i)
                    {
                        case 2:
                        case 12:
                        case 22:
                        case 32:
                        case 42:
                            continue;

                    }
                    evenNumbers += i + " ";

                }

            }
            Console.WriteLine("Evwn Numbrs String is " + evenNumbers);
        }
        public static void program3()
        {
            int[] numbers;
            try
            {
                Console.WriteLine("Enter array lengrh");
                var arraylength = Convert.ToInt32(Console.ReadLine());
                numbers = new int[arraylength];

                for (int i = 0; i < numbers.Length; i++)
                {
                    int enteredElement = 0;


                    try
                    {
                        Console.WriteLine("Enter element Number" + i);
                        enteredElement = Convert.ToInt32(Console.ReadLine());
                        numbers[i] = enteredElement;
                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                      //  break;
                    }
                    
                }
                int negativeNumberCount = 0;
                foreach (int j in numbers)
                {
                    if (j < 0)
                    {
                        negativeNumberCount++;
                    }
                }
                Console.WriteLine("Total negative Number in the array is " + negativeNumberCount);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void program4()
        {
            int[] numbers;
            try
            {
                Console.WriteLine("Enter array lengrh");
                var arraylength = Convert.ToInt32(Console.ReadLine());
                numbers = new int[arraylength];

                for (int i = 0; i < numbers.Length; i++)
                {
                    int enteredElement = 0;


                    try
                    {
                        Console.WriteLine("Enter element Number" + i);
                        enteredElement = Convert.ToInt32(Console.ReadLine());

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                    numbers[i] = enteredElement;
                }
                /*int max = numbers[0];
                int min= numbers[0];
               
                for (int i=1; i<numbers.Length; i++)
                {
                    if (numbers[i-1]< numbers[i])
                    {
                        min = numbers[i-1];
                    }

                    if (numbers[i-1] > numbers[i])
                    {
                        max = numbers[i - 1];
                    }

                }*/
                int max = numbers.Max();
                int min = numbers.Min();

                Console.WriteLine("Maximum of array is " + max);
                Console.WriteLine("Minimum of array is " + min);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void program5()
        {
            int[] numbers;
            try
            {
                Console.WriteLine("Enter array lengrh");
                var arraylength = Convert.ToInt32(Console.ReadLine());
                numbers = new int[arraylength];

                for (int i = 0; i < numbers.Length; i++)
                {
                    int enteredElement = 0;


                    try
                    {
                        Console.WriteLine("Enter element Number" + i);
                        enteredElement = Convert.ToInt32(Console.ReadLine());

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                    numbers[i] = enteredElement;
                }

                int even = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        even++;
                    }

                }

                Console.WriteLine("Total even number in array is " + even + " Total odd number in array is " + (numbers.Length - even));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void program6()
        {
            try
            {
                Console.WriteLine("Please Enter your Name");
                string name = Console.ReadLine();
                Console.WriteLine("Please Enetr your age");
                var age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please Enetr your fav number");
                var favnumber = Convert.ToInt32(Console.ReadLine());

                MethodOverloading.print(age, favnumber);
                MethodOverloading.print(age);
                MethodOverloading.print(age, name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void program7()
        {
            
            MethodOverloading.Add(4, 50);
            MethodOverloading.Add(8.2, 78.12);
            MethodOverloading.Add(4, 50, 8);

        }
    }
}
