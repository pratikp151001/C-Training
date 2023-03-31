using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C__Day8_trainig
{
    internal class Program
    {
         

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            string JsonformatData = "";
            if (File.Exists("D:\\Employee.txt"))
            {


                /* using (StreamReader reader = new StreamReader(@"D:\Employee.txt"))
                 {
                     while (!reader.EndOfStream)
                     {
                         JsonformatData = reader.ReadLine();
                         var employee = JsonConvert.DeserializeObject<Employee>(JsonformatData);

                         //Console.ReadLine();
                         Console.WriteLine("\nEmployee Details Areee....");
                         Console.WriteLine("Employee FirstName : " + employee.FirstName);
                         Console.WriteLine("Employee LastName : " + employee.LastName);
                         Console.WriteLine("Employee Email : " + employee.Email);
                         Console.WriteLine("Employee Phonenumber : " + employee.Phonenumber);
                         Console.WriteLine("Employee Degignation : " + employee.Designation);
                         Console.WriteLine("Employee Salary : " + employee.Salary);
                     }
                 }*/
                JsonformatData = File.ReadAllText("D:\\Employee.txt");
                var array = JArray.Parse(JsonformatData);
               // List<Employee> objectsList = new List<Employee>();

                foreach (var item in array)
                {
                    try
                    {
                        // CorrectElements  
                        employees.Add(item.ToObject<Employee>());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
           // List<Employee> employees = new List<Employee>();

            string performOperation = "n";
            do
            {
                Console.Write("\r\nPlease Enter A for Add Employee,\r\nD for Display student & any other character for continue :");
                var OprationKey = (Console.ReadLine()).ToLower();
                switch (OprationKey)
                {
                    case "a":
                        employees=Employee.AddEmployee(employees);
                        break;
                    case "d":
                          Employee.DisplayEmployee(employees);
                        break;
                    default:
                        Console.WriteLine("Thank you for executing Program");
                        break;
                }
                Console.Write("Please Enter y for Perform another Operation & any other character for continue(Exit) : ");
                performOperation = (Console.ReadLine()).ToLower();
            } while (performOperation == "y");
        }
    }
    class Employee
    {
        public enum DesignationEnum
        {
            QA=1,
            Developer=2

        }
      /*  private string firstName;
        private string lastName;
        private string gender;
        private string email;
        private long phonenumber;
        private string designation;
        private long salary;*/

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public long Phonenumber { get;set; }
        public string Designation { get; set; }
        public long Salary { get; set; }

        public Employee(string firstName, string lastName, string gender, string email, long phonenumber, string designation, long salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            Phonenumber = phonenumber;
            Designation = designation;
            Salary = salary;
           
        }

        public static List<Employee> AddEmployee(List<Employee> employees)
        {
            string firstName="";
            string lastName="";
            string gender = "";
            string email = "";
            string designation = "";
            long phonenumber=0; ;
            long salary=0;

            Console.WriteLine("Please Enter Employee Details");
            bool checkFirstNameNull = true;
            while (checkFirstNameNull)
            {
                Console.Write("Please Enter First Name : ");
                firstName = Console.ReadLine();
                checkFirstNameNull = firstName.CheckingNull();
                if (checkFirstNameNull == false)
                {
                    checkFirstNameNull = firstName.CheckingOnlyAlphabet();
                }
            }

            bool checkLastNameNull = true;
            while (checkLastNameNull)
            {
                Console.Write("Please Enter Last Name : ");
                lastName = Console.ReadLine();
                checkLastNameNull = lastName.CheckingNull();

                if(checkLastNameNull == false)
                {
                    checkLastNameNull= lastName.CheckingOnlyAlphabet();
                }
            }

            bool checkGenderNull = true;
            while (checkGenderNull)
            {
                Console.Write("Please Enter M For Male & F for Female : ");
                gender = (Console.ReadLine()).ToLower();

                switch(gender)
                {
                    case "m":
                        gender = "MALE";
                        checkGenderNull = false;
                        break;
                    case "f":
                        gender = "FEMALE";
                        checkGenderNull = false;
                        break;
                    default:
                        checkGenderNull = true;
                        break;
                }

                //checkGenderNull = gender.CheckingNull();
            }
            bool checkEmailNull = true;
            while (checkEmailNull)
            {
                Console.Write("Please Enter Email : ");
                email = Console.ReadLine();
                checkEmailNull = email.CheckingNull();

                if (checkEmailNull == false)
                {
                    checkEmailNull=email.CheckingEmail();
                }

            }

            bool checkPhonenumber=true;
            while (checkPhonenumber)
            {
                try
                {
                    Console.Write("Please Enter Phonenumber : ");
                    phonenumber =Convert.ToInt64(Console.ReadLine());
                    // checkPhonenumberNull = phonenumber.CheckingNull();
                    checkPhonenumber = phonenumber.CheckingPhonenumber();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            bool checkdesignationNull = true;
            while(checkdesignationNull)
            {
                Console.Write("Please Enter designation : ");
                designation = (Console.ReadLine()).ToLower().Trim();

                switch(designation)
                {
                    case "qa":
                        designation =Convert.ToString( DesignationEnum.QA);
                        checkdesignationNull = false;
                        break;
                    case "developer":
                        designation = Convert.ToString(DesignationEnum.Developer);
                        checkdesignationNull = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter Proper Designation");
                        checkdesignationNull = true;
                        break;

                }
            }

            bool checkSalaryNull = true;
            while (checkSalaryNull)
            {
                try
                {
                    Console.Write("Please Enter Salary : ");
                    salary =Convert.ToInt64(Console.ReadLine());
                    // checkSalaryNull = salary.CheckingNull();
                    checkSalaryNull = salary.CheckingSalary();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            

            // using (StreamWriter writer = new StreamWriter("Employee.txt"));

            Employee employee=new Employee(firstName, lastName,gender,email,phonenumber,designation,salary);

            employees.Add(employee);
            string output = JsonConvert.SerializeObject(employees);
            Console.WriteLine(output);

            using (StreamWriter writer = new StreamWriter(@"D:\Employee.txt"))
            {
                writer.WriteLine(output);
            }
           
            return employees;
        }

        public static void DisplayEmployee(List<Employee> employees)
        {
            /* if (employees.Count != 0)
              {
                  foreach(var employee in employees)
                  {
                      Console.WriteLine("Employee Details Areee....");
                      Console.WriteLine("Employee FirstName : "+employee.FirstName);
                      Console.WriteLine("Employee LastName : " + employee.LastName);
                      Console.WriteLine("Employee Email : " + employee.Email);
                      Console.WriteLine("Employee Phonenumber : " + employee.Phonenumber);
                      Console.WriteLine("Employee Degignation : " + employee.Designation);
                      Console.WriteLine("Employee Salary : " + employee.Salary);
                  }
              }
              else
              {
                  Console.WriteLine("No Employee is Present");
              }
            */


            /* using (StreamReader reader = new StreamReader(@"D:\Employee.txt"))
             {
                 while (!reader.EndOfStream)
                 {
                     JsonformatData = reader.ReadLine();
                     var employee = JsonConvert.DeserializeObject<Employee>(JsonformatData);

                     //Console.ReadLine();
                     Console.WriteLine("\nEmployee Details Areee....");
                     Console.WriteLine("Employee FirstName : " + employee.FirstName);
                     Console.WriteLine("Employee LastName : " + employee.LastName);
                     Console.WriteLine("Employee Email : " + employee.Email);
                     Console.WriteLine("Employee Phonenumber : " + employee.Phonenumber);
                     Console.WriteLine("Employee Degignation : " + employee.Designation);
                     Console.WriteLine("Employee Salary : " + employee.Salary);
                 }
             }*/
            if (employees.Count != 0)
            {


                foreach (var employee in employees)
                {
                    Console.WriteLine("\nEmployee Details Areee....");
                    Console.WriteLine("Employee FirstName : " + employee.FirstName);
                    Console.WriteLine("Employee LastName : " + employee.LastName);
                    Console.WriteLine("Employee Email : " + employee.Email);
                    Console.WriteLine("Employee Phonenumber : " + employee.Phonenumber);
                    Console.WriteLine("Employee Degignation : " + employee.Designation);
                    Console.WriteLine("Employee Salary : " + employee.Salary);
                }
            }
            else
            {
                Console.WriteLine("No Employee is Present");
            }


           
        }

      /*  public static void RemoveEmployee()
        {
            string JsonformatData = "";
            using (StreamReader reader = new StreamReader(@"D:\Employee.txt"))
            {
                Console.WriteLine("Enter Student Email you want to delete");
                string emailToRemove = (Console.ReadLine()).ToLower().Trim();
                while (!reader.EndOfStream)
                {
                    JsonformatData = reader.ReadLine();
                    var employee = JsonConvert.DeserializeObject<Employee>(JsonformatData);

                    if(emailToRemove== (employee.Email).ToLower().Trim())
                    {

                    }
                   
                }
            }

        }*/
        /* public static bool CheckingNull(string value)
         {
             if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
             {
                 return false;
             }
             return true;
         }*/
    }
   public static class Validations
    {
        public static bool CheckingNull(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str) || !string.IsNullOrEmpty(str))
            {
                return false;
            }
            return true;
        }

        public static bool CheckingSalary(this long salary)
        {
            if (salary<10000)
            {
                Console.WriteLine("Salary is Less than 10000");
                return true;
            }
            else if (salary > 50000)
            {
                Console.WriteLine("Salary is greater than 50000");
                return true;
            }
            return false;
        }

        public static bool CheckingPhonenumber(this long phonenumber)
        {
            Regex phonenumberRegex = new Regex(@"^\+?[1-9][0-9]{9}$");
            bool check = phonenumberRegex.IsMatch(phonenumber.ToString());
            if (!check)
            {
                Console.WriteLine("Please Enter Valid Phonenumber with 10 digits");
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

        public static bool CheckingEmail(this string email)
        {
            Regex emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            bool check = emailRegex.IsMatch(email);
            if (check)
            {
                /*if (File.Exists("D:\\Employee.txt"))
                {

                    string JsonformatEmployeeData = "";
                    using (StreamReader reader = new StreamReader(@"D:\Employee.txt"))
                    {
                        while (!reader.EndOfStream)
                        {
                            JsonformatEmployeeData = reader.ReadLine();
                            var employee = JsonConvert.DeserializeObject<Employee>(JsonformatEmployeeData);

                            if (email.ToLower() == (employee.Email).ToLower())
                            {
                                Console.WriteLine("Please Enter Other Email,This Email is Already Present");
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
                */
            }
            else
            {
                return true;
            }
            return false;
           

        }
    }
}
