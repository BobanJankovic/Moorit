using Moorit.Data;
using Moorit.Models;
using Microsoft.EntityFrameworkCore;


namespace Moorit.Repository
{
    public class MooringRepository : IMooringRepository
    {
        private readonly MooritContext _context;
        public MooringRepository(MooritContext context)
        {
            _context = context;
        }


        static public MooringModel.MooringStatus GetStatus(
            DateTime sf, 
            DateTime ef, 
            IEnumerable<BookingModel> Bookings
       )
        {

            foreach (var booking in Bookings)
            {
                // sf and ef stands for filterStardDate and filterEndDate
                // sb and eb stands for bookingStardDate and bookingEndDate

                var sb = booking.StartDate;
                var eb = booking.EndDate;

                if ((sf < sb && eb<ef) || (sb<sf&&eb<ef&&sf<eb) || (sf < sb && ef < eb&&sb<ef))
                {
                    return MooringModel.MooringStatus.ExpiresSoon;
                }
                else if (sb < sf && ef < eb)
                {
                    return MooringModel.MooringStatus.Occupied;
                }
                else if (sb == sf && ef < eb)
                {
                    return MooringModel.MooringStatus.Occupied;
                }
            }

            return MooringModel.MooringStatus.Available;
        }

        public async Task<List<MooringModel>> GetAllMooringsAsync(string startDate, string endDate)
        {
            Console.WriteLine(startDate, endDate);
            // Parse the start and end date strings to DateTime objects
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);


            var records = await _context.Moorings.Select(x =>  new MooringModel()
            {
                Id = x.Id,
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude=x.Longitude,
                Price = x.Price,
                Status = GetStatus(start,end, x.Bookings.Select(m => new BookingModel
                {
                    Id = m.Id,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    Price = m.Price,
                    ApplicationUserModelId = m.ApplicationUserModelId
                    // map other properties as needed
                }).ToList()),
                Bookings = x.Bookings.Select(m => new BookingModel
                {
                    Id = m.Id,
                    StartDate=m.StartDate,
                    EndDate=m.EndDate,
                    Price=m.Price,
                    ApplicationUserModelId=m.ApplicationUserModelId
                    // map other properties as needed
                }).ToList()

            }).ToListAsync();

            return records;
        }

        public async Task<MooringModel> GetMooringByIdAsync(int mooringId)
        {
            var records = await _context.Moorings.Where(x => x.Id == mooringId).Select(x => new MooringModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).FirstOrDefaultAsync();

            if (records == null)
            {
                throw new Exception();
            }

            return records;
        }

        public async Task<int> AddMooringAsync(MooringModel mooringModel)
        {

        var mooring = new Mooring()
        {
            Name = mooringModel.Name,
            Length = mooringModel.Length,
            Width = mooringModel.Width,
            IsOccupied = mooringModel.IsOccupied,
            Price = mooringModel.Price,
            LocationId=mooringModel.LocationId,
            Latitude = mooringModel.Latitude,
            Longitude = mooringModel.Longitude,
        };
            _context.Moorings.Add(mooring);
            await _context.SaveChangesAsync();
            return mooring.Id;
        }

        public async Task DeleteMooringAsync(int Id)
        {
            var mooring = new Mooring()
            {
                Id = Id
            };
            _context.Moorings.Remove(mooring);
            await _context.SaveChangesAsync();

        }
    }
}

