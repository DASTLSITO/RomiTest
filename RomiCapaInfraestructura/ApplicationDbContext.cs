using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RomiCapaDominio.Entidades;

namespace RomiCapaInfraestructura;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) 
    {
    } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public DbSet<Cliente> Cliente  { get; set; }
}