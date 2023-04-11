using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Employee_Details_Project
{
    public static class Validation
    {
        public static bool CheckingNull(this string value)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }
        public static bool CheckingOnlyAlphabet(this string str)
        {
            Regex onlyAlphabetRegex = new Regex(@"^[A-Za-z]+$");
            bool check = onlyAlphabetRegex.IsMatch(str.ToString());
            if (!check)
            {
                Console.WriteLine("Please Enter Valid string(Only Alphabetes)");
                return true;
            }

            return false;
        }
        public static string checkingdate(this DateTime date)
        {
            string formattedDate = date.ToString("dd-MMM-yyyy");
            return formattedDate;


        }

        public static bool CheckingPhonenumber(this string phonenumber)
        {
            Regex phonenumberRegex = new Regex(@"^\+?[1-9][0-9]{9}$");
            bool check = phonenumberRegex.IsMatch(phonenumber);
            if (!check)
            {
                Console.WriteLine("Please Enter Valid Phonenumber with 10 digits");
                return true;
            }

            return false;
        }
        public static bool CheckingPostalnumber(this string pincode)
        {
            Regex pincodeRegex = new Regex(@"^[1-9][0-9]{5}$");
            bool check = pincodeRegex.IsMatch(pincode);
            if (!check)
            {
                Console.WriteLine("Please Enter Valid Pincode with 6 digits");
                return true;
            }

            return false;
        }
        //public static bool CheckingDateformat(this string date)
        //{

        //}


        public static bool CheckingEmail(this string email)
        {
            // @"^[^\s@]+@[^\s@]+\.(com|org|edu|info|in)$"
            Regex emailRegex = new Regex(@"^[^\s@]+@[^\s@]+\.(com|org|edu|info|in)$");
            bool check = emailRegex.IsMatch(email);
            if (check)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please Enter Email valid format(abc@gmail.com)");
                return true;
            }
        }
    }
}
