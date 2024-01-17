using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteAnimalAsync(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Animal> GetAnimalAsync(int id)
        {
            return await _context.Animals
                .Include(a => a.Enclosure)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Animal>> GetAnimalsAsync()
        {
            return await _context.Animals
                .Include(a => a.Enclosure)
                .ToListAsync();
        }

        public async Task<Animal> UpdateAnimalAsync(Animal animal)
        {
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
            return animal;
        }
    }
}
