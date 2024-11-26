using DemoApp2024Fall.Shared;
using Microsoft.EntityFrameworkCore;

namespace DemoApp2024Fall.Contexts;

public class DemoAppContext : DbContext
{
    public DemoAppContext(DbContextOptions<DemoAppContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Person> People { get; set; }
    
    public virtual DbSet<Item> Items { get; set; }
}