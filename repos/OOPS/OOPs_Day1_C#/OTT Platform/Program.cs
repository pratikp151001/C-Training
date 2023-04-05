using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTT_Platform
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class User
    {
        List<Series> series;
        List<Content> movies;
        List<User> users;

        List<string> watchedMovies;
        public User(/*get details*/)
        { 
            //add user to user list

        }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public void login()
        {
            //read and check credentials
            User user = new User(/*pass details*/);
        }


    }
    interface Content
    {
       
         string MovieName { get; set; }
         string MovieUrl { get; set;}

         string MovieDirector { get; set; }

         double Ratings { get; set; }
         void WatchMovies();
        void GiveRating();
    }
  

    class Movie : Content
    {
       public  List<Movie>   movies;
        public string MovieName { get; set; }
        public string MovieUrl { get; set; }

        public string MovieDirector { get; set; }

        public  double Ratings { get; set; }

        public void AddMovie()
        {

        }

        public void RemoveMovie()
        {

        }
        public void WatchMovies(/*get all Movies List*/)
        {

        }
        public void GiveRating(/*get all Movies List*/)
        {

        }
    }

    class Series : Content
    {

       public List<Series> series;
        public string MovieName { get; set; }
        public string MovieUrl { get; set; }

        public string MovieDirector { get; set; }

        public double Ratings { get; set; }

        public int NoOfParts
        {
            get; set;
        }
       public void AddSeries()
        {

        }
        public void RemoveSeries()
        {

        }
        public void WatchMovies(/*get all Movies List*/)
        {

        }
        public void GiveRating(/*get all Movies List*/)
        {

        }


    }

}
