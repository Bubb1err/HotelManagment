using HotelManagment.Core.Entities;
using HotelManagment.Core.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Infrastructure.Data;

public class HotelDbContext : IdentityDbContext
{
  public DbSet<User> Accounts { get; set; } = null!; 
  public DbSet<Report> Reports { get; set; } = null!; 
  public DbSet<Reservation> Reservations { get; set; } = null!; 
  public DbSet<Room> Rooms { get; set; } = null!;
  public DbSet<Visitor> Visitors { get; set; } = null!;
  public DbSet<RoomBenefit> RoomBenefits { get; set; } = null!;
  public DbSet<Benefit> Benefits { get; set; } = null!;
  
  public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfigurationsFromAssembly(typeof(HotelDbContext).Assembly);
    base.OnModelCreating(builder);
    builder.Entity<Room>().HasMany(x => x.Benefits).WithOne(x => x.Room);
  }
}