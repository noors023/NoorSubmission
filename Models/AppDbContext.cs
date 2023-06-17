using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace NoorSubmission.Models

{
    public class AppDbContext : DbContext
    {   //which model to use as table 
        public DbSet<MainFormModel> Forms { get; set; }
        //public DbSet<CountriesModel> Countries { get; set; }
        //Which DB to connect to
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog =MainFormDB;Integrated Security=True;TrustServerCertificate=True");
        }

      



    }
}
