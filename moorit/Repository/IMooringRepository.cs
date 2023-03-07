using Moorit.Models;

namespace Moorit.Repository
{
    public interface IMooringRepository
    {
        Task<List<MooringModel>> GetAllMooringsAsync();
        Task<MooringModel> GetMooringByIdAsync(int mooringId);
        Task<int> AddMooringAsync(MooringModel mooringModel);
    }
}
