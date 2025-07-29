using HuntAPI.Data;
using HuntAPI.Models;
using HuntAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HuntAPI.Repositories
{
    public class HuntRepository : IHuntRepository
    {
        private readonly HuntContext _context;
        private bool _disposed = false;

        public HuntRepository(HuntContext context)
        {
            _context = context;
        }

        public async Task<Hunt> Add(Hunt entity)
        {
            await _context.Hunts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Hunt> Delete(int id)
        {
            var hunt = await GetByID(id);
            if (hunt != null)
            {
                _context.Hunts.Remove(hunt);
                await _context.SaveChangesAsync();
                return hunt;
            }
            throw new KeyNotFoundException($"Hunt with id {id} not found");
        }

        public async Task<List<Hunt>> GetAll()
        {
            return await _context.Hunts.ToListAsync();
        }

        public async Task<Hunt?> GetByID(int id)
        {
            return await _context.Hunts.FindAsync(id);
        }

        public async Task<Hunt> Update(Hunt entity)
        {
            _context.Hunts.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
