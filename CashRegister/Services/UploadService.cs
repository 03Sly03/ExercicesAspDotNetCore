using CashRegister.Data;

namespace CashRegister.Services
{
    public class UploadService : IUploadService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _dbContext;

        public UploadService(IWebHostEnvironment env, ApplicationDbContext dbContext)
        {
            _env = env;
            _dbContext = dbContext;
        }

        public string Upload(IFormFile file) 
        {
            string guid = Guid.NewGuid().ToString();
            string fileName = guid + "-" + file.FileName;
            string pathToFile = Path.Combine(_env.WebRootPath, "images", fileName); // chemin du ficher sur le serveur (on récupère wwwroot/images/)
            FileStream stream = File.Create(pathToFile); // on créer un fichier vide (stream)
            file.CopyTo(stream); // on copie le conteneu dans le fichier créé (stream)
            stream.Close(); // on ferme le fichier
            return "/images/" + fileName; // on retoune le chemin du fichier sur le navigateur (le dossier wwwroot correspond à la racine)
        }
    }
}
