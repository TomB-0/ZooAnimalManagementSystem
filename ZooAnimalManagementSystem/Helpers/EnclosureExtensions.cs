using static ZooAnimalManagementSystem.Helpers.Enums;

namespace ZooAnimalManagementSystem.Helpers
{
    public static class EnclosureExtensions
    {
        public static int ToInt(this EnclosureSize size)
        {
            switch (size)
            {
                case EnclosureSize.Small: return 10;
                case EnclosureSize.Medium: return 25;
                case EnclosureSize.Large: return 50;
                case EnclosureSize.Huge: return 100;
                default: return 10;
            }
        }
    }
}
