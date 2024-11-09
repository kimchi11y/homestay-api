namespace HomeStayAPI.DataTransferObjects;

public class CreateRoomDto
{
    public string? RoomName { get; set; }
    public string? RoomType { get; set; }
    public decimal? RoomPrice { get; set; }
}

public class UpdateRoomDto : CreateRoomDto
{
    public string RoomId { get; set; } = Guid.NewGuid().ToString();
}

public class DeleteRoomDto : CreateRoomDto
{
    public string RoomId { get; set; } = Guid.NewGuid().ToString();

}

public class RoomDto
{
    public string RoomId { get; set; } = Guid.NewGuid().ToString();
    public string? RoomName { get; set; }
    public string? RoomType { get; set; }
    public decimal? RoomPrice { get; set; }
}