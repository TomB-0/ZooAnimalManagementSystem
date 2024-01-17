namespace ZooAnimalManagementSystem.Interfaces
{
    public interface IAnimalTransferService
    {
        Task TransferAnimalsAsync();
        Task ResetAnimalEnclosures();
    }
}
