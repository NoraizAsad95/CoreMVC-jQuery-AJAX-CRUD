using Microsoft.EntityFrameworkCore;

namespace JQueryCoreMVCCrudsOperations.Models
{
    public class JQueryDbContext : DbContext
    {
        public JQueryDbContext(DbContextOptions<JQueryDbContext> options) : base(options)
        {
        }

        public DbSet<TransactionModel> Transactions { get; set; }
    }
}
