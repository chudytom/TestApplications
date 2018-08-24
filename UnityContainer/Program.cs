using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace UnityContainerSample
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Initializer
    {
        Customer initialVariable;
        public void InitializeVariables()
        {
            initialVariable = new Customer() { Age = 25, FirstName = "Tomek", LastName = "Chudzik" };
            var container = new UnityContainer();
            container.RegisterType<ICustomer, DetailedCustomer>();
            var savedVariable = container.Resolve<ICustomer>();
            Console.WriteLine($"Number of properties { savedVariable.PropertiesCount}");
        }
    }

    public interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        int PropertiesCount { get; }
    }

    public class Customer : ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int PropertiesCount => this.GetType().GetProperties().Count();
        //{
        //    get
        //    {
        //        var resultText = new StringBuilder();
        //        foreach (var property in this.GetType().GetProperties())
        //        {
        //            if (nameof(property) == "FullInfo")
        //            {
        //                continue;
        //            }
        //            resultText.Append(property.GetValue(null) as string + " ");
        //        } 
        //        return resultText.ToString();
        //    }
        //}

    }

    public class DetailedCustomer : ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string University { get; set; }
        public int PropertiesCount => this.GetType().GetProperties().Count();
        //public string FullInfo
        //{
        //    get
        //    {
        //        var resultText = new StringBuilder();
        //        foreach (var property in this.GetType().GetProperties())
        //        {
        //            resultText.Append(property.GetValue(null) as string + " ");
        //        }
        //        return resultText.ToString();
        //    }
        //}
    }

}
