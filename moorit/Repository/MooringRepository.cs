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
        public async Task<List<MooringModel>> GetAllMooringsAsync()
        {
            var records = await _context.Moorings.Select(x => new MooringModel()
            {
                Id = x.Id,
                Name = x.Name,
             
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
            };
            _context.Moorings.Add(mooring);
            await _context.SaveChangesAsync();
            return mooring.Id;
        }
    }
}

                