using static ZooAnimalManagementSystem.Helpers.Enums;

namespace ZooAnimalManagementSystem.Dtos
{
    public class AnimalEnclosureDto
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public AnimalFood Food { get; set; }
        public int Amount { get; set; }
        public int? EnclosureId { get; set; }
        public EnclosureDto? EnclosureDto{ get; set; }
    }
}
