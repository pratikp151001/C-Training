using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Employee_Details_Project
{
    internal class Employee
    {

        public enum DepartmentEnum
        {
            Sales = 1,
            Marketing = 2,
            Development = 3,
            QA = 4,
            HR = 5,
            SEO = 6,


        }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string DateOfBirth {  get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string DateOfJoining { get; set; }

        public double TotalExperience { get; set; }
        public string Remarks { get; set; }

        public string Department { get; set; }
        public double MonthlySalary { get; set; }

        public Employee( int employeeID,string employeeName,string employeegender,string employeeCity,string employeeState,string employeeEmail,string employeePostalcode, string employeePhonenumber,string employeeRemark,string designation,double salary,string employeeDOB, string employeeDOJ,string department,double experience) 
        { 
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            Gender = employeegender;
            City = employeeCity;
            State = employeeState;
            PostalCode = employeePostalcode;
            Phone = employeePhonenumber;
            Email = employeeEmail;
            DateOfBirth = employeeDOB;
            Remarks=employeeRemark;
            MonthlySalary = salary;
            Designation = designation;
            Department = department;
            DateOfJoining = employeeDOJ;
            TotalExperience = experience;

        }

        public static List<Employee> AddEmployee( List<Employee> employees)
        {
            int employeeID=0;
            var employeeName = "";
            var employeegender = "";
            var employeeCity = "";
            var employeeState = "";
            var employeeEmail = "";
            var employeePostalcode = "";
            var employeePhonenumber = "";
            var employeeRemark = "";
            var designation = "";
            var department = "";
            var salary = 0.0;
            DateTime employeeDOB=DateTime.MinValue;
            DateTime employeeDOJ = DateTime.MinValue;


            //take id from user
            bool checkvalidation=true;
            while (checkvalidation)
            {
                try
                {
                    Console.Write("Please Enter Employee id : ");
                    employeeID = Convert.ToInt32(Console.ReadLine());

                    bool present = false;
                    foreach (var item in employees)
                    {
                        if (employeeID == item.EmployeeID)
                        {
                            Console.WriteLine("Employee Id is already present");
                            checkvalidation = true;
                            present = true;
                            break;
                        }
                    }
                    if (present == false)
                    {
                        checkvalidation = false;
                    }
                   // checkvalidation = checkid(employeeID);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please Enter Int Numbers");
                }
            }




            //Employee NAme from user
            do
            {
                employeeName = TakeStringInput("Employee Name");
                checkvalidation = employeeName.CheckingOnlyAlphabet();
            } while (checkvalidation);

            //
            checkvalidation = true;
            while (checkvalidation)
            {
                try
                {
                    Console.Write("Please Enter M for Male and F for Female : ");
                     employeegender=(Console.ReadLine().ToLower()).Trim();
                    switch (employeegender)
                    {
                        case "m":
                            checkvalidation = false;
                            employeegender = "M";
                            break;
                        case "f":
                            employeegender = "F";
                            checkvalidation = false;
                            break;
                        default:
                            break;
                    } 

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //take Designation from user
            designation=TakeStringInput("Employee designation");

            // Take city from user

            do
            {
                employeeCity = TakeStringInput("Employee City");
                checkvalidation=employeeCity.CheckingOnlyAlphabet();
            } while (checkvalidation);
            // Take State from user
            do
            {
                employeeState = TakeStringInput("Employee State");
                checkvalidation=employeeState.CheckingOnlyAlphabet();
            } while (checkvalidation);

            //take Email from user 
            checkvalidation = true;
            while (checkvalidation)
            {
                Console.Write("Please Enter Employee Email : ");
                 var email = (Console.ReadLine()).ToLower();
               
                    checkvalidation = email.CheckingEmail();
                if (checkvalidation == false)
                {
                    bool present = false;
                    foreach (var item in employees)
                    {
                        if (email == item.Email)
                        {
                            Console.WriteLine("Employee Email is already present");
                            checkvalidation = true;
                            present = true;
                            break;
                        }
                    }
                    if (present == false)
                    {
                        employeeEmail = email;
                        checkvalidation = false;
                    }
                   
                }
            }

            //take PINCODE from user

            do
            {
                employeePostalcode = TakeStringInput("Employee Postalcode");
                checkvalidation=employeePostalcode.CheckingPostalnumber();
                
            } while (checkvalidation);

            //take Phonenumber from user
            do
            {
                employeePhonenumber = TakeStringInput("Employee Phonenumber");
                checkvalidation = employeePhonenumber.CheckingPhonenumber();

            } while (checkvalidation);

            //take Remark from user
            employeeRemark = TakeStringInput("Employee Remark");

            //take Salary from user
            salary = TakeIntInput("Employee Salary");

            //take Department From user
             checkvalidation = true;
            while (checkvalidation)
            {
                Console.Write("Please Enter 1 for Sales,2 for QA,3 for Marketing,4 for Development,5 for HR ,6 for SEO");
                department = (Console.ReadLine()).ToLower().Trim();

              //  department = TakeIntInput("Please Enter 1 for Sales,2 for QA,3 for Marketing,4 for Development,5 for HR ,6 for SEO")

                switch (department)
                {
                    case "1":
                        department = Convert.ToString(DepartmentEnum.Sales);
                        checkvalidation = false;
                        break;
                    case "2":
                        department = Convert.ToString(DepartmentEnum.QA);
                        checkvalidation = false;
                        break;
                    case "3":
                        department = Convert.ToString(DepartmentEnum.Marketing);
                        checkvalidation = false;
                        break;
                    case "4":
                        department = Convert.ToString(DepartmentEnum.Development);
                        checkvalidation = false;
                        break;
                    case "5":
                        department = Convert.ToString(DepartmentEnum.HR);
                        checkvalidation = false;
                        break;
                    case "6":
                        department = Convert.ToString(DepartmentEnum.SEO);
                        checkvalidation = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter Proper Department");
                        checkvalidation = true;
                        break;

                }
            }
            //take birthdate from user
            do
            {
                checkvalidation = false;
                var employDob = TakeStringInput("Employee DOB(dd/mm/yyyy)");
                try
                {
                    //DateTime employDOB = employDob.CheckingDate();
                    employeeDOB = DateTime.Parse(employDob);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please Enter Int Numbers");
                    checkvalidation=true; 
                }

            } while (checkvalidation);

            //take joining from user
            do
            {
                checkvalidation = false;
                var employDoj = TakeStringInput("Employee joining date(dd/mm/yyyy)");
                try
                {
                    //DateTime employDOB = employDob.CheckingDate();
                    employeeDOJ = DateTime.Parse(employDoj);
                    if(employeeDOJ <employeeDOB)
                    {
                        checkvalidation = true;
                        Console.WriteLine("Date of joining is older than Date of Birth");
                    }
                   // employeeDOJ= employeeDOJ.ToString("dd-MMM-yyyy");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    checkvalidation=true;
                }

            } while (checkvalidation);
            var experience= (double)((DateTime.Now - employeeDOJ).TotalDays / 365.242199);
            //double expMonth= ((DateTime.Now - employeeDOJ).TotalDays % 365.242199)*0.001;
            //experience = experience + expMonth;

            var employeebirthday= employeeDOB.checkingdate();
            var employeejoining = employeeDOJ.checkingdate();
            Employee employee = new Employee(employeeID, employeeName, employeegender, employeeCity, employeeState, employeeEmail, employeePostalcode, employeePhonenumber, employeeRemark, designation, salary, employeebirthday, employeejoining, department,experience);
            employees.Add(employee);

            employees =employees.OrderByDescending(o=> o.MonthlySalary).ToList();
            var filepath = ConfigurationManager.AppSettings["filepath"];
            string jsonformatList = JsonConvert.SerializeObject(employees);
           // Console.WriteLine(jsonformatList);


            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine(jsonformatList);
            }
            return employees;
        }
        
        public static double TakeIntInput(string str)
        {

            bool checkvalidation = true;
            while (checkvalidation)
            {
                try
                {
                    Console.Write("Please Enter "+str+" : ");
                    double userInput = Convert.ToDouble(Console.ReadLine());
                    checkvalidation = false;
                    return userInput;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please enter Int numbers");
                }
            }
            return 0;
        }

        public static string TakeStringInput(string str)
        {
           bool checkvalidation = true;
           while (checkvalidation)
            {
                try
                {
                    Console.Write("Please Enter " +str+" : ");
                    var userInput = Console.ReadLine();

                    checkvalidation = userInput.CheckingNull();
                    if (checkvalidation == false)
                    {
                        return userInput;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return " ";
        }

        public static List<Employee> DeleteEmployee(List<Employee> employeelist)
        {
            try
            {
                
                if (employeelist.Count != 0)
                {
                    Console.WriteLine("Please Enter Employee id you want to delete");
                    int EmployeeIdToRemove = Convert.ToInt32(Console.ReadLine());
                    bool present = false;
                    foreach (var item in employeelist)
                    {
                        if (item.EmployeeID == EmployeeIdToRemove)
                        {
                            employeelist.Remove(item);
                            present = true;
                            Console.WriteLine("Employee Remove Successfully");
                            var filepath = ConfigurationManager.AppSettings["filepath"];
                            string jsonformatList = JsonConvert.SerializeObject(employeelist);
                           // Console.WriteLine(jsonformatList);


                            using (StreamWriter writer = new StreamWriter(filepath))
                            {
                                writer.WriteLine(jsonformatList);
                            }
                        }
                    }
                    if (present == false)
                    {
                        Console.WriteLine("No Employee Present With this id");
                    }
                }
                else
                {
                    Console.WriteLine("No Employee is Present");
                }
            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex.Message);
            }

            return employeelist;
        }
        static void Main(string[] args)
        {

            List<Employee> employeeslist=new List<Employee>();
            var filepath = ConfigurationManager.AppSettings["filepath"];
            string JsonformatData = "";

            if (File.Exists(filepath))
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
                JsonformatData = File.ReadAllText(filepath);
                var array = JArray.Parse(JsonformatData);
                // List<Employee> objectsList = new List<Employee>();

                foreach (var item in array)
                {
                    try
                    {
                        // CorrectElements  
                        employeeslist.Add(item.ToObject<Employee>());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            bool runAgain=true;
            do
            {
                Console.Write("Please Enter 1 for ADD Employee, 2 for Delete Employee,3 for Exit the program : ");
                var input = Console.ReadLine().Trim();
                switch (input)
                {
                    case "1":
                        employeeslist=Employee.AddEmployee(employeeslist);
                        break;

                    case "2":
                        employeeslist = Employee.DeleteEmployee(employeeslist);
                        break;

                    case "3":
                        runAgain=false;
                        Console.WriteLine("Thank you for Executing the Program");
                        break;
                    default:
                        
                        break;
                }
            } while (runAgain);
        }
    }
    public static class Validation
    {
        public static bool CheckingNull( this string value)
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
