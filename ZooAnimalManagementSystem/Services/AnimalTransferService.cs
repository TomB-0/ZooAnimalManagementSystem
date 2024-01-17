using ZooAnimalManagementSystem.Entities;
using ZooAnimalManagementSystem.Interfaces;
using static ZooAnimalManagementSystem.Helpers.Enums;
using static ZooAnimalManagementSystem.Helpers.EnclosureExtensions;
using ZooAnimalManagementSystem.Helpers;

namespace ZooAnimalManagementSystem.Services
{
    public class AnimalTransferService : IAnimalTransferService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IEnclosureRepository _enclosureRepository;

        public AnimalTransferService(IAnimalRepository animalRepository, IEnclosureRepository enclosureRepository)
        {
            _animalRepository = animalRepository;
            _enclosureRepository = enclosureRepository;
        }

        public async Task TransferAnimalsAsync()
        {
            var animals = await _animalRepository.GetAnimalsAsync();
            var enclosures = await _enclosureRepository.GetEnclosuresAsync();

            foreach (var animal in animals)
            {
                var suitableEnclosure = enclosures.FirstOrDefault(e => IsSuitableEnclosure(e, animal));

                if (suitableEnclosure != null)
                {
                    animal.EnclosureId = suitableEnclosure.Id;
                    animal.Enclosure = suitableEnclosure;
                    await _animalRepository.UpdateAnimalAsync(animal);
                }
                else
                {
                    throw new InvalidOperationException($"Unable to find suitable enclosure");
                }

            }
        }

        public async Task ResetAnimalEnclosures()
        {
            var animals = await _animalRepository.GetAnimalsAsync();

            foreach (var animal in animals)
            {
                animal.EnclosureId = null;
                animal.Enclosure = null;
                await _animalRepository.UpdateAnimalAsync(animal);
            }
        }

        private bool IsSuitableEnclosure(Enclosure enclosure, Animal animal)
        {
            IEnumerable<Animal> currentAnimalsInEnclosure = null;

            if(enclosure.Animals == null)
            {
                currentAnimalsInEnclosure = null;
            }
            else
            {
                currentAnimalsInEnclosure = enclosure
                    .Animals
                    .Where(a => a.EnclosureId == enclosure.Id);
            }

            if(currentAnimalsInEnclosure == null || !currentAnimalsInEnclosure.Any())
            {
                return true;
            }

            var currentAnimalsCountInEnclosure = currentAnimalsInEnclosure.Sum(a => a.Amount);

            var size = EnclosureExtensions.ToInt(enclosure.Size);

            if (currentAnimalsCountInEnclosure >= size || currentAnimalsCountInEnclosure + animal.Amount > size)
            {
                return false;
            }


            if (currentAnimalsInEnclosure.All(a => (a.Food == AnimalFood.Herbivore || a.Food == AnimalFood.Omnivore)) && (animal.Food == AnimalFood.Herbivore || animal.Food == AnimalFood.Herbivore))
            {
                return true;
            }

            if (animal.Food == AnimalFood.Carnivore)
            {
                var distinctCarnivoreSpecies = currentAnimalsInEnclosure
                    .Where(a => a.Food == AnimalFood.Carnivore)
                    .Count();

                return distinctCarnivoreSpecies < 2 && currentAnimalsInEnclosure.All(a => a.Food == animal.Food);
            }

            return false;
        }
    }
}
