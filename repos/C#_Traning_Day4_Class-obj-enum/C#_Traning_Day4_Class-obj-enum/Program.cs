using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C__Traning_Day4_Class_obj_enum
{
    internal class Program
    {
        static void Main(string[] args)
        {

           // SortedList<int,int> dsv = new SortedList<int,int>();
          //  Dictionary<int,int> dsvq = new Dictionary<int, int>();
            try
            {
                Console.Write("Please enter your number 1:");
                var number1=Convert.ToInt32(Console.ReadLine());

                Console.Write("Please enter your number2 :");
                var number2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please enter Operation symbol to perform Operation (+,-,*,/,%) :");
                string oprationSymbol = Console.ReadLine();

                program1 program = new program1();
                
                switch (oprationSymbol)
                {
                    case "+":
                        program.Addition(number1,number2);
                        break;
                    case "-":
                        program.Subtration(number1, number2);
                        break;
                    case "*":
                        program.Multiplication(number1, number2);
                        break;
                    case "/":
                        program.Division(number1, number2);
                        break;
                    case "%":
                        program.Modulo(number1, number2);
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Console.Write("How many student you want to Enter :");
                var numberOfStudent = Convert.ToInt64(Console.ReadLine());

                Student[] students = new Student[numberOfStudent];

                for (int i = 0; i < numberOfStudent; i++)
                {
                    //  Console.WriteLine("Please Enter obj Name");
                    // var objname=Console.ReadLine();


                    //Code
                   

                    students[i] = new Student();


                    //  students[i].takeInputs(students[i]);
               /*     Console.WriteLine(students[i].StudentId);
                    Console.WriteLine(students[i].StudentName);
                    Console.WriteLine(students[i].StudentDOB);
                    Console.WriteLine(students[i].StudentRollNumber);
                    Console.WriteLine(students[i].StudentEmail);
                    for (int l = 0; l < 5; l++)
                    {
                        Console.WriteLine(students[i].StudentGPA[l]);
                    }*/
                    //Console.WriteLine(students[i].StudentGPA);
                }

                students[numberOfStudent-1].FindCr(students);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //   double[] gpa = { 3, 3, 3, 3, 3};
            //  DateTime date2 = new DateTime(2012, 12, 25, 10, 30, 50);
            //  Student student1= new Student(45, "Pratik", date2, 45, "Pratik@gmail.com", gpa,5);

            //  Student student2 = new Student(78, "Mehul", date2, 35, "Mehul@gmail.com", gpa,5);
            Student student1 = new Student();
            Student student2= new Student();
            Student student3 = new Student(student1);
            Console.WriteLine("Student1 Name is : "+student1.StudentName);
            Console.WriteLine("Student2 Name is : "+student3.StudentName);

           // Student student4 = new Student();

            Student student4 = student1 + student2;


        }
       
    }

    class program1
    {
        static int ans;
        public  void Addition(int number1, int number2)
        {
            ans=number1+number2;
            Console.WriteLine("sum of "+number1+" + "+number2+" is "+ans);
        }
        public void Subtration(int number1, int number2)
        {
            ans = number1 - number2;
            Console.WriteLine("subtraction of " + number1 + " - " + number2 + " is " + ans);
        }
        public void Multiplication(int number1, int number2)
        {
            ans = number1 * number2;
            Console.WriteLine("Multiplication of " + number1 + " * " + number2 + " is " + ans);
        }
        public void Division(int number1, int number2)
        {
            try
            {
                ans = number1 / number2;
                Console.WriteLine("Division of " + number1 + " / " + number2 + " is " + ans);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Modulo(int number1, int number2)
        {
            ans = number1 % number2;
            Console.WriteLine(ans);
        }
    }
    public class Student
    {
        private int studentId;
        private string studentName;
        private DateTime studentDOB;
        private int studentRollNumber;
        private string studentEmail;
        private double[] studentGPA;
        private double studentCGPA;

       public enum studentgpa
        {
            one = 1,
            two = 2,
            three = 3,
            four = 4
        };

        public Student()
        {
            studentGPA=new double[5];
            for (int i = 0; i < 5; i++)
            {
                studentGPA[i] = 3.0;
               // Console.WriteLine(studentGPA[i]);
            }

            //  try
            //  {
            bool validId=true;
            while (validId)
            {
                try
                {
                    Console.Write("Please enter Student id :");
                    int studentID = Convert.ToInt32(Console.ReadLine());
                    StudentId = studentID;
                    validId = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
                Console.Write("Please enter Student Name :");
                string studentName = Console.ReadLine();
                StudentName = studentName;

            bool validDate = true;
            while (validDate)
            {
                try
                {
                    Console.Write("Please enter Student Date of birth (mm/dd/yyyy) :");
                     DateTime studentDob =Convert.ToDateTime(Console.ReadLine());
                     StudentDOB = studentDob;
                    validDate = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            bool validRollnumber = true;
            while (validRollnumber)
            {
                try
                {
                    Console.Write("Please enter Student Rollnumber :");
                    int studentRollnumber = Convert.ToInt32(Console.ReadLine());
                    StudentRollNumber = studentRollnumber;
                    validRollnumber = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            bool check = false;
                do
                {
                    Console.Write("Please Proper enter Student email :");
                    string studentEmail = Console.ReadLine();
                    check = EmailCheck(studentEmail);
                }
                while (check == false);
                
                    StudentEmail = studentEmail;
                    Console.WriteLine("Please enter Student last 5 sem gpa :");
                    double[] last5semGPA = new double[5];
                    double cgpa = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        try
                        {
                            Console.Write("Please enter lasth " + (i+1) + "th sem GPA :");

                            var Gpa = Convert.ToDouble(Console.ReadLine());
                            switch (Gpa)
                            {
                                case 1:
                                    last5semGPA[i] = Convert.ToDouble(studentgpa.one);
                                    break;

                                case 2:
                                    last5semGPA[i] = Convert.ToDouble(studentgpa.two);
                                    break;
                                case 3:
                                    last5semGPA[i] = Convert.ToDouble(studentgpa.three);
                                    break;
                                case 4:
                                    last5semGPA[i] = Convert.ToDouble(studentgpa.four);
                                    break;
                                default:
                                    last5semGPA[i] = Convert.ToDouble(studentgpa.three);
                                    Console.WriteLine("Only 1 to 4 is allow, default 3 is taken");
                                    break;

                            }
                            cgpa += last5semGPA[i];


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Only 1 to 4 is allow, default 3 is taken");

                        }
                        StudentGPA = last5semGPA;
                    }
                    StudentCGPA = cgpa / 5;
                
                
                

               

               

          /*  }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/





        }

        public Student(int studentId,string studentName,DateTime studentDOB,int studentRollNumber,string studentEmail, double[] studentGPA)
        { 
           // Console.Write("CopyConstructor Called");
            this.StudentId= studentId;
            this.StudentName= studentName;
            this.StudentDOB= studentDOB;
            this.studentRollNumber= studentRollNumber;
            this.StudentEmail= studentEmail;
            this.StudentGPA= studentGPA;
            // this.StudentCGPA= studentCGPA;
            
           

        }

        public Student(Student studentobj)
        {
            StudentId = studentobj.StudentId;
            StudentName = studentobj.StudentName;
            StudentDOB = studentobj.StudentDOB;
            StudentRollNumber = studentobj.StudentRollNumber;
            StudentEmail = studentobj.StudentEmail;
            StudentGPA = studentobj.StudentGPA;
            StudentCGPA = studentobj.StudentCGPA;

        }

       public int StudentId
        {
            get;
            set;
        }
        public string StudentName
        {
            get;
            set;
        }
        public DateTime StudentDOB
        {
            get;
            set;
        }
        public int StudentRollNumber
        {
            get;
            set;
        }
        public string StudentEmail
        {
            get;
            set;
        }
        public double[] StudentGPA
        {
            get; set;
        }
        public double StudentCGPA
        {
            get;
            set;
        }

/*
        public void takeInputs(Student obj)
        {
            
            try
            {
                Console.WriteLine("Please enter Student id");
               int studentID = Convert.ToInt32(Console.ReadLine());
                obj.StudentId = studentID;

                Console.WriteLine("Please enter Student Name");
                string studentName = Console.ReadLine();
                obj.StudentName = studentName;

                Console.WriteLine("Please enter Student Date of birth");
               string studentDob = Console.ReadLine();
                obj.StudentDOB= studentDob;

                Console.WriteLine("Please enter Student Rollnumber");
                int studentRollnumber= Convert.ToInt32(Console.ReadLine());
                obj.StudentRollNumber = studentRollnumber;

                Console.WriteLine("Please enter Student email");
                string studentEmail = Console.ReadLine();
                obj.StudentEmail = studentEmail;

               Console.WriteLine("Please enter Student last 5 sem gpa");
                double[] last5semGPA = new double[5];
                double cgpa=0;
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        Console.WriteLine("Please enter lasth " + i + "th sem pga");
                        last5semGPA[i] = Convert.ToDouble(Console.ReadLine());
                        cgpa+= last5semGPA[i];


                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                    obj.StudentGPA = last5semGPA;
                }

                obj.StudentCGPA= cgpa/5;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }*/

        public void FindCr(Student[] Obj)
        {
            double maxcgpa = 0;
            string nameOfCr = "";
            for (int i = 0; i < Obj.Length; i++)
            {
                Console.WriteLine(Obj[i].StudentCGPA);
                if(Obj[i].StudentCGPA == maxcgpa)
                {
                    nameOfCr += Obj[i].StudentName +" ";
                }

                else if (Obj[i].StudentCGPA > maxcgpa)
                {
                    maxcgpa = Obj[i].StudentCGPA;
                    nameOfCr = Obj[i].StudentName + " ";
                }
            }
            Console.WriteLine("CR is ==  " + nameOfCr);

            // double CRofClass = cgpsOfAllstudents.Max();

        }
        public static Student operator +(Student c1, Student c2)
        {
            
            Student temp = new Student();
             temp.StudentId = c1.StudentId + c2.StudentId;
            Console.WriteLine(temp.StudentId);
            return temp;
        }
        public static bool EmailCheck(string email)
        {
            // bool check=email.IsMa
            Regex emailRegex = new Regex(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");
            bool check = emailRegex.IsMatch(email);
            return check;
        }
        /*public bool checkeEmail(string Email)
        {
            Regex reg = new Regex("([0-9.])+");
            if (String.IsNullOrEmpty(Email))
            {
                if()
            }
            return true
        }*/

    }

}
