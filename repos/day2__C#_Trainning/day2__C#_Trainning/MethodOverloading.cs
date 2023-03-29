using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2__C__Trainning
{
    internal class MethodOverloading
    {
        static double ans;
        public static void print(int age)
        {
            Console.WriteLine("your age is " + age);

        }
        public static void print(int age, int favnumber)
        {
            Console.WriteLine("your age is " + age + " and fav number is " + favnumber);

        }
        public static void print(int age, string name)
        {
            Console.WriteLine("your name is " + name + " and age is " + age);

        }
        public static void print(string string1)
        {
            Console.WriteLine("string 1:-  " + string1);

        }
        public static void Add(int number1, int number2)
        {
            ans = number1 + number2;
            Console.WriteLine(ans);

        }
        public static void Add(int number1, int number2, int number3)
        {
            ans = number1 + number2 + number3;
            Console.WriteLine(ans);

        }
        public static void Add(double number1, double number2)
        {
            ans = number1 + number2;
            Console.WriteLine(ans);

        }
    }
}
