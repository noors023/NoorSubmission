using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace NoorSubmission.Models

{
    public class AppDbContext : DbContext
    {   
        
        public AppDbContext(DbContextOptions options ) : base(options ) { 
        
        }
        public DbSet<MainFormModel> Forms { get; set; }
       

      



    }
}
