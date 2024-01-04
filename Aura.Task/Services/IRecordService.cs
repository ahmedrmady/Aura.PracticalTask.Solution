using Aura.PracticalTask.Data.Entites;
using Aura.PracticalTask.Dtos;

namespace Aura.PracticalTask.Services
{
    public interface IRecordService
    {
        public Task<Record?> AddRecodAsync(Record record);

        public Task<IReadOnlyList<Record>> GetAllRecodAsync();

        public Task<bool> DeleteRecordAsync(int id);
    }
}
