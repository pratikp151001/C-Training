using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROI_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ROICalculator calculator = new ROICalculator();

            Console.Write("Please Enter Investment");
            var investment=Console.ReadLine();
            Console.Write("Please Enter Gain onInvestment");
            var gainOnInvestment = Console.ReadLine();

            
            Console.Write("Enter a month starting: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day starting: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year starting: ");
            int year = int.Parse(Console.ReadLine());

            DateTime StratDate = new DateTime(year, month, day);

            Console.Write("Enter a month End: ");
            int month1 = int.Parse(Console.ReadLine());
            Console.Write("Enter a day End: ");
            int day1= int.Parse(Console.ReadLine());
            Console.Write("Enter a year End: ");
            int year1 = int.Parse(Console.ReadLine());

            DateTime endDate = new DateTime(year1, month1, day1);

            var noofDays = (endDate - StratDate).TotalDays;



            //Console.Write("Please Enter lenght in yeaer");
            //var noofDays = (Console.ReadLine())*365;
            double RoI =calculator.FindROI(Convert.ToInt64(investment), Convert.ToInt64(gainOnInvestment), Convert.ToInt32(noofDays));

            Console.WriteLine("ROI :"+RoI+"%");
            Console.WriteLine("Gain Investment : "+( Convert.ToInt64(gainOnInvestment)-Convert.ToInt64(investment)));
            Console.WriteLine("Investment Length :" + (noofDays/365));
        }
    }
    class ROICalculator
    {
        public long FindROI(long investment,long gainOnInvestment,int Days)
        {
            var roi = (gainOnInvestment - investment) / investment;

            return roi*100;
        }
    }
}
