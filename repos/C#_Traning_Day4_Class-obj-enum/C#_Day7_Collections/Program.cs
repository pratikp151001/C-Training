using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C__Day7_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
              string check = "n";
             //  Program1 program1obj = new Program1();
           
               Program2 program2obj= new Program2();
                do
                {
                
                   //  program1obj.AddIntToList();
                    program2obj.AddIntToList();
                    Console.Write("Please Enter y for Enter another int to list & any other character for continue : ");
                    check = (Console.ReadLine()).ToLower();
                
                   
               
                } while (check=="y");
                  try
                  {
                     program2obj.DisplayListForProgram2();
                       // program1obj.DisplayListForProgram1();
                  }
                  catch (Exception ex)
                  {
                    Console.WriteLine(ex.Message);
                  }
            
              

             // Program2 program2obj = new Program2();
            
           List<StudentAddmission> studentAddmissionsRecord = new List<StudentAddmission>();
          
            string performOperation = "n";
            do
            {
                Console.Write("\r\nPlease Enter R for Remove student,\r\nM for set Best Student,\r\nF for Find Best Student,\r\nA for Add,\r\nD for Display student & any other character for continue :");
                var OprationKey = (Console.ReadLine()).ToLower();
                switch (OprationKey)
                {
                    case "a":
                        studentAddmissionsRecord = StudentAddmission.AddStudent(studentAddmissionsRecord);
                        break;
                    case "r":
                        studentAddmissionsRecord= StudentAddmission.RemoveStudent(studentAddmissionsRecord);
                        break;
                    case "d":
                        StudentAddmission.DisplayAllStudent(studentAddmissionsRecord);
                        break;
                    case "m":
                        StudentAddmission.MakeBestStudent(studentAddmissionsRecord);
                        break;
                    case "f":
                        StudentAddmission.FindBestStudent(studentAddmissionsRecord);
                        break;
                    default:
                        Console.WriteLine("Thank you for executing Program");
                        break;
                }
                Console.Write("Please Enter y for Perform another Operation & any other character for continue(Exit) : ");
                performOperation = (Console.ReadLine()).ToLower();
            } while (performOperation=="y");
            
        }
        
    }
    class Program1
    {
      public List<int> list = new List<int>();
        public void AddIntToList()
        {
            try
            {
                Console.Write("Please Enter Int you wnat to add : ");
                var inputInt =Convert.ToInt32(Console.ReadLine());
                list.Add((inputInt+2));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DisplayListForProgram1()
        {
            foreach(var item in list)
            {
                Console.WriteLine(item*5);
            }
        }

       
    }

    class Program2
    {
        List<int> sortedList = new List<int>();

        public void AddIntToList()
        {
            try
            {
                Console.Write("Please Enter Int you wnat to add : ");
                var inputInt = Convert.ToInt32(Console.ReadLine());
                sortedList.Add((inputInt));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayListForProgram2()
        {
            sortedList.Sort();
            /* foreach (var item in sortedList)
             {
                 Console.WriteLine(item);
             } */

             int startOfRange = 0;
             int endOfRange = 0;
             int maxOfList = sortedList[sortedList.Count-1];
             for (int i = 0; i <= maxOfList; i++)
             {
                 if (sortedList.Contains(i))
                 {
                     bool checkRange = false;
                     startOfRange = i;
                     while (sortedList.Contains(++i))
                     {
                         checkRange = true;

                     }
                     endOfRange = i-1;

                     if(checkRange)
                     {
                         Console.Write(startOfRange + " - " + endOfRange+",");
                     }
                     else
                     {
                         Console.Write(startOfRange+",");
                     }
                     --i;
                 }
             }
           

        }
    }
    class StudentAddmission
    {
        private string studentName;
        private string studentEmail;
        private string studentPhone;
        private long studentId;
        private bool bestStudent;

        public int StudentId
        {
            get;set;
        }
        public string StudentName
        {
            get;set;
        }
        public string StudentEmail
        {
            get;set;
        }
        public long StudentPhone
        {
            get;set;
        }
        public bool BestStudent
        {
            get;
            set;
        }

        public StudentAddmission(int id,string name,string email,long phoneNumber)
        {
            this.StudentId = id;
            this.StudentName = name;    
            this.StudentEmail = email;
            this.StudentPhone = phoneNumber;    
            this.BestStudent = false;

        }
        public static void DisplayAllStudent(List<StudentAddmission> studentslist)
        {
            Console.WriteLine("Displaying All Student Details");
            foreach (StudentAddmission student in studentslist)
            {
                Console.WriteLine("Student 1 Deatails");
                Console.WriteLine("Student Name : " + student.StudentName);
                Console.WriteLine("Student Email : " + student.StudentEmail);
                Console.WriteLine("Student PhoneNumber : " + student.StudentPhone);
                Console.WriteLine("Student Id : " + student.StudentId);
            }
        }
        public static List<StudentAddmission> RemoveStudent(List<StudentAddmission> studentslist)
        {
            if (studentslist.Count == 0)
            {
                Console.WriteLine("No student is Present");
            }
            else
            {
                //studentslist.Sort();
                try
                {
                    Console.Write("Please enter student id you want to remove :");
                    var idToRemove = Convert.ToInt32(Console.ReadLine());
                    bool studentPresent = false;
                    foreach (StudentAddmission student in studentslist)
                    {
                        if (student.StudentId == idToRemove)
                        {
                            studentslist.Remove(student);
                            studentPresent=true;
                        }


                    }
                    if (studentPresent == false)
                    {
                        Console.WriteLine("Student is not Present");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return studentslist;
        }
        public static List<StudentAddmission> AddStudent(List<StudentAddmission> studentslist)
        {

            Console.WriteLine("Please Enter Student Deatils");
            Console.Write("Please Enter Student Name : ");
            var name = Console.ReadLine();


            bool validid = true;
            int id = 0;
            while (validid)
            {
                try
                {
                    Console.Write("Please enter Student id :");
                    id = Convert.ToInt32(Console.ReadLine());

                    if (studentslist.Count != 0)
                    {
                        foreach (var item in studentslist)
                        {
                            if (id == item.StudentId)
                            {
                                Console.WriteLine("Student Id is already Present");
                                validid = true;
                            }
                            else
                            {
                                validid = false;
                            }
                        }
                    }
                    else
                    {
                        validid = false;
                    }
                    // var phone = phoneNumber;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool checkEmail = false;
            string email;
            do
            {
                Console.Write("Please Proper enter Student email :");
                email = Console.ReadLine();
                checkEmail = EmailCheck(email);
            }
            while (checkEmail == false);

            //  StudentEmail = email;
            // StudentId = id;
            //  BestStudent = false;

            bool validPhone = true;
            long phoneNumber = 0;
            while (validPhone)
            {
                try
                {
                    Console.Write("Please enter Student Phonenumber :");
                    phoneNumber = Convert.ToInt64(Console.ReadLine());
                    // var phone = phoneNumber;
                    validPhone = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            StudentAddmission student = new StudentAddmission(id, name, email, phoneNumber);
            studentslist.Add(student);

           
        

            return studentslist;
        }
        public static void MakeBestStudent(List<StudentAddmission> studentslist)
        {
            if (studentslist.Count == 0)
            {
                Console.WriteLine("No Student is Present");
            }
            else
            {
                try
                {
                    Console.Write("Please Enter student id you want to set as Best :");
                    var bestStudentId = Convert.ToInt32(Console.ReadLine());
                    bool bestStudent = true;
                    int oldBestStudentID=0;
                    foreach (var student in studentslist)
                    {
                        if (student.BestStudent)
                        {
                            oldBestStudentID = student.StudentId;
                        }
                        student.BestStudent = false;

                        if (student.StudentId == bestStudentId)
                        {
                            student.BestStudent = true;
                            bestStudent = false;

                        }

                    }
                    if (bestStudent)
                    {
                        Console.WriteLine("Entered Student id Student is not present");
                        foreach(var student in studentslist)
                        {
                            if(student.StudentId==oldBestStudentID)
                            {
                                student.BestStudent = true;
                            }
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public static void FindBestStudent(List<StudentAddmission> studentslist)
        {
            if (studentslist.Count != 0)
            {
                bool studentPresent = true;
                foreach (var student in studentslist)
                {
                    if (student.BestStudent == true)
                    {
                        Console.WriteLine("Best Student is " + student.StudentName);
                        studentPresent = false;
                    }

                }
                if (studentPresent)
                {
                    Console.WriteLine("Entered Student id Student is not best");
                }
            }
            else
            {
                Console.WriteLine("No Student Present");
            }
        }
        public static bool EmailCheck(string email)
        {

            // bool check=email.IsMa
            Regex emailRegex = new Regex(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");
            bool check = emailRegex.IsMatch(email);
            return check;
        }



    }
}
