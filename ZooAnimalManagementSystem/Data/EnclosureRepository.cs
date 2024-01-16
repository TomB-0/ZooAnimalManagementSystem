using Microsoft.EntityFrameworkCore;
using ZooAnimalManagementSystem.Entities;
using ZooAnimalManagementSystem.Interfaces;

namespace ZooAnimalManagementSystem.Data
{
    public class EnclosureRepository : IEnclosureRepository
    {
        private readonly DataContext _context;

        public EnclosureRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Enclosure> CreateEnclosureAsync(Enclosure enclosure)
        {
            _context.Enclosures.Add(enclosure);
            await _context.SaveChangesAsync();
            return enclosure;
        }

        public async Task DeleteEnclosureAsync(int id)
        {
            var enclosure = await _context.Enclosures.FindAsync(id);
            if (enclosure != null)
            {
                _context.Enclosures.Remove(enclosure);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Enclosure> GetEnclosureAsync(int id)
        {
            return await _context.Enclosures.FindAsync(id);
        }

        public async Task<List<Enclosure>> GetEnclosuresAsync()
        {
            return await _context.Enclosures.ToListAsync();
        }

        public async Task<Enclosure> UpdateEnclosureAsync(Enclosure enclosure)
        {
            _context.Enclosures.Update(enclosure);
            await _context.SaveChangesAsync();
            return enclosure;
        }
    }
}
