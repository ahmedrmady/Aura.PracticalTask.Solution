using Aura.PracticalTask.Data.Entites;
using Aura.PracticalTask.Dtos;

namespace Aura.PracticalTask.Data
{
    public interface IRecordRepository
    {
        public Task<int> AddAsync(Record record);

        public Task<int> DeleteASync(int id);

        public Task<IReadOnlyList<Record>> GetAllAsync();   
    }
}
