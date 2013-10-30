using System.Data.Entity;

namespace MVCBlog.Models
{
    public class MVCBlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(c => c.Articles).WithOptional(u => u.Author).WillCascadeOnDelete(false);
        }*/
    }
}