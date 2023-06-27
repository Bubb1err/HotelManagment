namespace HotelManagment.Core.Entities
{
    public sealed class Benefit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public Benefit()
        {
            Description= string.Empty;
            Icon= string.Empty;
        }
    }
}