using Microsoft.AspNetCore.JsonPatch;
using Moorit.Models;

namespace Moorit.Repository
{
    public interface IBookingRepository
    {
        Task<List<BookingModel>> GetAllBookingsAsync();
        Task<BookingModel> GetBookingByIdAsync(int bookingId);
        Task<int> AddBookingAsync(BookingModel bookingModel);

        Task<List<BookingModel>> GetBookingsByUserIdAsync(string userId);
        Task<List<BookingModel>> GetBookingsByMooringIdAsync(int id);

        Task PutUpdateBookingAsync(int bookingId, BookingModel bookingModel);
        Task PatchUpdateBookingAsync(int Id, JsonPatchDocument bookingModel);
        Task DeleteBookingAsync(int Id);
    }
}
