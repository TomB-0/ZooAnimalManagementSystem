using static ZooAnimalManagementSystem.Helpers.Enums;

namespace ZooAnimalManagementSystem.Dtos
{
    public class AnimalDto
    {
        public string Species { get; set; }
        public AnimalFood Food { get; set; }
        public int Amount { get; set; }
    }
}
