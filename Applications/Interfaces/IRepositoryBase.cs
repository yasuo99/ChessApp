using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChessApp.Applications.Interfaces
{
    public interface IRepositoryBase<TKey, TData>
    {
        Task<IEnumerable<TData>> GetAllAsync();
        Task<TData> GetDetailAsync(TKey key);
        Task<TData> CreateAsync(TData data);
        Task<TData> UpdateAsync(TKey key, TData data);
        Task DeleteAsync(TKey key);
        Task DeleteAsync(TData data);
        Task<bool> ExistAsync(TKey key);
        Task<bool> ExistAsync(TData data);
    }
}