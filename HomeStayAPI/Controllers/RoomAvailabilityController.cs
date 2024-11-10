namespace HomeStayAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using HomeStayAPI.Models;
using Microsoft.EntityFrameworkCore;
using HomeStayAPI.DataTransferObjects;

[Route("[controller]")]
[ApiController]


public class RoomAvailabilityController : ControllerBase
{
    private readonly ILogger<RoomAvailabilityController> _logger;
    private readonly AppDbContext _context;

    public RoomAvailabilityController(ILogger<RoomAvailabilityController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }   
    
    [HttpGet]
    public async Task<IActionResult> GetRoomAvailabilities()
    {
        var roomAvailabilities = await _context.RoomAvailabilities.ToListAsync();
        var res = roomAvailabilities.Select(x => new RoomAvailabilityDto
        {
            RoomAvailabilityId = x.RoomAvailabilityId,
            RoomId = x.RoomId,
            Date = x.Date,
            Availability = x.Availability
        }).ToList();
        return Ok(res);
    }
    
    [HttpGet("{roomAvailabilityId}")]
    public async Task<IActionResult> GetRoomAvailabilityById(string roomAvailabilityId)
    {
        var roomAvailability = await _context.RoomAvailabilities.Where(x => x.RoomAvailabilityId == roomAvailabilityId).FirstOrDefaultAsync();
        return Ok(roomAvailability);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRoomAvailability(CreateRoomAvailabilityDto createRoomAvailabilityDto)
    {
        //map dto to entity
        var roomAvailability = new RoomAvailability
        {
            RoomId = createRoomAvailabilityDto.RoomId,
            Date = createRoomAvailabilityDto.Date,
            Availability = createRoomAvailabilityDto.Availability
        };
        var res = await _context.RoomAvailabilities.AddAsync(roomAvailability);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPut("{roomAvailabilityId}")]
    public async Task<IActionResult> UpdateRoomAvailability(string roomAvailabilityId, UpdateRoomAvailabilityDto updateRoomAvailabilityDto)
    {
        var roomAvailability = await _context.RoomAvailabilities.Where(x => x.RoomAvailabilityId == roomAvailabilityId).FirstOrDefaultAsync();
        roomAvailability.RoomId = updateRoomAvailabilityDto.RoomId;
        roomAvailability.Date = updateRoomAvailabilityDto.Date;
        roomAvailability.Availability = updateRoomAvailabilityDto.Availability;
        _context.RoomAvailabilities.Update(roomAvailability);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete("{roomAvailabilityId}")]
    public async Task<IActionResult> DeleteRoomAvailability(string roomAvailabilityId)
    {
        var roomAvailability = await _context.RoomAvailabilities.Where(x => x.RoomAvailabilityId == roomAvailabilityId).FirstOrDefaultAsync();
        _context.RoomAvailabilities.Remove(roomAvailability);
        await _context.SaveChangesAsync();
        return Ok();
    }
}