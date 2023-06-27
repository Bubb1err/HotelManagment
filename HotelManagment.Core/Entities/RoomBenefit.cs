using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagment.Core.Entities
{
    public sealed class RoomBenefit
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Benefit))]
        public int BenefitId {get;set;}
        public Benefit Benefit { get; set;}
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set;}
        public Room Room { get; set;}
    }
}