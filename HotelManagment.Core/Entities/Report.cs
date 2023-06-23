namespace HotelManagment.Core.Entities;

public class Report
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string CreatorId { get; set; } = string.Empty;

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
