using static ZooAnimalManagementSystem.Helpers.Enums;

namespace ZooAnimalManagementSystem.Entities
{
    public class Enclosure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnclosureSize Size { get; set; }
        public EnclosureLocation Location { get; set; }
        public List<String> Objects { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
