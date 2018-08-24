using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPracticesCs
{
    class Program
    {
        private static List<Person> people = new List<Person>();
        static void Main(string[] args)
        {
            //SetUpSampleData();

            //GreetAllPeople();

            StringDemo();

            Console.ReadLine();
        }

        private static void StringDemo()
        {
            string s = "Hi";
            StringBuilder sb = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 50; i++)
            {
                //s += " Hi";
                sb.Append(" Hi");
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }


        private static void GreetAllPeople()
        {
            foreach (var person in people)
            {
                if (person.FirstName == "Tomek")
                    Console.WriteLine($"Hello Mr. {person.LastName}");
                else
                {
                    Console.WriteLine($"Hello {person.FirstName} {person.LastName}");
                }
            }
        }

        private static void SetUpSampleData()
        {
            people.Add(new Person { FirstName = "Tomek", LastName = "Chudzik" });
            people.Add(new Person { FirstName = "Janusz", LastName = "Janaszewski" });
            people.Add(new Person { FirstName = "Krzysztof", LastName = "Jarzyna" });
        }
    }
}
