using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GiftRandomPicker.Models;
using SQLite;

namespace GiftRandomPicker.Data
{
    public class EasterStepsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public EasterStepsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<EasterData>().Wait();
        }

        public Task<List<EasterData>> GetStepsListAsync()
        {
            return _database.Table<EasterData>().ToListAsync();
        }

        public Task<EasterData> GetStepsAsync(int id)
        {
            return _database.Table<EasterData>()
                .FirstOrDefaultAsync();
        }

        public async Task<int> SaveStepsAsync(EasterData data)
        {
            if (data.Id != 0 && (await GetStepsAsync(data.Id)) != null)
            {
                return await _database.UpdateAsync(data);
            }
            else
            {
                return await _database.InsertAsync(data);
            }
        }

        public Task<int> DeleteStepsAsync(EasterData data)
        {
            // Delete a note.
            return _database.DeleteAsync(data);
        }
    }
}
