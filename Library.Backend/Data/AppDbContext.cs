using Library.Backend.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Backend.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
        Database.EnsureCreated();
    }

    public DbSet<Book> Books { get; set; }
}
