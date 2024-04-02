using Microsoft.EntityFrameworkCore;
using Phong_Tro.Models;

public class DatabaseAccount : DbContext
{
    public DatabaseAccount(DbContextOptions<DatabaseAccount> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }

    // Additional DbSet properties if needed
}
