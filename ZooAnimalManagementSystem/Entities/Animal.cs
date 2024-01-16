using static ZooAnimalManagementSystem.Helpers.Enums;

namespace ZooAnimalManagementSystem.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public AnimalFood Food { get; set; }
        public int Amount { get; set; }
        public int? EnclosureId { get; set; }
        public Enclosure Enclosure { get; set; }
    }
}
