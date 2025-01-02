using CudOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CudOperations.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Empolyee> Empolyees { get; set; }   
    
}