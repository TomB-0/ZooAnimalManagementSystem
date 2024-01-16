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

        public async Task<Animal> CreateAnimalAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            return animal;
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

        public async Task<Animal> UpdateAnimalAsync(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
            return animal;
        }
    }
}
