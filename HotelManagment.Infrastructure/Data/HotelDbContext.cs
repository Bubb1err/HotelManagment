using HotelManagment.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Infrastructure.Data;

public class HotelDbContext : IdentityDbContext
{
  public DbSet<User> Accounts { get; set; } = null!;

  public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }
}