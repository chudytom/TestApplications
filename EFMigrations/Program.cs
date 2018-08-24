using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BlogContext())
            {
                db.Blogs.ToList().ForEach(blog => Console.WriteLine($"{blog.BlogId} {blog.Name} {blog.AnotherUrl}"));
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
