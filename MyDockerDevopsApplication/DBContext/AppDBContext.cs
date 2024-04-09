using Microsoft.EntityFrameworkCore;
using MyDockerDevopsApplication.DataModel;

namespace MyDockerDevopsApplication.DBContext
{
    public class AppDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "db");
        }

        public DbSet<ProductDataModel> Products { get; set; }
    }
}
