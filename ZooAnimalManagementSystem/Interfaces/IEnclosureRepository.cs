using ZooAnimalManagementSystem.Entities;

namespace ZooAnimalManagementSystem.Interfaces
{
    public interface IEnclosureRepository
    {
        Task<Enclosure> CreateEnclosureAsync(Enclosure enclosure);
        Task<Enclosure> UpdateEnclosureAsync(Enclosure enclosure);
        Task<Enclosure> GetEnclosureAsync(int id);
        Task<List<Enclosure>> GetEnclosuresAsync();
        Task DeleteEnclosureAsync(int id);
    }
}
