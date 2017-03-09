using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlankApplying.Interfaces
{
    public interface IFileWorker
    {
        Task<bool> ExistAsync(string fileName);
        Task SaveTextAsync(string fileName, string text);
        Task<string> LoadTextAsync(string fileName);
        Task<IEnumerable<string>> GeFileAsync();
        Task DeleteAsync(string fileName);
    }
}
