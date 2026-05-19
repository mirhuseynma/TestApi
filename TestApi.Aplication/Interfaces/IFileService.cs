
namespace TestApi.Aplication.Interfaces
{
    public interface IFileService 
    {
        Task<string> SaveFileAsync(IFormFile file, string rootPath, string folderPath);
        void DeleteFile(string rootPath, string filePath);
    }
}
