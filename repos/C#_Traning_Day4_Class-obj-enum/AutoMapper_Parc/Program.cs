using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using static AutoMapper_Parc.Program;

namespace AutoMapper_Parc
{
    internal class Program
    {
        public int EmployeeId { get; set; }
        public string EmployeeFName { get; set; }
        public string EmployeeLName { get; set; }
        public string Address { get; set; }
        static void Main(string[] args)
        {

            Program objEmployee = new Program
            {
                EmployeeId = 1001,
                EmployeeFName = "Pradeep",
                EmployeeLName = "Sahoo",
                Address = "KRPURAM"
            };
            //Mapper.Initialize<Program,Employeee>

            var config=new MapperConfiguration(cfg => { cfg.CreateMap<Program,Employeee>(); });     

        }
    }
    public class Employeee
    {
        public int EmployeeId { get; set; }
        public string EmployeeFName { get; set; }
        public string EmployeeLName { get; set; }
        public string Address { get; set; }
    }


}
