using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day2
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Number");
            var programNumbertoRun=Console.ReadLine();

            int programNumberToRun;

            if(int.TryParse(programNumbertoRun, out programNumberToRun))
            {
                switch(programNumberToRun)
                {
                    case 1:
                        Program1();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please Enter Number");
            }

        }
        public static void Program1()
        {
            Console.WriteLine("as");
        }


    }
   
}
