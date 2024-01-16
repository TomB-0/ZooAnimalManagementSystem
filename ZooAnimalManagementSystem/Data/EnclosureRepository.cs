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

        public Task DeleteEnclosureAsync(int enclosureId)
        {
            throw new NotImplementedException();
        }

        public Task<Enclosure> GetEnclosureAsync(int enclosureId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Enclosure>> GetEnclosuresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Enclosure> UpdateEnclosureAsync(Enclosure enclosure)
        {
            throw new NotImplementedException();
        }
    }
}
