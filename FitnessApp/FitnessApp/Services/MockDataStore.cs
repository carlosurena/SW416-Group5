using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();

            var mockItems = new List<Item>
            {
                new Item { ID = 1, Text = "Chest", Description="This is an item description.", Day = "Monday" },
                new Item { ID = 2, Text = "Back/Biceps", Description="This is an item description.", Day = "Tuesday" },
                new Item { ID = 3, Text = "Abs/Cardio", Description="This is an item description.", Day = "Wednesday" },
                new Item { ID = 4, Text = "Shoulders", Description="This is an item description.", Day = "Thursday" },
                new Item { ID = 5, Text = "Triceps", Description="This is an item description.", Day = "Friday" },
                new Item { ID = 6, Text = "HIIT", Description="This is an item description.", Day = "Saturday" },
            };



            foreach (var item in mockItems)
            {
                items.Add(item);
            }
            //foreach (var exercise in mockExercises)
            //{
            //    exercises.Add(exercise);
            //}
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);
            await App.Database.SaveItemAsync(item);
            return await Task.FromResult(true);
        }



        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }



        public async Task<bool> DeleteItemAsync(int id)
        {
            var _item = items.Where((Item arg) => arg.ID == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }


        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }


        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

    }
}
