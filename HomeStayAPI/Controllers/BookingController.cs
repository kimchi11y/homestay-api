using Microsoft.AspNetCore.Mvc;

namespace HomeStayAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using HomeStayAPI.DataTransferObjects;
using HomeStayAPI.Models;


public class BookingController : ControllerBase
{
    private readonly ILogger<BookingController> _logger;
    private readonly AppDbContext _context;

    public BookingController(ILogger<BookingController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetBookings()
    {
        var bookings = await _context.Bookings.ToListAsync();
        var res = bookings.Select(x => new BookingDto
        {
            BookingId = x.BookingId,
            BookingName = x.BookingName,
            RoomId = x.RoomId,
            BookingDate = x.BookingDate
        }).ToList();
        return Ok(res);
    }
    

    [HttpGet("{bookingId}")]
    public async Task<IActionResult> GetBookingById(string bookingId)
    {
        var booking = await _context.Bookings.Where(x => x.BookingId == bookingId).FirstOrDefaultAsync();
        return Ok(booking);
    }
    

    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
    {
        //map dto to entity
        var booking = new Booking
        {
            BookingName = createBookingDto.BookingName,
            RoomId = createBookingDto.RoomId,
            BookingDate = createBookingDto.BookingDate
        };
        var res = await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
        return Ok();
    }
    

    [HttpPut("{bookingId}")]
    public async Task<IActionResult> UpdateBooking(string bookingId, UpdateBookingDto updateBookingDto)
    {
        var booking = await _context.Bookings.Where(x => x.BookingId == bookingId).FirstOrDefaultAsync();
        booking.BookingName = updateBookingDto.BookingName;
        booking.BookingDate = updateBookingDto.BookingDate;
        booking.RoomId = updateBookingDto.RoomId;
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    
    [HttpDelete("{bookingId}")]
    public async Task<IActionResult> DeleteBooking(string bookingId)
    {
        var booking = await _context.Bookings.Where(x => x.BookingId == bookingId).FirstOrDefaultAsync();
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    
    


}