using ZooAnimalManagementSystem.Entities;

namespace ZooAnimalManagementSystem.Interfaces
{
    public interface IAnimalRepository
    {
        Task<Animal> CreateAnimalAsync(Animal animal);
        Task<Animal> UpdateAnimalAsync(Animal animal);
        Task<Animal> GetAnimalAsync(int animalId);
        Task<List<Animal>> GetAnimalsAsync();
        Task DeleteAnimalAsync(int animalId);
    }
}
