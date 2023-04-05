using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OfficeManagment_Day2_OOPs
{
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {

            
    //    }
    //}
    public  class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Salary { get; set; }
        public string Type { get; set; }
        static void Main(string[] args)
        {


        }
       
      



    }
   public  class Admin: User
    {
        Employee[] employees;
        List<Task> tasks;
        //  Employee e=new Employee();

        static void LoinAsAdmin(string username, string password)
        {
          
           

        }

       
    }
    public class Employee : User
    {
       static List<Task> tasks;
        static void LoinAsEmployee(string username, string password)
        {
            Task task = new Task();
            Task.AddTask(tasks);
        }
        public static void AddEmployee(Employee[] employee) 
        {

        }
        public static void RemoveEmployee(Employee employee)
        {

        }
        
       


    }
    class Task
    {
      
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskID { get; set; }

        public static void AddTask(List<Task> task)
        {

        }
        public static void MarkTaskAsCompleted(List<Task> task)
        {

        }
        public static void CheckAllocatedTask(List<Task> task)
        {

        }


    }
    
}
