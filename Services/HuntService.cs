using HuntAPI.Models;
using HuntAPI.Repositories.Interfaces;
using HuntAPI.Services.ServiceInterfaces;

namespace HuntAPI.Services
{
    public class HuntService : IHuntService
    {
        private readonly IHuntRepository _huntRepository;

        public HuntService(IHuntRepository huntRepository)
        {
            _huntRepository = huntRepository;
        }

        public async Task<Hunt> CreateHuntAsync(Hunt hunt)
        {
            return await _huntRepository.Add(hunt);
        }

        public async Task DeleteHuntAsync(int id)
        {
            await _huntRepository.Delete(id);
        }

        public async Task<IEnumerable<Hunt>> GetAllHuntsAsync()
        {
            var hunts = await _huntRepository.GetAll();
            return hunts;
        }

        public async Task<Hunt?> GetHuntByIdAsync(int id)
        {
            return await _huntRepository.GetByID(id);
        }

        public async Task<Hunt> UpdateHuntAsync(Hunt hunt)
        {
            return await _huntRepository.Update(hunt);
        }
    }
}
