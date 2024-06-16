using Blog.Presentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Presentation.Contexts
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<InfoItem> InfoItems { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

    }
}
