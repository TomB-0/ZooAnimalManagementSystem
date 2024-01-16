using static ZooAnimalManagementSystem.Helpers.Enums;

namespace ZooAnimalManagementSystem.Dtos
{
    public class EnclosureDto
    {
        public string Name { get; set; }
        public EnclosureSize Size { get; set; }
        public EnclosureLocation Location { get; set; }
        public List<String> Objects { get; set; }
    }
}
