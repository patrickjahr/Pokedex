using System;
using System.Threading.Tasks;

namespace PokeDex.Core.Services
{
    public interface IPackageStorageService
    {
        Task<String> GetStringAsync(string relativePath);
        Task<String> GetStringAsync(Uri uri);
        Task<byte[]> GetBinaryAsync(string relativePath);
    }
}