using Microsoft.EntityFrameworkCore;
using Project11EF.API.Models;

namespace Project11EF.API.Data;

public class Project11EFContext : DbContext
{
    //Fields
    public DbSet<User> Users {get; set;}
    public DbSet<Vehicle> Vehicles {get; set;}
    public DbSet<Truck> Trucks {get; set;}

    //Constructors
    public Project11EFContext() {}

    public Project11EFContext(DbContextOptions options) : base (options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>().UseTpcMappingStrategy()
            .ToTable("Cars");
        modelBuilder.Entity<Truck>()
            .ToTable("Trucks");
        
        modelBuilder.Entity<User>()
            .ToTable("Users");

        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
    }

}