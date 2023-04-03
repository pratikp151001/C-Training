using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs_Day1_C_
{
    internal class Cricket
    {
        static void Main(string[] args)
        {
            Umpire u=new Umpire();
            u.Description();
            Teams teams1 = new Teams();
            teams1.TeamName = "Phantoms";
            Console.WriteLine(teams1.TeamName);
            Players s=new Skills();
            s.Description();

            Bowler bowler1 = new Bowler();
            bowler1.Name="Pratik";

            Console.WriteLine(bowler1.Name);
            
        }
    }
    class Teams
    {
        private string teamName;
        private int teamRating;
        public string TeamName
        {
            get; set;
        }
        public int TeamRating
        {
            get;set;
        }

    }
    internal abstract class Players
    {
        public Players(){
            Console.WriteLine("Players Constructor Called");
            }
        protected string name;
        protected string description;
        protected string battinStyle;
        protected string bowlingStyle;

        public string Name
        {
            get;set;
        }


       public abstract void Description();
        //bool umpire;
    }

    class Skills : Players
    {
        private double battingSkill;
        private double bowlingSkill;
        private double umpireingSkill;

        public override void Description()
        {
            Console.WriteLine("skills are good");

        }

    }

    class Umpire : Players
    {
        //private double accuracy;
        public override void Description()
        {

            Console.WriteLine("Umpire is Good");
        }

    }
   

    class Batsman: Players
    {
        public override void Description()
        {
            Console.WriteLine("Batsman is good");

        }

    }

    class Bowler: Players
    {
        public override void Description()
        {
            Console.WriteLine("Bowler is good");
        }
    }

    class runs:  Teams
    {

        public void fourRuns()
        {
            Console.WriteLine("Its 4 run");
        }

    }
}
