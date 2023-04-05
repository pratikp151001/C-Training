using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_builder_website
{
    internal class User
    {
        static void Main(string[] args)
        {
            BuildBasicPC buildBasicPC = new BuildBasicPC("hii");
        }
    }
    class Components
    {
        public Components(string PcType) 
        {
            Console.WriteLine("Selecting Components for " + PcType);
        }
        public string SelectProcessor
        {
            get; set;
        }
        public string SelectMotherboard
        {
            get; set;
        }
        public string SelectRAM
        {
            get; set;
        }

        public string SelectStorage

        {
            get; set;
        }
        public string SelectKeyboardAndMouse

        {
            get; set;
        }
        public string SelectPowerSupplyUnit

        {
            get; set;
        }

        public  virtual void CheckPerformance()
        {
            Console.WriteLine("Performance of individual Components are good");
        }




    }

    class BuildBasicPC:Components
    {
        public BuildBasicPC(string PcType) : base(PcType)
        {
            Console.WriteLine("hello");
        }
        public override void CheckPerformance()
        {
            Console.WriteLine("Performance  of BasicPC is good");
        }

    }
    class BuildGamingPC : Components
    {
        public BuildGamingPC(string PcType) : base(PcType)
        {
            Console.WriteLine("hello");
        }
        public string SelectGraphicsCard

        {
            get; set;
        }
        public string SelectMonitorType

        {
            get; set;
        }

        public string SelectCooler
        {
            get; set;
        }
        public override void CheckPerformance()
        {
            Console.WriteLine("Performance  of GamimngPC is good");
        }

    }
    
}
