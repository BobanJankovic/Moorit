using Moorit.Data;
using Moorit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;

namespace Moorit.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MooritContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(MooritContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }
        public async Task<List<BookingModel>> GetAllBookingsAsync()
        {
            var records = await _context.Bookings.Select(x => new BookingModel()
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Price= x.Price,
                ApplicationUserModelId=x.ApplicationUserModelId,
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
                        //Moorings = x.Mooring.Location.Moorings.Select(m => new MooringModel
                        //{
                        //    Id = m.Id,
                        //    Name = m.Name,
                         
                        //}).ToList()
                    }
                }
            }).ToListAsync();

            return records;
        }

        public async Task<BookingModel> GetBookingByIdAsync(int bookingId)
        {
            //var records = await _context.Bookings.Where(x => x.Id == bookingId).Select(x => new BookingModel()
            //{
            //    Id = x.Id,
            //    StartDate = x.StartDate,
            //    EndDate = x.EndDate,
            //    Price = x.Price,
            //    ApplicationUserModelId = x.ApplicationUserModelId,
            //    User = x.User,
            //    MooringId = x.MooringId,
            //    Mooring = new MooringModel()
            //    {
            //        Id = x.Mooring.Id,
            //        Name = x.Mooring.Name,
            //        Length = x.Mooring.Length,
            //        Width = x.Mooring.Width,
            //        IsOccupied = x.Mooring.IsOccupied,
            //        Price = x.Mooring.Price,
            //        LocationId = x.Mooring.LocationId,
            //        Location = new LocationModel()
            //        {
            //            Id = x.Mooring.Location.Id,
            //            Name = x.Mooring.Location.Name,
            //            Moorings = x.Mooring.Location.Moorings.Select(m => new MooringModel
            //            {
            //                Id = m.Id,
            //                Name = m.Name,

            //            }).ToList()
            //        }
            //    }
            //}).FirstOrDefaultAsync();

            //if (records == null)
            //{
            //    throw new Exception();
            //}


            //return records;
            var booking = await _context.Bookings.FindAsync(bookingId);
            return _mapper.Map<BookingModel>(booking);
        }

        public async Task<int> AddBookingAsync(BookingModel bookingModel)
        {
            //UserModel user = await userRepository.GetUserByIdAsync(bookingModel.UserId);
            //MooringModel mooring = await mooringRepository.GetMooringByIdAsync(bookingModel.MooringId);
            

            var booking = new Booking() { 
                EndDate = bookingModel.EndDate, 
                StartDate = bookingModel.StartDate, 
                Price = bookingModel.Price,
                ApplicationUserModelId = bookingModel.ApplicationUserModelId, 
                MooringId = bookingModel.MooringId,
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking.Id;
        }

        public async Task<List<BookingModel>> GetBookingsByUserIdAsync(string userId)
        {
            var records = await _context.Bookings.Where(x => x.ApplicationUserModelId == userId).Select(x => new BookingModel()
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Price = x.Price,
                ApplicationUserModelId = x.ApplicationUserModelId,
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
                        //Moorings = x.Mooring.Location.Moorings.Select(m => new MooringModel
                        //{
                        //    Id = m.Id,
                        //    Name = m.Name,

                        //}).ToList()
                    }
                }
            }).ToListAsync();

            if (records == null)
            {
                throw new Exception();
            }


            return records;
        }

        public async Task<List<BookingModel>> GetBookingsByMooringIdAsync(int id)
        {
            var records = await _context.Bookings.Where(x => x.MooringId == id).Select(x => new BookingModel()
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Price = x.Price,
                ApplicationUserModelId = x.ApplicationUserModelId,
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
                        //Moorings = x.Mooring.Location.Moorings.Select(m => new MooringModel
                        //{
                        //    Id = m.Id,
                        //    Name = m.Name,

                        //}).ToList()
                    }
                }
            }).ToListAsync();

            if (records == null)
            {
                throw new Exception();
            }


            return records;
        }

        public async Task PutUpdateBookingAsync(int bookingId, BookingModel bookingModel)
        {
            //var book = await _context.Bookings.FindAsync(bookingId);

            var booking = new Booking()
            {
                Id= bookingId,
                EndDate = bookingModel.EndDate,
                StartDate = bookingModel.StartDate,
                Price = bookingModel.Price,
                ApplicationUserModelId = bookingModel.ApplicationUserModelId,
                MooringId = bookingModel.MooringId,
            };

            //_context.Bookings.Add(booking);
            //await _context.SaveChangesAsync();
            //return booking.Id;

            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
        public async Task PatchUpdateBookingAsync(int Id, JsonPatchDocument bookingModel)
        {
            var book = await _context.Bookings.FindAsync(Id);
            if (book != null)
            {
                bookingModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteBookingAsync(int Id)
        {
            var book = new Booking()
            {
                Id = Id
            };
            _context.Bookings.Remove(book);
            await _context.SaveChangesAsync();
        
        }
    }
}

