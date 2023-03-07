using Moorit.Models;

namespace Moorit.Repository
{
    public interface IRoleRepository
    {
        Task<List<RoleModel>> GetAllRolesAsync();
        Task<RoleModel> GetRoleByIdAsync(int roleId);
    }
}
