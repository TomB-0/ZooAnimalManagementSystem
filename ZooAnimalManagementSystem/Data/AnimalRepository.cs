using ZooAnimalManagementSystem.Entities;
using ZooAnimalManagementSystem.Interfaces;

namespace ZooAnimalManagementSystem.Data
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly DataContext _context;

        public AnimalRepository(DataContext context)
        {
            _context = context;
        }

        public Task<Animal> CreateAnimalAsync(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAnimalAsync(int animalId)
        {
            throw new NotImplementedException();
        }

        public Task<Animal> GetAnimalAsync(int animalId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Animal>> GetAnimalsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Animal> UpdateAnimalAsync(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
