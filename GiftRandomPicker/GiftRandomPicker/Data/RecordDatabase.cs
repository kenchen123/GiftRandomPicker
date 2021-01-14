using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using GiftRandomPicker.Models;

namespace GiftRandomPicker.Data
{
    public class RecordDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public RecordDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RecordTable>().Wait();
        }

        public Task<List<RecordTable>> GetRecordsAsync()
        {
            return _database.Table<RecordTable>().ToListAsync();
        }

        public Task<RecordTable> GetRecordAsync(int id)
        {
            return _database.Table<RecordTable>()
                .FirstOrDefaultAsync();
        }

        public async Task<int> SaveRecordAsync(RecordTable record)
        {
            if (record.ID != 0 && (await GetRecordAsync(record.ID))!=null)
            {
                return await _database.UpdateAsync(record);
            }
            else
            {
                return await _database.InsertAsync(record);
            }
        }
    }
}