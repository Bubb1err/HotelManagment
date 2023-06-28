using HotelManagment.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagment.Infrastructure.Data.Configuration;

public class RoomBenefitConfiguration : IEntityTypeConfiguration<RoomBenefit>
{
  public void Configure(EntityTypeBuilder<RoomBenefit> builder)
  {
    builder.HasKey(benefit => new { benefit.RoomId, benefit.BenefitId });
  }
}