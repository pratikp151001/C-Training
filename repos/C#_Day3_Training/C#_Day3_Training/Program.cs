using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace C__Day3_Training
{
    internal class Program
    {
       static string fileName = "D:\\PRACTICE.txt";
       
        static void Main(string[] args)
        {
             bool flag= false;
            do
            {
                // File.Create("hello.txt");
                try
                {
                    Console.WriteLine("Please Enter program number");
                    var programNumber = Convert.ToInt32(Console.ReadLine());

                    switch (programNumber)
                    {
                        case 1:
                            WriteInfile();
                            break;
                        case 2:
                            ReadWholeFile();
                            break;
                        case 3:
                            writeArray();
                            break;
                        case 4:
                            ReadFirstLine();
                            break;
                        case 5:
                            LinesCount();
                            break;
                        case 6:
                            simpleException();
                            break;
                        case 7:
                            DivideZero();
                            break;
                        case 8:
                            extentionMethod();
                            break;
                        case 9:
                            argumentNullError();
                            break;
                        case 10:
                            EmailEncryptionandDecryption();
                            break;
                        case 11:
                            ReadConfigValue();
                            break;
                        default:
                            Console.WriteLine("Please Enter number between 1 to 11");
                            break;


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Enter y for continue or other for stop execution");
                var value=Console.ReadLine();
                if (value.ToLower() == "y")
                {
                    flag=true;
                }
                else
                {
                    flag=false;
                    Console.WriteLine("Thank you for Executing Program");
                }


            } while (flag); 
           
            // writeArray();
            // ReadWholeFile();
            //ReadFirstLine();
            //  LinesCount();
            //simpleException();
            //DivideZero();
            // extentionMethod();
            // EmailEncryptionandDecryption();
           // ReadConfigValue();

        }

        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        static void WriteInfile()
        {
            Console.WriteLine("Enter text tou want to add to file");
            var Input = Console.ReadLine();
            //File.WriteAllText(fileName, Input);
            File.AppendAllText(fileName, Input);
        }
        static void ReadWholeFile()
        {
            var textInFile = File.ReadAllText(fileName);
            Console.WriteLine("Text in File is " + textInFile);
        }
        static void writeArray()
        {
            string[] StringArray;
            try
            {
                Console.WriteLine("Enter Array lenght");
                var arrayLenght = Convert.ToInt32(Console.ReadLine());
                StringArray=new string[arrayLenght];
                
                using (StreamWriter writer = new StreamWriter(fileName,append:true))
                {
                    for (int i = 0; i < arrayLenght; i++)
                    {
                        Console.WriteLine("Please Enter Element number " + i);
                        StringArray[i] = Console.ReadLine();
                        writer.WriteLine(StringArray[i]);
                    }

                }
                ReadWholeFile();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ReadFirstLine()
        {
           var Firstine= File.ReadLines(fileName).First();
            Console.WriteLine(Firstine);
        }
        static void LinesCount()
        {
            int noOfLinesInFile=0;
            //  noOfLinesInFile = File.ReadAllLines(fileName).Length;
            // Console.WriteLine(noOfLinesInFile);
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (reader.ReadLine() != null)
                {
                    noOfLinesInFile++;
                }
                Console.WriteLine("Number of lines in File is:-  "+noOfLinesInFile);
            }
               
        }
        static void simpleException()
        {
            try
            {
                Console.WriteLine("Please Enter Number");
                var input=Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Digits String is not allowed");
            }
        }
        static void DivideZero()
        {
            try
            {
                Console.WriteLine("Please Enter Number1");
                var number1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please Enter Number2");
                var number2 = Convert.ToInt32(Console.ReadLine());

                double ans= number1/number2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void extentionMethod()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            /*  "MM/dd/yyyy",
              "dddd, dd MMMM yyyy",
                  "MMMM dd",
                  "yyyy MMMM",*/
             Console.WriteLine("Please Enter Date Format");
            //Console.WriteLine("Some Formats are .....\n MM/dd/yyyy \n dddd, dd MMMM yyyy \n MMMM dd \n yyyy MMMM ");
            string format =Console.ReadLine();
            now.ChangeFormatOFDate(format);
        }
        public static void EmailEncryptionandDecryption()
        {
            Console.WriteLine("Please Enter Email");
            var Email = Console.ReadLine();

            bool checkEmail = EmailCheck(Email);
             if (checkEmail)
             {
                // string EncryptedEmail = EnryptString(Email);
                 string  EncryptedEmail = EncryptString("b14ca5898a4e4133bbce2ea2315a1916", Email);
           

                 string path = "C:\\Users\\hp\\Desktop\\Email.txt";

                 if(File.Exists(path))
                 {
                     Console.WriteLine("already Prsent");

                 }
                 else
                 {
                     Console.WriteLine("Creating File");
                     File.Create(path);
                 }

                 File.WriteAllText(path, EncryptedEmail);

                 var fileEncryptedEmail=File.ReadAllText(path);
                 Console.WriteLine(EncryptedEmail);
                //  var decryptedfileEmail= DecryptString(fileEncryptedEmail);
                var decryptedfileEmail = DecryptString("b14ca5898a4e4133bbce2ea2315a1916", EncryptedEmail);
                 Console.WriteLine(decryptedfileEmail);
             }
             else
             {
                 Console.WriteLine("Please Enter valid email");
             }

        }
        public static bool EmailCheck(string email)
        {
            // bool check=email.IsMa
            Regex emailregex = new Regex(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");
            bool check = emailregex.IsMatch(email);
            return check;
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

        public static string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
        public static void ReadConfigValue()
        {
            string Password= ConfigurationManager.AppSettings["Password"];
            string encryptedpassword = EnryptString(Password);
            Console.WriteLine(encryptedpassword);
            Console.WriteLine(Password);
            string path = "C:\\Users\\hp\\Desktop\\Password.txt";

            if (File.Exists(path))
            {
                Console.WriteLine("already Prsent");
            }
            else
            {
                Console.WriteLine("Creating File");
                File.Create(path);
            }

            File.WriteAllText(path, encryptedpassword);
        }
        public static void argumentNullError()
        {
            string name = null;
            try
            {
                printName(name);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void printName(string name)
        {
            
            if(name == null)
            {
                throw new ArgumentNullException("argrument can't br null");
            }

        }

    }
    public static class  ExtentionMethodClass
    {
        public static void ChangeFormatOFDate(this DateTime Date, string format)
        {
            if(Date != null)
            {
                if (!String.IsNullOrEmpty(format) || !String.IsNullOrWhiteSpace(format))
                {
                    if (format.Trim() == "MM/dd/yyyy" || format.Trim()== "dddd, dd MMMM yyyy" || format.Trim() == "dddd, dd MMMM yyyy HH:mm:ss" || format.Trim() == "MM/dd/yyyy HH:mm" || format.Trim() == "MM/dd/yyyy hh:mm tt" || format.Trim() == "MM/dd/yyyy H:mm"
                        || format.Trim() == "MMMM dd")
                    {
                        String DateInNewFormat = Date.ToString(format);
                        Console.WriteLine(DateInNewFormat);
                    }
                    else
                    {
                        Console.WriteLine("Please Enter Proper value");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Format");
                }

            }
            
        }
       
    }
}
