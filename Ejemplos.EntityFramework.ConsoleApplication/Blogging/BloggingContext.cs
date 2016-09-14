using System.Data.Entity;

namespace Ejemplos.EntityFramework.ConsoleApplication.Blogging
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
