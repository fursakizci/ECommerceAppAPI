using E_CommerceAppAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace E_CommerceAppAPI.Infrastructure.Services.Storage;

public class StorageService:IStorageService
{
    private readonly IStorage _storage;
    
    public StorageService(IStorage storage)
    {
        _storage = storage;
    }
    
    public async Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string pathOrContainerName, string fileName)
        => await _storage.DeleteAsync(pathOrContainerName, fileName);

    public List<string> GetFiles(string pathOrContainerName)
        => _storage.GetFiles(pathOrContainerName);

    public bool HasFile(string pathOrContainerName, string fileName)
        => _storage.HasFile(pathOrContainerName, fileName);

    public string StorageName
    {
        get => _storage.GetType().Name;
        set { throw new NotImplementedException(); }
    }
}