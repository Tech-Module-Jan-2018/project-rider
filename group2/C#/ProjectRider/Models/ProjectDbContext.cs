namespace ProjectRider.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ProjectDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public ProjectDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=projectrider_asp;user=root;");
        }
    }
}
