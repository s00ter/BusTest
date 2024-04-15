using Microsoft.EntityFrameworkCore;

namespace BusTest.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) 
        : base(options)
    {
        
    }
    
    public DbSet<Url> Urls { get; set; }
}