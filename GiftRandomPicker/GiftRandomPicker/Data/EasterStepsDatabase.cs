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
            _database.CreateTableAsync<EasterSteps>().Wait();
        }

        public Task<List<EasterSteps>> GetStepsListAsync()
        {
            return _database.Table<EasterSteps>().ToListAsync();
        }

        public Task<EasterSteps> GetStepsAsync(int id)
        {
            return _database.Table<EasterSteps>()
                .FirstOrDefaultAsync();
        }

        public async Task<int> SaveStepsAsync(EasterSteps steps)
        {
            if (steps.ID != 0 && (await GetStepsAsync(steps.ID)) != null)
            {
                return await _database.UpdateAsync(steps);
            }
            else
            {
                return await _database.InsertAsync(steps);
            }
        }

        public Task<int> DeleteStepsAsync(EasterSteps steps)
        {
            // Delete a note.
            return _database.DeleteAsync(steps);
        }
    }
}
