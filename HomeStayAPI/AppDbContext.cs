using HomeStayAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeStayAPI;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<RoomAvailability> RoomAvailabilities { get; set; }   
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Room>()
            .HasMany<Booking>(e=> e.Bookings)
            .WithOne(e=>e.Room)
            .HasForeignKey(e => e.RoomId);
        
        modelBuilder.Entity<Room>().HasMany<RoomAvailability>(e => e.RoomAvailabilities)
            .WithOne(e => e.Room)
            .HasForeignKey(e => e.RoomId);

        modelBuilder.Entity<Booking>()
            .HasOne<Room>(e => e.Room);
        
        base.OnModelCreating(modelBuilder);
    }
}