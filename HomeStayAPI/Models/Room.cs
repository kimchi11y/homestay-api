using System.ComponentModel.DataAnnotations;

namespace HomeStayAPI.Models;

public class Room : BaseEntity
{
    [Key]
    public string RoomId { get; set; } = Guid.NewGuid().ToString();
    public string? RoomName { get; set; }
    public string? RoomType { get; set; }
    public decimal? RoomPrice { get; set; }
    
    public ICollection <RoomAvailability>? RoomAvailabilities { get; set; }
    public ICollection <Booking>? Bookings { get; set; }
}