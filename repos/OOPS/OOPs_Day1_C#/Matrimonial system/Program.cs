using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrimonial_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Boys boys = new Boys();

        }
    }

    public abstract class User
    {
        public string Name
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public abstract void searchingPartner();
        public abstract void RemoveProfile();

        public abstract void ViewOwnProfile();



    }
    public class Boys : User
    {
        List<Boys> boys;
        public long Salary
        {
            get;
            set;
        }
        public override void searchingPartner()
        {

        }
        public override void ViewOwnProfile()
        {

        }
        public void RegisterAsBoys()
        {

        }
        public override void RemoveProfile()
        {

        }


    }

     class Girls : User
    {
        List<Girls> girls;
        public override void searchingPartner()
        {

        }
        public override void ViewOwnProfile()
        {

        }
        public void RegisterAsGirls() 
        { 

        }
        public override void RemoveProfile()
        {

        }
    }
}
