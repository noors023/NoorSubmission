using Microsoft.EntityFrameworkCore;
using NoorSubmission.API.Models;

namespace NoorSubmission.Models
{
    //TODO: Migrate this please
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<MainFormModel> Forms { get; set; }
    }
}
