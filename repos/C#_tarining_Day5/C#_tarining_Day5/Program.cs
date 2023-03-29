using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace C__tarining_Day5
{
   
    class Program {
        static void Main(string[] args)
        {
            try
            {

                Person person1 = new Person();

                Console.WriteLine("Please Enter Person Name");
                person1.Name = Console.ReadLine();
                Console.WriteLine("Please Enter Person Age");
                person1.Age = Convert.ToInt32(Console.ReadLine());

                person1.city =new City();
                Console.WriteLine("Please Enter City Name");
                //string cityName=Convert.ToString(Console.ReadLine());
                person1.city.CityName = Console.ReadLine();


                Console.WriteLine("Please Enter City Population");
                person1.city.CityPopulation=Convert.ToInt32(Console.ReadLine());
                // City=Console.ReadLine()

                Console.WriteLine("Please enter 1 for json serialization,2 for xml serialization");
                var input=Console.ReadLine();
                if (input == "1")
                {
                    JSONSerialization(person1);
                    JSONDeSerialization();
                }
                else if(input == "2")
                {
                     XMLSerializeData(person1);
                     XMLDeSerializeData();
                }
                else
                {
                    Console.WriteLine("Please enter proper value");
                }



                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }
        }
        public static void JSONSerialization(Person other)
        {
           
            Console.WriteLine(other.Name + " " +  other.city.CityName + " " + other.city.CityPopulation+" " + other.Age);
            string output = JsonConvert.SerializeObject(other);
            Console.WriteLine(output);

            using (StreamWriter writer = new StreamWriter(@"D:\json.txt")) { 
                writer.WriteLine(output);
            }
            
          //  Console.WriteLine("from File" + JsonformatData);
         //   Console.WriteLine("from File" + JsonformatData);
            Console.ReadLine();

        }

        public static void JSONDeSerialization()
        {
            string JsonformatData;
            if (File.Exists("D:\\json.txt"))
            {


                using (StreamReader reader = new StreamReader(@"D:\json.txt"))
                {
                    JsonformatData = reader.ReadLine();

                }
                var result = JsonConvert.DeserializeObject<Person>(JsonformatData);
                Console.WriteLine(result.Name);
                Console.WriteLine(result.ToString());
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("File is not Present");
            }

        }
        internal static void XMLSerializeData(Person obj)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(Person));
            TextWriter txtWriter = new StreamWriter(@"D:\json1.txt");

            Serializer.Serialize(txtWriter, obj);
            txtWriter.Close();
        }
        internal static void XMLDeSerializeData()
        {
            if (File.Exists("D:\\json1.txt")) {
                //XmlSerializer Serializer = new XmlSerializer(typeof(Person));
                string JsonformatData = File.ReadAllText("D:\\json1.txt");
                /* using (StreamReader reader = new StreamReader(@"D:\json1.txt")) 
                  {
                                 while (reader.ReadLine() != null)
                                 {
                                     JsonformatData += reader.ReadLine();
                                 }

                             }*/

                Console.WriteLine(JsonformatData);


                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                Person person2 = (Person)serializer.Deserialize(new StringReader(JsonformatData));

                Console.WriteLine(person2.Name);
                Console.WriteLine(person2.ToString());
                // Console.ReadLine();
                //   = (Person)serializer.Deserialize(reader);
            }
            else
            {
                Console.WriteLine("File is not Present");
            }

        }


    }
     public class Person
    {
       // private string name;
       // private int age;
       //  private string city;

        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public City city
        {
            get;
            set;
        }
        public override string ToString()
        {
            return this.Name + " " + this.Age + " " + this.city.CityName +" "+this.city.CityPopulation;
        }
    }
    public class City
    {
        // private string cityName;
        // private int cityPopulation;

        public string CityName
        {
            get;
            set;
        }
        public int CityPopulation
        {
            get;
            set;
        }

    }
   

}
