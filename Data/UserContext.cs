using Microsoft.EntityFrameworkCore;
using plusoft_backend.Models;

namespace plusoft_backend.Data;

public class UserContext : DbContext{
    public DbSet<User> Users {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "Data Source=users.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}
