namespace HomeStayAPI.DataTransferObjects;

public class RoomAvailabilityDto
{
    public string RoomAvailabilityId { get; set; } = Guid.NewGuid().ToString();
    public string? RoomId { get; set; }
    public DateTime? Date { get; set; }
    public Boolean? Availability { get; set; }
}

public class CreateRoomAvailabilityDto
{
    public string? RoomId { get; set; }
    public DateTime? Date { get; set; }
    public Boolean? Availability { get; set; }
}

public class UpdateRoomAvailabilityDto : CreateRoomAvailabilityDto
{
    public string RoomAvailabilityId { get; set; } = Guid.NewGuid().ToString();
}

public class DeleteRoomAvailabilityDto
{
    public string RoomAvailabilityId { get; set; } = Guid.NewGuid().ToString();
}