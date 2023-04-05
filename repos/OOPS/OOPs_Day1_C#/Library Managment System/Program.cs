using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Book
    {
        

       
       public string BookName
        {
            get; set;
        }
        public string BookCondition
        {
            get; set;
        }
        public int BookPages
        {

            get; set;
        }
        public string BookPrice
        {
            get; set;
        }
     }
        
    
    class Inventory
    {
       
        public void Addbook(List<Book> books)
        {
            Book book = new Book();
            book.BookPages = 154;

        }

        public void BorrowBook(List<Book> books)
        {

        }

    }

   // public class User
   // {
   //     public string Name { get; set; }
   //     public string Email { get; set; }
   //     public string Password { get; set; }
   // }

   //public  class Admin : User
   // {
   //    Inventory inventory= new Inventory();
       

   // }
}
