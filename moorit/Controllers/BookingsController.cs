using Moorit.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Moorit.Models;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBookingByUsersId([FromRoute] string userId)
        {
            var records = await _bookingRepository.GetBookingsByUserIdAsync(userId);
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }


        [HttpGet("mooring/{id}")]
        public async Task<IActionResult> GetBookingByMooringId([FromRoute] int id)
        {
            var records = await _bookingRepository.GetBookingsByMooringIdAsync(id);
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }


        // To update all columns value of single record/entity row
        // all columns value need to paased for put call ;
        // if we didnt passed value of all columns in body then it will give error 400 
        [HttpPut("putUpdateBookingAsync/{bookingId}")]
        public async Task<IActionResult> PutUpdateBookingAsync([FromRoute] int bookingId, [FromBody] BookingModel bookingModel)
        {
            await _bookingRepository.PutUpdateBookingAsync(bookingId, bookingModel);

            return Ok(true);
        }
        [HttpPatch("patchUpdateBookingAsync/{id}")]
        public async Task<IActionResult> PatchUpdateBookingAsync([FromRoute] int Id, [FromBody] JsonPatchDocument bookingModel)
        {
            await _bookingRepository.PatchUpdateBookingAsync(Id, bookingModel);

            return Ok(true);
        }


        [HttpDelete("deleteBookingAsync/{id}")]
        public async Task<IActionResult> DeleteBookingAsync(int Id)
        {

            await _bookingRepository.DeleteBookingAsync(Id);
            return Ok(true);
        }




    }
}
