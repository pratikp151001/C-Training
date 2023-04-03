using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Oops_vehicleBooking
{
   /* sealed internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    } */

     interface  Vehicle
    {
        
         void Condition();
        void type();
        void number();

    }
    class VehicleBooking : Vehicle
    {

       

        public void Condition()
        {
            Console.WriteLine("Condition is good");

        }

        public void type()
        {
            Console.WriteLine("type is 4 wheeler");
        }
        public void number()
        {
            Console.WriteLine("GJ0000");
        }
        
        public static string RentVehicle()
        {
            Console.WriteLine("vehicle i rented");
            return "Scds";
        }



    }

    class User
    {
        private string name;
        private string adharnumber;


    }
    class Customer : User
    {
         static string  RentVehihclenumber;

        static void Main(string[] args)
        {
            RentVehihclenumber = VehicleBooking.RentVehicle();
        }
       


    }
}
