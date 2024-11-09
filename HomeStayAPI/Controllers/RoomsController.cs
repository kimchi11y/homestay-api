using System.Diagnostics;
using HomeStayAPI.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using HomeStayAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeStayAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly ILogger<RoomsController> _logger;
    private readonly AppDbContext _context;

    public RoomsController(ILogger<RoomsController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetRooms()
    {
        var rooms = await _context.Rooms.ToListAsync();
        var res = rooms.Select(x => new RoomDto
        {
            RoomName = x.RoomName,
            RoomPrice = x.RoomPrice,
            RoomType = x.RoomType,
        }).ToList();
        return Ok(res);
    }

    [HttpGet("{roomId}")]
    public async Task<IActionResult> GetRoomById(string roomId)
    {
        var room = await _context.Rooms.Where(x => x.RoomId == roomId).FirstOrDefaultAsync();
 
        
        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom(CreateRoomDto createRoomDto)
    {
        //map dto to entity
        var room = new Room
        {
            RoomName = createRoomDto.RoomName,
            RoomPrice = createRoomDto.RoomPrice,
            RoomType = createRoomDto.RoomType,
        };
        var res = await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();

        var createdRoom = new RoomDto
        {
            RoomName = res.Entity.RoomName,
            RoomPrice = res.Entity.RoomPrice,
            RoomType = res.Entity.RoomType,
        };
        return Ok(createdRoom);

    }

    [HttpPut("{roomId}")]
    public async Task<IActionResult> UpdateRoom(string roomId, UpdateRoomDto updateRoomDto)
    {
        var room = await _context.Rooms.FindAsync(roomId);
        if (room == null)
        {
            return NotFound("Room not found");
        }

        // Update the properties of the found room
        room.RoomName = updateRoomDto.RoomName;
        room.RoomPrice = updateRoomDto.RoomPrice;
        room.RoomType = updateRoomDto.RoomType;

        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();

        var updatedRoom = new RoomDto
        {
            RoomName = room.RoomName,
            RoomPrice = room.RoomPrice,
            RoomType = room.RoomType,
        };
        
        return Ok(updatedRoom);
    }

    [HttpDelete("{roomId}")]
    public async Task<IActionResult> DeleteRoom(string roomId)
    {
        var room = await _context.Rooms.FindAsync(roomId);
        if (room == null)
        {
            return NotFound("Room not found");
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        return Ok("Room deleted successfully");
    }



}