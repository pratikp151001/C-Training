using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment_System
{
    internal class HospitalManagment_System
    {
        static void Main(string[] args)
        {
            //login Code
        }
    }

    interface user
    {
         string Name { get; set; }
         string Password { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }

    }

    class Admin:user
    {
      public  string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public void aa()
        {


            Doctor d = new Doctor();
            d.Operation();
        }
    }
     class Doctor: user
    {
        
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Degree { get; set; }


        public void Operation()
        {

        }
        public void AddDoctor()
        {

        }
    }

    public class Patient : user
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

       public string Codition { get; set; }

        public  void ConditionafterOperation()
        {

        }

    }
}
