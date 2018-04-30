using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Diagnostics;

namespace FitnessApp
{
    public class WorkoutDatabase
    {
        readonly SQLiteAsyncConnection database;

        public WorkoutDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();
            Debug.WriteLine("db Item Table created");
            database.CreateTableAsync<Exercise>().Wait();
            Debug.WriteLine("db Exercise Table created");

        }

        public Task<List<Item>> GetItemsAsync()
        {
            return database.Table<Item>().ToListAsync();
        }

        public Task<List<Exercise>> GetExercisesAsync()
        {
            return database.Table<Exercise>().ToListAsync();
        }

        public Task<List<Exercise>> FindExercisesAsync(int id)
        {
            return database.QueryAsync<Exercise>("SELECT * FROM [Exercise] WHERE [ItemID] =" + id );
        }

        public Task<Item> GetItemAsync(int id)
        {
            return database.Table<Item>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<Exercise> GetExerciseAsync(int id)
        {
            return database.Table<Exercise>().Where(i => i.eID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> SaveExerciseAsync(Exercise exercise)
        {
            if (exercise.eID != 0)
            {
                return database.UpdateAsync(exercise);
            }
            else
            {
                Debug.WriteLine("Adding Exercise " + exercise.name + "to Exercise... ItemID="+exercise.ItemID);
                return database.InsertAsync(exercise);
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return database.DeleteAsync(item);
        }
        public Task<int> DeleteExerciseAsync(Exercise exercise)
        {
            return database.DeleteAsync(exercise);
        }
    }
}

