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

        public Task<Enclosure> CreateEnclosureAsync(Enclosure enclosure)
        {
            throw new NotImplementedException();
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
