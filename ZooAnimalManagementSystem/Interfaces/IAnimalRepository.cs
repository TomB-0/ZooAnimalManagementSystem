using ZooAnimalManagementSystem.Entities;

namespace ZooAnimalManagementSystem.Interfaces
{
    public interface IAnimalRepository
    {
        Task<Animal> CreateAnimalAsync(Animal animal);
        Task<Animal> UpdateAnimalAsync(Animal animal);
        Task<Animal> GetAnimalAsync(int id);
        Task<List<Animal>> GetAnimalsAsync();
        Task DeleteAnimalAsync(int id);
    }
}
