using Aura.PracticalTask.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace Aura.PracticalTask.Data
{
    public class RecordRepository : IRecordRepository
    {
        private readonly AppDbContext _context;

        public RecordRepository(AppDbContext context)
        {
            
            this._context = context;
        }


       

        public async Task<int> AddAsync(Record record)
        {
            // if null return 0 row effected
            if (record is  null) return 0;

            //add to dbSet
            _context.Records.Add(record);

            //return number of row effected, save it to database 
            return await _context.SaveChangesAsync();

        }

        public async Task<int> DeleteASync(int id)
        {
            // serch for the record in local or db
            var record = await _context.Records.FindAsync(id);

            // if null return 0 row effected
            if (record is null) return 0;

            //change the flage to false (soft delete)
            record.Activated = false;
            //return number of row effected, save it to database 
            return await  _context.SaveChangesAsync();

        }

        public async Task<IReadOnlyList<Record>> GetAllAsync()
        //select all records exept the deleted records (Activated==false) 
        => await _context.Records.AsNoTracking()
                                 .Where(R=>R.Activated==true)
                                 .ToListAsync();
            
        
    }
}
