using Aura.PracticalTask.Data;
using Aura.PracticalTask.Data.Entites;
using Aura.PracticalTask.Dtos;

namespace Aura.PracticalTask.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordsRepo;

        public RecordService(IRecordRepository recordsRepo)
        {
            this._recordsRepo = recordsRepo;
        }

        public async Task<Record?> AddRecodAsync(Record record)
        {

            var countOfRecordEffected = await _recordsRepo.AddAsync(record);

            if(countOfRecordEffected>0) return record;

            //if 0 row is effected, return null
            return null;

        }

        public async Task<bool> DeleteRecordAsync(int id)
        {
            var countOfRecordEffected = await _recordsRepo.DeleteASync(id);

            return countOfRecordEffected > 0 ? true : false;
        }

        public async Task<IReadOnlyList<Record>> GetAllRecodAsync()
        => await _recordsRepo.GetAllAsync();
    }
}
