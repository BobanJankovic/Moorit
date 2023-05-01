using Moorit.Data;
using Moorit.Models;
using Microsoft.EntityFrameworkCore;

namespace Moorit.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly MooritContext _context;
        public LocationRepository(MooritContext context)
        {
            _context = context;
        }
        public async Task<List<LocationModel>> GetAllLocationsAsync()
        {
            var records = await _context.Locations.Select(x => new LocationModel()
            {
                Id = x.Id,
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Moorings = x.Moorings.Select(m => new MooringModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Width = m.Width,
                    Length = m.Length,
                    Price = m.Price,
                    LocationId =m.Id,
                    IsOccupied =m.IsOccupied,
                    // map other properties as needed
                }).ToList()
            }).ToListAsync();

            return records;
        }



        //ParentModel parentFromDB = db.ParentsRepository.GetByID(id);
        //IEnumerable<StudentModel> remainingStudents = db.StudentsRepository.Get().Except(parentFromDB.Students);

        //ICollection<StudentInfoDTO> remainingDTOs = new List<StudentInfoDTO>();

        //    foreach (StudentModel student in remainingStudents)
        //    {
        //        //ubaci razred
        //        remainingDTOs.Add(new StudentInfoDTO(student.Id, student.FirstName, student.LastName, student.UserName, student.DateOfBirth));
        //    }



    public async Task<LocationModel> GetLocationByIdAsync(int locationId)
        {
            var records = await _context.Locations.Where(x => x.Id == locationId).Select(x => new LocationModel()
            {
                Id = x.Id,
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Moorings = x.Moorings.Select(m => new MooringModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Width = m.Width,
                    Length = m.Length,
                    Price = m.Price,
                    LocationId = m.Id,
                    IsOccupied = m.IsOccupied,
                    // map other properties as needed
                }).ToList()
            }).FirstOrDefaultAsync();

            if (records == null)
            {
                throw new Exception();
            }
          

            return records;
        }

        public async Task<int> AddLocationAsync(LocationModel locationModel)
        {
            var location = new Location()
            {
                Name = locationModel.Name,
                Latitude = locationModel.Latitude,
                Longitude = locationModel.Longitude,
            };
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location.Id;
        }

        public async Task PutUpdateLocationAsync(int locationId, LocationModel locationModel)
        {
            //var book = await _context.Bookings.FindAsync(bookingId);

            var location = new Location()
            {
                Id = locationId,
                Name = locationModel.Name,
                Latitude = locationModel.Latitude,
                Longitude = locationModel.Longitude
            };

            //_context.Bookings.Add(booking);
            //await _context.SaveChangesAsync();
            //return booking.Id;

            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(int Id)
        {
            var location = new Location()
            {
                Id = Id
            };
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

        }
    }
}

