using HuntAPI.Models;

namespace HuntAPI.Services.ServiceInterfaces
{
    public interface IHuntService
    {
        Task<IEnumerable<Hunt>> GetAllHuntsAsync();
        Task<Hunt?> GetHuntByIdAsync(int id);
        Task<Hunt> CreateHuntAsync(Hunt hunt);
        Task<Hunt> UpdateHuntAsync(Hunt hunt);
        Task DeleteHuntAsync(int id);
    }
}
