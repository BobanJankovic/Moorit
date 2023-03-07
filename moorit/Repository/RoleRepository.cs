using Moorit.Data;
using Moorit.Models;
using Microsoft.EntityFrameworkCore;

namespace Moorit.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MooritContext _context;
        public RoleRepository(MooritContext context)
        {
            _context = context;
        }
        public async Task<List<RoleModel>> GetAllRolesAsync()
        {
            var records = await _context.Roles.Select(x => new RoleModel()
            {
                Id = x.Id,
                Name = x.Name,
  
            }).ToListAsync();

            return records;
        }

        public async Task<RoleModel> GetRoleByIdAsync(int roleId)
        {
            var records = await _context.Roles.Where(x => x.Id == roleId).Select(x => new RoleModel()
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
    }
}
 
                