using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMigrations
{

    public class BlogContext: DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string AnotherUrl { get; set; }
        public int Rating { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
