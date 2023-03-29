using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_SP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arraylist1 = new ArrayList();

            arraylist1.Add(1);
            arraylist1.Add("sd");
            arraylist1.Add(true);
            int[] array = { 1, 5, 9, 7 };
            arraylist1.AddRange(array);

            arraylist1.Insert(1,"AS");

            arraylist1.RemoveAt(1);
           // arraylist1.InsertRange(2,array);
            foreach (var item in arraylist1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(arraylist1.Contains(5));
            Console.ReadLine();



            List<string> list = new List<string>();
            list.Add("asc");
            string s = "vs";
            string[] FA = { "SA", "saC", "sscds" };
            list.AddRange(FA);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine() ;


            var sortedLIST= new SortedList<int, string>();

            sortedLIST.Add(8, "sacv");
            sortedLIST.Add(1, "ASf");

            foreach (var item in sortedLIST)
            {
                Console.WriteLine(item.Key +" "+item.Value);
            }
            Console.ReadLine();

            SortedList<int, string> numberNames = new SortedList<int, string>()
                                    {
                                        {3, "Three"},
                                        {1, "One"},
                                        {2, "Two"}
                                    };
            if (numberNames.ContainsKey(4))
            {
                numberNames[4] = "four";
                Console.WriteLine("Inside If");
            }
            string result;
            if (numberNames.TryGetValue(4, out  result))
                Console.WriteLine("Key: {0}, Value: {1}", 4, result);


            foreach (var item in numberNames)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Console.ReadLine();

            var cities = new Hashtable(){
             {"UK", "London, Manchester, Birmingham"},
             {"USA", "Chicago, New York, Washington"},
               {"India", "Mumbai, New Delhi, Pune"}
            };

            foreach (DictionaryEntry de in cities)
                Console.WriteLine("Key: {0}, Value: {1}", de.Key, de.Value);
            Console.ReadLine();

            Stack asd= new Stack();
            asd.Push(arraylist1);


            foreach (var de in asd)
            {
                Console.WriteLine(de);
            }

            Console.WriteLine(asd.Pop());
            Console.ReadLine();
        }
    }
}
