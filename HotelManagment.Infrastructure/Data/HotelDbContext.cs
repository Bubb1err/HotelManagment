using HotelManagment.Core.Entities;
using HotelManagment.Core.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Infrastructure.Data;

public class HotelDbContext : IdentityDbContext
{
  public DbSet<User> Accounts { get; set; } 
  public DbSet<Report> Reports { get; set; } 
  public DbSet<Reservation> Reservations { get; set; } 
  public DbSet<Room> Rooms { get; set; }
  public DbSet<Visitor> Visitors { get; set; }
    public DbSet<RoomBenefit> RoomBenefits { get; set; }
    public DbSet<Benefit> Benefits { get; set; }


  public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Room>().HasMany(x => x.Benefits).WithOne(x => x.Room);
    }
}