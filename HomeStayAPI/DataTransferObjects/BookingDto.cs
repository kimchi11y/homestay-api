namespace HomeStayAPI.DataTransferObjects;

public class BookingDto
{
    public string BookingId { get; set; } = Guid.NewGuid().ToString();
    public string? BookingName { get; set; }
    public string? RoomId { get; set; }
    public string? BookingDate { get; set; }
}

public class CreateBookingDto  
{
    public string? RoomId { get; set; }
    public string? BookingName { get; set; }
    public string? BookingDate { get; set; }
    
    
}

public class UpdateBookingDto : CreateBookingDto
{
    public string BookingId { get; set; } = Guid.NewGuid().ToString();
}

public class DeleteBookingDto : CreateBookingDto
{
    public string BookingId { get; set; } = Guid.NewGuid().ToString();
}
