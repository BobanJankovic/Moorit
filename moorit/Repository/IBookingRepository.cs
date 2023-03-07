using Moorit.Models;

namespace Moorit.Repository
{
    public interface IBookingRepository
    {
        Task<List<BookingModel>> GetAllBookingsAsync();
        Task<BookingModel> GetBookingByIdAsync(int bookingId);
        Task<int> AddBookingAsync(BookingModel bookingModel);
    }
}
