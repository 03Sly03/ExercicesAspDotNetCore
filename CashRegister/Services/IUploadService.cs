namespace CashRegister.Services
{
    public interface IUploadService
    {
        string Upload(IFormFile file);
        // tout nos services d'uploasd devront avoir cette méthode
    }
}
