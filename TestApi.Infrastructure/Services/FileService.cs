
namespace TestApi.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public void DeleteFile(string rootPath, string filePath)
        {
            if(string.IsNullOrWhiteSpace(filePath)) throw new Exception("File path cannot be null or empty");
            if(!File.Exists(filePath)) throw new Exception("File not found");
            File.Delete(filePath);
        }

        public async Task<string> SaveFileAsync(IFormFile file, string rootPath, string folderPath)
        {
            if (file == null || file.Length == 0) throw new Exception("Invalid file");

            string extension = Path.GetExtension(file.FileName);
            string uniqueFileName = $"{Guid.NewGuid()}{extension}";

            string folderFullPath = Path.Combine(rootPath, folderPath);

            if(!Directory.Exists(folderFullPath)) Directory.CreateDirectory(folderFullPath);

            string filePath = Path.Combine(folderFullPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create)) await file.CopyToAsync(stream);
            
            return Path.Combine(folderPath, uniqueFileName).Replace("\\", "/");

        }
    }
}
