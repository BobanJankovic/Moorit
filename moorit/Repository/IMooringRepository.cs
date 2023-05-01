using Moorit.Models;

namespace Moorit.Repository
{
    public interface IMooringRepository
    {
        Task<List<MooringModel>> GetAllMooringsAsync(string startDate, string endDate);
        Task<MooringModel> GetMooringByIdAsync(int mooringId);
        Task<int> AddMooringAsync(MooringModel mooringModel);

        Task DeleteMooringAsync(int Id);
    }
}
