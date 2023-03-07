﻿using Moorit.Data;
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
            };
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location.Id;
        }
    }
}
