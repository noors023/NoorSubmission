using Microsoft.EntityFrameworkCore;

//TODO: This has to be removed from here. Create your migrations in API Project. 
namespace NoorSubmission.Models
{
    public class AppDbContext : DbContext
    {   
        public AppDbContext(DbContextOptions options ) : base(options ) { 
        
        }
        public DbSet<MainFormModel> Forms { get; set; }
    }
}
