using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class MockExercises : IDataStore<Item>
    {
        List<Item> exercises;

        public MockExercises()
        {
            
            var mockExercises = new List<Item>
            {
                new Item { ID = 1, Text = "Bench Press", Description="This is an item description." },
                new Item { ID = 2, Text = "Back Squat", Description="This is an item description." },
                new Item { ID = 3, Text = "Dumbbell Lunges", Description="This is an item description." },
                new Item { ID = 4, Text = "Lateral Raises", Description="This is an item description." },
                new Item { ID = 5, Text = "Military Press", Description="This is an item description." },
                new Item { ID = 6, Text = "Pull-up", Description="This is an item description." },
            };

            foreach (var item in mockExercises)
            {
                exercises.Add(item);
            }
            //foreach (var exercise in mockExercises)
            //{
            //    exercises.Add(exercise);
            //}
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            exercises.Add(item);

            return await Task.FromResult(true);
        }



        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = exercises.Where((Item arg) => arg.ID == item.ID).FirstOrDefault();
            exercises.Remove(_item);
            exercises.Add(item);

            return await Task.FromResult(true);
        }



        public async Task<bool> DeleteItemAsync(int id)
        {
            var _item = exercises.Where((Item arg) => arg.ID == id).FirstOrDefault();
            exercises.Remove(_item);

            return await Task.FromResult(true);
        }


        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(exercises.FirstOrDefault(s => s.ID == id));
        }


        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(exercises);
        }

    }
}
