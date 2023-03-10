using Moorit.Data;
using Moorit.Models;
using Microsoft.EntityFrameworkCore;

namespace Moorit.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MooritContext _context;
        public UserRepository(MooritContext context)
        {
            _context = context;
        }
        //public async Task<List<UserModel>> GetAllUsersAsync()
        //{
        //    var records = await _context.Users.Select(x => new UserModel()
        //    {
        //        Id = x.Id,
        //        FirstName = x.FirstName,
        //        LastName = x.LastName,
        //        Email = x.Email,
        //        Phone = x.Phone

        //    }).ToListAsync();

        //    return records;
        //}

        //public async Task<UserModel> GetUserByIdAsync(int userId)
        //{
        //    var records = await _context.Users.Where(x => x.Id == userId).Select(x => new UserModel()
        //    {
        //        Id = x.Id,
        //        FirstName = x.FirstName,
        
        //    }).FirstOrDefaultAsync();


        //    if (records == null)
        //    {
        //        throw new Exception();
        //    }

        //    return records;
        //}
    }
}

                