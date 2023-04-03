using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static C__training_Day9.StudentViewModal;

namespace C__training_Day9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<StudentEntity> students = new List<StudentEntity>();

            var filename = ConfigurationManager.AppSettings["file"];
            string XMLFormatData;
            if (File.Exists(filename))
            {
                // XMLFormatData = File.ReadAllText(filename);
                //Console.WriteLine(XMLFormatData);
                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StudentEntity>));
                //employees = xmlSerializer.Deserialize(XMLFormatData);

                XmlSerializer xmlserializer = new System.Xml.Serialization.XmlSerializer(typeof( List<StudentEntity>));

                //Use using so that streamReader object will be cleaned up properly after use. 
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    students=(List<StudentEntity>)xmlserializer.Deserialize(streamReader);
                }
            }

            

            string performOperation = "n";
            do
            {
                Console.Write("\r\nPlease Enter A for Add Employee,\r\nD for Display student & any other character for continue :");
                var OprationKey = (Console.ReadLine()).ToLower();
                switch (OprationKey)
                {
                    case "a":
                        students = StudentEntity.AddStudent(students);
                        break;
                    case "d":
                       StudentViewModal.DisplayStudents(students);
                        break;
                    case "r":
                        students=StudentEntity.DeleteStudent(students);
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
    public class StudentEntity
    {
        public enum Genderenum
        {
            MALE = 1,
            FEMALE = 2
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public int StudentID { get; set; }

        public StudentEntity()
        {

        }
        public StudentEntity(string firstName, string lastName,string fullName, string gender, string email, string phonenumber,int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            Phonenumber = phonenumber;
            FullName = fullName;
            StudentID = id;

        }

        public static List<StudentEntity> AddStudent(List<StudentEntity> Students)
        {
            string firstName = "";
            string lastName = "";
            string fullname = "";
            string gender = "";
            string email = "";
            string phonenumber="";
           

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

                if (checkLastNameNull == false)
                {
                    checkLastNameNull = lastName.CheckingOnlyAlphabet();
                }
            }
            fullname=firstName+ " "+ lastName;

            bool checkdesignationNull = true;
            while (checkdesignationNull)
            {
                Console.Write("Please Enter gender : ");
                gender= (Console.ReadLine()).ToLower().Trim();

                switch (gender)
                {
                    case "male":
                        gender = Convert.ToString(Genderenum.MALE);
                        checkdesignationNull = false;
                        break;
                    case "female":
                        gender = Convert.ToString(Genderenum.FEMALE);
                        checkdesignationNull = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter Proper gender");
                        checkdesignationNull = true;
                        break;

                }
            }
            bool checkEmailNull = true;
            while (checkEmailNull)
            {
                Console.Write("Please Enter Email : ");
                email = Console.ReadLine();
                checkEmailNull = email.CheckingNull();

                if (checkEmailNull == false)
                {
                    checkEmailNull = email.CheckingEmail();
                }

            }

            bool checkPhonenumber = true;
            while (checkPhonenumber)
            {
                try
                {
                    Console.Write("Please Enter Phonenumber : ");
                    phonenumber = Console.ReadLine();
                    // checkPhonenumberNull = phonenumber.CheckingNull();
                    checkPhonenumber = phonenumber.CheckingPhonenumber();
                    if(checkPhonenumber == false)
                    {
                        phonenumber=EnryptString(phonenumber.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            int id = 0;
            bool checkStudentID = true;
            while (checkStudentID)
            {
                try
                {
                    Console.Write("Please Enter Student id : ");
                    id=Convert.ToInt32(Console.ReadLine());
                    // checkPhonenumberNull = phonenumber.CheckingNull();
                    //checkStudentID = phonenumber.CheckingPhonenumber();

                    //if(Students.Count!=0)
                    bool present = false;
                    foreach(var item in Students)
                    {
                        if (id == item.StudentID)
                        {
                            Console.WriteLine("Student Id is already present");
                            checkStudentID = true;
                            present = true;
                            break;
                        }
                    }
                    if( present == false)
                    {
                        checkStudentID = false;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            StudentEntity student = new StudentEntity(firstName, lastName,fullname,gender, email, phonenumber,id);
                Students.Add(student);



                XmlSerializer Serializer = new XmlSerializer(typeof(List<StudentEntity>));
            var filename = ConfigurationManager.AppSettings["file"];
            TextWriter txtWriter = new StreamWriter(filename);

                Serializer.Serialize(txtWriter, Students);
                txtWriter.Close();
            


            return Students;
            



            // using (StreamWriter writer = new StreamWriter("Employee.txt"));



        }
        public static List<StudentEntity> DeleteStudent(List<StudentEntity> students)
        {
            try
            {
                Console.WriteLine("Please Enter Student id you want to delete");
                int studentsIdToRemove = Convert.ToInt32(Console.ReadLine());
                if (students.Count != 0)
                {
                    bool present = false;
                    foreach (var student in students)
                    {
                        if (student.StudentID == studentsIdToRemove)
                        {
                            students.Remove(student);
                            present = true;
                            Console.WriteLine("Student Remove Successfully");
                        }
                    }
                    if (present == false)
                    {
                        Console.WriteLine("No student Present With this id");
                    }
                }
                else
                {
                    Console.WriteLine("No student is Present");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return students;
        }
        public static string EnryptString(string strEncrypted)
        {

            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

       

    }
   public  class StudentViewModal
        {
            public enum gender
            {
                MALE = 1,
                FEMALE = 2
            }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public int StudentID { get; set; }

        public static void DisplayStudents(List<StudentEntity> students)
        {
            List<StudentViewModal> studentViewModalslist = new List<StudentViewModal>();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentEntity, StudentViewModal>();
                //Employeee e = cfg.Map<Employeee>(objEmployee);
            });
            var mapper = new Mapper(configuration);


            //Console.WriteLine(students[0].FirstName);
            foreach (var student in students)
            {
                StudentViewModal studentViewmodalobj = mapper.Map<StudentViewModal>(student);
                studentViewModalslist.Add(studentViewmodalobj);
            }

            foreach (var student in studentViewModalslist)
            {
                Console.WriteLine("\nDisplaying student details");
                Console.WriteLine("Student FullName : " + student.FullName);
                Console.WriteLine("Student Grnder : " + student.Gender);

                Console.WriteLine("Student Phone Number : " + DecryptString(student.Phonenumber));
                Console.WriteLine("Student id is  : " + student.StudentID);
                // student.Phonenumber
            }



        }

        
        public static string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }


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
            public static bool CheckingPhonenumber(this string phonenumber)
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


