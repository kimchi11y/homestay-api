using System.ComponentModel.DataAnnotations;

namespace HomeStayAPI.Models;

public class Booking : BaseEntity
{
    [Key]
    public string BoookingId { get; set; } = Guid.NewGuid().ToString();
    public string? BookingName { get; set; }
    public string? RoomId { get; set; }
    public string? BookingDate { get; set; }
    
    public Room? Room { get; set; }
}