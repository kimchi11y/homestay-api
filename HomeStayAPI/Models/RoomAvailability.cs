using System.ComponentModel.DataAnnotations;

namespace HomeStayAPI.Models;

public class RoomAvailability:BaseEntity
{
    [Key]
    public string RoomAvailabilityId { get; set; } = Guid.NewGuid().ToString();
    public string? RoomId { get; set; }
    public DateTime? Date { get; set; }
    public Boolean? Availability { get; set; }

    public Room? Room { get; set; }
}