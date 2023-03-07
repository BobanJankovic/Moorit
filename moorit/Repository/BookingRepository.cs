using Moorit.Data;
using Moorit.Models;
using Microsoft.EntityFrameworkCore;

namespace Moorit.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MooritContext _context;
    
        public BookingRepository(MooritContext context)
        {
            _context = context;
           
        }
        public async Task<List<BookingModel>> GetAllBookingsAsync()
        {
            var records = await _context.Bookings.Select(x => new BookingModel()
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Price= x.Price,
                ApplicationUserId=x.ApplicationUserId,
                User = x.User,
                MooringId=x.MooringId,
                Mooring = new MooringModel()
                {
                    Id = x.Mooring.Id,
                    Name = x.Mooring.Name,
                    Length = x.Mooring.Length,
                    Width = x.Mooring.Width,
                    IsOccupied = x.Mooring.IsOccupied,
                    Price = x.Mooring.Price,
                    LocationId = x.Mooring.LocationId,
                    Location = new LocationModel()
                    {
                        Id = x.Mooring.Location.Id,
                        Name = x.Mooring.Location.Name,
                        Moorings = x.Mooring.Location.Moorings.Select(m => new MooringModel
                        {
                            Id = m.Id,
                            Name = m.Name,
                         
                        }).ToList()
                    }
                }
            }).ToListAsync();

            return records;
        }

        public async Task<BookingModel> GetBookingByIdAsync(int bookingId)
        {
            var records = await _context.Bookings.Where(x => x.Id == bookingId).Select(x => new BookingModel()
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Price = x.Price,
                ApplicationUserId = x.ApplicationUserId,
                User = x.User,
                MooringId = x.MooringId,
                Mooring = new MooringModel()
                {
                    Id = x.Mooring.Id,
                    Name = x.Mooring.Name,
                    Length = x.Mooring.Length,
                    Width = x.Mooring.Width,
                    IsOccupied = x.Mooring.IsOccupied,
                    Price = x.Mooring.Price,
                    LocationId = x.Mooring.LocationId,
                    Location = new LocationModel()
                    {
                        Id = x.Mooring.Location.Id,
                        Name = x.Mooring.Location.Name,
                        Moorings = x.Mooring.Location.Moorings.Select(m => new MooringModel
                        {
                            Id = m.Id,
                            Name = m.Name,

                        }).ToList()
                    }
                }
            }).FirstOrDefaultAsync();

            if (records == null)
            {
                throw new Exception();
            }
          

            return records;
        }

        public async Task<int> AddBookingAsync(BookingModel bookingModel)
        {
            //UserModel user = await userRepository.GetUserByIdAsync(bookingModel.UserId);
            //MooringModel mooring = await mooringRepository.GetMooringByIdAsync(bookingModel.MooringId);
            

            var booking = new Booking() { 
                EndDate = bookingModel.EndDate, 
                StartDate = bookingModel.StartDate, 
                Price = bookingModel.Price,
                ApplicationUserId = bookingModel.ApplicationUserId, 
                MooringId = bookingModel.MooringId,
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking.Id;
        }
    }
}

