using Moorit.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Moorit.Models;

namespace Moorit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User,Admin")] 
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingsController(IBookingRepository bookingRepository) 
        {
            _bookingRepository = bookingRepository;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBookings()
        {
            var records = await _bookingRepository.GetAllBookingsAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById([FromRoute] int id)
        {
            var records = await _bookingRepository.GetBookingByIdAsync(id);
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBooking([FromBody]BookingModel bookingModel)
        {
            var id = await _bookingRepository.AddBookingAsync(bookingModel);
            return CreatedAtAction(nameof(GetBookingById),new {id=id,controller="bookings"},id);
        }
    }
}
