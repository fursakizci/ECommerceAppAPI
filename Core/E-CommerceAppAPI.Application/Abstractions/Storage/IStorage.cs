using Microsoft.AspNetCore.Http;

namespace E_CommerceAppAPI.Application.Abstractions.Storage;

public interface IStorage
{
    Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);
    Task DeleteAsync(string pathOrContainerName,string fileName);
    List<string> GetFiles(string pathOrContainerName);
    bool HasFile(string pathOrContainerName, string fileName);
}